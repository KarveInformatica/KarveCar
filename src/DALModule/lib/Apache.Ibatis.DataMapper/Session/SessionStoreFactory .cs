#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 378715 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2006 - Apache Fondation
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

using Apache.Ibatis.DataMapper.Session.Stores;
namespace Apache.Ibatis.DataMapper.Session
{
	/// <summary>
	/// Build a session container for a Windows or Web context.
	/// When running in the context of a web application the session object is 
	/// stored in HttpContext items and has 'per request' lifetime.
	/// When running in the context of a windows application the session object is 
	/// stored via CallContext.
	/// </summary>
	public sealed class SessionStoreFactory
	{

        /// <summary>
        /// Gets the session store.
        /// </summary>
        /// <param name="Id">A unique id to identify the session DataMapper parent.</param>
        /// <returns></returns>
        static public ISessionStore GetSessionStore(string Id)
		{
			if (System.Web.HttpContext.Current == null)
			{
                return new CallContextSessionStore(Id);
			}
			else
			{
                return new WebSessionStore(Id);
			}
		}

	}
}

