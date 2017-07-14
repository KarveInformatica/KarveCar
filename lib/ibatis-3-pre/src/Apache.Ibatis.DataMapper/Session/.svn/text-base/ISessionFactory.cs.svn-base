
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
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Session
{
    /// <summary>
    /// A factory for <c>ISession</c> instances.
    /// </summary>
    public interface ISessionFactory 
    {

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        IDataSource DataSource { set; get; }

        /// <summary>
        /// Open a <c>ISession</c> on the given connection
        /// </summary>
        /// <param name="conn">A connection provided by the application</param>
        /// <param name="autoClose">if set to <c>true</c> [auto close].</param>
        /// <returns>A session</returns>
        /// <remarks>
        /// The <c>ISession</c> is save in the <see cref="ISessionStore"/>
        /// </remarks>
        ISession OpenSession(IDbConnection conn, bool autoClose);

		/// <summary>
		/// Create a database connection and open a <c>ISession</c> on it.
		/// </summary>
        /// <returns>A session</returns>
        /// <remarks>
        /// The <c>ISession</c> is save in the <see cref="ISessionStore"/>
        /// </remarks>
		ISession OpenSession();

        /// <summary>
        /// Remove the specified session from the <see cref="ISessionStore"/>
        /// </summary>
        void Dispose();
    }
}
