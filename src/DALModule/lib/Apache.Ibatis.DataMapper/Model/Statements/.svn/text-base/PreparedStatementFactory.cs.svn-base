
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2009-06-28 01:03:34 -0600 (Sun, 28 Jun 2009) $
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
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Text;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Data;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Statements
{
	/// <summary>
	/// Summary description for PreparedStatementFactory.
	/// </summary>
	public class PreparedStatementFactory
	{

		#region Fields

        private PreparedStatement preparedStatement = null;

        private readonly string parameterPrefix = string.Empty;
        private readonly IStatement statement = null;
        private readonly ISession session = null;
        private readonly IDbProvider dbProvider = null;

        private readonly DBHelperParameterCache dbHelperParameterCache = null;

        private readonly string commandText = string.Empty;
		private readonly RequestScope request = null;
		// (property, DbParameter)
        private readonly HybridDictionary propertyDbParameterMap = new HybridDictionary();

		private static readonly ILog logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PreparedStatementFactory"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="dbHelperParameterCache">The db helper parameter cache.</param>
        /// <param name="request">The request.</param>
        /// <param name="statement">The statement.</param>
        /// <param name="commandText">The command text.</param>
        public PreparedStatementFactory(
            ISession session,
            DBHelperParameterCache dbHelperParameterCache,
            RequestScope request, 
            IStatement statement, 
            string commandText)
		{
            Contract.Require.That(session, Is.Not.Null).When("retrieving argument session using statement '" + statement.Id + "' in PreparedStatementFactory constructor");
            Contract.Require.That(dbHelperParameterCache, Is.Not.Null).When("retrieving argument dBHelperParameterCache using statement '" + statement.Id + "' in PreparedStatementFactory constructor");
            Contract.Require.That(request, Is.Not.Null).When("retrieving argument request using statement '" + statement.Id + "' in PreparedStatementFactory constructor");
            Contract.Require.That(statement, Is.Not.Null).When("retrieving argument statement using statement '" + statement.Id + "' in PreparedStatementFactory constructor");
            Contract.Require.That(commandText, Is.Not.Null & Is.Not.Empty).When("retrieving argument commandText using statement '" + statement.Id + "' in PreparedStatementFactory constructor");

            this.session = session;
            this.request = request;
            this.statement = statement;
            this.commandText = commandText;
            this.dbHelperParameterCache = dbHelperParameterCache;

            dbProvider = session.SessionFactory.DataSource.DbProvider;
            parameterPrefix = dbProvider.ParameterPrefix;
		}


        /// <summary>
        /// Create a list of IDataParameter for the statement and build the sql string.
        /// </summary>
        /// <param name="isDynamic">if set to <c>true</c> this statement is dynamic.</param>
        /// <returns></returns>
		public PreparedStatement Prepare(bool isDynamic)
		{
			preparedStatement = new PreparedStatement();

			if (statement.CommandType == CommandType.Text)
			{
                preparedStatement.PreparedSql = commandText;

				if (request.ParameterMap != null) 
				{
					CreateParametersForTextCommand();
					EvaluateParameterMap();
				}
			}
			else if (statement.CommandType == CommandType.StoredProcedure) // StoredProcedure
			{
                // Necessary to prevent stored procedures with extra space around their name like 
                // " ps_SelectAccount " to be sent to the database as "ps_SelectAccount".
                preparedStatement.PreparedSql = commandText.Trim();

				if (request.ParameterMap == null) // No parameterMap --> error
				{
					throw new DataMapperException("A procedure statement tag must have a parameterMap attribute, which is not the case for the procedure '"+statement.Id+"."); 
				}
			    if (dbProvider.UseDeriveParameters)
			    {
			        if (isDynamic)
			        {
			            DiscoverParameter(request.ParameterMap);                         
			        }
			        else
			        {
			            DiscoverParameter(statement.ParameterMap); 
			        }
			    }
			    else
			    {
			        CreateParametersForProcedureCommand();
			    }

			    #region Fix for Odbc
				// Although executing a parameterized stored procedure using the ODBC .NET Provider 
				// is slightly different from executing the same procedure using the SQL or 
				// the OLE DB Provider, there is one important difference 
				// -- the stored procedure must be called using the ODBC CALL syntax rather than 
				// the name of the stored procedure. 
				// For additional information on this CALL syntax, 
				// see the page entitled "Procedure Calls" in the ODBC Programmer's Reference 
				// in the MSDN Library. 
				//http://support.microsoft.com/default.aspx?scid=kb;EN-US;Q309486

                if (dbProvider.IsObdc)
				{
					StringBuilder commandTextBuilder = new StringBuilder("{ call ");
					commandTextBuilder.Append( commandText );

					if (preparedStatement.DbParameters.Length >0)
					{
						commandTextBuilder.Append(" (");
						int supIndex = preparedStatement.DbParameters.Length-1;
						for(int i=0;i<supIndex;i++)
						{
							commandTextBuilder.Append("?,");
						}
						commandTextBuilder.Append("?) }");
					}
					preparedStatement.PreparedSql = commandTextBuilder.ToString();
				}

				#endregion
			}

			if (logger.IsDebugEnabled) 
			{
				logger.Debug("Statement Id: [" + statement.Id + "] Prepared SQL: [" + preparedStatement.PreparedSql + "]");
			}

			return preparedStatement;
		}


		#region Private methods

        /// <summary>
        /// For store procedure, auto discover IDataParameters for stored procedures at run-time.
        /// </summary>
        private void DiscoverParameter(ParameterMap parameterMap)
		{
			// pull the parameters for this stored procedure from the parameter cache 
			// (or discover them & populate the cache)
            IDataParameter[] commandParameters = dbHelperParameterCache.GetSpParameterSet(session, commandText);

            preparedStatement.DbParameters = new IDbDataParameter[commandParameters.Length];

            int start = dbProvider.ParameterPrefix.Length;
			for(int i=0; i< commandParameters.Length;i++)
			{
				IDbDataParameter dataParameter = (IDbDataParameter)commandParameters[i];

                if (dbProvider.UseParameterPrefixInParameter == false)
				{
                    if (dataParameter.ParameterName.StartsWith(dbProvider.ParameterPrefix)) 
					{
						dataParameter.ParameterName = dataParameter.ParameterName.Substring(start);
					}
				}
				preparedStatement.DbParameters[i] = dataParameter;
                if (dataParameter.Direction == ParameterDirection.Output ||
                            dataParameter.Direction == ParameterDirection.InputOutput)
                {
                    parameterMap.HasOutputParameter = true;
                }
            }
		    
            // Re-sort DbParameters to match order used in the parameterMap
            IDbDataParameter[] sortedDbParameters = new IDbDataParameter[parameterMap.Properties.Count];
            for (int i = 0; i < parameterMap.Properties.Count; i++)
            {
                sortedDbParameters[i] = Search(preparedStatement.DbParameters, parameterMap.Properties[i], i);
                preparedStatement.DbParametersName.Add(sortedDbParameters[i].ParameterName);
            }
            preparedStatement.DbParameters = sortedDbParameters;
		}

        private IDbDataParameter Search(IDbDataParameter[] parameters, ParameterProperty property, int index)
        {
            if (property.ColumnName.Length>0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    string parameterName = parameters[i].ParameterName;
                    if (dbProvider.UseParameterPrefixInParameter)
                    {
                        if (parameterName.StartsWith(dbProvider.ParameterPrefix))
                        {
                           int prefixLength = dbProvider.ParameterPrefix.Length;
                           parameterName = parameterName.Substring(prefixLength);
                        }
                    }
                    if (property.ColumnName.Equals(parameterName))
                    {
                        return parameters[i];
                    }
                }
                throw new IndexOutOfRangeException("The parameter '" + property.ColumnName + "' does not exist in the stored procedure '" +statement.Id+"'. Check your parameterMap.");                
            }
            return parameters[index];
        }


	    /// <summary>
		/// Create IDataParameters for command text statement.
		/// </summary>
		private void CreateParametersForTextCommand()
		{
			string sqlParamName = string.Empty;
            string dbTypePropertyName = dbProvider.ParameterDbTypeProperty;
            Type enumDbType = dbProvider.ParameterDbType;
			ParameterPropertyCollection list = null;

            if (dbProvider.UsePositionalParameters) //obdc/oledb
			{
				list = request.ParameterMap.Properties;
			}
			else 
			{
				list = request.ParameterMap.PropertiesList;
			}

            preparedStatement.DbParameters = new IDbDataParameter[list.Count];
 
			for(int i =0; i<list.Count; i++)
			{
				ParameterProperty property = list[i];

                if (dbProvider.UseParameterPrefixInParameter)
				{
					// From Ryan Yao: JIRA-27, used "param" + i++ for sqlParamName
					sqlParamName = parameterPrefix + "param" + i;
				}
				else
				{
					sqlParamName = "param" + i;
				}

                IDbDataParameter dataParameter = dbProvider.CreateDataParameter();

				// Manage dbType attribute if any
				if (!string.IsNullOrEmpty(property.DbType)) 
				{
					// Exemple : Enum.parse(System.Data.SqlDbType, 'VarChar')
					object dbType = Enum.Parse( enumDbType, property.DbType, true );

					// Exemple : ObjectHelper.SetProperty(sqlparameter, 'SqlDbType', SqlDbType.Int);
					ObjectProbe.SetMemberValue(dataParameter, dbTypePropertyName, dbType, 
						request.DataExchangeFactory.ObjectFactory, 
                        request.DataExchangeFactory.AccessorFactory );
				}

				// Set IDbDataParameter
				// JIRA-49 Fixes (size, precision, and scale)
                if (dbProvider.SetDbParameterSize) 
				{
					if (property.Size != -1)
					{
						dataParameter.Size = property.Size;
					}
				}

                if (dbProvider.SetDbParameterPrecision) 
				{
					dataParameter.Precision = property.Precision;
				}
                if (dbProvider.SetDbParameterScale) 
				{
					dataParameter.Scale = property.Scale;
				}
				
				// Set as direction parameter
				dataParameter.Direction = property.Direction;

				dataParameter.ParameterName = sqlParamName;

				preparedStatement.DbParametersName.Add( property.PropertyName );
				preparedStatement.DbParameters[i] = dataParameter ;

                if (dbProvider.UsePositionalParameters == false)
				{
					propertyDbParameterMap.Add(property, dataParameter);
				}
			}
		}


		/// <summary>
		/// Create IDataParameters for procedure statement.
		/// </summary>
		private void CreateParametersForProcedureCommand()
		{
			string sqlParamName = string.Empty;
            string dbTypePropertyName = dbProvider.ParameterDbTypeProperty;
            Type enumDbType = dbProvider.ParameterDbType;
			ParameterPropertyCollection list = null;

            if (dbProvider.UsePositionalParameters) //obdc/oledb
			{
				list = request.ParameterMap.Properties;
			}
			else 
			{
				list = request.ParameterMap.PropertiesList;
			}

            preparedStatement.DbParameters = new IDbDataParameter[list.Count];

			// ParemeterMap are required for procedure and we tested existance in Prepare() method
			// so we don't have to test existence here.
			// A ParameterMap used in CreateParametersForProcedureText must
			// have property and column attributes set.
			// The column attribute is the name of a procedure parameter.
			for(int i =0; i<list.Count;  i++)
			{
				ParameterProperty property = list[i];

                if (dbProvider.UseParameterPrefixInParameter)
				{
					sqlParamName = parameterPrefix + property.ColumnName;
				}
				else //obdc/oledb
				{
					sqlParamName =  property.ColumnName;
				}

                IDbDataParameter dataParameter = dbProvider.CreateCommand().CreateParameter();

				// Manage dbType attribute if any
				if (!string.IsNullOrEmpty(property.DbType)) 
				{
					// Exemple : Enum.parse(System.Data.SqlDbType, 'VarChar')
					object dbType = Enum.Parse( enumDbType, property.DbType, true );

					// Exemple : ObjectHelper.SetProperty(sqlparameter, 'SqlDbType', SqlDbType.Int);
					ObjectProbe.SetMemberValue(dataParameter, dbTypePropertyName, dbType,
                        request.DataExchangeFactory.ObjectFactory, 
                        request.DataExchangeFactory.AccessorFactory);
				}

				// Set IDbDataParameter
				// JIRA-49 Fixes (size, precision, and scale)
                if (dbProvider.SetDbParameterSize) 
				{
					if (property.Size != -1)
					{
						dataParameter.Size = property.Size;
					}
				}

                if (dbProvider.SetDbParameterPrecision) 
				{
					dataParameter.Precision = property.Precision;
				}
                if (dbProvider.SetDbParameterScale) 
				{
					dataParameter.Scale = property.Scale;
				}
				
				// Set as direction parameter
				dataParameter.Direction = property.Direction;

				dataParameter.ParameterName = sqlParamName;

				preparedStatement.DbParametersName.Add( property.PropertyName );
				preparedStatement.DbParameters[i] = dataParameter;

                if (dbProvider.UsePositionalParameters == false)
				{
					propertyDbParameterMap.Add(property, dataParameter);
				}
			}
		}

		/// <summary>
		/// Parse sql command text.
		/// </summary>
		private void EvaluateParameterMap()
		{
			string delimiter = "?";
			string token = null;
			int index = 0;
			string sqlParamName = string.Empty;			
			StringTokenizer parser = new StringTokenizer(commandText, delimiter, true);
			StringBuilder newCommandTextBuffer = new StringBuilder();

			IEnumerator enumerator = parser.GetEnumerator();

			while (enumerator.MoveNext()) 
			{
				token = (string)enumerator.Current;

				if (delimiter.Equals(token)) // ?
				{
					ParameterProperty property = request.ParameterMap.Properties[index];
					IDataParameter dataParameter = null;

                    if (dbProvider.UsePositionalParameters)
					{
						// TODO Refactor?
						if (parameterPrefix.Equals(":"))
						{
							// ODP.NET uses positional parameters by default
							// but uses ":0" or ":1" instead of "?"
							sqlParamName = ":" + index;	
						}
						else 
						{
							// OLEDB/OBDC doesn't support named parameters !!!
							sqlParamName = "?";
						}
					}
					else
					{
						dataParameter = (IDataParameter) propertyDbParameterMap[property];
						
						// 5 May 2004
						// Need to check UseParameterPrefixInParameter here 
						// since CreateParametersForStatementText now does
						// a check for UseParameterPrefixInParameter before 
						// creating the parameter name!
                        if (dbProvider.UseParameterPrefixInParameter) 
						{
							// Fix ByteFX.Data.MySqlClient.MySqlParameter
							// who strip prefix in Parameter Name ?!
                            if (dbProvider.Id.IndexOf("ByteFx") >= 0)
							{
								sqlParamName = parameterPrefix+dataParameter.ParameterName;
							}
							else
							{
								sqlParamName = dataParameter.ParameterName;
							}
						}
						else
						{
							sqlParamName = parameterPrefix+dataParameter.ParameterName;
						}
					}			
		
					newCommandTextBuffer.Append(" ");
					newCommandTextBuffer.Append(sqlParamName);

					sqlParamName = string.Empty;
					index ++;
				}
				else
				{
					newCommandTextBuffer.Append(token);
				}
			}
			preparedStatement.PreparedSql = newCommandTextBuffer.ToString();
		}

		#endregion
	}
}
