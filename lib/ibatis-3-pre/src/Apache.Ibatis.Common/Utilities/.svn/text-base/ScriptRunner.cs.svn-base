
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408164 $
 * $Date: 2009-06-13 20:04:50 -0600 (Sat, 13 Jun 2009) $
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
using System.IO;

using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Utilities
{
	/// <summary>
	/// Description résumée de ScriptRunner.
	/// </summary>
	public class ScriptRunner
	{
		/// <summary>
		/// Run an sql script
		/// </summary>
		/// <param name="dataSource">The dataSouce that will be used to run the script.</param>
		/// <param name="sqlScriptPath">a path to an sql script file.</param>
		public void RunScript(IDataSource dataSource, string sqlScriptPath) {
			RunScript(dataSource, sqlScriptPath, true);
		}

		/// <summary>
		/// Run an sql script
		/// </summary>
		/// <param name="dataSource">The dataSouce that will be used to run the script.</param>
		/// <param name="sqlScriptPath">a path to an sql script file.</param>
		/// <param name="doParse">parse out the statements in the sql script file.</param>
		public void RunScript(IDataSource dataSource, string sqlScriptPath, bool doParse)
		{
			// Get script file
            FileInfo fileInfo = new FileInfo(sqlScriptPath);
            string script = string.Empty;

            using (Stream stream = new FileStream(sqlScriptPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    script = reader.ReadToEnd();
                }                
            }

            AnalyseScript(dataSource, script, doParse, fileInfo.Name);

        }

        /// <summary>
        /// Runs the sql script.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="doParse">if set to <c>true</c> [do parse].</param>
        public void RunScript(IDataSource dataSource, Stream stream, bool doParse)
        {
            string script = string.Empty;
            using (TextReader reader = new StreamReader(stream))
            {
                script = reader.ReadToEnd();
            }
            AnalyseScript(dataSource, script, doParse, "stream input");
        }

        /// <summary>
        /// Analyses the script.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="script">The script.</param>
        /// <param name="doParse">if set to <c>true</c> [do parse].</param>
        /// <param name="fileName">Name of the file.</param>
        private void AnalyseScript(IDataSource dataSource, string script, bool doParse, string fileName)
        {
            ArrayList sqlStatements = new ArrayList();

            if (doParse)
            {
                switch (dataSource.DbProvider.Id)
                {
                    case "oracle9.2":
                    case "oracle10.1":
                    case "oracleClient1.0":
                    case "ByteFx":
                    case "MySql":
                    case "SQLite3":
                        sqlStatements = ParseScript(script);
                        break;
                    case "OleDb1.1":
                        if (dataSource.ConnectionString.IndexOf("Microsoft.Jet.OLEDB") > 0)
                        {
                            // Access
                            sqlStatements = ParseScript(script);
                        }
                        else
                        {
                            sqlStatements.Add(script);
                        }
                        break;
                    default:
                        sqlStatements.Add(script);
                        break;
                }
            }
            else
            {
                switch (dataSource.DbProvider.Id)
                {
                    case "oracle9.2":
                    case "oracle10.1":
                    case "oracleClient1.0":
                    case "ByteFx":
                    case "MySql":
                        script = script.Replace("\r\n", " ");
                        script = script.Replace("\t", " ");
                        sqlStatements.Add(script);
                        break;
                    case "OleDb1.1":
                        if (dataSource.ConnectionString.IndexOf("Microsoft.Jet.OLEDB") > 0)
                        {
                            // Access
                            script = script.Replace("\r\n", " ");
                            script = script.Replace("\t", " ");
                            sqlStatements.Add(script);
                        }
                        else
                        {
                            sqlStatements.Add(script);
                        }
                        break;
                    default:
                        sqlStatements.Add(script);
                        break;
                }
            }

            try
            {
                ExecuteStatements(dataSource, sqlStatements);
            }
            catch (Exception e)
            {
                throw new IbatisException("Unable to execute the sql: " + fileName, e);
            }

        }

	    /// <summary>
		/// Execute the given sql statements
		/// </summary>
		/// <param name="dataSource">The dataSouce that will be used.</param>
		/// <param name="sqlStatements">An ArrayList of sql statements to execute.</param>
		private void ExecuteStatements(IDataSource dataSource, ArrayList sqlStatements) {
			IDbConnection connection = dataSource.DbProvider.CreateConnection();
			connection.ConnectionString = dataSource.ConnectionString;
			connection.Open();
			IDbTransaction transaction = connection.BeginTransaction();
			
			IDbCommand command = connection.CreateCommand();

			command.Connection = connection;
			command.Transaction = transaction;			

			try {
				foreach (string sqlStatement in sqlStatements) {
					command.CommandText = sqlStatement;
					command.ExecuteNonQuery();
				}
				transaction.Commit();
			}
			catch(Exception e) {
				transaction.Rollback();
				throw (e);
			}
			finally {
				connection.Close();
			}
		}

		/// <summary>
		/// Parse and tokenize the sql script into multiple statements
		/// </summary>
		/// <param name="script">the script to parse</param>
		private ArrayList ParseScript(string script) {
			ArrayList statements = new ArrayList();
			StringTokenizer parser = new StringTokenizer(script, ";");
			IEnumerator enumerator = parser.GetEnumerator();

			while (enumerator.MoveNext()) {
				string statement= ((string)enumerator.Current).Replace("\r\n"," ");
				statement = statement.Trim();
				if (statement != string.Empty) {
					statements.Add(statement);
				}
			}

			return statements;
		}	
	}
}
