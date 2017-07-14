#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-09-21 10:29:40 -0600 (Sun, 21 Sep 2008) $
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

namespace Apache.Ibatis.Common.Data
{
	/// <summary>
	/// IDataSource
	/// </summary>
	public interface IDataSource
	{
		/// <summary>
		/// DataSource Name.
		/// </summary>
		string Id { get; }

        /// <summary>
        /// Gets the command timeout.
        /// </summary>
        /// <value>The command timeout.</value>
        int CommandTimeout { get; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { set; get; }

        /// <summary>
        /// Gets or sets the db provider.
        /// </summary>
        /// <value>The db provider.</value>
        IDbProvider DbProvider { set; get; }

	}
}
