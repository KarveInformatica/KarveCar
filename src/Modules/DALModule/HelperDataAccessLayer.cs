using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed. The so called auxiliares.
    /// </summary>
    class HelperDataAccessLayer :  IHelperDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        /// It needs the data accessr
        /// </summary>
        /// <param name="dataMapper">SQL executor</param>
        public HelperDataAccessLayer(ISqlExecutor dataMapper)
        {
            this._sqlExecutor = dataMapper;
        }

      
        /// <summary>
        /// Get the helper dataset for the async layer.
        /// </summary>
        /// <param name="assistQuery"></param>
        /// <param name="assitTableName"></param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(string assistQuery, string assitTableName)
        {
            DataSet set = await _sqlExecutor.AsyncDataSetLoad(assistQuery);
            set.Tables[0].TableName = assitTableName;
            return set;
        }
        /// <summary>
        /// This returns the way of data layer.
        /// </summary>
        /// <param name="assistQuery"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery)
        {
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<T> result = null;
            
            bool isOpen = false;
            if (connection == null)
            {
                isOpen = _sqlExecutor.Open();
            }
            else
            {
                if (connection.State != ConnectionState.Open)
                {
                   isOpen =  _sqlExecutor.Open();
                }
            }
            if (isOpen)
            {
                connection = _sqlExecutor.Connection;
                // TODO: exception handling.


                try
                {
                    result = await connection.QueryAsync<T>(assistQuery);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// Assist query using the data set
        /// </summary>
        /// <param name="assitQueryDictionary">Dictionary that contgins the assist query.</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await _sqlExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }
       
    }
}
