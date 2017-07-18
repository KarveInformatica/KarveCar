
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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

using System;
using System.Data;
using System.Reflection;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.Common.Data;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.Data
{
	/// <summary>
	/// DBHelperParameterCache provides functions to leverage a 
	/// static cache of procedure parameters, and the
	/// ability to discover parameters for stored procedures at run-time.
	/// </summary>
	public sealed class DBHelperParameterCache
	{
        private readonly object syncLock = new object();
        private readonly IDictionary<string, IDataParameter[]> paramCache = new Dictionary<string, IDataParameter[]>();

		#region private methods

        /// <summary>
        /// Resolve at run time the appropriate set of Parameters for a stored procedure
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
        /// <returns></returns>
        private static IDataParameter[] DiscoverSpParameterSet(ISession session, string spName, bool includeReturnValueParameter)
		{
			return InternalDiscoverSpParameterSet(
                session,
                spName, 
                includeReturnValueParameter);	
		}


        /// <summary>
        /// Discover at run time the appropriate set of Parameters for a stored procedure
        /// </summary>
        /// <param name="session">An IDalSession object</param>
        /// <param name="?">The ?.</param>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="includeReturnValueParameter">if set to <c>true</c> [include return value parameter].</param>
        /// <returns>The stored procedure parameters.</returns>
		private static IDataParameter[] InternalDiscoverSpParameterSet(
            ISession session, 
            string spName, 
            bool includeReturnValueParameter)
		{
            IDbCommand dbCommand = session.SessionFactory.DataSource.DbProvider.CreateCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;

            using (dbCommand)
			{
                dbCommand.CommandText = spName;
                dbCommand.Connection = session.Connection;

                // Assign transaction
                if (session.Transaction != null)
                {
                    session.Transaction.Enlist(dbCommand);
                }

			    // The session connection object is always created but the connection is not alwys open
			    // so we try to open it in case.
				session.OpenConnection();

                DeriveParameters(session.SessionFactory.DataSource.DbProvider, dbCommand);

                if (dbCommand.Parameters.Count > 0)
                {
                    IDataParameter firstParameter = (IDataParameter)dbCommand.Parameters[0];
					if (firstParameter.Direction == ParameterDirection.ReturnValue) {
						if (!includeReturnValueParameter) {
                            dbCommand.Parameters.RemoveAt(0);
						}
					}	
				}


                IDataParameter[] discoveredParameters = new IDataParameter[dbCommand.Parameters.Count];
                dbCommand.Parameters.CopyTo(discoveredParameters, 0);
				return discoveredParameters;
			}
		}

        /// <summary>
        /// Derives the parameters.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="command">The command.</param>
		private static void DeriveParameters(IDbProvider provider, IDbCommand command)
        {
            // Find the CommandBuilder
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (string.IsNullOrEmpty(provider.CommandBuilderClass))
            {
                throw new Exception(String.Format(
                                        "CommandBuilderClass not defined for provider \"{0}\".",
                                        provider.Id));
            }

	        Type commandBuilderType = provider.CommandBuilderType;

			// Invoke the static DeriveParameter method on the CommandBuilder class
			// NOTE: OracleCommandBuilder has no DeriveParameter method
			try
			{
				commandBuilderType.InvokeMember("DeriveParameters",
				                                BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null,
					new object[] {command});
			}
			catch(Exception ex)
			{
				throw new IbatisException("Could not retrieve parameters for the store procedure named "+command.CommandText, ex);
			}
		}

		/// <summary>
		/// Deep copy of cached IDataParameter array.
		/// </summary>
		/// <param name="originalParameters"></param>
		/// <returns></returns>
		private static IDataParameter[] CloneParameters(IDataParameter[] originalParameters)
		{
			IDataParameter[] clonedParameters = new IDataParameter[originalParameters.Length];

			int length = originalParameters.Length;
			for (int i = 0, j = length; i < j; i++)
			{
				clonedParameters[i] = (IDataParameter) ((ICloneable) originalParameters[i]).Clone();
			}

			return clonedParameters;
		}

		#endregion private methods, variables, and constructors

		#region caching functions

		/// <summary>
		/// Add parameter array to the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for an IDbConnection</param>
		/// <param name="commandText">the stored procedure name or SQL command</param>
		/// <param name="commandParameters">an array of IDataParameters to be cached</param>
		public void CacheParameterSet(string connectionString, string commandText, params IDataParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;

            lock (syncLock)
            {
                paramCache[hashKey] = commandParameters;
            }
		}


		/// <summary>
		/// Clear the parameter cache.
		/// </summary>
		public void Clear()
		{
			paramCache.Clear();
		}

		/// <summary>
		/// retrieve a parameter array from the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for an IDbConnection</param>
		/// <param name="commandText">the stored procedure name or SQL command</param>
		/// <returns>an array of IDataParameters</returns>
		public IDataParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;

            IDataParameter[] cachedParameters = null;
            paramCache.TryGetValue(hashKey, out cachedParameters) ;
			
			if (cachedParameters == null)
			{			
				return null;
			}
		    return CloneParameters(cachedParameters);
		}

		#endregion caching functions

		#region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of IDataParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <returns>an array of IDataParameters</returns>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        public IDataParameter[] GetSpParameterSet(ISession session, string spName)
		{
            return GetSpParameterSet(session, spName, false);
		}

        /// <summary>
        /// Retrieves the set of IDataParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>an array of IDataParameters</returns>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        public IDataParameter[] GetSpParameterSet(
            ISession session, 
			string spName, 
            bool includeReturnValueParameter)
		{
            string hashKey = session.SessionFactory.DataSource.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

			IDataParameter[] cachedParameters = null;

           paramCache.TryGetValue(hashKey, out cachedParameters);

			if (cachedParameters == null)
			{
                cachedParameters = DiscoverSpParameterSet(session, spName, includeReturnValueParameter);
                paramCache[hashKey] = cachedParameters;
			}
			
			return CloneParameters(cachedParameters);
		}

		#endregion Parameter Discovery Functions
	}
}
