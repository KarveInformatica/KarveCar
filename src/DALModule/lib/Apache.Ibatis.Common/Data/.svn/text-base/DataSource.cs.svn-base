
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
 * $LastChangedDate: 2008-09-21 10:29:40 -0600 (Sun, 21 Sep 2008) $
 * $LastChangedBy: gbayon $
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

#region Using

using System;
using Apache.Ibatis.Common.Contracts;
using System.Diagnostics;

#endregion

namespace Apache.Ibatis.Common.Data
{
	/// <summary>
	/// Information about a data source.
	/// </summary>
	[Serializable]
    [DebuggerDisplay("DataSource: {Id}-{ConnectionString}")]
	public class DataSource : IDataSource
	{
		[NonSerialized]
		private string connectionString = string.Empty;
		[NonSerialized]
		private IDbProvider provider = null;
		[NonSerialized]
        private readonly string id = string.Empty;
        private readonly int commandTimeout;

		#region Properties

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public virtual string ConnectionString
		{
			get { return connectionString; }
            set { connectionString = value; }
		}

		/// <summary>
		/// DataSource Name
		/// </summary>
        public string Id
		{
            get { return id; }
		}

        /// <summary>
        /// Gets the command timeout.
        /// </summary>
        /// <value>The command timeout.</value>
        public int CommandTimeout
        {
            get { return commandTimeout; }
        }

        /// <summary>
        /// Gets or sets the db provider.
        /// </summary>
        /// <value>The db provider.</value>
		public virtual IDbProvider DbProvider
		{
			get { return provider; }
            set { provider = value; }
		}
		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="provider">The provider.</param>
        public DataSource(string id, string connectionString, int commandTimeout, IDbProvider provider)
        {
            Contract.Require.That(connectionString, Is.Not.Null & Is.Not.Empty).When("retrieving argument connectionString in DataSource constructor");
            Contract.Require.That(provider, Is.Not.Null).When("retrieving argument provider in DataSource constructor");

            this.id = id;
            this.connectionString = connectionString;
            this.provider = provider;
            this.commandTimeout = commandTimeout;
        }


		/// <summary>
		/// ToString implementation.
		/// </summary>
		/// <returns>A string that describes the data source</returns>
		public override string ToString()
		{
			return "Source: ConnectionString : "+ connectionString;
		}

    }
}
