using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KarveTest.DAL.Mock
{
    class HelperDataServices : IHelperDataServices
    {
        public Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncHelper(string assistQuery, string assistTableName)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncHelper(IDictionary<string, string> viewModelAssitantQueries)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer>(string query) where DtoTransfer : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query) where DtoTransfer : class
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUniqueId<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
