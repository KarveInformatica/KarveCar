
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 476843 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
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
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.Configuration.Sql
{
	/// <summary>
	/// Summary description for ISql.
	/// </summary>
	public interface ISql
	{

		#region Methods
		/// <summary>
		/// Builds a new <see cref="RequestScope"/> and the <see cref="IDbCommand"/> text to execute.
		/// </summary>
		/// <param name="parameterObject">
		/// The parameter object (used by DynamicSql/SimpleDynamicSql).
		/// Use to complete the sql statement.
		/// </param>
		/// <param name="session">The current session</param>
		/// <param name="mappedStatement">The <see cref="IMappedStatement"/>.</param>
		/// <returns>A new <see cref="RequestScope"/>.</returns>
		RequestScope GetRequestScope(IMappedStatement mappedStatement, object parameterObject, ISqlMapSession session);
		#endregion

	}
}
