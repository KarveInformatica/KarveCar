#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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
using System.Collections;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.TypeHandlers;

namespace Apache.Ibatis.DataMapper.DataExchange
{
	/// <summary>
	/// Factory for DataExchange objects
	/// </summary>
	public class DataExchangeFactory
	{
		private readonly TypeHandlerFactory _typeHandlerFactory = null;
		private readonly IObjectFactory _objectFactory = null;
        private readonly AccessorFactory _accessorFactory = null;

		private readonly IDataExchange _primitiveDataExchange = null;
		private readonly IDataExchange _complexDataExchange = null;
		private readonly IDataExchange _listDataExchange = null;
		private readonly IDataExchange _dictionaryDataExchange = null;

		/// <summary>
		///  Getter for the type handler factory
		/// </summary>
		public TypeHandlerFactory TypeHandlerFactory
		{
			get{ return _typeHandlerFactory; }
		}

		/// <summary>
		/// The factory for object
		/// </summary>
		public IObjectFactory ObjectFactory
		{
			get{ return _objectFactory; }
		}
		
		/// <summary>
        /// The factory which build <see cref="ISetAccessor"/>
		/// </summary>
        public AccessorFactory AccessorFactory
		{
            get { return _accessorFactory; }
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="DataExchangeFactory"/> class.
        /// </summary>
        /// <param name="typeHandlerFactory">The type handler factory.</param>
        /// <param name="objectFactory">The object factory.</param>
        /// <param name="accessorFactory">The accessor factory.</param>
		public DataExchangeFactory(TypeHandlerFactory typeHandlerFactory,
			IObjectFactory objectFactory,
            AccessorFactory accessorFactory)
		{
			_objectFactory = objectFactory;
			_typeHandlerFactory = typeHandlerFactory;
            _accessorFactory = accessorFactory;

			_primitiveDataExchange = new PrimitiveDataExchange(this);
			_complexDataExchange = new ComplexDataExchange(this);
			_listDataExchange = new ListDataExchange(this);
			_dictionaryDataExchange = new DictionaryDataExchange(this);
		}

		/// <summary>
		/// Get a DataExchange object for the passed in Class
		/// </summary>
		/// <param name="clazz">The class to get a DataExchange object for</param>
		/// <returns>The IDataExchange object</returns>
		public IDataExchange GetDataExchangeForClass(Type clazz)
		{
			IDataExchange dataExchange = null;
			if (clazz == null) 
			{
				dataExchange = _complexDataExchange;
			}
			else if (typeof(IList).IsAssignableFrom(clazz)) 
			{
				dataExchange = _listDataExchange;
			} 
			else if (typeof(IDictionary).IsAssignableFrom(clazz)) 
			{
				dataExchange = _dictionaryDataExchange;
			} 
			else if (_typeHandlerFactory.GetTypeHandler(clazz) != null) 
			{
				dataExchange = _primitiveDataExchange;
			} 
			else 
			{
				dataExchange = new DotNetObjectDataExchange(clazz, this);
			}
			
			return dataExchange;
		}

	}
}
