
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 477815 $
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

#region Using

using System.Collections.Specialized;
using System.Data;

#endregion 

namespace Apache.Ibatis.DataMapper.Model.Statements
{
	/// <summary>
	/// Construct the list of IDataParameters for the statement and prepare the sql. 
    /// </summary>
    /// <remarks>
    /// This class is used as a template for filling the parameters
    /// on a real IDbCommand. The template is constructured once and its values are copied
    /// to the current command's parameter as appropriate.
    /// </remarks>
	public class PreparedStatement
	{
		#region Fields

		private string _preparedSql = string.Empty;
		private StringCollection  _dbParametersName = new StringCollection ();
		private IDbDataParameter[] _dbParameters = null;

		#endregion

		#region Properties


		/// <summary>
		/// The list of IDataParameter name used by the PreparedSql.
		/// </summary>
		public StringCollection DbParametersName
		{
			get { return _dbParametersName; }
		}

		/// <summary>
		/// The list of IDataParameter to use for the PreparedSql.
		/// </summary>
        public IDbDataParameter[] DbParameters
		{
			get { return _dbParameters;}
			set { _dbParameters =value;}
		}

		/// <summary>
		/// The prepared statement.
		/// </summary>
		public string PreparedSql
		{
			get { return _preparedSql; }
			set {_preparedSql = value;}
		}

		#endregion
	}
}
