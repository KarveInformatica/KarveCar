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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    public partial class MappedStatement
    {
        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>
        public virtual IList ExecuteQueryForRowDelegate(ISession session, object parameterObject, RowDelegate rowDelegate)
        {
            return Execute(PreSelectEventKey, PostSelectEventKey, session, parameterObject,
                 (r, p) => RunQueryForList(r, session, p, null, rowDelegate));
        }

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>
        public virtual IList<T> ExecuteQueryForRowDelegate<T>(ISession session, object parameterObject, RowDelegate<T> rowDelegate)
        {
            if (rowDelegate == null)
            {
                throw new DataMapperException("A null RowDelegate was passed to QueryForRowDelegate.");
            }

            return Execute(PreSelectEventKey, PostSelectEventKey, session, parameterObject,
                (r, p) => RunQueryForList(r, session, p, null, rowDelegate));
        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected. 
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        public virtual IList ExecuteQueryForList(ISession session, object parameterObject)
        {
            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForList(r, session, p, null, null));
        }

        /// <summary>
        /// Executes the SQL and and fill a strongly typed collection.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">A strongly typed collection of result objects.</param>
        public virtual void ExecuteQueryForList(ISession session, object parameterObject, IList resultObject)
        {
            Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForList(r, session, p, resultObject, null));
        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected. 
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        public virtual IList<T> ExecuteQueryForList<T>(ISession session, object parameterObject)
        {
            return Execute(PreSelectEventKey, PostSelectEventKey, session, parameterObject,
                (r, p) => RunQueryForList<T>(r, session, p, null, null));
        }

        /// <summary>
        /// Executes the SQL and and fill a strongly typed collection.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">A strongly typed collection of result objects.</param>
        public virtual void ExecuteQueryForList<T>(ISession session, object parameterObject, IList<T> resultObject)
        {
            Execute(PreSelectEventKey, PostSelectEventKey, session, parameterObject,
                (r, p) => RunQueryForList(r, session, p, resultObject, null));
        }

        /// <summary>
        /// Executes the SQL and retuns a List of result objects.
        /// </summary>
        /// <param name="request">The request scope.</param>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">A strongly typed collection of result objects.</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A List of result objects.</returns>
        internal IList RunQueryForList(RequestScope request, ISession session, object parameterObject, IList resultObject, RowDelegate rowDelegate)
        {
            IList list = resultObject;

            using (IDbCommand command = request.IDbCommand)
            {
                if (resultObject == null)
                {
                    if (statement.ListClass == null)
                    {
                        list = new ArrayList();
                    }
                    else
                    {
                        list = statement.CreateInstanceOfListClass();
                    }
                }

                IDataReader reader = command.ExecuteReader();

                try
                {
                    do
                    {
                        if (rowDelegate == null)
                        {
                            //***
                            IList currentList = null;
                            if (request.Statement.ResultsMap.Count == 1)
                            {
                                currentList = list;
                            }
                            else
                            {
                                if (request.CurrentResultMap != null)
                                {
                                    Type genericListType = typeof(List<>).MakeGenericType(new Type[] { request.CurrentResultMap.Class });
                                    currentList = (IList)Activator.CreateInstance(genericListType);
                                }
                                else
                                {
                                    currentList = new ArrayList();
                                }
                                list.Add(currentList);

                            }
                            //***
                            while (reader.Read())
                            {
                                object obj = resultStrategy.Process(request, ref reader, null);
                                if (obj != BaseStrategy.SKIP)
                                {
                                    //list.Add(obj);
                                    currentList.Add(obj);
                                }
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                object obj = resultStrategy.Process(request, ref reader, null);
                                rowDelegate(obj, parameterObject, list);
                            }
                        }
                    }
                    while (reader.NextResult());
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }

                ExecuteDelayedLoad(request);
                RetrieveOutputParameters(request, session, command, parameterObject);
            }

            return list;
        }

        /// <summary>
        /// Executes the SQL and retuns a List of result objects.
        /// </summary>
        /// <param name="request">The request scope.</param>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A List of result objects.</returns>
        internal IList<T> RunQueryForList<T>(RequestScope request, ISession session, object parameterObject, IList<T> resultObject, RowDelegate<T> rowDelegate)
        {
            IList<T> list = resultObject;

            using (IDbCommand command = request.IDbCommand)
            {
                if (resultObject == null)
                {
                    if (statement.ListClass == null)
                    {
                        list = new List<T>();
                    }
                    else
                    {
                        list = statement.CreateInstanceOfGenericListClass<T>();
                    }
                }

                IDataReader reader = command.ExecuteReader();
                try
                {
                    do
                    {
                        if (rowDelegate == null)
                        {
                            while (reader.Read())
                            {
                                object obj = resultStrategy.Process(request, ref reader, null);
                                if (obj != BaseStrategy.SKIP)
                                {
                                    list.Add((T)obj);
                                }
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                T obj = (T)resultStrategy.Process(request, ref reader, null);
                                rowDelegate(obj, parameterObject, list);
                            }
                        }
                    }
                    while (reader.NextResult());
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }

                ExecuteDelayedLoad(request);
                RetrieveOutputParameters(request, session, command, parameterObject);
            }

            return list;
        }
    }
}
