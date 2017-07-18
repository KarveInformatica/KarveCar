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
        #region ExecuteQueryForDataTable
        /// <summary>
        /// Executes an SQL statement that returns DataTable.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>The object</returns>
        public virtual DataTable ExecuteQueryForDataTable(ISession session, object parameterObject)
        {
            return Execute(PreSelectEventKey, PostSelectEventKey, session, parameterObject,
                (r, p) => RunQueryForDataTable(r, session, parameterObject));

            // return RaisePostEvent<DataTable, PostSelectEventArgs>(PostSelectEventKey, param, dataTable);
        }

        /// <summary>
        /// Runs the query for for data table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="session">The session.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
        internal DataTable RunQueryForDataTable(RequestScope request, ISession session, object parameterObject)
        {
            DataTable dataTable = new DataTable("DataTable");

            using (IDbCommand command = request.IDbCommand)
            {
                IDataReader reader = command.ExecuteReader();

                try
                {
                    // Get Results
                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();
                        dataTable.Rows.Add(dataRow);
                        resultStrategy.Process(request, ref reader, dataRow);
                    }
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }

                // do we need ??
                //ExecuteDelayedLoad(request);

                // do we need ??
                //RetrieveOutputParameters(request, session, command, parameterObject);
            }

            return dataTable;
        }
        #endregion
    }
}
