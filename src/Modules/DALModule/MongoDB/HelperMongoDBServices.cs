using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.MongoDB
{
    internal class HelperMongoDBServices : IHelperDataServices
    {
        private object _executor;

        public HelperMongoDBServices(object executor)
        {
            _executor = executor;
        }

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

        public Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
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
    }
}