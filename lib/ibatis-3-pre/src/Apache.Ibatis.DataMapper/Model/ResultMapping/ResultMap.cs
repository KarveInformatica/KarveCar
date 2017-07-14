
#region Apache Notice
/*****************************************************************************
 * $Revision: 576082 $
 * $LastChangedDate: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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

#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.TypeHandlers;

#endregion

namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
    /// <summary>
    /// Main implementation of ResultMap interface
    /// </summary>
    [Serializable]
    [DebuggerDisplay("ResultMap: {Id}-{ClassName}")]
    public sealed class ResultMap : ResultMapEventSupport, IResultMap
    {
        private static IResultMap nullResultMap = null;

        #region Fields
        [NonSerialized]
        private bool isInitalized = true;
        [NonSerialized]
        private readonly string id = string.Empty;
        [NonSerialized]
        private readonly string className = string.Empty;
        [NonSerialized]
        private readonly string extendMap = string.Empty;
        [NonSerialized]
        private readonly Type type = null;
        [NonSerialized]
        private readonly List<string> groupByPropertyNames = new List<string>();
        [NonSerialized]
        private readonly ResultPropertyCollection properties = new ResultPropertyCollection();
        [NonSerialized]
        private readonly ResultPropertyCollection groupByProperties = new ResultPropertyCollection();
        [NonSerialized]
        private readonly ArgumentPropertyCollection parameters = new ArgumentPropertyCollection();
        [NonSerialized]
        private readonly Discriminator discriminator = null;
        [NonSerialized]
        private readonly IFactory objectFactory = null;
        [NonSerialized]
        private IDataExchange dataExchange = null;
        [NonSerialized]
        private readonly bool isSimpleType = false;
        [NonSerialized]
        private readonly List<string> keyPropertyNames = new List<string>();
        [NonSerialized]
        private readonly ResultPropertyCollection keysProperties = new ResultPropertyCollection();

        #endregion

        #region Properties

        /// <summary>
        /// The GroupBy Properties.
        /// </summary>
        public List<string> GroupByPropertyNames
        {
            get { return groupByPropertyNames; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initalized.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is initalized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitalized
        {
            get { return true; }
            set { isInitalized = value; }
        }

        /// <summary>
        /// The discriminator used to choose the good Case
        /// </summary>
        public Discriminator Discriminator
        {
            get { return discriminator; }
        }

        /// <summary>
        /// The collection of ResultProperty.
        /// </summary>
        public ResultPropertyCollection Properties
        {
            get { return properties; }
        }

        /// <summary>
        /// The GroupBy Properties.
        /// </summary>
        public ResultPropertyCollection GroupByProperties
        {
            get { return groupByProperties; }
        }

        /// <summary>
        /// The collection of constructor parameters.
        /// </summary>
        public ArgumentPropertyCollection Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// Identifier used to identify the resultMap amongst the others.
        /// </summary>
        /// <example>GetProduct</example>
        public string Id
        {
            get { return id; }
        }

        /// <summary>
        /// Extend ResultMap attribute
        /// </summary>
        public string ExtendMap
        {
            get { return extendMap; }
        }

        /// <summary>
        /// The output type class of the resultMap.
        /// </summary>
        public Type Class
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName
        {
            get { return className; }
        }

        /// <summary>
        /// Sets the IDataExchange
        /// </summary>
        public IDataExchange DataExchange
        {
            set { dataExchange = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMap"/> class.
        /// </summary>
        /// <param name="id">Identifier used to identify the resultMap amongst the others.</param>
        /// <param name="className">The output class name of the resultMap.</param>
        /// <param name="extendMap">The extend result map bame.</param>
        /// <param name="groupBy">The groupBy properties</param>
        /// <param name="keyColumns">The key columns.</param>
        /// <param name="type">The result type.</param>
        /// <param name="dataExchange">The data exchange.</param>
        /// <param name="objectFactory">The object factory.</param>
        /// <param name="typeHandlerFactory">The type handler factory.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="discriminator">The discriminator.</param>
        public ResultMap(
            string id, 
            string className, 
            string extendMap, 
            string groupBy,
            string keyColumns,
            Type type,
            IDataExchange dataExchange,
            IFactory objectFactory,
            TypeHandlerFactory typeHandlerFactory,
            ResultPropertyCollection properties,
            ArgumentPropertyCollection parameters,
            Discriminator discriminator)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving argument id in ResultMap constructor");
            Contract.Require.That(className, Is.Not.Null & Is.Not.Empty).When("retrieving argument className in ResultMap constructor");
            Contract.Require.That(type, Is.Not.Null).When("retrieving argument type in ResultMap constructor");
            Contract.Require.That(typeHandlerFactory, Is.Not.Null).When("retrieving argument typeHandlerFactory in ResultMap constructor");

            nullResultMap = new NullResultMap();

            this.id = id;
            this.className = className;
            this.extendMap = extendMap;
            this.type = type;
            this.dataExchange = dataExchange;
            this.properties = properties;
            this.parameters = parameters;
            this.discriminator = discriminator;
            this.objectFactory = objectFactory;
            isSimpleType = typeHandlerFactory.IsSimpleType(type);

            if (!string.IsNullOrEmpty(groupBy))
            {
                string[] props = groupBy.Split(',');
                for (int i = 0; i < props.Length; i++)
                {
                    string memberName = props[i].Trim();
                    groupByPropertyNames.Add(memberName);
                }

                InitializeGroupByProperties();
                CheckGroupBy();
            }

            if (!string.IsNullOrEmpty(keyColumns))
            {
                string[] columns = keyColumns.Split(',');
                for (int i = 0; i < columns.Length; i++)
                {
                    string column = columns[i].Trim();
                    keyPropertyNames.Add(column);
                }

                InitializeKeysProperties();
                CheckKeysProperties();
            }

       }

        #region IResultMap Members

        /// <summary>
        /// Create an instance Of result.
        /// </summary>
        /// <param name="parameters">An array of values that matches the number, order and type
        /// of the parameters for this constructor.</param>
        /// <returns>An object.</returns>
        public object CreateInstanceOfResult(object[] parameters)
        {
            if (!isSimpleType)
            {
                parameters = RaisePreCreateEvent(parameters);

                object instance = objectFactory.CreateInstance(parameters);

                instance = RaisePostCreateEvent(instance);

                return instance;
            }
            return TypeUtils.InstantiatePrimitiveType(type);
        }

        /// <summary>
        /// Set the value of an object property.
        /// </summary>
        /// <param name="target">The object to set the property.</param>
        /// <param name="property">The result property to use.</param>
        /// <param name="dataBaseValue">The database value to set.</param>
        public void SetValueOfProperty(ref object target, ResultProperty property, object dataBaseValue)
        {
            dataExchange.SetData(ref target, property, dataBaseValue);
        }


        /// <summary>
        /// Resolve the submap
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public IResultMap ResolveSubMap(IDataReader dataReader)
        {
            IResultMap subMap = this;
            if (discriminator != null)
            {
                ResultProperty mapping = discriminator.ResultProperty;
                object dataBaseValue = mapping.GetDataBaseValue(dataReader);

                if (dataBaseValue != null)
                {
                    subMap = discriminator.GetSubMap(dataBaseValue.ToString());

                    if (subMap == null)
                    {
                        subMap = this;
                    }
                    else if (subMap != this)
                    {
                        subMap = subMap.ResolveSubMap(dataReader);
                    }
                }
                else
                {
                    subMap = nullResultMap;
                }
            }
            return subMap;
        }


        /// <summary>
        /// The Key properties names (used for resolved circular reference).
        /// </summary>
        /// <value></value>
        public List<string> KeyPropertyNames
        {
            get { return keyPropertyNames; }
        }

        /// <summary>
        /// The Keys Properties.
        /// </summary>
        /// <value></value>
        public ResultPropertyCollection KeysProperties
        {
            get { return keysProperties; }
        }     

        #endregion


        /// <summary>
        /// Initializes the key Column properties.
        /// </summary>
        private void InitializeKeysProperties()
        {
            for (int i = 0; i < keyPropertyNames.Count; i++)
            {
                ResultProperty resultProperty = properties.FindByPropertyName(keyPropertyNames[i]);
                if (resultProperty == null)
                {
                    resultProperty = parameters.FindByPropertyName(keyPropertyNames[i]);
                }

                KeysProperties.Add(resultProperty);
            }
        }

        /// <summary>
        /// Checks the group by.
        /// </summary>
        private void CheckGroupBy()
        {
            try
            {
                // Verify that that each groupBy element correspond to a class member
                // of one of result property
                for (int i = 0; i < groupByProperties.Count; i++)
                {
                    string memberName = GroupByPropertyNames[i];
                    if (!properties.Contains(memberName))
                    {
                        throw new ConfigurationException(
                            string.Format(
                                "Could not configure ResultMap named \"{0}\". Check the groupBy attribute. Cause: there's no result property named \"{1}\".",
                                id, memberName));
                    }
                }
            }
            catch (Exception e)
            {
                throw new ConfigurationException(
                    string.Format("Could not configure ResultMap named \"{0}\", Cause: {1}", id, e.Message)
                    , e);
            }
        }

        /// <summary>
        /// Initializes the groupBy properties.
        /// </summary>
        private void InitializeGroupByProperties()
        {
            for (int i = 0; i < GroupByPropertyNames.Count; i++)
            {
                ResultProperty resultProperty = Properties.FindByPropertyName(GroupByPropertyNames[i]);
                GroupByProperties.Add(resultProperty);
            }
        }

        /// <summary>
        /// Checks the key Column.
        /// </summary>
        private void CheckKeysProperties()
        {
            try
            {
                // Verify that that each key column element correspond to a class member
                // of one of result property
                for (int i = 0; i < keyPropertyNames.Count; i++)
                {
                    string memberName = keyPropertyNames[i];
                    if (!properties.Contains(memberName))
                    {
                        if (!parameters.Contains(memberName))
                        {
                            throw new ConfigurationException(
                                string.Format(
                                    "Could not configure ResultMap named \"{0}\". Check the keyPropertyNames attribute. Cause: there's no result property or parameter constructor named \"{1}\".",
                                    id, memberName));

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ConfigurationException(
                    string.Format("Could not configure ResultMap named \"{0}\", Cause: {1}", id, e.Message)
                    , e);
            }
        }
    }
}
