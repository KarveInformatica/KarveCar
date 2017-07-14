
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 575902 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
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
using System.Collections;
using System.Data;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.TypeHandlers;
using System.Collections.Generic;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;

#endregion

namespace Apache.Ibatis.DataMapper.Model.ParameterMapping
{
	/// <summary>
	/// Summary description for ParameterMap.
	/// </summary>
    [DebuggerDisplay("ParameterMap: {Id}-{ClassName})")]
	public class ParameterMap
	{
		#region private
		private static readonly ILog logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );
		
		private string id = string.Empty;
		// Properties list
		private ParameterPropertyCollection properties = new ParameterPropertyCollection();
		// Same list as properties but without doubled (Test UpdateAccountViaParameterMap2)
		private ParameterPropertyCollection propertiesList = new ParameterPropertyCollection();
		//(property Name, property)
        private IDictionary<string, ParameterProperty> propertiesMap = new Dictionary<string, ParameterProperty>(); // Corrected ?? Support Request 1043181, move to HashTable
		private string extendMap = string.Empty;
		private bool usePositionalParameters =false;
		private string className = string.Empty;
		private Type parameterClass = null;
		private IDataExchange dataExchange = null;
		#endregion

		#region Properties
		/// <summary>
		/// The parameter class name.
		/// </summary>
		public string ClassName
		{
			get { return className; }
		}

		/// <summary>
		/// The parameter type class.
		/// </summary>
		public Type Class
		{
			get { return parameterClass; }
		}

		/// <summary>
		/// Identifier used to identify the ParameterMap amongst the others.
		/// </summary>
		public string Id
		{
			get { return id; }
		}


		/// <summary>
		/// The collection of ParameterProperty
		/// </summary>
		public ParameterPropertyCollection Properties
		{
			get { return properties; }
		}


        /// <summary>
        /// Gets the properties list.
        /// </summary>
        /// <value>The properties list.</value>
		public ParameterPropertyCollection PropertiesList
		{
			get { return propertiesList; }
		}

		/// <summary>
		/// Extend Parametermap attribute
		/// </summary>
		/// <remarks>The id of a ParameterMap</remarks>
		public string ExtendMap
		{
			get { return extendMap; }
		}

		/// <summary>
		/// Sets the IDataExchange
		/// </summary>
		public IDataExchange DataExchange
		{
			get { return dataExchange; }
		}
		#endregion

		#region Constructor (s) / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMap"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="extendMap">The extend map.</param>
        /// <param name="type">The type.</param>
        /// <param name="dataExchange">The data exchange.</param>
        /// <param name="usePositionalParameters">if set to <c>true</c> [use positional parameters].</param>
 		public ParameterMap(
            string id,
            string className,
            string extendMap,
            Type type,
            IDataExchange dataExchange,
            bool usePositionalParameters)
		{
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving argument id");
            //Contract.Require.That(className, Is.Not.Null & Is.Not.Empty).When("retrieving argument className");

            if (logger.IsInfoEnabled)
            {
                if ((className == null) || (className.Length < 1))
                {
                    logger.Info("The class attribute is recommended for better performance in a ParameterMap tag '" + id + "'.");
                }
            }

            this.id = id;
            this.className = className;
            this.usePositionalParameters = usePositionalParameters;
            this.parameterClass = type;
            this.dataExchange = dataExchange;
            this.extendMap = extendMap;
		}

		#endregion

		#region Methods
		/// <summary>
		/// Get the ParameterProperty at index.
		/// </summary>
		/// <param name="index">Index</param>
		/// <returns>A ParameterProperty</returns>
		public ParameterProperty GetProperty(int index)
		{
			if (usePositionalParameters) //obdc/oledb
			{
				return properties[index];
			}
			else 
			{
				return propertiesList[index];
			}
		}

		/// <summary>
		/// Get a ParameterProperty by his name.
		/// </summary>
		/// <param name="name">The name of the ParameterProperty</param>
		/// <returns>A ParameterProperty</returns>
		public ParameterProperty GetProperty(string name)
		{
			return propertiesMap[name];
		}


		/// <summary>
		/// Add a ParameterProperty to the ParameterProperty list.
		/// </summary>
		/// <param name="property"></param>
		public void AddParameterProperty(ParameterProperty property)
		{
			// These mappings will replace any mappings that this map 
			// had for any of the keys currently in the specified map. 
			propertiesMap[property.PropertyName] = property;
			properties.Add( property );
			
			if (propertiesList.Contains(property) == false)
			{
				propertiesList.Add( property );
			}
		}

		/// <summary>
		/// Insert a ParameterProperty ine the ParameterProperty list at the specified index..
		/// </summary>
		/// <param name="index">
		/// The zero-based index at which ParameterProperty should be inserted. 
		/// </param>
		/// <param name="property">The ParameterProperty to insert. </param>
		public void InsertParameterProperty(int index, ParameterProperty property)
		{
			// These mappings will replace any mappings that this map 
			// had for any of the keys currently in the specified map. 
			propertiesMap[property.PropertyName] = property;
			properties.Insert( index, property );
			
			if (propertiesList.Contains(property) == false)
			{
				propertiesList.Insert( index, property );
			}
		}

		/// <summary>
		/// Retrieve the index for array property
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public int GetParameterIndex(string propertyName) 
		{
			int index = -1;
            index = Convert.ToInt32(propertyName.Replace("[", "").Replace("]", ""));
            return index;
		}
		
		/// <summary>
		/// Get all Parameter Property Name 
		/// </summary>
		/// <returns>A string array</returns>
		public string[] GetPropertyNameArray() 
		{
			string[] propertyNameArray = new string[propertiesMap.Count];

			for (int index=0;index<propertiesList.Count;index++)
			{
				propertyNameArray[index] = propertiesList[index].PropertyName;
			}
			return propertyNameArray; 
		}

		/// <summary>
		/// Set parameter value, replace the null value if any.
		/// </summary>
		/// <param name="mapping"></param>
		/// <param name="dataParameter"></param>
		/// <param name="parameterValue"></param>
		public void SetParameter(ParameterProperty mapping, IDataParameter dataParameter, object parameterValue)
		{
			object value = dataExchange.GetData(mapping, parameterValue);

			ITypeHandler typeHandler = mapping.TypeHandler;

			// Apply Null Value
			if (mapping.HasNullValue) 
			{
				if (typeHandler.Equals(value, mapping.NullValue)) 
				{
					value = null;
				}
			}

			typeHandler.SetParameter(dataParameter, value, mapping.DbType);
		}

		/// <summary>
		/// Set output parameter value.
		/// </summary>
		/// <param name="mapping"></param>
		/// <param name="dataBaseValue"></param>
		/// <param name="target"></param>
		public void SetOutputParameter(ref object target, ParameterProperty mapping, object dataBaseValue )
		{
			dataExchange.SetData(ref target, mapping, dataBaseValue);
		}

        ///// <summary>
        ///// Get the parameter properties child for the xmlNode parameter.
        ///// </summary>
        ///// <param name="configScope"></param>
        //public void BuildProperties(ConfigurationScope configScope)
        //{
        //    ParameterProperty property = null;

        //    foreach (XmlNode parameterNode in configScope.NodeContext.SelectNodes(DomSqlMapBuilder.ApplyMappingNamespacePrefix(XMLPARAMATER), configScope.XmlNamespaceManager))
        //    {
        //        property = ParameterPropertyDeSerializer.Deserialize(parameterNode, configScope);

        //        property.Initialize(configScope, parameterClass);

        //        AddParameterProperty(property);
        //    }
        //}

		#endregion

	}
}
