
#region Apache Notice
/*****************************************************************************
 * $Revision: 575787 $
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.MappedStatements.ArgumentStrategy;
using Apache.Ibatis.DataMapper.MappedStatements.PropertyStrategy;
using Apache.Ibatis.DataMapper.Proxy;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.TypeHandlers;

#endregion

namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
	/// <summary>
	/// Summary description for ResultProperty.
	/// </summary>
	[Serializable]
    [DebuggerDisplay("ResultProperty: {propertyName}-{columnName}")]
    public class ResultProperty : ResultPropertyEventSupport
	{
        /// <summary>
        /// Unknow Column Index
        /// </summary>
		public const int UNKNOWN_COLUMN_INDEX = -999999;

		#region Fields
		[NonSerialized]
		private readonly ISetAccessor setAccessor = null;
		[NonSerialized]
		private readonly string nullValue = null;
		[NonSerialized]
		private readonly string propertyName = string.Empty;
		[NonSerialized]
		private readonly string columnName = string.Empty;
		[NonSerialized]
        private readonly int columnIndex = UNKNOWN_COLUMN_INDEX;
		[NonSerialized]
		private readonly string select = string.Empty;
		[NonSerialized]
		private readonly string nestedResultMapName = string.Empty; 
		[NonSerialized]
		private IResultMap nestedResultMap = null;
		[NonSerialized]
		private readonly string dbType = null;
		[NonSerialized]
		private readonly string clrType = string.Empty;
		[NonSerialized]
		private readonly bool isLazyLoad = false;
		[NonSerialized]
		private ITypeHandler typeHandler = null;
		[NonSerialized]
		private readonly string callBackName= string.Empty;
		[NonSerialized]
		private readonly bool isComplexMemberName = false;
		[NonSerialized]
		private IPropertyStrategy propertyStrategy = null;
        [NonSerialized]
        private readonly ILazyFactory lazyFactory = null;
        [NonSerialized]
        private readonly bool isIList = false;
        [NonSerialized]    
	    private readonly bool isGenericIList = false;
        [NonSerialized]
        private readonly IFactory listFactory = null;
	    [NonSerialized]
        private static readonly IFactory arrayListFactory = new ArrayListFactory();

		#endregion

		#region Properties

        /// <summary>
        /// Tell us if the member type implement generic Ilist interface.
        /// </summary>
        public bool IsGenericIList
        {
            get { return isGenericIList; }
        }

        /// <summary>
        /// Tell us if the member type implement Ilist interface.
        /// </summary>
        public bool IsIList
        {
            get { return isIList; }
        }
        /// <summary>
        /// List factory for <see cref="IList"/> property
        /// </summary>
        /// <remarks>Used by N+1 Select solution</remarks>
        public IFactory ListFactory
        {
            get { return listFactory; }
        }
	    
        /// <summary>
        /// The lazy loader factory
        /// </summary>
        public ILazyFactory LazyFactory
        {
            get { return lazyFactory; }
        }

		/// <summary>
		/// Sets or gets the <see cref="IArgumentStrategy"/> used to fill the object property.
		/// </summary>
		public virtual IArgumentStrategy ArgumentStrategy
		{
			get { throw new NotImplementedException("Valid on ArgumentProperty") ; }
		}

		/// <summary>
		/// Sets or gets the <see cref="IPropertyStrategy"/> used to fill the object property.
		/// </summary>
		public IPropertyStrategy PropertyStrategy
		{
			get { return propertyStrategy; }
		}

		/// <summary>
		/// Specify the custom type handlers to used.
		/// </summary>
		/// <remarks>Will be an alias to a class wchic implement ITypeHandlerCallback</remarks>
		public string CallBackName
		{
			get { return callBackName; }
		}

		/// <summary>
		/// Tell us if we must lazy load this property..
		/// </summary>
		public virtual bool IsLazyLoad
		{
			get { return isLazyLoad; }
		}

		/// <summary>
		/// The typeHandler used to work with the result property.
		/// </summary>
		public ITypeHandler TypeHandler
		{
			get
			{
                if (typeHandler == null)
                {
                    throw new DataMapperException(
                        String.Format("Error on Result property {0}, type handler for {1} is not registered.", PropertyName , MemberType.Name));
                }
			    return typeHandler;
			}
            set { typeHandler = value; }
        
		}

		/// <summary>
		/// Give an entry in the 'DbType' enumeration
		/// </summary>
		/// <example >
		/// For Sql Server, give an entry of SqlDbType : Bit, Decimal, Money...
		/// <br/>
		/// For Oracle, give an OracleType Enumeration : Byte, Int16, Number...
		/// </example>
		public string DbType
		{
			get { return dbType; }
		}

		
		/// <summary>
		/// Specify the CLR type of the result.
		/// </summary>
		/// <remarks>
		/// The type attribute is used to explicitly specify the property type of the property to be set.
		/// Normally this can be derived from a property through reflection, but certain mappings such as
		/// HashTable cannot provide the type to the framework.
		/// </remarks>
		public string CLRType
		{
			get { return clrType; }
		}


		/// <summary>
		/// The name of the statement to retrieve the property
		/// </summary>
		public string Select
		{
			get { return select; }
		}

		/// <summary>
		/// The name of a nested ResultMap to set the property
		/// </summary>
		public string NestedResultMapName
		{
			get { return nestedResultMapName; }
		}

		/// <summary>
		/// The property name used to identify the property amongst the others.
		/// </summary>
		public string PropertyName
		{
			get { return propertyName; }
		}

        /// <summary>
        /// Defines a field/property <see cref="ISetAccessor"/>
        /// </summary>
        public ISetAccessor SetAccessor
        {
            get {return setAccessor;}
        }

		/// <summary>
		/// Get the field/property type
		/// </summary>
		public virtual Type MemberType
		{
            get
            {
                if (setAccessor != null)
                {
                    return setAccessor.MemberType;
                }
                if (nestedResultMap != null)
                {
                    return nestedResultMap.Class;
                }
                throw new DataMapperException(
                    String.Format(CultureInfo.InvariantCulture,
                                  "Could not resolve member type for result property '{0}'. Neither nested result map nor typed setter was provided.",
                                  PropertyName));
            }
		}

		/// <summary>
		/// Tell if a nullValue is defined.
		/// </summary>
		public bool HasNullValue
		{
			get { return (nullValue!=null); }
		}

		/// <summary>
		/// Null value replacement.
		/// </summary>
		/// <example>"noemail@provided.com"</example>
		public string NullValue
		{
			get { return nullValue; }
		}

		/// <summary>
		/// A nested ResultMap use to set a property
		/// </summary>	
		public IResultMap NestedResultMap
		{
			get { return nestedResultMap; }
			set 
            {
                nestedResultMap = value; 
                propertyStrategy = PropertyStrategyFactory.Get(this);
            }
		}

		/// <summary>
		/// Indicate if we have a complex member name as [FavouriteLineItem.Id]
		/// </summary>
		public bool IsComplexMemberName
		{
			get { return isComplexMemberName; }
		}

		/// <summary>
		/// Column Index
		/// </summary>
		public int ColumnIndex
		{
			get { return columnIndex; }
		}

		/// <summary>
		/// Column Name
		/// </summary>
		public string ColumnName
		{
			get { return columnName; }
		}

		#endregion

		#region Constructor (s) / Destructor


        /// <summary>
        /// Initializes a new instance of the <see cref="ResultProperty"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <param name="clrType">Type of the CLR.</param>
        /// <param name="callBackName">Name of the call back.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="isLazyLoad">if set to <c>true</c> [is lazy load].</param>
        /// <param name="nestedResultMapName">Name of the nested result map.</param>
        /// <param name="nullValue">The null value.</param>
        /// <param name="select">The select.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="typeHandler">The type handler.</param>
		public ResultProperty(
            string propertyName,
            string columnName,
            int columnIndex,
            string clrType,
            string callBackName,
            string dbType,
            bool isLazyLoad,
            string nestedResultMapName,
            string nullValue,
            string select,
            Type resultClass,
            DataExchangeFactory dataExchangeFactory,
            ITypeHandler typeHandler
            )
		{
            Contract.Require.That(propertyName, Is.Not.Null & Is.Not.Empty).When("retrieving argument propertyName in ResultProperty constructor");

            this.propertyName = propertyName;

            this.columnName = columnName;
            this.callBackName = callBackName;
            this.dbType = dbType;
            this.clrType = clrType;
            this.select = select;
            this.nestedResultMapName = nestedResultMapName;
            this.isLazyLoad = isLazyLoad;
            this.nullValue = nullValue;
            this.columnIndex = columnIndex;
            this.typeHandler = typeHandler;

            #region isComplexMemberName
            if (propertyName.IndexOf('.') < 0)
            {
                isComplexMemberName = false;
            }
            else // complex member name FavouriteLineItem.Id
            {
                isComplexMemberName = true;
            } 
            #endregion			
            
            if ( propertyName.Length>0 && 
				 propertyName != "value" && 
				!typeof(IDictionary).IsAssignableFrom(resultClass)&&
                !typeof(DataRow).IsAssignableFrom(resultClass)) 
			{   
                #region SetAccessor
                if (!isComplexMemberName)
                {
                    setAccessor = dataExchangeFactory.AccessorFactory.SetAccessorFactory.CreateSetAccessor(resultClass, propertyName);
                }
                else // complex member name FavouriteLineItem.Id
                {
                    MemberInfo propertyInfo = ObjectProbe.GetMemberInfoForSetter(resultClass, propertyName);
                    string memberName = propertyName.Substring(propertyName.LastIndexOf('.') + 1);
                    setAccessor = dataExchangeFactory.AccessorFactory.SetAccessorFactory.CreateSetAccessor(propertyInfo.ReflectedType, memberName);
                }
                #endregion

                isGenericIList = TypeUtils.IsImplementGenericIListInterface(MemberType);
                isIList = typeof(IList).IsAssignableFrom(MemberType);
                    
                #region Set the list factory
                if (isGenericIList)
                {
                    if (MemberType.IsArray)
                    {
                        listFactory = arrayListFactory;
                    }
                    else
                    {
                        Type[] typeArgs = MemberType.GetGenericArguments();

                        if (typeArgs.Length == 0)// Custom collection which derive from List<T>
                        {
                            listFactory = dataExchangeFactory.ObjectFactory.CreateFactory(MemberType, Type.EmptyTypes);
                        }
                        else
                        {
                            Type genericIList = typeof(IList<>);
                            Type interfaceListType = genericIList.MakeGenericType(typeArgs);

                            Type genericList = typeof(List<>);
                            Type listType = genericList.MakeGenericType(typeArgs);

                            if ((interfaceListType == MemberType) || (listType == MemberType))
                            {
                                Type constructedType = genericList.MakeGenericType(typeArgs);
                                listFactory = dataExchangeFactory.ObjectFactory.CreateFactory(
                                    constructedType,
                                    Type.EmptyTypes);
                            }
                            else // Custom collection which derive from List<T>
                            {
                                listFactory = dataExchangeFactory.ObjectFactory.CreateFactory(MemberType, Type.EmptyTypes);
                            }
                        }
                    }
                }
                else if (isIList)
                {
                    if (MemberType.IsArray)
                    {
                        listFactory = arrayListFactory;
                    }
                    else
                    {
                        if (MemberType == typeof(IList))
                        {
                            listFactory = arrayListFactory;
                        }
                        else // custom collection
                        {
                            listFactory = dataExchangeFactory.ObjectFactory.CreateFactory(MemberType, Type.EmptyTypes);
                        }
                    }
                } 
                #endregion
			}

            #region TypeHandler
            if (!string.IsNullOrEmpty(CallBackName))
            {
                try
                {
                    Type type = dataExchangeFactory.TypeHandlerFactory.GetType(CallBackName);
                    ITypeHandlerCallback typeHandlerCallback = (ITypeHandlerCallback)Activator.CreateInstance(type);
                    this.typeHandler = new CustomTypeHandler(typeHandlerCallback);
                }
                catch (Exception e)
                {
                    throw new ConfigurationException("Error occurred during custom type handler configuration.  Cause: " + e.Message, e);
                }
            }
            else
            {
                if (typeHandler == null)
                {
                    //configScope.ErrorContext.MoreInfo = "Result property '" + propertyName + "' set the typeHandler attribute.";
                    this.typeHandler = dataExchangeFactory.TypeHandlerFactory.ResolveTypeHandler(resultClass, propertyName, clrType, dbType, true);
                }
            } 
            #endregion
                
            #region LazyLoad
            if (IsLazyLoad)
            {
                lazyFactory = new LazyFactoryBuilder().GetLazyFactory(setAccessor.MemberType);
            } 
            #endregion

            if (!GetType().IsSubclassOf(typeof(ResultProperty)))
            {
                propertyStrategy = PropertyStrategyFactory.Get(this);
            }
        }

		#endregion

		#region Methods

        /// <summary>
        /// Sets the value for the field/property .
        /// </summary>
        /// <param name="target">Object to set the field/property on.</param>
        /// <param name="value">Value.</param>
        public void Set(object target, object value)
        {
            value = RaisePrePropertyEvent(target, value);

            setAccessor.Set(target, value);

            RaisePostPropertyEvent(target);
        }

       /// <summary>
       /// Gets a result argument value.
       /// </summary>
       /// <param name="request">The request.</param>
       /// <param name="reader">The reader.</param>
       /// <param name="keys">The keys.</param>
       /// <returns></returns>
       public object GetValue(RequestScope request, ref IDataReader reader, object keys)
       {
           return ArgumentStrategy.GetValue(request, this, ref reader, keys);
       }

	    /// <summary>
        /// Gets the data base value.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <returns></returns>
		public object GetDataBaseValue(IDataReader dataReader)
		{
			object value = null;

			if (columnIndex == UNKNOWN_COLUMN_INDEX)  
			{
                value = TypeHandler.GetValueByName(this, dataReader);
			} 
			else 
			{
                value =TypeHandler.GetValueByIndex(this, dataReader);
			}

			bool wasNull = (value == DBNull.Value);
			if (wasNull)
			{
				if (this.HasNullValue) 
				{
                    if (setAccessor != null)
					{
                        value = TypeHandler.ValueOf(setAccessor.MemberType, nullValue);
					}
					else
					{
                        value = TypeHandler.ValueOf(null, nullValue);
					}
				}
				else
				{
                    value = TypeHandler.NullValue;
				}			
			}

			return value;
		}

        /// <summary>
        /// Translates the value tu null value if need
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
		public object TranslateValue(object value)
        {
            if (value == null)
			{
                return TypeHandler.NullValue;
			}
            return value;
        }

	    #endregion
    
	    /// <summary>
        /// <see cref="IFactory"/> that constructs <see cref="ArrayList"/> instance
	    /// </summary>
	    private class ArrayListFactory : IFactory
	    {
            #region IFactory Members

            /// <summary>
            /// Create a new instance with the specified parameters
            /// </summary>
            /// <param name="parameters">An array of values that matches the number, order and type
            /// of the parameters for this constructor.</param>
            /// <returns>A new instance</returns>
            /// <remarks>
            /// If you call a constructor with no parameters, pass null.
            /// Anyway, what you pass will be ignore.
            /// </remarks>
            public object CreateInstance(object[] parameters)
            {
              return new ArrayList();
            }

            #endregion
        }
    }

}
