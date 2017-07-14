#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 470514 $
 * $Date: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

#region Using

using System;
using System.Collections.Generic;
using System.Reflection;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using System.Data;

#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for ResultMapDeSerializer.
	/// </summary>
	public sealed class ResultMapDeSerializer
	{
        public static BindingFlags ANY_VISIBILITY_INSTANCE = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// Deserializes the specified config.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="waitResultPropertyResolution">The wait result property resolution delegate.</param>
        /// <param name="waitDiscriminatorResolution">The wait discriminator resolution.</param>
        /// <returns></returns>
        public static ResultMap Deserialize(
            IConfiguration config,
            DataExchangeFactory dataExchangeFactory,
            WaitResultPropertyResolution waitResultPropertyResolution,
            WaitDiscriminatorResolution waitDiscriminatorResolution
            )
        {
            string id = config.Id;
            string className = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_CLASS);
            string extends = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_EXTENDS);
            string groupBy = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_GROUPBY);
            string keyColumns = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_KEYS_PROPERTIES);
            string suffix = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SUFFIX, string.Empty);
            string prefix = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_PREFIX, string.Empty);

            Type type = dataExchangeFactory.TypeHandlerFactory.GetType(className);
            IDataExchange dataExchange = dataExchangeFactory.GetDataExchangeForClass(type);
            IFactory factory = null;
            ArgumentPropertyCollection arguments = new ArgumentPropertyCollection();

            #region Get the constructor & associated parameters 

            ConfigurationCollection constructors = config.Children.Find(ConfigConstants.ELEMENT_CONSTRUCTOR);

            if (constructors.Count > 0)
            {
                IConfiguration constructor = constructors[0];

                Type[] argumentsType = new Type[constructor.Children.Count];
                string[] argumentsName = new string[constructor.Children.Count];

                // Builds param name list
                for (int i = 0; i < constructor.Children.Count; i++)
                {
                    argumentsName[i] = ConfigurationUtils.GetStringAttribute(constructor.Children[i].Attributes, ConfigConstants.ATTRIBUTE_ARGUMENTNAME);
                }

                // Find the constructor
                ConstructorInfo constructorInfo = GetConstructor(id, type, argumentsName);

                // Build ArgumentProperty and parameter type list
                for (int i = 0; i < constructor.Children.Count; i++)
                {
                    ArgumentProperty argumentMapping = ArgumentPropertyDeSerializer.Deserialize(
                        constructor.Children[i],
                        type,
                        constructorInfo,
                        dataExchangeFactory);

                    arguments.Add(argumentMapping);

                    if (argumentMapping.NestedResultMapName.Length > 0)
                    {
                        waitResultPropertyResolution(argumentMapping);
                    }
                    
                    argumentsType[i] = argumentMapping.MemberType;
                }
                // Init the object factory
                factory = dataExchangeFactory.ObjectFactory.CreateFactory(type, argumentsType);
            }
            else
            {
                if (!dataExchangeFactory.TypeHandlerFactory.IsSimpleType(type) && type!=typeof(DataRow))
                {
                    factory = dataExchangeFactory.ObjectFactory.CreateFactory(type, Type.EmptyTypes);
                }
            }

            #endregion

            ResultPropertyCollection properties = BuildResultProperties(
                id, 
                config, 
                type, 
                prefix,
                suffix,
                dataExchangeFactory, 
                waitResultPropertyResolution);
            Discriminator discriminator = BuildDiscriminator(config, type, dataExchangeFactory, waitDiscriminatorResolution);

            ResultMap resultMap = new ResultMap(
                    id,
                    className,
                    extends,
                    groupBy,
                    keyColumns,
                    type,
                    dataExchange,
                    factory,
                    dataExchangeFactory.TypeHandlerFactory,
                    properties,
                    arguments,
                    discriminator
                    );                

            return resultMap;
        }

        /// <summary>
        /// Finds the constructor that takes the parameters.
        /// </summary>
        /// <param name="resultMapId">The result map id.</param>
        /// <param name="type">The <see cref="System.Type"/> to find the constructor in.</param>
        /// <param name="parametersName">The parameters name to use to find the appropriate constructor.</param>
        /// <returns>
        /// An <see cref="ConstructorInfo"/> that can be used to create the type with
        /// the specified parameters.
        /// </returns>
        /// <exception cref="DataMapperException">
        /// Thrown when no constructor with the correct signature can be found.
        /// </exception>
        private static ConstructorInfo GetConstructor(string resultMapId, Type type, string[] parametersName)
        {
            ConstructorInfo[] candidates = type.GetConstructors(ANY_VISIBILITY_INSTANCE);
            for (int i = 0; i < candidates.Length; i++)
            {
                ParameterInfo[] parameters = candidates[i].GetParameters();

                if (parameters.Length == parametersName.Length)
                {
                    bool found = true;

                    for (int j = 0; j < parameters.Length; j++)
                    {
                        bool ok = (parameters[j].Name == parametersName[j]);
                        if (!ok)
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        return candidates[i];
                    }
                }
            }
            throw new DataMapperException("In ResultMap (" + resultMapId + ") can't find an appropriate constructor which map parameters in class: " + type.Name);
        }

        /// <summary>
        /// Builds the result properties.
        /// </summary>
        /// <param name="resultMapId">The result map id.</param>
        /// <param name="resultMapConfig">The result map config.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="waitResultPropertyResolution">The wait result property resolution.</param>
        /// <returns></returns>
        private static ResultPropertyCollection BuildResultProperties(
            string resultMapId,
            IConfiguration resultMapConfig, 
            Type resultClass,
            string prefix,
            string suffix,
            DataExchangeFactory dataExchangeFactory,
            WaitResultPropertyResolution waitResultPropertyResolution)
        {
            ResultPropertyCollection properties = new ResultPropertyCollection();

            ConfigurationCollection resultsConfig = resultMapConfig.Children.Find(ConfigConstants.ELEMENT_RESULT);
            for (int i = 0; i < resultsConfig.Count; i++)
            {
                ResultProperty mapping = null;
                try
                {
                    mapping = ResultPropertyDeSerializer.Deserialize(resultsConfig[i], resultClass, prefix, suffix, dataExchangeFactory);
                }
                catch(Exception e)
                {
                    throw new ConfigurationException("In ResultMap (" + resultMapId + ") can't build the result property: " + ConfigurationUtils.GetStringAttribute(resultsConfig[i].Attributes, ConfigConstants.ATTRIBUTE_PROPERTY) + ". Cause " + e.Message, e);
                }
                if (mapping.NestedResultMapName.Length > 0)
                {
                    waitResultPropertyResolution(mapping);
                }
                properties.Add(mapping);
            }

            return properties;
        }

        /// <summary>
        /// Builds the discriminator and his subMaps
        /// </summary>
        /// <param name="resultMapConfig">The result map config.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="waitDiscriminatorResolution">The wait discriminator resolution.</param>
        /// <returns></returns>
        private static Discriminator BuildDiscriminator(
            IConfiguration resultMapConfig,
            Type resultClass,
            DataExchangeFactory dataExchangeFactory,
            WaitDiscriminatorResolution waitDiscriminatorResolution)
        {
            Discriminator discriminator = null;
            // Build the Discriminator/Case Property

            ConfigurationCollection discriminatorsConfig = resultMapConfig.Children.Find(ConfigConstants.ELEMENT_DISCRIMINATOR);
            if (discriminatorsConfig.Count > 0)
            {
                //configScope.ErrorContext.MoreInfo = "initialize discriminator";

                // Find the cases
                IList<Case> cases = new List<Case>();
                ConfigurationCollection caseConfigs = discriminatorsConfig[0].Children.Find(ConfigConstants.ELEMENT_CASE);
                for (int i = 0; i < caseConfigs.Count; i++)
                {
                    Case caseElement = CaseDeSerializer.Deserialize(caseConfigs[i]);
                    cases.Add(caseElement);
                }

                discriminator = DiscriminatorDeSerializer.Deserialize(
                    discriminatorsConfig[0], 
                    resultClass, 
                    dataExchangeFactory,
                    cases
                    );
                waitDiscriminatorResolution(discriminator);
            }
            return discriminator;
        }
	}
}
