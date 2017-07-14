#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 378715 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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

using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Apache.Ibatis.DataMapper.Session.Stores

{
    /// <summary>
    /// This implementation of <see cref="ISessionStore"/>will first try 
    /// to get the currentrequest, and if not found, will use a thread local.
    /// </summary>
    /// <remarks>
    /// This is used for scenarios where most of the you need per request session, but you also does some work outside a 
    /// request (in a thread pool thread, for instance).
    /// </remarks>
    public class HybridWebThreadSessionStore : AbstractSessionStore
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSessionStore"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public HybridWebThreadSessionStore(string id)
            : base(id)
		{}

		/// <summary>
		/// Get the local session
		/// </summary>
        public override ISession CurrentSession
		{
			get
			{
                HttpContext currentContext = HttpContext.Current;
                if (currentContext == null)
                {
                    return (ISession)CallContext.GetData(sessionName); 
                }
                return (ISession)currentContext.Items[sessionName];
			}
		}

		/// <summary>
		/// Store the specified session.
		/// </summary>
		/// <param name="session">The session to store</param>
        public override void Store(ISession session)
		{
            HttpContext currentContext = HttpContext.Current;
            if (currentContext == null)
            {
                CallContext.SetData(sessionName, session);
            }
		    else
            {
                currentContext.Items[sessionName] = session;
            }
		}

		/// <summary>
		/// Remove the local session.
		/// </summary>
		public override void Dispose()
		{
            HttpContext currentContext = HttpContext.Current;
            if (currentContext == null)
            {
                CallContext.SetData(sessionName, null);
            }
		    else
            {
 			    currentContext.Items.Remove(sessionName);
            }
		}


	}
}
