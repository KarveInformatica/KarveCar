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

        public Task<bool> DeleteAsync(IInvoiceData booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<IInvoiceData> GetDoAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public IInvoiceData GetNewDo(string value)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<InvoiceSummaryValueDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<InvoiceSummaryValueDto>> GetSummaryAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public string NewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IInvoiceData bookingData)
        {
            throw new System.NotImplementedException();
        }
    }
}