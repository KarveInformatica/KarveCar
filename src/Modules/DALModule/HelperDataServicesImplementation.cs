using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace DataAccessLayer
{
    public class HelperDataServicesImplementation : IHelperDataServices
    {
        private ISqlQueryExecutor _sqlQueryExecutor;
       
        public HelperDataServicesImplementation(ISqlQueryExecutor sqlQueryExecutor)
        {
            _sqlQueryExecutor = sqlQueryExecutor;
        }
        public async Task<DataSet>  GetAsyncHelper(string assistQuery, string assistTableName)
        {
            DataSet dataSet = await _sqlQueryExecutor.AsyncDataSetLoad(assistQuery).ConfigureAwait(false);
            dataSet.Tables[0].TableName = assistTableName;
            return dataSet;
        }

        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> queryList)
        {
            DataSet helperDataSet = await _sqlQueryExecutor.AsyncDataSetLoadBatch(queryList).ConfigureAwait(false);
            return helperDataSet;
        }
    }
}
