
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 513043 $
 * $Date: 2008-09-21 13:25:16 -0600 (Sun, 21 Sep 2008) $
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


using System;
using System.Data;
using System.Reflection;

using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.DataMapper.Session.Transaction.Ado
{
    /// <summary>
    /// Implement the <see cref="ITransaction" /> interface using an ADO.NET <see cref="IDbTransaction"/>
    /// </summary>
    public class AdoTransaction : ITransaction
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ISession session = null;
        private IDbTransaction transaction = null;
        private bool wasCommit = false;
        private bool wasRollback = false;
        private bool isStarted = false;
        /// <summary>
        /// Changes the vote to commit (true) or to abort (false) in transsaction
        /// </summary>
        private bool isConsistent = false;

        /// <summary>
        /// Gets a value indicating whether this instance is started.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the <see cref="ITransaction" /> is started; otherwise, <c>false</c>.
        /// </value>
        public bool IsStarted
        {
            get { return isStarted;}
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AdoTransaction"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
		public AdoTransaction( ISession session )
		{
            Contract.Require.That(session, Is.Not.Null).When("retrieving argument session in AdoTransaction constructor.");

			this.session = session;
		}

        #region ITransaction Members

        /// <summary>
        /// Begin the transaction with the specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">Isolation level of the transaction</param>
        public void Begin(IsolationLevel isolationLevel)
        {
            logger.Debug("begin transaction");

            try
            {
                session.OpenConnection();

                //if (isolationLevel == IsolationLevel.Unspecified)
                //{
                //    isolationLevel = session.Factory.Isolation;
                //}

                if (isolationLevel == IsolationLevel.Unspecified)
                {
                    transaction = session.Connection.BeginTransaction();
                }
                else
                {
                    transaction = session.Connection.BeginTransaction(isolationLevel);
                }
            }
            catch (Exception e)
            {
                logger.Error("Begin transaction failed", e);
                throw new DataMapperException("Begin transaction failed, cause ", e);
            }
            
            wasCommit = false;
            wasRollback = false;
            isStarted = true;
        }

        /// <summary>
        /// Flush the associated <c>ISession</c> and end the unit of work.
        /// </summary>
        /// <remarks>
        /// This method will commit the underlying transaction if and only if the transaction
        /// was initiated by this object.
        /// </remarks>
        public void Commit()
        {
            if (!isStarted)
            {
                throw new DataMapperException("Transaction not successfully started");
            }

            logger.Debug("Commit transaction");

            try
            {
                transaction.Commit();
                wasCommit = true;
                Dispose();
            }
            catch (Exception e)
            {
                logger.Error("Commit failed", e);
                throw new DataMapperException("Commit failed, cause "+e.Message, e);
            }
        }

        /// <summary>
        /// Force the underlying transaction to roll back.
        /// </summary>
        public void Rollback()
        {
            if (!isStarted)
            {
                throw new DataMapperException("Transaction not successfully started");
            }

            logger.Debug("rollback");
            try
            {
                transaction.Rollback();
                wasRollback = true;
                Dispose();
            }
            catch (Exception e)
            {
                logger.Error("Rollback failed", e);
                throw new DataMapperException("Rollback failed, cause ", e);
            }
        }

        /// <summary>
        /// Was the transaction rolled back or set to rollback only?
        /// </summary>
        /// <value></value>
        public bool WasRollback
        {
            get { return wasRollback; }
        }

        /// <summary>
        /// Was the transaction successfully committed?
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This method could return <see langword="false"/> even after successful invocation of <c>Commit()</c>
        /// </remarks>
        public bool WasCommit
        {
            get { return wasCommit; }
        }

        /// <summary>
        /// Enlist the <see cref="IDbCommand"/> in the current Transaction.
        /// </summary>
        /// <param name="command">The <see cref="IDbCommand"/> to enlist.</param>
        /// <remarks>
        /// It is okay for this to be a no op implementation.
        /// </remarks>
        public void Enlist(IDbCommand command)
        {
            command.Transaction = transaction;
        }

        /// <summary>
        /// Indicates that all operations within the scope are completed successfully.
        /// </summary>
        public void Complete()
        {
            isConsistent = true;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// A flag to indicate if <c>Dispose()</c> has been called.
        /// </summary>
        private bool isAlreadyDisposed = false;

        /// <summary>
        /// Finalizer that ensures the object is correctly disposed of.
        /// </summary>
        ~AdoTransaction()
        {
            Dispose(false);
        }

        /// <summary>
        /// Takes care of freeing the managed and unmanaged resources that 
        /// this class is responsible for.
        /// </summary>
        public void Dispose()
        {
            logger.Debug("Calling AdoTransaction.Dispose()");
            Dispose(true);
        }


        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool isDisposing)
        {
            if (isAlreadyDisposed)
            {
                // don't dispose of multiple times.
                return;
            }
            if (isDisposing)
            {
                if (transaction != null)
                {
                    if (isConsistent)
                    {
                        if (!wasCommit && !wasRollback)
                        {
                            logger.Debug("Commit transaction");
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        if (!wasCommit && !wasRollback)
                        {
                            logger.Debug("Rollback transaction");
                            transaction.Rollback();
                        }
                    }
                    transaction.Dispose();
                    transaction = null;
                }
            }

            isStarted = false;
            session = null;
            isAlreadyDisposed = true;
            // nothing for Finalizer to do - so tell the GC to ignore it
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
