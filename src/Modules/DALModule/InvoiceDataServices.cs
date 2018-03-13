using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Data;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using KarveDataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.Model;
using AutoMapper;
using DataAccessLayer.SQL;
using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    ///  InvoiceDataServices has the reposability to manage the crud of an invoice.
    /// </summary>
    internal class InvoiceDataServices : IInvoiceDataServices
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="sqlExecutor">Sql executor interface. This interface is the boundary between a dataservice and the ADO.NET </param>
        public InvoiceDataServices(ISqlExecutor sqlExecutor)
        {
            this._sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        /// Retrieve an invoice from the code in asynchronous way.
        /// </summary>
        /// <param name="code">Code of the invoice</param>
        /// <returns>The invoice.</returns>
        public async Task<IInvoiceData> GetInvoiceDoAsync(string code)
        {
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                var invoice = await db.GetAsync<FACTURAS>(code);
                var voice = _mapper.Map<FACTURAS, InvoiceDto>(invoice);
                var currentInvoice = new Invoice(code, voice);
                return currentInvoice;
            }
        }
        /// <summary>
        ///  Retrieve the invoice summary in asynchronous way.
        /// </summary>
        /// <returns>A collection of invoices.</returns>
        public async Task<IEnumerable<InvoiceSummaryValueDto>> GetInvoiceSummaryAsync()
        {
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                QueryStore store = new QueryStore();
                store.AddParam(QueryStore.QueryType.QueryInvoiceSummaryExtended);
                var query = store.BuildQuery();
                var invoice = await db.QueryAsync<InvoiceSummaryValueDto>(query);
                return invoice;
            }
        }

        
    }
}