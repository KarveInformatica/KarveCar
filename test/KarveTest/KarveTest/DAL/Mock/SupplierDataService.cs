using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Data;

namespace KarveTest.DAL.Mock
{
    class SupplierDataService : ISupplierDataServices
    {
        public Task<bool> DeleteAsyncSupplierDo(ISupplierData data)
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

        public Task<DataSet> GetAsyncAllSupplierSummary()
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, DataSet>> GetAsyncDelegations(string supplierId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ISupplierData>> GetAsyncSupplierCollection()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSupplierContacts(string supplierId)
        {
            throw new NotImplementedException();
        }

        public Task<ISupplierData> GetAsyncSupplierDo(string validSupplierCode)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSupplierInfo(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSuppliersSummaryPaged()
        {
            throw new NotImplementedException();
        }

        public string GetNewId()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
        }

        public ISupplierData GetNewSupplierDo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierSummaryDto>> GetSupplierAsyncSummaryDo()
        {
            throw new NotImplementedException();
        }

        public DataSet GetSuppliersSummaryPaged(long startPos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(ISupplierData data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges(ISupplierData supplierData)
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
    }
}
