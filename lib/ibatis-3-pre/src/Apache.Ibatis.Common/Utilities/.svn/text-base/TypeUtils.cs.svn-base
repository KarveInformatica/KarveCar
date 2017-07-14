#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
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

using System.Collections.Generic;
using Apache.Ibatis.Common.Utilities.TypesResolver;

namespace Apache.Ibatis.Common.Utilities
{
    /// <summary>
    ///  Helper methods with regard to type.
    /// </summary>
    /// <remarks>
    /// <p>
    /// Mainly for internal use within the framework.
    /// </p>
    /// </remarks>
    public static class TypeUtils
    {
        #region Fields

        private static readonly ITypeResolver _internalTypeResolver = new CachedTypeResolver(new TypeResolver());

        #endregion

        #region Constructor (s) / Destructor

        #endregion

        /// <summary>
        /// Resolves the supplied type name into a <see cref="System.Type"/>
        /// instance.
        /// </summary>
        /// <param name="typeName">
        /// The (possibly partially assembly qualified) name of a
        /// <see cref="System.Type"/>.
        /// </param>
        /// <returns>
        /// A resolved <see cref="System.Type"/> instance.
        /// </returns>
        /// <exception cref="System.TypeLoadException">
        /// If the type cannot be resolved.
        /// </exception>
        public static Type ResolveType(string typeName)
        {
            Type type = TypeRegistry.ResolveType(typeName);
            if (type == null)
            {
                type = _internalTypeResolver.Resolve(typeName);
            }
            return type;
        }

        /// <summary>
        /// Instantiate a 'Primitive' Type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>An object.</returns>
        public static object InstantiatePrimitiveType(Type type)
        {
            object resultObject = null;

            if (type.IsPrimitive || type == typeof(string))
            {
                TypeCode typeCode = Type.GetTypeCode(type);
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        resultObject = new Boolean();
                        break;
                    case TypeCode.Byte:
                        resultObject = new Byte();
                        break;
                    case TypeCode.Char:
                        resultObject = new Char();
                        break;
                    case TypeCode.DateTime:
                        resultObject = new DateTime();
                        break;
                    case TypeCode.Decimal:
                        resultObject = new Decimal();
                        break;
                    case TypeCode.Double:
                        resultObject = new Double();
                        break;
                    case TypeCode.Int16:
                        resultObject = new Int16();
                        break;
                    case TypeCode.Int32:
                        resultObject = new Int32();
                        break;
                    case TypeCode.Int64:
                        resultObject = new Int64();
                        break;
                    case TypeCode.SByte:
                        resultObject = new SByte();
                        break;
                    case TypeCode.Single:
                        resultObject = new Single();
                        break;
                    case TypeCode.String:
                        resultObject = string.Empty;
                        break;
                    case TypeCode.UInt16:
                        resultObject = new UInt16();
                        break;
                    case TypeCode.UInt32:
                        resultObject = new UInt32();
                        break;
                    case TypeCode.UInt64:
                        resultObject = new UInt64();
                        break;
                }
            }
            else
            {
                if (type.IsValueType)
                {
                    if (type == typeof(DateTime))
                    {
                        return new DateTime();
                    }
                    if (type == typeof(Decimal))
                    {
                        return new Decimal();
                    }
                    if (type == typeof(Guid))
                    {
                        return Guid.Empty;
                    }
                    if (type == typeof(TimeSpan))
                    {
                        return new TimeSpan(0);
                    }
                    if (type.IsGenericType &&
                        typeof(Nullable<>).IsAssignableFrom(type.GetGenericTypeDefinition()))
                    {
                        return InstantiateNullableType(type);
                    }
                    throw new NotImplementedException("Unable to instanciate value type");
                }
            }

            return resultObject;
        }

        /// <summary>
        /// Instantiate a Nullable Type.
        /// </summary>
        /// <param name="type">The nullable type.</param>
        /// <returns>An object.</returns>
        public static object InstantiateNullableType(Type type)
        {
            object resultObject = null;

            if (type== typeof(bool?))
            {
                resultObject = new Nullable<bool>(false);
            }
            else if (type== typeof(byte?))
            {
                resultObject = new Nullable<byte>(byte.MinValue);
            }               
            else if (type== typeof(char?))
            {
                resultObject = new Nullable<char>(char.MinValue);
            }
            else if (type == typeof(DateTime?))
            {
                resultObject = new Nullable<DateTime>(DateTime.MinValue);
            }
            else if (type == typeof(decimal?))
            {
                resultObject = new Nullable<decimal>(decimal.MinValue);
            }
            else if (type == typeof(double?))
            {
                resultObject = new Nullable<double>(double.MinValue);
            }
            else if (type == typeof(Int16?))
            {
                resultObject = new Nullable<Int16>(Int16.MinValue);
            }
            else if (type == typeof(Int32?))
            {
                resultObject = new Nullable<Int32>(Int32.MinValue);
            }
            else if (type == typeof(Int64?))
            {
                resultObject = new Nullable<Int64>(Int64.MinValue);
            }
            else if (type == typeof(SByte?))
            {
                resultObject = new Nullable<SByte>(SByte.MinValue);
            }
            else if (type == typeof(Single?))
            {
                resultObject = new Nullable<Single>(Single.MinValue);
            }
            else if (type == typeof(UInt16?))
            {
                resultObject = new Nullable<UInt16>(UInt16.MinValue);
            }
            else if (type == typeof(UInt32?))
            {
                resultObject = new Nullable<UInt32>(UInt32.MinValue);
            }
            else if (type == typeof(UInt64?))
            {
                resultObject = new Nullable<UInt64>(UInt64.MinValue);
            }              

            return resultObject;
        }

        /// <summary>
        /// Determines whether the specified type is implement generic Ilist interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if the specified type is implement generic Ilist interface; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsImplementGenericIListInterface(Type type)
        {
            bool ret = false;

            if (!type.IsGenericType)
            {
                ret = false;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                return true;
            }
            // check if one of the derived interfaces is IList<>
            Type[] interfaceTypes = type.GetInterfaces();
            for (int i = 0; i < interfaceTypes.Length; i++)
            {
                ret = IsImplementGenericIListInterface(interfaceTypes[i]);
                if (ret)
                {
                    break;
                }
            }
            return ret;
        } 

    }
}
