using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.Fake
{
    /// <summary>
    ///  This is a mock class for data access layer
    /// </summary>
    public class FakeHelperDataAccessLayer:  IHelperDataServices
    {
        //private IList<string> listString = new List<string>();
        public async Task<DataSet>  GetAsyncHelper(string assistQuery, string assistTableName)
        {
            await Task.Delay(1);
            DataSet set = new DataSet();
            set.Tables.Add(new DataTable());
            return set;
        }

        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> viewModelAssitantQueries)
        {
            DataSet set = new DataSet();
            await Task.Delay(1);
            set.Tables.Add(new DataTable());
            return set;
        }

        public Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUniqueId<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query) where DtoTransfer : class
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMappedUniqueId<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<DtoTransfer> GetSingleMappedAsyncHelper<DtoTransfer, T>(string code) where DtoTransfer : class, new() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DtoTransfer>> GetMappedAllAsyncHelper<DtoTransfer, T>() where DtoTransfer : class where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, DtoTransfer>> GetAsyncBatchData<DtoTransfer>(IDictionary<string, string> value)
        {
            throw new NotImplementedException();
        }
    }
}
