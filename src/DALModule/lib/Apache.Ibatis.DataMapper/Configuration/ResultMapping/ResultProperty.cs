
#region Apache Notice
/*****************************************************************************
 * $Revision: 575787 $
 * $LastChangedDate: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2006/2005 - The Apache Software Foundation
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
using System.Reflection;
using System.Xml.Serialization;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.MappedStatements.ArgumentStrategy;
using Apache.Ibatis.DataMapper.MappedStatements.PropertyStrategy;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.TypeHandlers;
using Apache.Ibatis.DataMapper.Proxy;

#endregion

namespace Apache.Ibatis.DataMapper.Configuration.ResultMapping
{
	/// <summary>
	/// Summary description for ResultProperty.
	/// </summary>
	[Serializable]
	[XmlRoot("result", Namespace="http://ibatis.apache.org/mapping")]
	public class ResultProperty 
	{
		#region Const

		/// <summary>
		/// 
		/// </summary>		
		public const int UNKNOWN_COLUMN_INDEX = -999999;

		#endregion 

		#region Fields
		[NonSerialized]
		private ISetAccessor _setAccessor = null;
		[NonSerialized]
		private string _nullValue = null;
		[NonSerialized]
		private string _propertyName = string.Empty;
		[NonSerialized]
		private string _columnName = string.Empty;
		[NonSerialized]
		private int _columnIndex = UNKNOWN_COLUMN_INDEX;
		[NonSerialized]
		private string _select = string.Empty;
		[NonSerialized]
		private string _nestedResultMapName = string.Empty; 
		[NonSerialized]
		private IResultMap _nestedResultMap = null;
		[NonSerialized]
		private string _dbType = null;
		[NonSerialized]
		private string _clrType = string.Empty;
		[NonSerialized]
		private bool _isLazyLoad = false;
		[NonSerialized]
		private ITypeHandler _typeHandler = null;
		[NonSerialized]
		private string _callBackName= string.Empty;
		[NonSerialized]
		private bool _isComplexMemberName = false;
		[NonSerialized]
		private IPropertyStrategy _propertyStrategy = null;
        [NonSerialized]
        private ILazyFactory _lazyFactory = null;
        [NonSerialized]
        private bool _isIList = false;
        [NonSerialized]    
	    private bool _isGenericIList = false;
        [NonSerialized]
        private IFactory _listFactory = null;
	    [NonSerialized]
        private static IFactory _arrayListFactory = new ArrayListFactory();
	    
		#endregion

		#region Properties

        /// <summary>
        /// Tell us if the member type implement generic Ilist interface.
        /// </summary>
        [XmlIgnore]
        public bool IsGenericIList
        {
            get { return _isGenericIList; }
        }

        /// <summary>
        /// Tell us if the member type implement Ilist interface.
        /// </summary>
        [XmlIgnore]
        public bool IsIList
        {
            get { return _isIList; }
        }
        /// <summary>
        /// List factory for <see cref="IList"/> property
        /// </summary>
        /// <remarks>Used by N+1 Select solution</remarks>
        [XmlIgnore]
        public IFactory ListFactory
        {
            get { return _listFactory; }
        }
	    
        /// <summary>
        /// The lazy loader factory
        /// </summary>
        [XmlIgnore]
        public ILazyFactory LazyFactory
        {
            get { return _lazyFactory; }
        }

		/// <summary>
		/// Sets or gets the <see cref="IArgumentStrategy"/> used to fill the object property.
		/// </summary>
		[XmlIgnore]
		public virtual IArgumentStrategy ArgumentStrategy
		{
			set { throw new NotImplementedException("Valid on ArgumentProperty") ; }
			get { throw new NotImplementedException("Valid on ArgumentProperty") ; }
		}

		/// <summary>
		/// Sets or gets the <see cref="IPropertyStrategy"/> used to fill the object property.
		/// </summary>
		[XmlIgnore]
		public IPropertyStrategy PropertyStrategy
		{
			set { _propertyStrategy = value ; }
			get { return _propertyStrategy; }
		}

		/// <summary>
		/// Specify the custom type handlers to used.
		/// </summary>
		/// <remarks>Will be an alias to a class wchic implement ITypeHandlerCallback</remarks>
		[XmlAttribute("typeHandler")]
		public string CallBackName
		{
			get { return _callBackName; }
			set { _callBackName = value; }
		}

		/// <summary>
		/// Tell us if we must lazy load this property..
		/// </summary>
		[XmlAttribute("lazyLoad")]
		public virtual bool IsLazyLoad
		{
			get { return _isLazyLoad; }
			set { _isLazyLoad = value; }
		}

		/// <summary>
		/// The typeHandler used to work with the result property.
		/// </summary>
		[XmlIgnore]
		public ITypeHandler TypeHandler
		{
			get
			{
                if (_typeHandler == null)
                {
                    throw new DataMapperException(
                        String.Format("Error on Result property {0}, type handler for {1} is not registered.", this.PropertyName , this.MemberType.Name));
                }
			    return _typeHandler;
			}
			set { _typeHandler = value; }
		}

		/// <summary>
		/// Give an entry in the 'DbType' enumeration
		/// </summary>
		/// <example >
		/// For Sql Server, give an entry of SqlDbType : Bit, Decimal, Money...
		/// <br/>
		/// For Oracle, give an OracleType Enumeration : Byte, Int16, Number...
		/// </example>
		[XmlAttribute("dbType")]
		public string DbType
		{
			get { return _dbType; }
			set { _dbType = value; }
		}

		
		/// <summary>
		/// Specify the CLR type of the result.
		/// </summary>
		/// <remarks>
		/// The type attribute is used to explicitly specify the property type of the property to be set.
		/// Normally this can be derived from a property through reflection, but certain mappings such as
		/// HashTable cannot provide the type to the framework.
		/// </remarks>
		[XmlAttribute("type")]
		public string CLRType
		{
			get { return _clrType; }
			set { _clrType = value; }
		}


		/// <summary>
		/// The name of the statement to retrieve the property
		/// </summary>
		[XmlAttribute("select")]
		public string Select
		{
			get { return _select; }
			set { _select = value; }
		}

		/// <summary>
		/// The name of a nested ResultMap to set the property
		/// </summary>
		[XmlAttribute("resultMapping")]
		public string NestedResultMapName
		{
			get { return _nestedResultMapName; }
			set { _nestedResultMapName = value; }
		}

		/// <summary>
		/// The property name used to identify the property amongst the others.
		/// </summary>
		[XmlAttribute("property")]
		public string PropertyName
		{
			get { return _propertyName; }
			set
			{
				_propertyName = value;
				if (_propertyName.IndexOf('.')<0)
				{
					_isComplexMemberName = false;
				}
				else // complex member name FavouriteLineItem.Id
				{
					_isComplexMemberName = true;
				}
			}
		}

		/// <summary>
        /// Defines a field/property <see cref="ISetAccessor"/>
		/// </summary>
		[XmlIgnore]
		public ISetAccessor SetAccessor
		{
			get { return _setAccessor; }
		}

		/// <summary>
		/// Get the field/property type
		/// </summary>
		[XmlIgnore]
		public virtual Type MemberType
		{
            get { return _setAccessor.MemberType; }
		}

		/// <summary>
		/// Tell if a nullValue is defined.
		/// </summary>
		[XmlIgnore]
		public bool HasNullValue
		{
			get { return (_nullValue!=null); }
		}

		/// <summary>
		/// Null value replacement.
		/// </summary>
		/// <example>"no_email@provided.com"</example>
		[XmlAttribute("nullValue")]
		public string NullValue
		{
			get { return _nullValue; }
			set { _nullValue = value; }
		}

		/// <summary>
		/// A nested ResultMap use to set a property
		/// </summary>
		[XmlIgnore]
		public IResultMap NestedResultMap
		{
			get { return _nestedResultMap; }
			set { _nestedResultMap = value; }
		}

		/// <summary>
		/// Indicate if we have a complex member name as [FavouriteLineItem.Id]
		/// </summary>
		public bool IsComplexMemberName
		{
			get { return _isComplexMemberName; }
		}

		/// <summary>
		/// Column Index
		/// </summary>
		[XmlAttribute("columnIndex")]
		public int ColumnIndex
		{
			get { return _columnIndex; }
			set { _columnIndex = value; }
		}

		/// <summary>
		/// Column Name
		/// </summary>
		[XmlAttribute("column")]
		public string ColumnName
		{
			get { return _columnName; }
			set { _columnName = value; }
		}

		#endregion

		#region Constructor (s) / Destructor
		/// <summary>
		/// Do not use direclty, only for serialization.
		/// </summary>
		public ResultProperty()
		{
		}
		#endregion

		#region Methods

		/// <summary>
		/// Initialize the PropertyInfo of the result property.
		/// </summary>
		/// <param name="resultClass"></param>
		/// <param name="configScope"></param>
		public void Initialize( ConfigurationScope configScope, Type resultClass )
		{
			if ( _propertyName.Length>0 && 
				 _propertyName != "value" && 
				!typeof(IDictionary).IsAssignableFrom(resultClass) )
			{
				if (!_isComplexMemberName)
				{
                    _setAccessor = configScope.DataExchangeFactory.AccessorFactory.SetAccessorFactory.CreateSetAccessor(resultClass, _propertyName);
				}
				else // complex member name FavouriteLineItem.Id
				{
					MemberInfo propertyInfo = ObjectProbe.GetMemberInfoForSetter(resultClass, _propertyName);
					string memberName = _propertyName.Substring( _propertyName.LastIndexOf('.')+1);
                    _setAccessor = configScope.DataExchangeFactory.AccessorFactory.SetAccessorFactory.CreateSetAccessor(propertyInfo.ReflectedType, memberName);
				}

                _isGenericIList = TypeUtils.IsImplementGenericIListInterface(this.MemberType);
                _isIList = typeof(IList).IsAssignableFrom(this.MemberType);
			    
			    // set the list factory
			    if (_isGenericIList)
			    {
			        if (this.MemberType.IsArray)
			        {
                        _listFactory = _arrayListFactory;
			        }
			        else
			        {
                        Type[] typeArgs = this.MemberType.GetGenericArguments();

                        if (typeArgs.Length == 0)// Custom collection which derive from List<T>
			            {
                            _listFactory = configScope.DataExchangeFactory.ObjectFactory.CreateFactory(this.MemberType, Type.EmptyTypes);
			            }
			            else
			            {
                            Type genericIList = typeof(IList<>);
                            Type interfaceListType = genericIList.MakeGenericType(typeArgs);

                            Type genericList = typeof(List<>);
                            Type listType = genericList.MakeGenericType(typeArgs);

                            if ((interfaceListType == this.MemberType) || (listType == this.MemberType))
                            {
                                Type constructedType = genericList.MakeGenericType(typeArgs);
                                _listFactory = configScope.DataExchangeFactory.ObjectFactory.CreateFactory(
                                    constructedType,
                                    Type.EmptyTypes);
                            }
                            else // Custom collection which derive from List<T>
                            {
                                _listFactory = configScope.DataExchangeFactory.ObjectFactory.CreateFactory(this.MemberType, Type.EmptyTypes);
                            }  
			            }			            
			        }
			    }
			    else if (_isIList)
			    {
                    if (this.MemberType.IsArray)
                    {
                        _listFactory = _arrayListFactory;
                    }
			        else
                    {
                        if (this.MemberType == typeof(IList))
                        {
                            _listFactory = _arrayListFactory;
                        }
                        else // custom collection
                        {
                            _listFactory = configScope.DataExchangeFactory.ObjectFactory.CreateFactory(this.MemberType,                                                                                                   Type.EmptyTypes);
                        }                        
                    }
			    }
			}

			if (this.CallBackName!=null && this.CallBackName.Length >0)
			{
				configScope.ErrorContext.MoreInfo = "Result property '"+_propertyName+"' check the typeHandler attribute '" + this.CallBackName + "' (must be a ITypeHandlerCallback implementation).";
				try 
				{
					Type type = configScope.SqlMapper.TypeHandlerFactory.GetType(this.CallBackName);
					ITypeHandlerCallback typeHandlerCallback = (ITypeHandlerCallback) Activator.CreateInstance( type );
					_typeHandler = new CustomTypeHandler(typeHandlerCallback);
				}
				catch (Exception e) 
				{
					throw new ConfigurationException("Error occurred during custom type handler configuration.  Cause: " + e.Message, e);
				}
			}
			else
			{
				configScope.ErrorContext.MoreInfo = "Result property '"+_propertyName+"' set the typeHandler attribute.";
				_typeHandler = configScope.ResolveTypeHandler( resultClass, _propertyName, _clrType, _dbType, true);
			}

            if (this.IsLazyLoad)
            {
                _lazyFactory = new LazyFactoryBuilder().GetLazyFactory(_setAccessor.MemberType);
            }
		}

		/// <summary>
		/// Initialize a the result property
		/// for AutoMapper
		/// </summary>
        /// <param name="setAccessor">An <see cref="ISetAccessor"/>.</param>
		/// <param name="typeHandlerFactory"></param>
		internal void Initialize(TypeHandlerFactory typeHandlerFactory, ISetAccessor setAccessor )
		{
            _setAccessor = setAccessor;
            _typeHandler = typeHandlerFactory.GetTypeHandler(setAccessor.MemberType);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataReader"></param>
		/// <returns></returns>
		public object GetDataBaseValue(IDataReader dataReader)
		{
			object value = null;

			if (_columnIndex == UNKNOWN_COLUMN_INDEX)  
			{
                value = this.TypeHandler.GetValueByName(this, dataReader);
			} 
			else 
			{
                value = this.TypeHandler.GetValueByIndex(this, dataReader);
			}

			bool wasNull = (value == DBNull.Value);
			if (wasNull)
			{
				if (this.HasNullValue) 
				{
                    if (_setAccessor != null)
					{
                        value = this.TypeHandler.ValueOf(_setAccessor.MemberType, _nullValue);
					}
					else
					{
                        value = this.TypeHandler.ValueOf(null, _nullValue);
					}
				}
				else
				{
                    value = this.TypeHandler.NullValue;
				}			
			}

			return value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public object TranslateValue(object value)
		{
			if (value == null)
			{
                return this.TypeHandler.NullValue;
			}
			else
			{
				return value;
			}
		}

		#endregion

        #region ICloneable Members

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>An <see cref="ResultProperty"/></returns>
        public ResultProperty Clone()
        {
            ResultProperty resultProperty = new ResultProperty();

            resultProperty.CLRType = this.CLRType;
            resultProperty.CallBackName = this.CallBackName;
            resultProperty.ColumnIndex = this.ColumnIndex;
            resultProperty.ColumnName = this.ColumnName;
            resultProperty.DbType = this.DbType;
            resultProperty.IsLazyLoad = this.IsLazyLoad;
            resultProperty.NestedResultMapName = this.NestedResultMapName;
            resultProperty.NullValue = this.NullValue;
            resultProperty.PropertyName = this.PropertyName;
            resultProperty.Select = this.Select;

            return resultProperty;
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
