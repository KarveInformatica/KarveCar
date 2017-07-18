
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 513043 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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
using System;
using Apache.Ibatis.DataMapper.Session.Transaction;

namespace Apache.Ibatis.DataMapper.Session
{
    /// <summary>
    /// The DataMapper Session contract
    /// </summary>
    public interface ISession : IDisposable
    {
        /// <summary>
        /// Get the <see cref="ISessionFactory" /> that created this instance.
        /// </summary>
        ISessionFactory SessionFactory { get; }
        
        /// <summary>
        /// Gets the ADO.NET connection.
        /// </summary>
        /// <remarks>
        /// Applications are responsible for calling commit/rollback upon the connection before
        /// closing the <c>ISession</c>.
        /// </remarks>
        IDbConnection Connection { get; }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns>The connection provided by the DataMapper</returns>
        IDbConnection OpenConnection();

        /// <summary>
        /// End the <c>ISession</c> by disconnecting from the ADO.NET connection and cleaning up.
        /// </summary>
        /// <returns>The connection provided by the DataMapper or <see langword="null" /></returns>
        IDbConnection Close();

        /// <summary>
        /// Begin a unit of work and return the associated <c>ITransaction</c> object.
        /// </summary>
        /// <returns>A transaction instance</returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Begin a transaction with the specified <c>isolationLevel</c>
        /// </summary>
        /// <param name="isolationLevel">Isolation level for the new transaction</param>
        /// <returns>A transaction instance having the specified isolation level</returns>
        ITransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Get the current associated <c>ITransaction</c> object.
        /// </summary>
        ITransaction Transaction { get; }
    }
}
