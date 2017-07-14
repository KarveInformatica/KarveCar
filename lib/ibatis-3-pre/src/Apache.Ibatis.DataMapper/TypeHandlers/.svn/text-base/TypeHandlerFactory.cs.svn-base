
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 501527 $
 * $Date: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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
using System.Reflection;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model.Alias;
using Apache.Ibatis.DataMapper.TypeHandlers.Nullables;
using CommonExceptions = Apache.Ibatis.Common.Exceptions;

#endregion 

namespace Apache.Ibatis.DataMapper.TypeHandlers
{
	/// <summary>
	/// Not much of a suprise, this is a factory class for TypeHandler objects.
	/// </summary>
	public sealed class TypeHandlerFactory
	{
		private static readonly ILog logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );
        // <type, <dbType, ITypeHandler>>
        private readonly IDictionary<Type, IDictionary<string, ITypeHandler>> typeHandlerMap = new Dictionary<Type, IDictionary<string, ITypeHandler>>();
		private readonly ITypeHandler unknownTypeHandler = null;
		private const string NULL = "NULLTYPE";
        private readonly IDictionary<string, TypeAlias> typeAliasMaps = new Dictionary<string, TypeAlias>();
        private readonly IDictionary<Type, bool> simpleTypes = new Dictionary<Type, bool>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeHandlerFactory"/> class.
        /// </summary>
		public TypeHandlerFactory() 
		{
			ITypeHandler handler = null;

			handler = new DBNullTypeHandler();
			Register(typeof(DBNull), handler);

			handler = new BooleanTypeHandler();
			Register(typeof(bool), handler); // key= "System.Boolean"

			handler = new ByteTypeHandler();
			Register(typeof(Byte), handler);

			handler = new CharTypeHandler();
			Register(typeof(Char), handler);

			handler = new DateTimeTypeHandler();
			Register(typeof(DateTime), handler);

			handler = new DecimalTypeHandler();
			Register(typeof(Decimal), handler);

			handler = new DoubleTypeHandler();
			Register(typeof(Double), handler);

			handler = new Int16TypeHandler();
			Register(typeof(Int16), handler);

			handler = new Int32TypeHandler();
			Register(typeof(Int32), handler);

			handler = new Int64TypeHandler();
			Register(typeof(Int64), handler);

			handler = new SingleTypeHandler();
			Register(typeof(Single), handler);

			handler = new StringTypeHandler();
			Register(typeof(String), handler);

			handler = new GuidTypeHandler();
			Register(typeof(Guid), handler);

			handler = new TimeSpanTypeHandler();
			Register(typeof(TimeSpan), handler);

			handler = new ByteArrayTypeHandler();
			Register(typeof(Byte[]), handler);

			handler = new ObjectTypeHandler();
			Register(typeof(object), handler);

			handler = new EnumTypeHandler();
			Register( typeof(Enum), handler);

            handler = new UInt16TypeHandler();
            Register(typeof(UInt16), handler);

            handler = new UInt32TypeHandler();
            Register(typeof(UInt32), handler);

            handler = new UInt64TypeHandler();
            Register(typeof(UInt64), handler);

            handler = new SByteTypeHandler();
            Register(typeof(SByte), handler);
		    
            handler = new NullableBooleanTypeHandler();
            Register(typeof(bool?), handler);

            handler = new NullableByteTypeHandler();
            Register(typeof(byte?), handler);

            handler = new NullableCharTypeHandler();
            Register(typeof(char?), handler);

            handler = new NullableDateTimeTypeHandler();
            Register(typeof(DateTime?), handler);

            handler = new NullableDecimalTypeHandler();
            Register(typeof(decimal?), handler);

            handler = new NullableDoubleTypeHandler();
            Register(typeof(double?), handler);

            handler = new NullableGuidTypeHandler();
            Register(typeof(Guid?), handler);

            handler = new NullableInt16TypeHandler();
            Register(typeof(Int16?), handler);
            
            handler = new NullableInt32TypeHandler();
            Register(typeof(Int32?), handler);

            handler = new NullableInt64TypeHandler();
            Register(typeof(Int64?), handler);

            handler = new NullableSingleTypeHandler();
            Register(typeof(Single?), handler);

            handler = new NullableUInt16TypeHandler();
            Register(typeof(UInt16?), handler);

            handler = new NullableUInt32TypeHandler();
            Register(typeof(UInt32?), handler);

            handler = new NullableUInt64TypeHandler();
            Register(typeof(UInt64?), handler);

            handler = new NullableSByteTypeHandler();
            Register(typeof(SByte?), handler);

            handler = new NullableTimeSpanTypeHandler();
            Register(typeof(TimeSpan?), handler);

            unknownTypeHandler = new UnknownTypeHandler(this);

		}

		#region Methods

		/// <summary>
		/// Get a TypeHandler for a Type
		/// </summary>
		/// <param name="type">the Type you want a TypeHandler for</param>
		/// <returns>the handler</returns>
		public ITypeHandler GetTypeHandler(Type type)
		{
			return GetTypeHandler(type, null);
		}

		/// <summary>
		/// Get a TypeHandler for a type
		/// </summary>
		/// <param name="type">the type you want a TypeHandler for</param>
		/// <param name="dbType">the database type</param>
		/// <returns>the handler</returns>
		public ITypeHandler GetTypeHandler(Type type, string dbType)
		{
		    if (type.IsEnum)
			{
				return GetPrivateTypeHandler(typeof(Enum), dbType);
			}
		    return GetPrivateTypeHandler(type, dbType);
		}

	    /// <summary>
		///  Get a TypeHandler for a type and a dbType type
		/// </summary>
		/// <param name="type">the type</param>
		/// <param name="dbType">the dbType type</param>
		/// <returns>the handler</returns>
		private ITypeHandler GetPrivateTypeHandler(Type type, string dbType) 
		{
            // <dbType, ITypeHandler>
            IDictionary<string, ITypeHandler> dbTypeHandlerMap = null;
            typeHandlerMap.TryGetValue(type, out dbTypeHandlerMap);
			ITypeHandler handler = null;

			if (dbTypeHandlerMap != null) 
			{
				if (dbType==null)
				{
                    dbTypeHandlerMap.TryGetValue(NULL, out handler);
				}
				else
				{
                    dbTypeHandlerMap.TryGetValue(dbType, out handler);
					if (handler == null) 
					{
						handler = dbTypeHandlerMap[ NULL ];
					}					
				}
				if (handler==null)
				{
					throw new DataMapperException(String.Format("Type handler for {0} not registered.",type.Name));
				}
			}

			return handler;
		}


		/// <summary>
		/// Register (add) a type handler for a type
		/// </summary>
		/// <param name="type">the type</param>
		/// <param name="handler">the handler instance</param>
		public void Register(Type type, ITypeHandler handler) 
		{
			Register(type, null, handler);
		}

		/// <summary>
		/// Register (add) a type handler for a type and dbType
		/// </summary>
		/// <param name="type">the type</param>
		/// <param name="dbType">the dbType (optional, if dbType is null the handler will be used for all dbTypes)</param>
		/// <param name="handler">the handler instance</param>
		public void Register(Type type, string dbType, ITypeHandler handler) 
		{
            IDictionary<string, ITypeHandler> map = null;
            typeHandlerMap.TryGetValue(type, out map);
			if (map == null) 
			{
                map = new Dictionary<string, ITypeHandler>();
				typeHandlerMap.Add(type, map)  ;
			}
			if (dbType==null)
			{
				if (logger.IsInfoEnabled)
				{
					// notify the user that they are no longer using one of the built-in type handlers
                    ITypeHandler oldTypeHandler = null;
                    map.TryGetValue(NULL, out oldTypeHandler);

					if (oldTypeHandler != null)
					{
						// the replacement will always(?) be a CustomTypeHandler
						CustomTypeHandler customTypeHandler = handler as CustomTypeHandler;
						
						string replacement = string.Empty;
						
						if (customTypeHandler != null)
						{
							// report the underlying type
							replacement = customTypeHandler.Callback.ToString();
						}
						else
						{
							replacement = handler.ToString();
						}

						// should oldTypeHandler be checked if its a CustomTypeHandler and if so report the Callback property ???
						logger.Info("Replacing type handler [" + oldTypeHandler + "] with [" + replacement + "].");
					}
				}

				map[NULL] = handler;
			}
			else
			{
				map.Add(dbType, handler);
			}
		}

		/// <summary>
		/// When in doubt, get the "unknown" type handler
		/// </summary>
		/// <returns>if I told you, it would not be unknown, would it?</returns>
		public ITypeHandler GetUnkownTypeHandler() 
		{
			return unknownTypeHandler;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public bool IsSimpleType(Type type) 
		{
			bool result = false;
		    
            if (!simpleTypes.TryGetValue(type, out result))
            {
		        if (type != null) 
			    {
				    ITypeHandler handler = GetTypeHandler(type, null);
				    if (handler != null) 
				    {
					    result = handler.IsSimpleType;
				    }
			        simpleTypes[type] = result;
			    }
            }

			return result;
		}

        /// <summary>
        /// Resolves the type handler for Get/Set members.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="memberType">Type of the member.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="forSetter">if set to <c>true</c> [for setter].</param>
        /// <returns></returns>
        public ITypeHandler ResolveTypeHandler(
            Type classType,
            string memberName,
            string memberType,
            string dbType,
            bool forSetter)
        {
            ITypeHandler handler = null;
            if (classType == null)
            {
                handler = GetUnkownTypeHandler();
            }
            else if (typeof(IDictionary).IsAssignableFrom(classType) || typeof(DataRow).IsAssignableFrom(classType))
            {
                // IDictionary or DataTable
                if (string.IsNullOrEmpty(memberType))
                {
                    handler = GetUnkownTypeHandler();
                }
                else
                {
                    try
                    {
                        Type type = TypeUtils.ResolveType(memberType);
                        handler = GetTypeHandler(type, dbType);
                    }
                    catch (Exception e)
                    {
                        throw new ConfigurationException("Error. Could not set TypeHandler.  Cause: " + e.Message, e);
                    }
                }
            }
            else if (GetTypeHandler(classType, dbType) != null)
            {
                // Primitive
                handler = GetTypeHandler(classType, dbType);
            }
            else
            {
                // .NET object
                if (string.IsNullOrEmpty(memberType))
                {
                    Type type = null;
                    if (forSetter)
                    {
                        type = ObjectProbe.GetMemberTypeForSetter(classType, memberName);
                    }
                    else
                    {
                        type = ObjectProbe.GetMemberTypeForGetter(classType, memberName);
                    }
                    handler = GetTypeHandler(type, dbType);
                }
                else
                {
                    try
                    {
                        Type type = TypeUtils.ResolveType(memberType);
                        handler = GetTypeHandler(type, dbType);
                    }
                    catch (Exception e)
                    {
                        throw new ConfigurationException("Error. Could not set TypeHandler.  Cause: " + e.Message, e);
                    }
                }
            }

            return handler;
        }

        /// <summary>
        /// Resolves the type handler for constructor argument
        /// </summary>
        /// <param name="argumentType">Type of the argument.</param>
        /// <param name="clrType">Type of the CLR.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <returns></returns>
        public ITypeHandler ResolveTypeHandler(
            Type argumentType,
            string clrType,
            string dbType)
        {
            ITypeHandler handler = null;
            if (argumentType == null)
            {
                handler = GetUnkownTypeHandler();
            }
            else if (typeof(IDictionary).IsAssignableFrom(argumentType) || typeof(DataRow).IsAssignableFrom(argumentType))
            {
                // IDictionary or 
                if (string.IsNullOrEmpty(clrType))
                {
                    handler = GetUnkownTypeHandler();
                }
                else
                {
                    try
                    {
                        Type type = TypeUtils.ResolveType(clrType);
                        handler = GetTypeHandler(type, dbType);
                    }
                    catch (Exception e)
                    {
                        throw new ConfigurationException("Error. Could not set TypeHandler.  Cause: " + e.Message, e);
                    }
                }
            }
            else if (GetTypeHandler(argumentType, dbType) != null)
            {
                // Primitive
                handler = GetTypeHandler(argumentType, dbType);
            }
            else
            {
                // .NET object
                if (string.IsNullOrEmpty(clrType))
                {
                    handler = GetUnkownTypeHandler();
                }
                else
                {
                    try
                    {
                        Type type = TypeUtils.ResolveType(clrType);
                        handler = GetTypeHandler(type, dbType);
                    }
                    catch (Exception e)
                    {
                        throw new ConfigurationException("Error. Could not set TypeHandler.  Cause: " + e.Message, e);
                    }
                }
            }

            return handler;
        }

		#endregion

		/// <summary>
		/// Gets a named TypeAlias from the list of available TypeAlias
		/// </summary>
        /// <param name="id">The id of the TypeAlias.</param>
		/// <returns>The TypeAlias.</returns>
        public TypeAlias GetTypeAlias(string id)
		{
		    if (typeAliasMaps.ContainsKey(id)) 
			{
                return typeAliasMaps[id];
			}
		    throw new ConfigurationException("There's no type alias with the name:" + id);
		}

	    /// <summary>
		/// Gets the type object from the specific class name.
		/// </summary>
		/// <param name="className">The supplied class name.</param>
		/// <returns>The correpsonding type.
		/// </returns>
        public Type GetType(string className) 
		{
			Type type = null;

            if (typeAliasMaps.ContainsKey(className)) 
			{
			    TypeAlias typeAlias = GetTypeAlias(className);
				type = typeAlias.Type;
			}
			else
			{
                type = TypeUtils.ResolveType(className);
			}

			return type;
		}

		/// <summary>
		/// Adds a named TypeAlias to the list of available TypeAlias.
		/// </summary>
		/// <param name="key">The key name.</param>
		/// <param name="typeAlias"> The TypeAlias.</param>
        public void AddTypeAlias(string key, TypeAlias typeAlias) 
		{
            if (typeAliasMaps.ContainsKey(key)) 
			{
				throw new DataMapperException(" Alias name conflict occurred.  The type alias '" + key + "' is already mapped to the value '"+typeAlias +"'.");
			}
			typeAliasMaps.Add(key, typeAlias);
		}
	}
}
