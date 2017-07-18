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
using System.Collections;
using System.Data;
using System.Reflection;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.ArgumentStrategy
{
    /// <summary>
    /// <see cref="IArgumentStrategy"/> implementation when a 'select' attribute exists
    /// on an <see cref="ArgumentProperty"/> and the object property is 
    /// different from an <see cref="Array"/> or an <see cref="IList"/>.
    /// </summary>
    public sealed class SelectGenericListStrategy : IArgumentStrategy
    {
        #region IArgumentStrategy Members

        /// <summary>
        /// Gets the value of an argument constructor.
        /// </summary>
        /// <param name="request">The current <see cref="RequestScope"/>.</param>
        /// <param name="mapping">The <see cref="ResultProperty"/> with the argument infos.</param>
        /// <param name="reader">The current <see cref="IDataReader"/>.</param>
        /// <param name="keys">The keys</param>
        /// <returns>The paremeter value.</returns>
        public object GetValue(RequestScope request, ResultProperty mapping, 
                               ref IDataReader reader, object keys)
        {
            // Get the select statement
            IMappedStatement selectStatement = request.MappedStatement.ModelStore.GetMappedStatement(mapping.Select);
           
            reader = DataReaderTransformer.Transform(reader, request.Session.SessionFactory.DataSource.DbProvider);

            //Type[] typeArgs = mapping.MemberType.GetGenericArguments();
            //Type genericList = typeof(IList<>);
            //Type constructedType = genericList.MakeGenericType(typeArgs);
            Type elementType = mapping.MemberType.GetGenericArguments()[0];

            Type mappedStatementType = selectStatement.GetType();

            //Type[] typeArguments = { typeof(ISession), typeof(object) };

            MethodInfo[] mis = mappedStatementType.GetMethods(BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance);
            MethodInfo mi = null;
            for (int i = 0; i < mis.Length; i++)
            {
                if (mis[i].IsGenericMethod &&
                    mis[i].Name == "ExecuteQueryForList" &&
                    mis[i].GetParameters().Length == 2)
                {
                    mi = mis[i];
                    break;
                }
            }

            MethodInfo miConstructed = mi.MakeGenericMethod(elementType);

            // Invoke the method.
            object[] args = { request.Session, keys };
            object values = miConstructed.Invoke(selectStatement, args);

            return values;
        }

        #endregion
    }
}