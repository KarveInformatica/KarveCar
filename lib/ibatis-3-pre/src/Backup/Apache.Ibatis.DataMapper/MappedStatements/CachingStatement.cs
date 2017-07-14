#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 587946 $
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

#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Events;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Session;

#endregion 

namespace Apache.Ibatis.DataMapper.MappedStatements
{
	/// <summary>
    /// Acts as a decorator arounf an <see cref="IMappedStatement"/> to add cache functionality
	/// </summary>
    [DebuggerDisplay("MappedStatement: {mappedStatement.Id}")]
    public sealed class CachingStatement : MappedStatementEventSupport, IMappedStatement
	{
        // Func<T1, T2, T3, T4, T5, TResult>
        delegate T RequestRunner<T>(RequestScope requestScope, ISession session, object parameter, CacheKey cacheKey, out bool cacheHit);

        private readonly MappedStatement mappedStatement;

		/// <summary>
        /// Event launch on Execute query
		/// </summary>
        public event EventHandler<ExecuteEventArgs> Executed = delegate { };

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="statement"></param>
        public CachingStatement(MappedStatement statement) 
		{
			mappedStatement = statement;
		}

		#region IMappedStatement Members

		/// <summary>
		/// The IPreparedCommand to use
		/// </summary>
		public IPreparedCommand PreparedCommand
		{
			get { return mappedStatement.PreparedCommand; }
		}

		/// <summary>
		/// Name used to identify the MappedStatement amongst the others.
		/// This the name of the SQL statment by default.
		/// </summary>
		public string Id
		{
			get { return mappedStatement.Id; }
		}

		/// <summary>
		/// The SQL statment used by this MappedStatement
		/// </summary>
		public IStatement Statement
		{
			get { return mappedStatement.Statement; }
		}

        /// <summary>
        /// The <see cref="IModelStore"/> used by this MappedStatement
        /// </summary>
        /// <value>The model store.</value>
        public IModelStore ModelStore
		{
            get { return mappedStatement.ModelStore; }
		}

        /// <summary>
        /// Executes an SQL statement that returns DataTable.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>The object</returns>
        public DataTable ExecuteQueryForDataTable(ISession session, object parameterObject)
        {
            RequestRunner<DataTable> requestRunner = delegate(RequestScope requestscope, ISession session2, object parameter, CacheKey cachekey, out bool cachehit)
            {
                cachehit = true;
                DataTable dataTable = Statement.CacheModel[cachekey] as DataTable;
                if (dataTable == null)
                {
                    cachehit = false;
                    dataTable = mappedStatement.RunQueryForDataTable(requestscope, session, parameter);
                    Statement.CacheModel[cachekey] = dataTable;
                }

                return dataTable;
            };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForDataTable", requestRunner);
        }

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
		public IDictionary ExecuteQueryForMap(ISession session, object parameterObject, string keyProperty, string valueProperty)
		{
            // this doesn't need to be in its own RunQueryForCachedMap method because the class is sealed and can't be called by anyone else
            RequestRunner<IDictionary> requestRunner = delegate(RequestScope requestscope, ISession session2, object parameter, CacheKey cachekey, out bool cachehit)
               {
                   if (keyProperty != null)
                   {
                       cachekey.Update(keyProperty);
                   }
                   if (valueProperty != null)
                   {
                       cachekey.Update(valueProperty);
                   }

                   cachehit = true;
                   IDictionary map = Statement.CacheModel[cachekey] as IDictionary;
                   if (map == null)
                   {
                       cachehit = false;
                       map = mappedStatement.RunQueryForMap(requestscope, session, parameter, keyProperty, valueProperty, null);
                       Statement.CacheModel[cachekey] = map;
                   }

                   return map;
               };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForMap", requestRunner);
		}

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
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty)
        {
            // this doesn't need to be in its own RunQueryForCachedDictionary method because the class is sealed and can't be called by anyone else
            RequestRunner<IDictionary<K, V>> requestRunner = delegate(RequestScope requestScope, ISession session2, object parameter, CacheKey cacheKey, out bool cacheHit)
             {
                 if (keyProperty != null)
                 {
                     cacheKey.Update(keyProperty);
                 }
                 if (valueProperty != null)
                 {
                     cacheKey.Update(valueProperty);
                 }

                 cacheHit = true;
                 IDictionary<K, V> map = Statement.CacheModel[cacheKey] as IDictionary<K, V>;
                 if (map == null)
                 {
                     cacheHit = false;
                     map = mappedStatement.RunQueryForDictionary<K, V>(requestScope, session2, parameter, keyProperty, valueProperty, null);
                     Statement.CacheModel[cacheKey] = map;
                 }

                 return map;
             };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForDictionary", requestRunner);
        }

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
        /// <param name="session">The session used to execute the statement</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
        /// <param name="keyProperty">The property of the result object to be used as the key. </param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
        /// <exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        public IDictionary<K, V> ExecuteQueryForDictionary<K, V>(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate<K, V> rowDelegate)
        {
            return mappedStatement.ExecuteQueryForDictionary(session, parameterObject, keyProperty, valueProperty, rowDelegate);
        }
        #endregion
        
	    /// <summary>
		/// Execute an update statement. Also used for delete statement.
		/// Return the number of row effected.
		/// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <returns>The number of row effected.</returns>
		public int ExecuteUpdate(ISession session, object parameterObject)
		{
			return mappedStatement.ExecuteUpdate(session, parameterObject);
		}

		/// <summary>
		/// Execute an insert statement. Fill the parameter object with 
		/// the ouput parameters if any, also could return the insert generated key
		/// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
		/// <param name="session">The session</param>
		/// <param name="parameterObject">The parameter object used to fill the statement.</param>
		/// <returns>Can return the insert generated key.</returns>
		public object ExecuteInsert(ISession session, object parameterObject)
		{
			return mappedStatement.ExecuteInsert(session, parameterObject);
        }

        #region ExecuteQueryForList

        /// <summary>
		/// Executes the SQL and and fill a strongly typed collection.
		/// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="resultObject">A strongly typed collection of result objects.</param>
		public void ExecuteQueryForList(ISession session, object parameterObject, IList resultObject)
		{
			mappedStatement.ExecuteQueryForList(session, parameterObject, resultObject);
		}

        /// <summary>
        /// Executes the SQL and retuns all rows selected. 
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        public IList ExecuteQueryForList(ISession session, object parameterObject)
        {
            // this doesn't need to be in its own RunQueryForCachedList method because the class is sealed and can't be called by anyone else
            RequestRunner<IList> requestRunner = delegate(RequestScope requestScope, ISession session2, object parameter, CacheKey cacheKey, out bool cacheHit)
             {
                 cacheHit = true;
                 IList list = Statement.CacheModel[cacheKey] as IList;
                 if (list == null)
                 {
                     cacheHit = false;
                     list = mappedStatement.RunQueryForList(requestScope, session, parameter, null, null);
                     Statement.CacheModel[cacheKey] = list;
                 }
                 return list;
             };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForList", requestRunner);
        }

	    #endregion

        #region ExecuteQueryForList .NET 2.0

        /// <summary>
        /// Executes the SQL and and fill a strongly typed collection.
        /// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">A strongly typed collection of result objects.</param>
        public void ExecuteQueryForList<T>(ISession session, object parameterObject, IList<T> resultObject)
        {
            mappedStatement.ExecuteQueryForList(session, parameterObject, resultObject);
        }

        /// <summary>
        /// Executes the SQL and retuns all rows selected. 
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        public IList<T> ExecuteQueryForList<T>(ISession session, object parameterObject)
        {
            // this doesn't need to be in its own RunQueryForCachedList method because the class is sealed and can't be called by anyone else
            RequestRunner<IList<T>> requestRunner = delegate(RequestScope requestScope, ISession session2, object parameter, CacheKey cacheKey, out bool cacheHit)
            {
                cacheHit = true;
                IList<T> list = Statement.CacheModel[cacheKey] as IList<T>;
                if (list == null)
                {
                    cacheHit = false;
                    list = mappedStatement.RunQueryForList<T>(requestScope, session, parameter, null, null);
                    Statement.CacheModel[cacheKey] = list;
                }
                return list;
            };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForList", requestRunner);
        }
       
        #endregion

        #region ExecuteQueryForObject

		/// <summary>
		/// Executes an SQL statement that returns a single row as an Object of the type of
		/// the resultObject passed in as a parameter.
		/// </summary>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="resultObject">The result object.</param>
		/// <returns>The object</returns>
		public object ExecuteQueryForObject(ISession session, object parameterObject, object resultObject)
		{
            // this doesn't need to be in its own RunQueryForCachedObject method because the class is sealed and can't be called by anyone else
            RequestRunner<object> requestRunner = delegate(RequestScope requestScope, ISession session2, object parameter, CacheKey cacheKey, out bool cacheHit)
            {
                cacheHit = true;
                object obj = Statement.CacheModel[cacheKey];
                // check if this query has alreay been run 
                if (obj == CacheModel.NULL_OBJECT)
                {
                    // convert the marker object back into a null value 
                    obj = null;
                }
                else if (obj == null)
                {
                    cacheHit = false;
                    obj = mappedStatement.RunQueryForObject(requestScope, session, parameter, resultObject);
                    Statement.CacheModel[cacheKey] = obj;
                }
                return obj;
            };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForObject", requestRunner);
        }
        
        #endregion

        #region ExecuteQueryForObject .NET 2.0

        /// <summary>
        /// Executes an SQL statement that returns a single row as an Object of the type of
        /// the resultObject passed in as a parameter.
        /// </summary>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The object</returns>
        public T ExecuteQueryForObject<T>(ISession session, object parameterObject, T resultObject)
        {
            // this doesn't need to be in its own RunQueryForCachedObject method because the class is sealed and can't be called by anyone else
            RequestRunner<T> requestRunner = delegate(RequestScope requestScope, ISession session2, object parameter, CacheKey cacheKey, out bool cacheHit)
            {
                T obj; 

                cacheHit = false;
                object cacheObjet = Statement.CacheModel[cacheKey];
                // check if this query has alreay been run 
                if (cacheObjet is T)
                {
                    cacheHit = true;
                    obj = (T)cacheObjet;
                }
                else if (cacheObjet == CacheModel.NULL_OBJECT)
                {
                    // convert the marker object back into a null value 
                    cacheHit = true;
                    obj = default(T);
                }
                else //if ((object)obj == null)
                {
                    obj = mappedStatement.RunQueryForObject(requestScope, session, parameter, resultObject);
                    Statement.CacheModel[cacheKey] = obj;
                }

                return obj;
            };

            return CachingStatementExecute(PreSelectEventKey, PostSelectEventKey, session, parameterObject, "ExecuteQueryForObject", requestRunner);
        }
        
        #endregion

        /// <summary>
		/// Runs a query with a custom object that gets a chance 
		/// to deal with each row as it is processed.
		/// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
		/// <param name="session">The session used to execute the statement.</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
		/// <param name="rowDelegate"></param>
		public IList ExecuteQueryForRowDelegate(ISession session, object parameterObject, RowDelegate rowDelegate)
		{
            // TODO: investigate allow the cached data to be processed by a different rowDelegate...add rowDelegate to the CacheKey ???
			return mappedStatement.ExecuteQueryForRowDelegate(session, parameterObject, rowDelegate);
		}

        /// <summary>
        /// Runs a query with a custom object that gets a chance 
        /// to deal with each row as it is processed.
        /// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
        /// <param name="session">The session used to execute the statement.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>
        public IList<T> ExecuteQueryForRowDelegate<T>(ISession session, object parameterObject, RowDelegate<T> rowDelegate)
        {
            // TODO: investigate allow the cached data to be processed by a different rowDelegate...add rowDelegate to the CacheKey ???
            return mappedStatement.ExecuteQueryForRowDelegate(session, parameterObject, rowDelegate);
        }

		/// <summary>
		/// Runs a query with a custom object that gets a chance 
		/// to deal with each row as it is processed.
		/// </summary>
        /// <remarks>
        /// This method always bypasses the cache.
        /// </remarks>
		/// <param name="session">The session used to execute the statement</param>
		/// <param name="parameterObject">The object used to set the parameters in the SQL. </param>
		/// <param name="keyProperty">The property of the result object to be used as the key. </param>
		/// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
		/// <param name="rowDelegate"></param>
		/// <returns>A hashtable of object containing the rows keyed by keyProperty.</returns>
		/// <exception cref="Apache.Ibatis.DataMapper.Exceptions.DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
		public IDictionary ExecuteQueryForMapWithRowDelegate(ISession session, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate rowDelegate)
		{
            // TODO: investigate allow the cached data to be processed by a different rowDelegate...add rowDelegate to the CacheKey ???
			return mappedStatement.ExecuteQueryForMapWithRowDelegate(session, parameterObject, keyProperty, valueProperty, rowDelegate);
		}

		#endregion

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the cache key</returns>
		private CacheKey GetCacheKey(RequestScope request) 
		{
			CacheKey cacheKey = new CacheKey();
			int count = request.IDbCommand.Parameters.Count;
			for (int i = 0; i < count; i++) 
			{
				IDataParameter dataParameter = (IDataParameter)request.IDbCommand.Parameters[i];
				if (dataParameter.Value != null) 
				{
					cacheKey.Update( dataParameter.Value );
				}
			}
			
			cacheKey.Update(mappedStatement.Id);
            cacheKey.Update(mappedStatement.ModelStore.SessionFactory.DataSource.ConnectionString);
			cacheKey.Update(request.IDbCommand.CommandText);

            //todo a supprimer
            //CacheModel cacheModel = mappedStatement.Statement.CacheModel;
            //if (!cacheModel.IsReadOnly && !cacheModel.IsSerializable) 
            //{
			//	cacheKey.Update(request);
            //}
			return cacheKey;
		}

        /// <summary>
        /// Ensures all the related Execute methods are run in a consistent manner with pre and post events.
        /// </summary>
        /// <remarks>
        /// Based off of MappedStatement.Execute
        /// </remarks>
        private T CachingStatementExecute<T>(object preEvent, object postEvent, ISession session, object parameterObject, string baseCacheKey, RequestRunner<T> requestRunner)
        {
            object paramPreEvent = RaisePreEvent(preEvent, parameterObject);

            RequestScope requestScope = Statement.Sql.GetRequestScope(this, paramPreEvent, session);
            mappedStatement.PreparedCommand.Create(requestScope, session, Statement, paramPreEvent);

            CacheKey cacheKey = GetCacheKey(requestScope);
            cacheKey.Update(baseCacheKey);

            bool cacheHit;
            T result = requestRunner(requestScope, session, paramPreEvent, cacheKey, out cacheHit);

            return RaisePostEvent(postEvent, paramPreEvent, result, cacheHit);
        }
    }
}
