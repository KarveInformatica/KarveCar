
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

namespace Apache.Ibatis.DataMapper.Session.Transaction
{
    /// <summary>
    /// Represents a transaction abstraction to be performed at a data source.
    /// </summary>
    /// <remarks>
    /// A transaction is associated with a <c>ISession</c> and is usually instanciated by a call to
    /// <c>ISession.BeginTransaction()</c>. 
    /// </remarks>
    public interface ITransaction : IDisposable
    {

        /// <summary>
        /// Begin the transaction with the specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">Isolation level of the transaction</param>
        void Begin(IsolationLevel isolationLevel);

        /// <summary>
        /// Flush the associated <c>ISession</c> and end the unit of work.
        /// </summary>
        /// <remarks>
        /// This method will commit the underlying transaction if and only if the transaction
        /// was initiated by this object.
        /// </remarks>
        void Commit();

        /// <summary>
        /// Force the underlying transaction to roll back.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Gets a value indicating whether this instance is started.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the <see cref="ITransaction"/> is started; otherwise, <c>false</c>.
        /// </value>
        bool IsStarted { get; }

        /// <summary>
        /// Was the transaction rolled back or set to rollback only?
        /// </summary>
        bool WasRollback { get; }

        /// <summary>
        /// Was the transaction successfully committed?
        /// </summary>
        /// <remarks>
        /// This method could return <see langword="false" /> even after successful invocation of <c>Commit()</c>
        /// </remarks>
        bool WasCommit { get; }

        /// <summary>
        /// Enlist the <see cref="IDbCommand"/> in the current Transaction.
        /// </summary>
        /// <param name="command">The <see cref="IDbCommand"/> to enlist.</param>
        /// <remarks>
        /// It is okay for this to be a no op implementation.
        /// </remarks>
        void Enlist(IDbCommand command);

        /// <summary>
        /// Indicates that all operations within the scope are completed successfully. 
        /// </summary>
        void Complete();
    }
}
