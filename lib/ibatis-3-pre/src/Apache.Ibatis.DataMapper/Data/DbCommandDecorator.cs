#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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
using System.Data;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.Data
{
    /// <summary>
    /// Decorate an <see cref="System.Data.IDbCommand"></see>
    /// to auto move to next ResultMap on ExecuteReader call. 
    /// </summary>
    public sealed class DbCommandDecorator : IDbCommand
    {
        private readonly IDbCommand innerDbCommand = null;
        private readonly RequestScope request = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbCommandDecorator"/> class.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="request">The request scope</param>
        public DbCommandDecorator(IDbCommand dbCommand, RequestScope request)
        {
            this.request = request;
            innerDbCommand = dbCommand;
        }


        #region IDbCommand Members

        /// <summary>
        /// Attempts to cancels the execution of an <see cref="System.Data.IDbCommand"></see>.
        /// </summary>
        void IDbCommand.Cancel()
        {
            innerDbCommand.Cancel();
        }

        /// <summary>
        /// Gets or sets the text command to run against the data source.
        /// </summary>
        /// <value></value>
        /// <returns>The text command to execute. The default value is an empty string ("").</returns>
        string IDbCommand.CommandText
        {
            get { return innerDbCommand.CommandText; }
            set {  innerDbCommand.CommandText = value; }
        }

        /// <summary>
        /// Gets or sets the wait time before terminating the attempt to execute a command and generating an error.
        /// </summary>
        /// <value></value>
        /// <returns>The time (in seconds) to wait for the command to execute. The default value is 30 seconds.</returns>
        /// <exception cref="System.ArgumentException">The property value assigned is less than 0. </exception>
        int IDbCommand.CommandTimeout
        {
            get { return innerDbCommand.CommandTimeout; }
            set { innerDbCommand.CommandTimeout = value; }
        }

        /// <summary>
        /// Indicates or specifies how the <see cref="P:System.Data.IDbCommand.CommandText"></see> property is interpreted.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="System.Data.CommandType"></see> values. The default is Text.</returns>
        CommandType IDbCommand.CommandType
        {
            get { return innerDbCommand.CommandType; }
            set { innerDbCommand.CommandType = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Data.IDbConnection"></see> used by this instance of the <see cref="System.Data.IDbCommand"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The connection to the data source.</returns>
        IDbConnection IDbCommand.Connection
        {
            get { return innerDbCommand.Connection; }
            set { innerDbCommand.Connection = value; }
        }

        /// <summary>
        /// Creates a new instance of an <see cref="System.Data.IDbDataParameter"></see> object.
        /// </summary>
        /// <returns>An IDbDataParameter object.</returns>
        IDbDataParameter IDbCommand.CreateParameter()
        {
            return innerDbCommand.CreateParameter();
        }

        /// <summary>
        /// Executes an SQL statement against the Connection object of a .NET Framework data provider, and returns the number of rows affected.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="T:System.InvalidOperationException">The connection does not exist.-or- The connection is not open. </exception>
        int IDbCommand.ExecuteNonQuery()
        {
            request.Session.OpenConnection();
            return innerDbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes the <see cref="P:System.Data.IDbCommand.CommandText"></see> against the <see cref="P:System.Data.IDbCommand.Connection"></see>, and builds an <see cref="System.Data.IDataReader"></see> using one of the <see cref="System.Data.CommandBehavior"></see> values.
        /// </summary>
        /// <param name="behavior">One of the <see cref="System.Data.CommandBehavior"></see> values.</param>
        /// <returns>
        /// An <see cref="System.Data.IDataReader"></see> object.
        /// </returns>
        IDataReader IDbCommand.ExecuteReader(CommandBehavior behavior)
        {
            request.Session.OpenConnection();
            return innerDbCommand.ExecuteReader(behavior);
        }

        /// <summary>
        /// Executes the <see cref="P:System.Data.IDbCommand.CommandText"></see> against the <see cref="P:System.Data.IDbCommand.Connection"></see> and builds an <see cref="System.Data.IDataReader"></see>.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Data.IDataReader"></see> object.
        /// </returns>
        IDataReader IDbCommand.ExecuteReader()
        {
            request.Session.OpenConnection();
            request.MoveNextResultMap();
            return new DataReaderDecorator(innerDbCommand.ExecuteReader(), request);
            
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.
        /// </summary>
        /// <returns>
        /// The first column of the first row in the resultset.
        /// </returns>
        object IDbCommand.ExecuteScalar()
        {
            request.Session.OpenConnection();
            return innerDbCommand.ExecuteScalar();
        }

        /// <summary>
        /// Gets the <see cref="System.Data.IDataParameterCollection"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The parameters of the SQL statement or stored procedure.</returns>
        IDataParameterCollection IDbCommand.Parameters
        {
            get { return innerDbCommand.Parameters; }
        }

        /// <summary>
        /// Creates a prepared (or compiled) version of the command on the data source.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The <see cref="P:System.Data.OleDb.OleDbCommand.Connection"></see> is not set.-or- The <see cref="System.Data.OleDb.OleDbCommand.Connection"></see> is not <see cref="System.Data.OleDb.OleDbConnection.Open"></see>. </exception>
        void IDbCommand.Prepare()
        {
            innerDbCommand.Prepare();
        }

        /// <summary>
        /// Gets or sets the transaction within which the Command object of a .NET Framework data provider executes.
        /// </summary>
        /// <value></value>
        /// <returns>the Command object of a .NET Framework data provider executes. The default value is null.</returns>
        IDbTransaction IDbCommand.Transaction
        {
            get { return innerDbCommand.Transaction; }
            set { innerDbCommand.Transaction = value; }
        }

        /// <summary>
        /// Gets or sets how command results are applied to the <see cref="System.Data.DataRow"></see> when used by the <see cref="M:System.Data.IDataAdapter.Update(System.Data.DataSet)"></see> method of a <see cref="System.Data.Common.DbDataAdapter"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="System.Data.UpdateRowSource"></see> values. The default is Both unless the command is automatically generated. Then the default is None.</returns>
        /// <exception cref="System.ArgumentException">The value entered was not one of the <see cref="System.Data.UpdateRowSource"></see> values. </exception>
        UpdateRowSource IDbCommand.UpdatedRowSource
        {
            get { return innerDbCommand.UpdatedRowSource; }
            set { innerDbCommand.UpdatedRowSource = value; }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
           innerDbCommand.Dispose();
        }

        #endregion
    }
}
