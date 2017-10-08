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
        private ISqlQueryExecutor sqlQueryExecutor;
        /// <summary>
        /// It needs the data accessr
        /// </summary>
        /// <param name="dataMapper">SQL executor</param>
        public HelperDataAccessLayer(ISqlQueryExecutor dataMapper)
        {
            this.sqlQueryExecutor = dataMapper;
        }
        public async Task<DataSet> GetAsyncHelper(string assistQuery, string assitTableName)
        {
            DataSet set = await sqlQueryExecutor.AsyncDataSetLoad(assistQuery);
            set.Tables[0].TableName = assitTableName;
            return set;
        }
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await sqlQueryExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }
    }
}
