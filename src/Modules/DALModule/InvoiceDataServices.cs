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
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    ///  InvoiceDataServices has the reposability to manage the crud of an invoice.
    /// </summary>
    internal class InvoiceDataServices : IInvoiceDataServices
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
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
            Invoice invoice = new Invoice(code, new InvoiceDto());
            invoice.Valid = false;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                string sql = "SELECT * FROM FACTURAS WHERE NUMERO_FAC='{0}';" +
                    " SELECT * FROM LIFAC WHERE NUMERO_LIF='{0}';";
                var query = string.Format(sql, code);
                var multi = await connection.QueryMultipleAsync(query);
                var invoices = multi.Read<FACTURAS>().FirstOrDefault();
                if (invoices != null)
                {
                    var invoiceItems = multi.Read<LIFAC>().ToList();
                    var dto = _mapper.Map<FACTURAS, InvoiceDto>(invoices);
                    invoice = new Invoice(code, dto);
                    invoice.InvoiceItems = _mapper.Map<IEnumerable<LIFAC>, IEnumerable<InvoiceItem>>(invoiceItems);
                    invoice.Valid = true;
                }
               
            }
            return invoice;
        }
        /// <summary>
        ///  Retrieve the invoice summary in asynchronous way.
        /// </summary>
        /// <returns>A collection of invoices.</returns>
        public async Task<IEnumerable<InvoiceSummaryValueDto>> GetInvoiceSummaryAsync()
        {
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                IQueryStore store = _queryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QueryInvoiceSummaryExtended);
                var query = store.BuildQuery();
                var invoice = await db.QueryAsync<InvoiceSummaryValueDto>(query);
                return invoice;
            }
        }

        
    }
}