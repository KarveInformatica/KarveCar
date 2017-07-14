
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 515691 $
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

using System;
using System.Data;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Session.Transaction;

namespace Apache.Ibatis.DataMapper.Session
{
    /// <summary>
    /// Default implementation of the <see cref="ISession"/> contract. 
    /// </summary>
    [DebuggerDisplay("DataMapperSession: {Connection}")]
    public class DataMapperSession : ISession
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [NonSerialized]
        private readonly ISessionFactory sessionFactory = null;
        [NonSerialized]
        private readonly ITransactionManager transactionManager = null;
        [NonSerialized]
        private IDbConnection connection = null;
        [NonSerialized]
        private readonly bool autoClose = false;
        [NonSerialized]
        private ITransaction transaction = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMapperSession"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="autoClose">if set to <c>true</c> [auto close].</param>
        public DataMapperSession(
            IDbConnection connection, 
            ISessionFactory factory, 
            ITransactionManager transactionManager,
            bool autoClose)
		{
            Contract.Require.That(connection, Is.Not.Null).When("retrieving argument connection in DataMapperSession constructor");
            Contract.Require.That(factory, Is.Not.Null).When("retrieving argument factory in DataMapperSession constructor");

            this.connection = connection;
            sessionFactory = factory;
            this.transactionManager = transactionManager;
            this.autoClose = autoClose;
        }

        #region ISession Members

        /// <summary>
        /// Get the <see cref="ISessionFactory"/> that created this instance.
        /// </summary>
        /// <value></value>
        public ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
        }

        /// <summary>
        /// Gets the ADO.NET connection.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// Applications are responsible for calling commit/rollback upon the connection before
        /// closing the <c>ISession</c>.
        /// </remarks>
        public IDbConnection Connection
        {
            get { return connection; }
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns>The connection provided by the DataMapper</returns>
        public IDbConnection OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug(string.Format("Open Connection \"{0}\" to \"{1}\".", connection.GetHashCode(), sessionFactory.DataSource.DbProvider.Description));
                    }
                }
                catch (Exception ex)
                {
                    throw new DataMapperException(string.Format("Unable to open connection to \"{0}\".", sessionFactory.DataSource.DbProvider.Description), ex);
                }
            }
            return connection;
        }

        /// <summary>
        /// End the <c>ISession</c> by disconnecting from the ADO.NET connection and cleaning up.
        /// </summary>
        /// <returns>
        /// The connection provided by the DataMapper or <see langword="null"/>
        /// </returns>
        public IDbConnection Close()
        {
            logger.Debug("Closing session");

            try
            {
                sessionFactory.Dispose();
                if (connection == null)
                {
                    return null;
                }
                else
                {
                    // get a new reference to the the Session's connection before 
                    // closing it - and set the existing to Session's connection to
                    // null but don't close it yet
                    IDbConnection connectionRef = connection;
                    connection = null;

                    // if Session is supposed to auto-close the connection then
                    // the Sesssion is managing the IDbConnection. 
                    if (autoClose)
                    {
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug(string.Format("Close Connection \"{0}\" to \"{1}\".", connectionRef.GetHashCode(), sessionFactory.DataSource.DbProvider.Description));
                        }                       
                        connectionRef.Close();
                        connectionRef.Dispose();

                        return null;
                    }
                    else
                    {
                        return connectionRef;
                    }
                }
            }
            finally
            {}
        }

        /// <summary>
        /// Begin a unit of work and return the associated <c>ITransaction</c> object.
        /// </summary>
        /// <returns>A transaction instance</returns>
        public ITransaction BeginTransaction()
        {
            transaction = transactionManager.BeginTransaction(this);
            //isCurrentTransaction = true;
            return transaction;
        }

        /// <summary>
        /// Begin a transaction with the specified <c>isolationLevel</c>
        /// </summary>
        /// <param name="isolationLevel">Isolation level for the new transaction</param>
        /// <returns>
        /// A transaction instance having the specified isolation level
        /// </returns>
        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            transaction = transactionManager.BeginTransaction(this, isolationLevel);
            //isCurrentTransaction = true;
            return transaction;
        }

        /// <summary>
        /// Get the current associated <c>ITransaction</c> object.
        /// </summary>
        /// <value></value>
        public ITransaction Transaction
        {
            get { return transaction; }
        }

        #endregion


        #region IDisposable Members

        /// <summary>
		/// A flag to indicate if <c>Disose()</c> has been called.
		/// </summary>
		private bool isAlreadyDisposed = false;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DataMapperSession"/> is reclaimed by garbage collection.
        /// </summary>
	    ~DataMapperSession()
	    {
		    Dispose( false );
	    }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
	    public void Dispose()
	    {
		    logger.Debug( "running ISession.Dispose()" );
		    Dispose( true );
	    }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool isDisposing)
        {
		    if( isAlreadyDisposed )
		    {
			    // don't dispose of multiple times.
			    return;
		    }

		    // free managed resources that are being managed by the session if we
		    // know this call came through Dispose()
		    if( isDisposing )
		    {
			    if( transaction != null )
			    {
				    transaction.Dispose();
			    }

                Close();
		    }

		    isAlreadyDisposed = true;
		    // nothing for Finalizer to do - so tell the GC to ignore it
		    GC.SuppressFinalize( this );
        }

        #endregion
    }
}
