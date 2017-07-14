#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591573 $
 * $Date: 2009-05-31 00:53:56 -0600 (Sun, 31 May 2009) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2005 - The Apache Software Foundation
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
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Text;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Data
{
	/// <summary>
	/// Summary description for DefaultPreparedCommand.
	/// </summary>
	public class DefaultPreparedCommand : IPreparedCommand
	{
		private static readonly ILog log = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );
		
		#region IPreparedCommand Members

		/// <summary>
		/// Create an IDbCommand for the current session and statement then fill in its IDataParameters based on parameterObject.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="session">The SqlMapSession</param>
		/// <param name="statement">The IStatement</param>
		/// <param name="parameterObject">
		/// The parameter object that will fill the sql parameter
		/// </param> 
        /// <remarks>
        /// The constructed IDbCommand is available from request.IDbCommand
        /// </remarks>
		public void Create(RequestScope request, ISession session, IStatement statement, object parameterObject )
		{
			// the IDbConnection & the IDbTransaction are assign in the CreateCommand 
            IDbProvider dbProvider = session.SessionFactory.DataSource.DbProvider;
            request.IDbCommand = new DbCommandDecorator(CreateCommandAndEnlistTransaction(dbProvider, statement.CommandType, session), request);
			
			request.IDbCommand.CommandText = request.PreparedStatement.PreparedSql;

			if (log.IsDebugEnabled)
			{
                log.Debug("Preparing to apply parameter information to Statement Id: [" + statement.Id + "] based off of PreparedStatement: [" + request.IDbCommand.CommandText + "]");
			}

			ApplyParameterMap( session.SessionFactory.DataSource.DbProvider , request.IDbCommand, request, statement, parameterObject  );
		}

        #endregion
        
        /// <summary>
        /// Creates an IDbCommand fills its parameters based on the parameterObject.
        /// </summary>
        /// <param name="mappedStatement"></param>
        /// <param name="parameterObject"></param>
        /// <returns>An IDbCommand with all the IDataParameter filled.</returns>
        public IDbCommand CreateCommand(IMappedStatement mappedStatement, object parameterObject)
        {
            IDbProvider dbProvider = mappedStatement.ModelStore.SessionFactory.DataSource.DbProvider;
            IStatement statement = mappedStatement.Statement;

            RequestScope request = statement.Sql.GetRequestScope(mappedStatement, parameterObject, null);
            request.IDbCommand = CreateCommandAndEnlistTransaction(dbProvider, statement.CommandType, null);
            request.IDbCommand.CommandText = request.PreparedStatement.PreparedSql;
            request.IDbCommand.CommandType = statement.CommandType;

            if (log.IsDebugEnabled)
            {
                log.Debug("Preparing to apply parameter information to Statement Id: [" + statement.Id + "] based off of PreparedStatement: [" + request.IDbCommand.CommandText + "]");
            }

            ApplyParameterMap(dbProvider, request.IDbCommand, request, statement, parameterObject);

            return request.IDbCommand;
        }

	    /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="dbProvider">The dbProvider.</param>
        /// <param name="session">If session is not null, attaches the session's Connection and Transaction to the command and sets the command's Timeout property.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>the command</returns>
        protected virtual IDbCommand CreateCommandAndEnlistTransaction(IDbProvider dbProvider, CommandType commandType, ISession session)
        {
            IDbCommand command = dbProvider.CreateCommand();
            command.CommandType = commandType;

            if (session != null)
            {
                command.Connection = session.Connection;
                SetCommandTimeout(command, session.SessionFactory.DataSource.CommandTimeout);

                // Assign transaction
                if (session.Transaction != null)
                {
                    session.Transaction.Enlist(command);
                }
            }

	        return command;
        }

	    /// <summary>
        /// Sets the command timeout.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        protected virtual void SetCommandTimeout(IDbCommand cmd, int commandTimeout)
        {
            if (commandTimeout >= 0)
            {
                try
                {
                    cmd.CommandTimeout = commandTimeout;
                }
                catch (Exception e)
                {
                    if (log.IsWarnEnabled)
                    {
                        log.Warn("Unable to set the IDbCommand.CommandTimeout property to [" + commandTimeout + "]. Cause: " + e.Message, e);
                    }
                }
            }
        }

        /// <summary>
        /// Applies the parameter map.
        /// </summary>
        /// <param name="dbProvider">The dbProvider.</param>
        /// <param name="command">The command.</param>
        /// <param name="request">The request.</param>
        /// <param name="statement">The statement.</param>
        /// <param name="parameterObject">The parameter object.</param>
		protected virtual void ApplyParameterMap
            (IDbProvider dbProvider, IDbCommand command,
			RequestScope request, IStatement statement, object parameterObject )
		{
			StringCollection properties = request.PreparedStatement.DbParametersName;
            IDbDataParameter[] parameters = request.PreparedStatement.DbParameters;
            StringBuilder paramLogList = new StringBuilder(); // Log info
            StringBuilder typeLogList = new StringBuilder(); // Log info

			int count = properties.Count;

            for ( int i = 0; i < count; ++i )
			{
                IDbDataParameter sqlParameter = parameters[i];
                IDbDataParameter parameterCopy = command.CreateParameter();
				ParameterProperty property = request.ParameterMap.GetProperty(i);

				#region Logging
				if (log.IsDebugEnabled)
				{
                    paramLogList.Append(sqlParameter.ParameterName);
                    paramLogList.Append("=[");
                    typeLogList.Append(sqlParameter.ParameterName);
                    typeLogList.Append("=[");
				}
				#endregion

				if (command.CommandType == CommandType.StoredProcedure)
				{
					#region store procedure command

					// A store procedure must always use a ParameterMap 
					// to indicate the mapping order of the properties to the columns
					if (request.ParameterMap == null) // Inline Parameters
					{
						throw new DataMapperException("A procedure statement tag must alway have a parameterMap attribute, which is not the case for the procedure '"+statement.Id+"'."); 
					}
					// Parameters via ParameterMap
					if (property.DirectionAttribute.Length == 0)
					{
						property.Direction = sqlParameter.Direction;
					}

					sqlParameter.Direction = property.Direction;					
					#endregion 
				}

				#region Logging
				if (log.IsDebugEnabled)
				{
                    paramLogList.Append(property.PropertyName);
                    paramLogList.Append(",");
				}
				#endregion 					

				request.ParameterMap.SetParameter(property, parameterCopy, parameterObject );

				parameterCopy.Direction = sqlParameter.Direction;

				// With a ParameterMap, we could specify the ParameterDbTypeProperty
				if (request.ParameterMap != null)
				{
                    if (!string.IsNullOrEmpty(property.DbType))
					{
                        string dbTypePropertyName = dbProvider.ParameterDbTypeProperty;
						object propertyValue = ObjectProbe.GetMemberValue(sqlParameter, dbTypePropertyName, request.DataExchangeFactory.AccessorFactory);
						ObjectProbe.SetMemberValue(parameterCopy, dbTypePropertyName, propertyValue, 
							request.DataExchangeFactory.ObjectFactory, request.DataExchangeFactory.AccessorFactory);
					}
				}

			    #region Logging
				if (log.IsDebugEnabled)
				{
					if (parameterCopy.Value == DBNull.Value) 
					{
                        paramLogList.Append("null");
                        paramLogList.Append("], ");
                        typeLogList.Append("System.DBNull, null");
                        typeLogList.Append("], ");
					} 
					else 
					{

                        paramLogList.Append(parameterCopy.Value.ToString());
                        paramLogList.Append("], ");

						// sqlParameter.DbType could be null (as with Npgsql)
						// if PreparedStatementFactory did not find a dbType for the parameter in:
						// line 225: "if (property.DbType.Length >0)"
						// Use parameterCopy.DbType

						//typeLogList.Append( sqlParameter.DbType.ToString() );
                        typeLogList.Append(parameterCopy.DbType.ToString());
                        typeLogList.Append(", ");
                        typeLogList.Append(parameterCopy.Value.GetType().ToString());
                        typeLogList.Append("], ");
					}
				}
				#endregion 

                ApplyDbProviderParameterSettings(dbProvider, sqlParameter, parameterCopy);

				parameterCopy.ParameterName = sqlParameter.ParameterName;

				command.Parameters.Add( parameterCopy );
			}

			#region Logging

			if (log.IsDebugEnabled && properties.Count>0)
			{
                log.Debug("Statement Id: [" + statement.Id + "] Parameters: [" + paramLogList.ToString(0, paramLogList.Length - 2) + "]");
                log.Debug("Statement Id: [" + statement.Id + "] Types: [" + typeLogList.ToString(0, typeLogList.Length - 2) + "]");
			}
			#endregion 
		}

        /// <summary>
        /// Applies IDbProvider specific settings to the dbParameter by first checking values on the templateParameter.
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="templateParameter">source</param>
        /// <param name="dbParameter">destination</param>
        protected virtual void ApplyDbProviderParameterSettings(IDbProvider dbProvider, IDbDataParameter templateParameter, IDbDataParameter dbParameter)
        {
            // JIRA-49 Fixes (size, precision, and scale)
            if (dbProvider.SetDbParameterSize)
            {
                if (templateParameter.Size > 0)
                {
                    dbParameter.Size = templateParameter.Size;
                }
            }

            if (dbProvider.SetDbParameterPrecision)
            {
                dbParameter.Precision = templateParameter.Precision;
            }

            if (dbProvider.SetDbParameterScale)
            {
                dbParameter.Scale = templateParameter.Scale;
            }
        }
	}
}
