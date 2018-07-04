using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.MongoDB
{
    internal class MongoHelperDataAccessLayer : IHelperDataServices
    {
        public Task<DataSet> GetAsyncHelper(string assistQuery, string assistTableName)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetAsyncHelper(IDictionary<string, string> viewModelAssitantQueries)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteBulkDeleteAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> objectValues) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteBulkUpdateAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExecuteBulkInsertAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUniqueId<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query) where DtoTransfer : class
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetMappedUniqueId<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<DtoTransfer> GetSingleMappedAsyncHelper<DtoTransfer, T>(string code) where DtoTransfer : class, new() where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, DtoTransfer>> GetAsyncBatchData<DtoTransfer>(IDictionary<string, string> value)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAllAsyncHelper<DtoTransfer, T>() where DtoTransfer : class where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetPagedSummaryDoAsync<DtoTransfer, T>(int pageIndex, int pageSize)
            where DtoTransfer : class
            where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetPagedSummaryDoAsync<DtoTransfer, T>(long pageIndex, int pageSize)
            where DtoTransfer : class
            where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetItemsCount<T>()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPagedQueryDoAsync<T>(string query, int pageIndex, int pageSize) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Dto>> GetPagedAsyncHelper<Dto, Entity>(string query, int pageIndex, int pageSize)
            where Dto : class
            where Entity : class
        {
            throw new System.NotImplementedException();
        }
    }
}