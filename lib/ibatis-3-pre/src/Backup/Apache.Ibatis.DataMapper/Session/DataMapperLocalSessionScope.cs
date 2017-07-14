
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 513043 $
 * $Date: 2009-06-13 20:01:00 -0600 (Sat, 13 Jun 2009) $
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
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.Session
{
    /// <summary>
    /// Local SessionScope management
    /// </summary>
    public class DataMapperLocalSessionScope : IDisposable
    {
        private readonly bool isSessionLocal = false;
        private readonly ISession session = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMapperLocalSessionScope"/> class.
        /// </summary>
        /// <param name="sessionStore">The session store.</param>
        /// <param name="sessionFactory">The session factory.</param>
        public DataMapperLocalSessionScope(ISessionStore sessionStore, ISessionFactory sessionFactory)
        {
            isSessionLocal = false;
            session = sessionStore.CurrentSession;

            if (session == null)
            {
                session = sessionFactory.OpenSession();
                isSessionLocal = true;
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <value>The session.</value>
        public ISession Session
        {
            get { return session; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (isSessionLocal)
            {
                session.Close();
            }
        }
    }
}
