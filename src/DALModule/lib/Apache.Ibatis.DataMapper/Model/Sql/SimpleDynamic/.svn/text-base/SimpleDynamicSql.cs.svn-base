
#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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

#region Using

using System.Collections;
using System.Text;

using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.Common.Contracts;
#endregion

namespace Apache.Ibatis.DataMapper.Model.Sql.SimpleDynamic
{
	/// <summary>
    /// Represents a sql commqnd text which contains $property$ (old syntax) or ${property}
    /// to be replace 
	/// </summary>
	public sealed class SimpleDynamicSql : ISql
	{
		private const string ELEMENT_TOKEN = "$";

        private readonly string sqlStatement = string.Empty;
        private readonly IStatement statement = null;
		private readonly DataExchangeFactory dataExchangeFactory = null;
        private readonly DBHelperParameterCache dbHelperParameterCache = null;


		#region Constructor (s) / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleDynamicSql"/> class.
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="dbHelperParameterCache">The db helper parameter cache.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <param name="statement">The statement.</param>
        public SimpleDynamicSql(
            DataExchangeFactory dataExchangeFactory,
            DBHelperParameterCache dbHelperParameterCache,
            string sqlStatement, 
			IStatement statement)
		{
            Contract.Require.That(dataExchangeFactory, Is.Not.Null).When("retrieving argument dataExchangeFactory in SimpleDynamicSql constructor");
            Contract.Require.That(dbHelperParameterCache, Is.Not.Null).When("retrieving argument dbHelperParameterCache in SimpleDynamicSql constructor");
            Contract.Require.That(statement, Is.Not.Null).When("retrieving argument statement in SimpleDynamicSql constructor");
            Contract.Require.That(sqlStatement, Is.Not.Null & Is.Not.Empty).When("retrieving argument sqlStatement in SimpleDynamicSql constructor");

            this.sqlStatement = sqlStatement;
            this.statement = statement;
            this.dataExchangeFactory = dataExchangeFactory;
            this.dbHelperParameterCache = dbHelperParameterCache;
		}
		#endregion
		
		#region Methods

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
		public string GetSql(object parameterObject)
		{
			return ProcessDynamicElements(parameterObject);
		}


        /// <summary>
        /// Determines whether the specified SQL statement is dynamic SQL.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>
        /// 	<c>true</c> if is dynamic SQL otherwise, <c>false</c>.
        /// </returns>
		public static bool IsSimpleDynamicSql(string sqlStatement) 
		{
            return ((sqlStatement != null) && sqlStatement.Contains(ELEMENT_TOKEN));
		}


        /// <summary>
        /// Processes the dynamic elements, 
        /// replace $property$ (old syntax) or ${property} (V3 syntax) element by her value
        /// </summary>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
		private string ProcessDynamicElements(object parameterObject) 
		{
            return ProcessDynamicElementsOldSyntax(parameterObject);
		}

        /// <summary>
        /// Processes the dynamic elements with old syntax $property$
        /// </summary>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
        private string ProcessDynamicElementsOldSyntax(object parameterObject)
        {
            // define which character is seperating fields

            StringTokenizer parser = new StringTokenizer(sqlStatement, ELEMENT_TOKEN, true);

            StringBuilder newSql = new StringBuilder();

            string lastToken = null;

            IEnumerator enumerator = parser.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string token = ((string)enumerator.Current);

                if (ELEMENT_TOKEN.Equals(lastToken))
                {
                    if (ELEMENT_TOKEN.Equals(token))
                    {
                        newSql.Append(ELEMENT_TOKEN);
                        token = null;
                    }
                    else
                    {
                        object value = null;
                        if (parameterObject != null)
                        {
                            if (dataExchangeFactory.TypeHandlerFactory.IsSimpleType(parameterObject.GetType()))
                            {
                                value = parameterObject;
                            }
                            else
                            {
                                value = ObjectProbe.GetMemberValue(parameterObject, token, dataExchangeFactory.AccessorFactory);
                            }
                        }
                        if (value != null)
                        {
                            newSql.Append(value.ToString());
                        }

                        enumerator.MoveNext();
                        token = ((string)enumerator.Current);

                        if (!ELEMENT_TOKEN.Equals(token))
                        {
                            throw new DataMapperException("Unterminated dynamic element in sql (" + sqlStatement + ").");
                        }
                        token = null;
                    }
                }
                else
                {
                    if (!ELEMENT_TOKEN.Equals(token))
                    {
                        newSql.Append(token);
                    }
                }

                lastToken = token;
            }

            return newSql.ToString();
        }

	    #region ISql Members

        /// <summary>
        /// Builds a new <see cref="RequestScope"/> and the sql command text to execute.
        /// </summary>
        /// <param name="mappedStatement">The <see cref="IMappedStatement"/>.</param>
        /// <param name="parameterObject">The parameter object (used in DynamicSql)</param>
        /// <param name="session">The current session</param>
        /// <returns>A new <see cref="RequestScope"/>.</returns>
		public RequestScope GetRequestScope(
            IMappedStatement mappedStatement, 
			object parameterObject, 
            ISession session)
		{
			string sql = ProcessDynamicElements(parameterObject);
			
			RequestScope request = new RequestScope( dataExchangeFactory, session, statement);

            request.PreparedStatement = BuildPreparedStatement(session, request, sql);
			request.MappedStatement = mappedStatement;

			return request;
		}

        /// <summary>
        /// Build the PreparedStatement
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="request">The request.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        private PreparedStatement BuildPreparedStatement(ISession session, RequestScope request, string sql)
		{
			PreparedStatementFactory factory = new PreparedStatementFactory( session, dbHelperParameterCache, request, statement, sql);
			return factory.Prepare(false);
		}
		#endregion

		#endregion

	}
}
