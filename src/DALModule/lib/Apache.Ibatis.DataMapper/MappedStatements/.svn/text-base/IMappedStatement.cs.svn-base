
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 476843 $
 * $Date: 2009-06-28 01:03:34 -0600 (Sun, 28 Jun 2009) $
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

#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Session;
#endregion

namespace Apache.Ibatis.DataMapper.MappedStatements
{

	/// <summary>
	/// Summary description for IMappedStatement.
	/// </summary>
	public interface IMappedStatement : IMappedStatementEvents
	{

		#region Event

		/// <summary>
		/// Event launch on exceute query
		/// </summary>
        event EventHandler<ExecuteEventArgs> Executed;

		#endregion 

		#region Properties


		/// <summary>
		/// The IPreparedCommand to use
		/// </summary>
		IPreparedCommand PreparedCommand { get; }

		/// <summary>
		/// Name used to identify the MappedStatement amongst the others.
		/// This the name of the SQL statment by default.
		/// </summary>
		string Id { get; }

		/// <summary>
		/// The SQL statment used by this MappedStatement
		/// </summary>
		IStatement Statement { get; }

        /// <summary>
        /// The <see cref="IModelStore"/> used by this MappedStatement
        /// </summary>
        /// <value>The model store.</value>
        IModelStore ModelStore { get; }

		#endregion

		#region ExecuteQueryForMap

		/// <summary>
		/// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
		/// in the keyProperty parameter.  The value at each key will be the value of the property specified
		/// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
		/// </summary>
		/// <param name="session">The session used to execute the statement</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
		/// <param name="keyProperty">The property of the result object to be used as the key. </param>
		/// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
		/// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
		///<exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
		IDictionary ExecuteQueryForMap( ISession session, object parameterObject, string keyProperty, string valueProperty );

		#endregion

        #region ExecuteQueryForMap .NET 2.0

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A IDictionary of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty);

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate">A delegate called once per row in the QueryForDictionary method</param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        /// <exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate<K, V> rowDelegate);

        #endregion

		#region ExecuteUpdate

		/// <summary>
		/// Execute an update statement. Also used for delete statement.
		/// Return the number of row effected.
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <returns>The number of row effected.</returns>
		int ExecuteUpdate(ISession session, object parameterObject );

		#endregion

		#region ExecuteInsert

		/// <summary>
		/// Execute an insert statement. Fill the parameter object with 
		/// the ouput parameters if any, also could return the insert generated key
		/// </summary>
		/// <param name="session">The session</param>
		/// <param name="parameterObject">The parameter object used to fill the statement.</param>
		/// <returns>Can return the insert generated key.</returns>
		object ExecuteInsert(ISession session, object parameterObject );

		#endregion

        #region ExecuteQueryForList

		/// <summary>
		/// Executes the SQL and and fill a strongly typed collection.
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="resultObject">A strongly typed collection of result objects.</param>
		void ExecuteQueryForList(ISession session, object parameterObject, IList resultObject );

		/// <summary>
		/// Executes the SQL and retuns all rows selected. 
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <returns>A List of result objects.</returns>
		IList ExecuteQueryForList( ISession session, object parameterObject );

		#endregion

        #region ExecuteQueryForList .NET 2.0
        /// <summary>
        /// Executes the SQL and and fill a strongly typed collection.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">A strongly typed collection of result objects.</param>
        void ExecuteQueryForList<T>(ISession session, object parameterObject, IList<T> resultObject);

        /// <summary>
        /// Executes the SQL and retuns all rows selected. 
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        IList<T> ExecuteQueryForList<T>(ISession session, object parameterObject);
        #endregion

		#region ExecuteForObject


		/// <summary>
		/// Executes an SQL statement that returns a single row as an Object of the type of
		/// the resultObject passed in as a parameter.
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="resultObject">The result object.</param>
		/// <returns>The object</returns>
		object ExecuteQueryForObject( ISession session, object parameterObject, object resultObject );

		#endregion

        #region ExecuteForObject .NET 2.0

        /// <summary>
        /// Executes an SQL statement that returns a single row as an Object of the type of
        /// the resultObject passed in as a parameter.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The object</returns>
        T ExecuteQueryForObject<T>(ISession session, object parameterObject, T resultObject);

        #endregion

		#region Delegate

		/// <summary>
		/// Runs a query with a custom object that gets a chance 
		/// to deal with each row as it is processed.
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="rowDelegate"></param>param>
		/// <returns></returns>
		IList ExecuteQueryForRowDelegate( ISession session, object parameterObject, RowDelegate rowDelegate );

 
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
		/// <exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
		IDictionary ExecuteQueryForMapWithRowDelegate( ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate rowDelegate );

		#endregion 
		
        #region ExecuteQueryForRowDelegate .NET 2.0
        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>param>
        /// <returns></returns>
        IList<T> ExecuteQueryForRowDelegate<T>(ISession session, object parameterObject, RowDelegate<T> rowDelegate);
        #endregion

        #region ExecuteQueryForDataTable
        /// <summary>
        /// Executes an SQL statement that returns DataTable.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>The object</returns>
        DataTable ExecuteQueryForDataTable(ISession session, object parameterObject); 
        #endregion
    }
}
