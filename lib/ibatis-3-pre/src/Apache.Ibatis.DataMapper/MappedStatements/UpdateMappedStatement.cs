#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 476843 $
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


using System.Collections;

using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
	/// <summary>
	/// Summary description for UpdateMappedStatement.
	/// </summary>
    public sealed class UpdateMappedStatement : MappedStatement
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMappedStatement"/> class.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        /// <param name="statement">The statement.</param>
        public UpdateMappedStatement(IModelStore modelStore, IStatement statement)
            : base(modelStore, statement)
		{ }

		#region ExecuteQueryForMap

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <param name="keyProperty"></param>
		/// <param name="valueProperty"></param>
		/// <returns></returns>
        public override IDictionary ExecuteQueryForMap(ISession session, object parameterObject, string keyProperty, string valueProperty)
		{
			throw new DataMapperException("Update statements cannot be executed as a query for map.");
		}

		#endregion

		#region ExecuteInsert

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
        public override object ExecuteInsert(ISession session, object parameterObject)
		{
			throw new DataMapperException("Update statements cannot be executed as a query insert.");
		}

		#endregion

		#region ExecuteQueryForList

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <param name="resultObject"></param>
        public override void ExecuteQueryForList(ISession session, object parameterObject, IList resultObject)
		{
			throw new DataMapperException("Update statements cannot be executed as a query for list.");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
        public override IList ExecuteQueryForList(ISession session, object parameterObject)
		{
			throw new DataMapperException("Update statements cannot be executed as a query for list.");
		}

		#endregion

		#region Delegate

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <param name="rowDelegate"></param>
		/// <returns></returns>
        public override IList ExecuteQueryForRowDelegate(ISession session, object parameterObject, RowDelegate rowDelegate)
		{
			throw new DataMapperException("Update statement cannot be executed as a query for row delegate.");
		}

		/// <summary>
		/// Runs a query with a custom object that gets a chance 
		/// to deal with each row as it is processed.
		/// </summary>
		/// <param name="session">The session used to execute the statement</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
		/// <param name="keyProperty">The property of the result object to be used as the key. </param>
		/// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
		/// <param name="rowDelegate"></param>
		/// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
		///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public override IDictionary ExecuteQueryForMapWithRowDelegate(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate rowDelegate)
		{
			throw new DataMapperException("Update statement cannot be executed as a query for row delegate.");
		}
		#endregion 

		#region ExecuteForObject

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="parameterObject"></param>
		/// <param name="resultObject"></param>
		/// <returns></returns>
        public override object ExecuteQueryForObject(ISession session, object parameterObject, object resultObject)
		{
			throw new DataMapperException("Update statements cannot be executed as a query for object.");
		}

		#endregion
	}
}
