
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
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Session.Transaction;

namespace Apache.Ibatis.DataMapper.Session
{
    /// <summary>
    /// Default implementation of the <see cref="ISessionFactory"/> contract. 
    /// Create <see cref="ISession" /> instance.
    /// </summary>
    public class DefaultSessionFactory : ISessionFactory
    {
        [NonSerialized]
        private IDataSource dataSource = null;
        [NonSerialized]
        private readonly ISessionStore sessionStore = null;
        private readonly ITransactionManager transactionManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSessionFactory"/> class.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="sessionStore">The session store.</param>
        /// <param name="transactionManager">The transaction manager.</param>
        public DefaultSessionFactory(IDataSource dataSource, ISessionStore sessionStore, ITransactionManager transactionManager)
		{
            Contract.Require.That(dataSource, Is.Not.Null).When("retrieving argument dataSource in DefaultSessionFactory constructor.");
            Contract.Require.That(sessionStore, Is.Not.Null).When("retrieving argument sessionStore in DefaultSessionFactory constructor.");
            Contract.Require.That(transactionManager, Is.Not.Null).When("retrieving argument transactionManager in DefaultSessionFactory constructor.");

            this.dataSource = dataSource;
            this.sessionStore = sessionStore;
            this.transactionManager = transactionManager;
        }

        #region ISessionFactory Members

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public virtual IDataSource DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }


        /// <summary>
        /// Open a <c>ISession</c> on the given connection
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="autoClose">if set to <c>true</c> [auto close].</param>
        /// <returns>A session</returns>
        /// <remarks>
        /// The <c>ISession</c> is save in the <see cref="ISessionStore"/>
        /// </remarks>
        public ISession OpenSession(IDbConnection connection, bool autoClose)
        {
            ISession session = new DataMapperSession(connection, this, transactionManager, autoClose);

            sessionStore.Store(session);
            return session;
        }

        /// <summary>
        /// Create a database connection and open a <c>ISession</c> on it.
        /// </summary>
        /// <returns>A session</returns>
        /// <remarks>
        /// The <c>ISession</c> is save in the <see cref="ISessionStore"/>
        /// </remarks>
        public ISession OpenSession()
        {
            IDbConnection connection = dataSource.DbProvider.CreateConnection();
            connection.ConnectionString = dataSource.ConnectionString;
            return OpenSession(connection, true);
        }

        /// <summary>
        /// Remove the specified session from the <see cref="ISessionStore"/>
        /// </summary>
        public void Dispose()
        {
            sessionStore.Dispose();
        }

        ///// <summary>
        ///// Gets the transaction manager.
        ///// </summary>
        ///// <value>The transaction manager.</value>
        //public ITransactionManager TransactionManager
        //{
        //    get { throw new Exception("The method or operation is not implemented."); }
        //}

        #endregion
    }
}
