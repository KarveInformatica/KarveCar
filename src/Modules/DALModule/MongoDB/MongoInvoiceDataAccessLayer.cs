using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoInvoiceDataAccessLayer : IInvoiceDataServices
    {
        public int NumberPage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public long NumberItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task<bool> DeleteAsync(IInvoiceData invoice)
        {
            throw new System.NotImplementedException();
        }

        public Task<IInvoiceData> GetInvoiceDoAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<InvoiceSummaryValueDto>> GetInvoiceSummaryAsync()
        {
            throw new System.NotImplementedException();
        }

        public IInvoiceData GetNewInvoiceDo(string s)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<InvoiceSummaryValueDto>> GetPagedSummaryDoAsync(long index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public string NewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IInvoiceData currentInvoice)
        {
            throw new System.NotImplementedException();
        }
    }
}