
#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-09-21 08:43:08 -0600 (Sun, 21 Sep 2008) $
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
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Sql.SimpleDynamic;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.Model.Sql.External
{
    /// <summary>
    /// Represents ths SQL of a mapped statement with an external <see cref="ISqlSource"/>.
    /// </summary>
    public class ExternalSql :ISql 
    {
        private readonly IStatement statement = null;
        private readonly InlineParemeterMapBuilder inlineParemeterMapBuilder = null;
        private readonly DataExchangeFactory dataExchangeFactory = null;
        private readonly DBHelperParameterCache dbHelperParameterCache = null;
        private readonly string commandText = string.Empty;

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <value>The command text.</value>
        public string CommandText
        {
            get { return commandText; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalSql"/> class.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        /// <param name="statement">The statement.</param>
        /// <param name="commandText">The command text.</param>
        public ExternalSql(
            IModelStore modelStore,
            IStatement statement,
            string commandText)
        {
            Contract.Require.That(modelStore, Is.Not.Null).When("retrieving argument modelStore in ExternalSql constructor");
            Contract.Require.That(statement, Is.Not.Null).When("retrieving argument statement in ExternalSql constructor");

            this.statement = statement;
            this.commandText = commandText;
            dataExchangeFactory = modelStore.DataExchangeFactory;
            dbHelperParameterCache = modelStore.DBHelperParameterCache;

            inlineParemeterMapBuilder = new InlineParemeterMapBuilder(modelStore);
        }


        #region ISql Members

        /// <summary>
        /// Builds a new <see cref="RequestScope"/> and the <see cref="IDbCommand"/> text to execute.
        /// </summary>
        /// <param name="mappedStatement">The <see cref="IMappedStatement"/>.</param>
        /// <param name="parameterObject">The parameter object (used by DynamicSql/SimpleDynamicSql).
        /// Use to complete the sql statement.</param>
        /// <param name="session">The current session</param>
        /// <returns>A new <see cref="RequestScope"/>.</returns>
        public RequestScope GetRequestScope(IMappedStatement mappedStatement, object parameterObject, ISession session)
        {
            RequestScope request = new RequestScope(dataExchangeFactory, session, statement);

            string sqlCommandText = statement.SqlSource.GetSql(mappedStatement, parameterObject);
            string newSqlCommandText = string.Empty;

            if (request.ParameterMap==null)
            {               
                request.ParameterMap = inlineParemeterMapBuilder.BuildInlineParemeterMap(statement, sqlCommandText, out newSqlCommandText);
            }

            // Processes $substitutions$ after DynamicSql
            if (SimpleDynamicSql.IsSimpleDynamicSql(newSqlCommandText))
            {
                newSqlCommandText = new SimpleDynamicSql(
                    dataExchangeFactory,
                    dbHelperParameterCache,
                    newSqlCommandText,
                    statement).GetSql(parameterObject);
            }

            request.PreparedStatement = BuildPreparedStatement(session, request, newSqlCommandText);

            return request;
        }

        #endregion

        /// <summary>
        /// Builds the prepared statement.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="request">The request.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        private PreparedStatement BuildPreparedStatement(ISession session, RequestScope request, string sqlStatement)
        {
            PreparedStatementFactory factory = new PreparedStatementFactory(session, dbHelperParameterCache, request, statement, sqlStatement);
            return factory.Prepare(true);
        }
    }
}
