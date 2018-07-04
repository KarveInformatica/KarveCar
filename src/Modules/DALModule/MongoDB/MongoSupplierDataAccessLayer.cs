using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
   
    internal class MongoSupplierDataAccessLayer :  ISupplierDataServices
    {
        public MongoSupplierDataAccessLayer()
        {
        }

        
        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public int NumberPage { get; set; }
        public long NumberItems { get; set; }
        public Task<DataSet> GetAsyncAllSupplierSummary()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSupplierInfo(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, DataSet>> GetAsyncDelegations(string supplierId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierSummaryDto>> GetPagedSummaryDo(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void UpdateDataSet(IDictionary<string, string> queries, DataSet set)
        {
            throw new NotImplementedException();
        }

        public void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSupplier(string sqlQuery, string supplierId, DataSet supplierDataSet)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSupplier(IDictionary<string, string> queries, DataSet currentDataSet)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierSummaryDto>> GetSupplierAsyncSummaryDo()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(ISupplierData data)
        {
            throw new NotImplementedException();
        }

        public string GetNewId()
        {
            throw new NotImplementedException();
        }

        public Task<ISupplierData> GetAsyncSupplierDo(string validSupplierCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsyncSupplierDo(ISupplierData data)
        {
            throw new NotImplementedException();
        }

        public ISupplierData GetNewSupplierDo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges(ISupplierData supplierData)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactsDto>> GetAsyncContacts(string codeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}