
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

#region Imports

using System.Collections;
using System.Data;
using System.Text;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Elements;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Handlers;
using Apache.Ibatis.DataMapper.Model.Sql.SimpleDynamic;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Scope;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.Common.Contracts;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Sql.Dynamic
{
	/// <summary>
	/// DynamicSql represent the root element of a dynamic sql statement
	/// </summary>
	/// <example>
	///      <dynamic prepend="where">...</dynamic>
	/// </example>
	public sealed class DynamicSql : ISql, IDynamicParent  
	{
        private const string MARK_TOKEN = "?";
        private const string COMMA_TOKEN = ",";

		#region Fields

        private readonly IList<ISqlChild> children = new List<ISqlChild>();
        private readonly IStatement statement = null;
        private readonly bool usePositionalParameters = false;
        private readonly InlineParameterMapParser paramParser = null;
        private readonly DataExchangeFactory dataExchangeFactory = null;
        private readonly DBHelperParameterCache dbHelperParameterCache = null;

		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicSql"/> class.
        /// </summary>
        /// <param name="usePositionalParameters">if set to <c>true</c> [use positional parameters].</param>
        /// <param name="dbHelperParameterCache">The db helper parameter cache.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="statement">The statement.</param>
        public DynamicSql(
            bool usePositionalParameters,
            DBHelperParameterCache dbHelperParameterCache,
            DataExchangeFactory dataExchangeFactory, 
            IStatement statement)
		{
            Contract.Require.That(dataExchangeFactory, Is.Not.Null).When("retrieving argument dataExchangeFactory in DynamicSql constructor");
            Contract.Require.That(dbHelperParameterCache, Is.Not.Null).When("retrieving argument dbHelperParameterCache in DynamicSql constructor");
            Contract.Require.That(statement, Is.Not.Null).When("retrieving argument statement in DynamicSql constructor");

			this.statement = statement;
            this.usePositionalParameters = usePositionalParameters;
            this.dataExchangeFactory = dataExchangeFactory;
            this.dbHelperParameterCache = dbHelperParameterCache;
            paramParser = new InlineParameterMapParser();
		}

		#region Methods

		#region ISql IDynamicParent

		/// <summary>
		/// 
		/// </summary>
		/// <param name="child"></param>
		public void AddChild(ISqlChild child)
		{
			children.Add(child);
		}

		#endregion

		#region ISql Members


		/// <summary>
		/// Builds a new <see cref="RequestScope"/> and the <see cref="IDbCommand"/> text to execute.
		/// </summary>
		/// <param name="parameterObject">The parameter object (used in DynamicSql)</param>
		/// <param name="session">The current session</param>
		/// <param name="mappedStatement">The <see cref="IMappedStatement"/>.</param>
		/// <returns>A new <see cref="RequestScope"/>.</returns>
		public RequestScope GetRequestScope(
            IMappedStatement mappedStatement, 
			object parameterObject, 
            ISession session)
		{ 
			RequestScope request = new RequestScope( dataExchangeFactory, session, statement);

			string sql = Process(request, parameterObject);
			request.PreparedStatement = BuildPreparedStatement(session, request, sql);
			request.MappedStatement = mappedStatement;

			return request;
		}
	
		
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		private string Process(RequestScope request, object parameterObject) 
		{
			SqlTagContext ctx = new SqlTagContext();
            IList<ISqlChild> localChildren = children;

			ProcessBodyChildren(request, ctx, parameterObject, localChildren);

			// Builds a 'dynamic' ParameterMap
            ParameterMap parameterMap = new ParameterMap(
                statement.Id + "-InlineParameterMap",
                statement.ParameterClass.FullName,
                string.Empty,
                statement.ParameterClass,
                dataExchangeFactory.GetDataExchangeForClass(null),
                usePositionalParameters);

			// Adds 'dynamic' ParameterProperty
			IList parameters = ctx.GetParameterMappings();
			int count = parameters.Count;
			for(int i=0;i<count;i++)
			{
                parameterMap.AddParameterProperty((ParameterProperty)parameters[i]);
			}
            request.ParameterMap = parameterMap;

			string dynSql = ctx.BodyText;

            if (statement is Procedure)
            {
                dynSql = dynSql.Replace(MARK_TOKEN, string.Empty).Replace(COMMA_TOKEN, string.Empty).Trim();
            }

		    // Processes $substitutions$ after DynamicSql
			if ( SimpleDynamicSql.IsSimpleDynamicSql(dynSql) ) 
			{
                dynSql = new SimpleDynamicSql(
                    dataExchangeFactory,
                    dbHelperParameterCache,
                    dynSql, 
                    statement).GetSql(parameterObject);
			}
			return dynSql;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="ctx"></param>
		/// <param name="parameterObject"></param>
		/// <param name="localChildren"></param>
		private void ProcessBodyChildren(RequestScope request, SqlTagContext ctx,
            object parameterObject, IList<ISqlChild> localChildren) 
		{
			StringBuilder buffer = ctx.GetWriter();
			ProcessBodyChildren(request, ctx, parameterObject, localChildren.GetEnumerator(), buffer);
		}


        /// <summary>
        /// Processes the body children.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ctx">The CTX.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <param name="childEnumerator">The child enumerator.</param>
        /// <param name="buffer">The buffer.</param>
		private void ProcessBodyChildren(
            RequestScope request, 
            SqlTagContext ctx,
            object parameterObject, 
            IEnumerator<ISqlChild> childEnumerator, 
            StringBuilder buffer) 
		{
            while (childEnumerator.MoveNext()) 
			{
                ISqlChild child = childEnumerator.Current;

				if (child is SqlText) 
				{
					SqlText sqlText = (SqlText) child;
					string sqlStatement = sqlText.Text;
					if (sqlText.IsWhiteSpace) 
					{
						buffer.Append(sqlStatement);
					} 
					else 
					{
//						if (SimpleDynamicSql.IsSimpleDynamicSql(sqlStatement)) 
//						{
//							sqlStatement = new SimpleDynamicSql(sqlStatement, _statement).GetSql(parameterObject);
//							SqlText newSqlText = _paramParser.ParseInlineParameterMap( null, sqlStatement );
//							sqlStatement = newSqlText.Text;
//							ParameterProperty[] mappings = newSqlText.Parameters;
//							if (mappings != null) 
//							{
//								for (int i = 0; i < mappings.Length; i++) 
//								{
//									ctx.AddParameterMapping(mappings[i]);
//								}
//							}
//						}
						// BODY OUT
						buffer.Append(" ");
						buffer.Append(sqlStatement);

						ParameterProperty[] parameters = sqlText.Parameters;
						if (parameters != null) 
						{
							int length = parameters.Length;
							for (int i = 0; i< length; i++) 
							{
								ctx.AddParameterMapping(parameters[i]);
							}
						}
					}
				} 
				else if (child is SqlTag) 
				{
					SqlTag tag = (SqlTag) child;
					ISqlTagHandler handler = tag.Handler;
					int response = BaseTagHandler.INCLUDE_BODY;

					do 
					{
						StringBuilder body = new StringBuilder();

						response = handler.DoStartFragment(ctx, tag, parameterObject);
						if (response != BaseTagHandler.SKIP_BODY) 
						{
							if (ctx.IsOverridePrepend
								&& ctx.FirstNonDynamicTagWithPrepend == null
								&& tag.IsPrependAvailable
								&& !(tag.Handler is DynamicTagHandler)) 
							{
								ctx.FirstNonDynamicTagWithPrepend = tag;
							}

							ProcessBodyChildren(request, ctx, parameterObject, tag.GetChildrenEnumerator(), body);
            
							response = handler.DoEndFragment(ctx, tag, parameterObject, body);
							handler.DoPrepend(ctx, tag, parameterObject, body);
							if (response != BaseTagHandler.SKIP_BODY) 
							{
								if (body.Length > 0) 
								{
									// BODY OUT

									if (handler.IsPostParseRequired) 
									{
                                        SqlText sqlText = InlineParameterMapParser.ParseInlineParameterMap(dataExchangeFactory, statement.Id, null, body.ToString());
										buffer.Append(sqlText.Text);
										ParameterProperty[] mappings = sqlText.Parameters;
										if (mappings != null) 
										{
											int length = mappings.Length;
											for (int i = 0; i< length; i++) 
											{
												ctx.AddParameterMapping(mappings[i]);
											}
										}
									} 
									else 
									{
										buffer.Append(" ");
										buffer.Append(body.ToString());
									}
									if (tag.IsPrependAvailable && tag == ctx.FirstNonDynamicTagWithPrepend) 
									{
										ctx.IsOverridePrepend = false;
									}
								}
							}
						}
					} 
					while (response == BaseTagHandler.REPEAT_BODY);
				}
			}
		}


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
		#endregion

	}
}
