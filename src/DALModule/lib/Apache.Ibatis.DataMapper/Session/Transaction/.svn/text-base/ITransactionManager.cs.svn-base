
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

namespace Apache.Ibatis.DataMapper.Session.Transaction
{
    /// <summary>
    /// The <c>TransactionManager</c> interface defines the methods to manage transaction boundaries. 
    /// </summary>
    public interface ITransactionManager
    {
        /// <summary>
        /// Begin a transaction and return the associated <c>ITransaction</c> instance
        /// </summary>
        /// <param name="session"></param>
        ITransaction BeginTransaction(ISession session);

        /// <summary>
        /// Begin a transaction with the specified isolation level and return
        /// the associated <c>ITransaction</c> instance
        /// </summary>
        /// <param name="session"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        ITransaction BeginTransaction(ISession session, IsolationLevel isolationLevel);
    }
}
