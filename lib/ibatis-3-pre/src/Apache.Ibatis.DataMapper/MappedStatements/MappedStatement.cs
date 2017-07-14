
#region Apache Notice
/*****************************************************************************
 * $Revision: 575902 $
 * $LastChangedDate: 2009-06-28 01:03:34 -0600 (Sun, 28 Jun 2009) $
 * $LastChangedBy: rgrabowski $
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
using System.Collections.Generic;
using System.Data;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Events;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.MappedStatements.PostSelectStrategy;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.TypeHandlers;
using Apache.Ibatis.DataMapper.Session;
using System.Diagnostics;

#endregion

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    /// <summary>
    /// Base implementation of <see cref="IMappedStatement"/>.
    /// </summary>
    [DebuggerDisplay("MappedStatement: {Id}")]
    public partial class MappedStatement : MappedStatementEventSupport, IMappedStatement
    {
        /// <summary>
        /// Event launch on execute query
        /// </summary>
        public event EventHandler<ExecuteEventArgs> Executed = delegate { };

        #region Fields
        private readonly IStatement statement = null;
        private readonly IModelStore modelStore = null;
        private readonly IPreparedCommand preparedCommand = null;
        private readonly IResultStrategy resultStrategy = null;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedStatement"/> class.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        /// <param name="statement">The statement.</param>
        public MappedStatement(IModelStore modelStore, IStatement statement)
        {
            this.modelStore = modelStore;
            this.statement = statement;
            preparedCommand = new DefaultPreparedCommand();
            resultStrategy = ResultStrategyFactory.Get(this.statement);
        }

        #region properties
        /// <summary>
        /// The IPreparedCommand to use
        /// </summary>
        public IPreparedCommand PreparedCommand
        {
            get { return preparedCommand; }
        }

        /// <summary>
        /// Name used to identify the MappedStatement amongst the others.
        /// This the name of the SQL statement by default.
        /// </summary>
        public string Id
        {
            get { return statement.Id; }
        }

        /// <summary>
        /// The SQL statment used by this MappedStatement
        /// </summary>
        public IStatement Statement
        {
            get { return statement; }
        }

        /// <summary>
        /// The <see cref="IModelStore"/> used by this MappedStatement
        /// </summary>
        /// <value>The model store.</value>
        public IModelStore ModelStore
        {
            get { return modelStore; }
        } 
        #endregion

       /// <summary>
        /// Retrieve the output parameter and map them on the result object.
        /// This routine is only use is you specified a ParameterMap and some output attribute
        /// or if you use a store procedure with output parameter...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="session">The current session.</param>
        /// <param name="result">The result object.</param>
        /// <param name="command">The command sql.</param>
        private static void RetrieveOutputParameters(RequestScope request, ISession session, IDbCommand command, object result)
        {
            if (request.ParameterMap != null && request.ParameterMap.HasOutputParameter)
            {
                int count = request.ParameterMap.PropertiesList.Count;
                for (int i = 0; i < count; i++)
                {
                    ParameterProperty mapping = request.ParameterMap.GetProperty(i);
                    if (mapping.Direction == ParameterDirection.Output ||
                        mapping.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = string.Empty;
                        if (session.SessionFactory.DataSource.DbProvider.UseParameterPrefixInParameter == false)
                        {
                            parameterName = mapping.ColumnName;
                        }
                        else
                        {
                            parameterName = session.SessionFactory.DataSource.DbProvider.ParameterPrefix +
                                mapping.ColumnName;
                        }

                        if (mapping.TypeHandler == null) // Find the TypeHandler
                        {
                            lock (mapping)
                            {
                                if (mapping.TypeHandler == null)
                                {
                                    Type propertyType = ObjectProbe.GetMemberTypeForGetter(result, mapping.PropertyName);

                                    mapping.TypeHandler = request.DataExchangeFactory.TypeHandlerFactory.GetTypeHandler(propertyType);
                                }
                            }
                        }

                        // Fix IBATISNET-239
                        //"Normalize" System.DBNull parameters
                        IDataParameter dataParameter = (IDataParameter)command.Parameters[parameterName];
                        object dbValue = dataParameter.Value;

                        object value = null;

                        bool wasNull = (dbValue == DBNull.Value);
                        if (wasNull)
                        {
                            if (mapping.HasNullValue)
                            {
                               value = mapping.TypeHandler.ValueOf(mapping.GetAccessor.MemberType, mapping.NullValue);
                            }
                            else
                            {
                                value = mapping.TypeHandler.NullValue;
                            }
                        }
                        else
                        {
                            value = mapping.TypeHandler.GetDataBaseValue(dataParameter.Value, result.GetType());
                        }

                        request.IsRowDataFound = request.IsRowDataFound || (value != null);

                        request.ParameterMap.SetOutputParameter(ref result, mapping, value);
                    }
                }
            }
        }

        /// <summary>
        /// Executes the <see cref="PostBindind"/>.
        /// </summary>
        /// <param name="request">The current <see cref="RequestScope"/>.</param>
        private static void ExecuteDelayedLoad(RequestScope request)
        {
            while (request.DelayedLoad.Count > 0)
            {
                PostBindind postSelect = request.DelayedLoad.Dequeue();

                PostSelectStrategyFactory.Get(postSelect.Method).Execute(postSelect, request);
            }
        }

        /// <summary>
        /// Raise an event ExecuteEventArgs
        /// (Used when a query is executed)
        /// </summary>
        private void RaiseExecuteEvent()
        {
            ExecuteEventArgs e = new ExecuteEventArgs();
            e.StatementName = statement.Id;
            Executed(this, e);
        }

        /// <summary>
        /// Ensures all the related Execute methods are run in a consistent manner with pre and post events.
        /// </summary>
        /// <returns></returns>
        protected virtual T Execute<T>(object preEvent, object postEvent, ISession session, object parameterObject, Func<RequestScope, object, T> requestRunner)
        {
            object paramPreEvent = RaisePreEvent(preEvent, parameterObject);

            RequestScope request = statement.Sql.GetRequestScope(this, paramPreEvent, session);
            preparedCommand.Create(request, session, Statement, paramPreEvent);
            T result = requestRunner(request, paramPreEvent);

            RaiseExecuteEvent();

            return RaisePostEvent(postEvent, paramPreEvent, result, false);
        }
    }
}
