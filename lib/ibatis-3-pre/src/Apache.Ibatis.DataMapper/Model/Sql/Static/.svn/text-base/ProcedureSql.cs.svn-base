#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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
using System;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.Common.Contracts;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Sql.Static
{
	/// <summary>
    /// Represents a procedure mapped statement without dynamic element.
	/// </summary>
	public sealed class ProcedureSql : ISql
	{
        private readonly IStatement statement = null;
        private readonly object syncLock = new Object();
        private readonly DataExchangeFactory dataExchangeFactory = null;
        private readonly DBHelperParameterCache dbHelperParameterCache = null;
		private PreparedStatement preparedStatement = null ;
        private readonly string sqlStatement = string.Empty;

       /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureSql"/> class.
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="dbHelperParameterCache">The db helper parameter cache.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <param name="statement">The statement.</param>
        public ProcedureSql(
            DataExchangeFactory dataExchangeFactory,
            DBHelperParameterCache dbHelperParameterCache,
            string sqlStatement, 
            IStatement statement)
		{
            Contract.Require.That(dataExchangeFactory, Is.Not.Null).When("retrieving argument dataExchangeFactory in ProcedureSql constructor");
            Contract.Require.That(dbHelperParameterCache, Is.Not.Null).When("retrieving argument dbHelperParameterCache in ProcedureSql constructor");
            Contract.Require.That(statement, Is.Not.Null).When("retrieving argument statement in ProcedureSql constructor");
            Contract.Require.That(sqlStatement, Is.Not.Null & Is.Not.Empty).When("retrieving argument sqlStatement in ProcedureSql constructor");

            this.sqlStatement = sqlStatement;
            this.statement = statement;
            this.dataExchangeFactory = dataExchangeFactory;
            this.dbHelperParameterCache = dbHelperParameterCache;
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
			object parameterObject, ISession session)
		{
			RequestScope request = new RequestScope(dataExchangeFactory, session, statement);

            request.PreparedStatement = BuildPreparedStatement(session, request, sqlStatement);
			request.MappedStatement = mappedStatement;

			return request;
		}

        /// <summary>
        /// Build the PreparedStatement
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="request">The request.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public PreparedStatement BuildPreparedStatement(ISession session, RequestScope request, string commandText)
		{
			if (preparedStatement == null )
			{
				lock(syncLock)
				{
					if (preparedStatement==null)
					{
                        PreparedStatementFactory factory = new PreparedStatementFactory(session, dbHelperParameterCache, request, statement, commandText);
						preparedStatement = factory.Prepare(false);
					}
				}
			}
			return preparedStatement;
		}

		#endregion
	}
}
