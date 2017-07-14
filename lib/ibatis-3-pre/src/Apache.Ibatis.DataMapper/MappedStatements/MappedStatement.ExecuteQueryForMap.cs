#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-11 12:07:44 -0400 (Sat, 11 Oct 2008) $
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

using System.Collections;
using System.Collections.Generic;
using System.Data;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    public partial class MappedStatement
    {
        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public virtual IDictionary ExecuteQueryForMap(ISession session, object parameterObject, string keyProperty, string valueProperty)
        {
            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForMap(r, session, p, keyProperty, valueProperty, null));
        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A IDictionary of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public virtual IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty)
        {
            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForDictionary<K, V>(r, session, p, keyProperty, valueProperty, null));
        }

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate">A delegate called once per row in the QueryForDictionary method</param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public virtual IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate<K, V> rowDelegate)
        {
            if (rowDelegate == null)
            {
                throw new DataMapperException("A null DictionaryRowDelegate was passed to QueryForDictionary.");
            }

            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForDictionary(r, session, p, keyProperty, valueProperty, rowDelegate));
        }

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public virtual IDictionary ExecuteQueryForMapWithRowDelegate(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate rowDelegate)
        {
            if (rowDelegate == null)
            {
                throw new DataMapperException("A null DictionaryRowDelegate was passed to QueryForMapWithRowDelegate.");
            }

            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
               (r, p) => RunQueryForMap(r, session, p, keyProperty, valueProperty, rowDelegate));
        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="request">The request scope.</param>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate">A delegate called once per row in the QueryForMapWithRowDelegate method</param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        internal IDictionary RunQueryForMap(RequestScope request,
            ISession session,
            object parameterObject,
            string keyProperty,
            string valueProperty,
            DictionaryRowDelegate rowDelegate)
        {
            IDictionary map = new Hashtable();

            using (IDbCommand command = request.IDbCommand)
            {
                IDataReader reader = command.ExecuteReader();
                try
                {

                    if (rowDelegate == null)
                    {
                        while (reader.Read())
                        {
                            object obj = resultStrategy.Process(request, ref reader, null);
                            object key = ObjectProbe.GetMemberValue(obj, keyProperty, request.DataExchangeFactory.AccessorFactory);
                            object value = obj;
                            if (valueProperty != null)
                            {
                                value = ObjectProbe.GetMemberValue(obj, valueProperty, request.DataExchangeFactory.AccessorFactory);
                            }
                            map.Add(key, value);
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            object obj = resultStrategy.Process(request, ref reader, null);
                            object key = ObjectProbe.GetMemberValue(obj, keyProperty, request.DataExchangeFactory.AccessorFactory);
                            object value = obj;
                            if (valueProperty != null)
                            {
                                value = ObjectProbe.GetMemberValue(obj, valueProperty, request.DataExchangeFactory.AccessorFactory);
                            }
                            rowDelegate(key, value, parameterObject, map);

                        }
                    }
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
                ExecuteDelayedLoad(request);
            }
            return map;

        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="request">The request scope.</param>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate">A delegate called once per row in the QueryForMapWithRowDelegate method</param>
        /// <returns>A IDictionary of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        internal IDictionary<TKey, TValue> RunQueryForDictionary<TKey, TValue>(RequestScope request,
            ISession session,
            object parameterObject,
            string keyProperty,
            string valueProperty,
            DictionaryRowDelegate<TKey, TValue> rowDelegate)
        {
            IDictionary<TKey, TValue> map = new Dictionary<TKey, TValue>();

            using (IDbCommand command = request.IDbCommand)
            {
                IDataReader reader = command.ExecuteReader();
                try
                {

                    if (rowDelegate == null)
                    {
                        while (reader.Read())
                        {
                            object obj = resultStrategy.Process(request, ref reader, null);
                            TKey key = (TKey)ObjectProbe.GetMemberValue(obj, keyProperty, request.DataExchangeFactory.AccessorFactory);
                            TValue value = default(TValue);
                            if (valueProperty != null)
                            {
                                value = (TValue)ObjectProbe.GetMemberValue(obj, valueProperty, request.DataExchangeFactory.AccessorFactory);
                            }
                            else
                            {
                                value = (TValue)obj;
                            }
                            map.Add(key, value);
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            object obj = resultStrategy.Process(request, ref reader, null);
                            TKey key = (TKey)ObjectProbe.GetMemberValue(obj, keyProperty, request.DataExchangeFactory.AccessorFactory);
                            TValue value = default(TValue);
                            if (valueProperty != null)
                            {
                                value = (TValue)ObjectProbe.GetMemberValue(obj, valueProperty, request.DataExchangeFactory.AccessorFactory);
                            }
                            else
                            {
                                value = (TValue)obj;
                            }
                            rowDelegate(key, value, parameterObject, map);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
                ExecuteDelayedLoad(request);
            }
            return map;

        }

    }
}
