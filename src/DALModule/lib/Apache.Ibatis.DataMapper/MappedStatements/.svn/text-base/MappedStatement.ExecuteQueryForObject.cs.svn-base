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

using System.Data;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    public partial class MappedStatement
    {
        /// <summary>
        /// Executes an SQL statement that returns a single row as an Object of the type of
        /// the resultObject passed in as a parameter.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The object</returns>
        public virtual object ExecuteQueryForObject(ISession session, object parameterObject, object resultObject)
        {
            return ExecuteQueryForObject<object>(session, parameterObject, resultObject);
        }

        /// <summary>
        /// Executes an SQL statement that returns a single row as an Object of the type of
        /// the resultObject passed in as a parameter.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The object</returns>
        public virtual T ExecuteQueryForObject<T>(ISession session, object parameterObject, T resultObject)
        {
            return Execute(PreSelectEventKey,PostSelectEventKey,session,parameterObject,
                (r, p) => RunQueryForObject(r, session, p, resultObject));
        }

        /// <summary>
        /// Executes an SQL statement that returns a single row as an Object of the type of
        /// the resultObject passed in as a parameter.
        /// </summary>
        /// <param name="request">The request scope.</param>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The object</returns>
        internal T RunQueryForObject<T>(RequestScope request, ISession session, object parameterObject, T resultObject)
        {
            T result = resultObject;

            using (IDbCommand command = request.IDbCommand)
            {
                IDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        object obj = resultStrategy.Process(request, ref reader, resultObject);
                        if (obj != BaseStrategy.SKIP)
                        {
                            result = (T)obj;
                        }
                    }
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }

                ExecuteDelayedLoad(request);

                #region remark
                // If you are using the OleDb data provider, you need to close the
                // DataReader before output parameters are visible.
                #endregion

                RetrieveOutputParameters(request, session, command, parameterObject);
            }

            return result;
        }
    }
}
