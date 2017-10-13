using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed. The so called auxiliares.
    /// </summary>
    class HelperDataAccessLayer :  IHelperDataServices
    {
        private readonly ISqlQueryExecutor _sqlQueryExecutor;
        /// <summary>
        /// It needs the data accessr
        /// </summary>
        /// <param name="dataMapper">SQL executor</param>
        public HelperDataAccessLayer(ISqlQueryExecutor dataMapper)
        {
            this._sqlQueryExecutor = dataMapper;
        }
        /// <summary>
        /// Get the helper dataset for the async layer.
        /// </summary>
        /// <param name="assistQuery"></param>
        /// <param name="assitTableName"></param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(string assistQuery, string assitTableName)
        {
            DataSet set = await _sqlQueryExecutor.AsyncDataSetLoad(assistQuery);
            set.Tables[0].TableName = assitTableName;
            return set;
        }
        /// <summary>
        /// Assist query using the data set
        /// </summary>
        /// <param name="assitQueryDictionary">Dictionary that contgins the assist query.</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await _sqlQueryExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }
       
    }
}
