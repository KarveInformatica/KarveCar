#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 378715 $
 * $Date: 2008-09-21 13:25:16 -0600 (Sun, 21 Sep 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - Apache Fondation
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

namespace Apache.Ibatis.DataMapper.Session.Stores

{
	/// <summary>
	/// Base class for session store
	/// </summary>
	public abstract class AbstractSessionStore  : MarshalByRefObject, ISessionStore
	{
        const string KEY = "_IBATIS_LOCAL_SQLMAP_SESSION_";
        /// <summary>
        /// session name
        /// </summary>	    
		protected string sessionName = string.Empty;


        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSessionStore"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        protected AbstractSessionStore(string id)
		{
            sessionName = KEY + id;
		}

		/// <summary>
		/// Get the local session
		/// </summary>
        public abstract ISession CurrentSession
		{
			get; 
		}


        /// <summary>
        /// Store the specified session.
        /// </summary>
        /// <param name="session">The session to store</param>
        public abstract void Store(ISession session);

		/// <summary>
		/// Remove the local session from the storage.
		/// </summary>
        public abstract void Dispose();
	}
}
