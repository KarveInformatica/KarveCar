#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
 * $LastChangedBy: gbayon $
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

using System;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;

namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {

        /// <summary>
        /// Builds the parameter maps.
        /// </summary>
        /// <param name="store">The store.</param>
        private void BuildParameterMaps(IConfigurationStore store)
        {
            for (int i = 0; i < store.ParameterMaps.Length; i++)
            {
                IConfiguration parameterMapConfig = store.ParameterMaps[i];
                ParameterMap parameterMap = ParameterMapDeSerializer.Deserialize(modelStore.DataExchangeFactory, parameterMapConfig, modelStore);

                BuildParameterProperties(parameterMap, parameterMapConfig);

                modelStore.AddParameterMap(parameterMap);
            }
        }

        /// <summary>
        /// Builds the parameter properties.
        /// </summary>
        /// <param name="parameterMap">The parameter map.</param>
        /// <param name="parameterMapConfig">The parameter map config.</param>
        private void BuildParameterProperties(ParameterMap parameterMap, IConfiguration parameterMapConfig)
        {
            ConfigurationCollection parametersConfig = parameterMapConfig.Children.Find(ConfigConstants.ELEMENT_PARAMETER);
            for (int i = 0; i < parametersConfig.Count; i++)
            {
                IConfiguration parameterConfig = parametersConfig[i];
                ParameterProperty property = null;
                try
                {
                    property = ParameterPropertyDeSerializer.Deserialize(modelStore.DataExchangeFactory, parameterMap.Class,
                                                                  parameterConfig);
                }
                catch (Exception e)
                {
                    throw new DataMapperException("In ParameterMap (" + parameterMap.Id + ") can't build the parameter property: " + ConfigurationUtils.GetStringAttribute(parameterConfig.Attributes, ConfigConstants.ATTRIBUTE_PROPERTY) + ". Cause " + e.Message, e);
                }
                parameterMap.AddParameterProperty(property);
            }
        }
    }
}