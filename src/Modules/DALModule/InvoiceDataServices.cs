using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Dapper;
using KarveDapper.Extensions;
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
    ///  Due to simplicity isses i dont want to split the loading/saving/deleting
    /// </summary>
    internal class InvoiceDataServices : IInvoiceDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
       
        private readonly QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="sqlExecutor">Sql executor interface. This interface is the boundary between a dataservice and the ADO.NET </param>
        public InvoiceDataServices(ISqlExecutor sqlExecutor)
        {
            this._sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
         
        }
        /// <inheritdoc />
        /// <summary>
        /// Retrieve an invoice from the code in asynchronous way.
        /// </summary>
        /// <param name="code">Code of the invoice</param>
        /// <returns>The invoice.</returns>
        public async Task<IInvoiceData> GetInvoiceDoAsync(string code)
        {
            var invoice = new Invoice(code, new InvoiceDto()) {Valid = false};
            //  check if the code is a valid integer.
           
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {

                var store = _queryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QueryInvoiceSingle, code);
                store.AddParam(QueryType.QueryInvoiceItem, code);
                var sql = store.BuildQuery();
                try
                {
                    var multi = await connection.QueryMultipleAsync(sql);
                    var invoices = multi.Read<FACTURAS>().FirstOrDefault();
                    if ((invoices == null) || (multi.IsConsumed))
                    {
                        if (invoices == null)
                            return new NullInvoice();

                        return invoice;

                    }

                    var invoiceItems = multi.Read<LIFAC>().ToList();

                    var dto = _mapper.Map<FACTURAS, InvoiceDto>(invoices);
                    if (dto == null)
                    {
                        return new NullInvoice();
                    }

                    // move this to sql store.
                    IEnumerable<ClientSummaryDto> clientDto = new List<ClientSummaryDto>();
                    if (!string.IsNullOrEmpty(invoices.CLIENTE_FAC))
                    {
                        var storeClient = new QueryStore();
                        storeClient.AddParam(QueryType.QueryClientSummaryExtById, invoices.CLIENTE_FAC);
                        var query = storeClient.BuildQuery();
                        clientDto = await connection.QueryAsync<ClientSummaryDto>(query);
                    }

                    invoice = new Invoice(code, dto)
                    {
                        InvoiceItems = _mapper.Map<IEnumerable<LIFAC>, IEnumerable<InvoiceSummaryDto>>(invoiceItems),
                        Valid = true,
                        Value = dto,
                        ClientSummary = clientDto,
                        Code = dto.NUMERO_FAC
                    };
                }
                catch (System.Exception ex)
                {
                    throw new DataLayerException("Cannot retrieve an invoice", ex);
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
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                var store = _queryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QueryInvoiceSummaryExtended);
                var query = store.BuildQuery();
                var invoice = await db.QueryAsync<InvoiceSummaryValueDto>(query);
                return invoice;
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///  Return the a new fresh invoice 
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>A new fresh invoice</returns>
        public IInvoiceData GetNewInvoiceDo(string code)
        {
            var dto = new InvoiceDto {NUMERO_FAC = code};
            return new Invoice(code, dto);    
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an asynchronous value.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IInvoiceData invoice)
        {
            var retValue = false;
            if (invoice is NullInvoice)
            {
                return false;
            }
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                var facturas = _mapper.Map<InvoiceDto, FACTURAS>(invoice.Value);

                if (db == null)
                {
                    return false;
                }
                retValue = await db.DeleteAsync(facturas);
                if ((invoice.Value.InvoiceItems != null)
                    && (invoice.Value.InvoiceItems.Any()))
                {
                    var lineas =
                        _mapper.Map<IEnumerable<InvoiceSummaryDto>, IEnumerable<LIFAC>>(invoice.Value.InvoiceItems);
                    var entityToDelete = lineas.ToArray();
                    retValue = retValue && await db.DeleteCollectionAsync(entityToDelete); 
                }
            }
            return retValue;
        }

        /// <inheritdoc />
        /// <summary>
        ///  Generate a new identifier.
        /// </summary>
        /// <returns>Returns an unique identifier.</returns>
        public string NewId()
        {
            var uniqueId = string.Empty;
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                if (db == null)
                {
                    return uniqueId;
                }
                var facturas = new FACTURAS();
                uniqueId = db.UniqueId<FACTURAS>(facturas);
            }

            return uniqueId;
        }



        /// <inheritdoc />
        /// <summary>
        ///  Save an inovice.
        /// </summary>
        /// <param name="currentInvoice">Inovice </param>
        /// <returns>Return true or false</returns>
        public async Task<bool> SaveAsync(IInvoiceData currentInvoice)
        {
            var item = currentInvoice.Value;
            var retValue = false;
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                if (db == null)
                {
                    return false;
                }
                // we are sure that the database is open here.
                var invoice = _mapper.Map<InvoiceDto, FACTURAS>(item);
                try
                {
                    if (db.IsPresent<FACTURAS>(invoice))
                    {
                        // update case.
                        retValue = await db.UpdateAsync(invoice).ConfigureAwait(false);
                        if (item.InvoiceItems.Any())
                        {
                            retValue = retValue && await SaveLines(item.InvoiceItems);
                        }
                    }
                    else
                    {
                        // insert case
                        retValue = await db.InsertAsync(invoice).ConfigureAwait(false) > 0;
                        if (item.InvoiceItems.Any())
                        {
                            retValue = retValue && await SaveLines(item.InvoiceItems);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw new DataLayerException("Saving invoices exception. Reason: " + e.Message, e);
                }
            }
            return retValue;
        }

        /// <summary>
        ///  Save the lines. Number of lines that are you.
        /// </summary>
        /// <param name="lines">Lines of the invoice</param>
        /// <returns></returns>
        private async Task<bool> SaveLines(IEnumerable<InvoiceSummaryDto> lines)
        {
            var retValue = false;
            if (lines == null)
            {
                return false;
            }
            var invoiceSummaryValueDtos = lines as InvoiceSummaryDto[] ?? lines.ToArray();
            var selectDirty = invoiceSummaryValueDtos.Where(x => x.IsDirty == true);
            var selectNew = invoiceSummaryValueDtos.Where(x => x.IsNew == true);
            var mappedToInsert = _mapper.Map<IEnumerable<InvoiceSummaryDto>, IEnumerable<LIFAC>>(selectNew);
            var mappedToUpdate = _mapper.Map<IEnumerable<InvoiceSummaryDto>, IEnumerable<LIFAC>>(selectDirty);
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                retValue = (await db.InsertAsync(mappedToInsert) > 0);
                retValue = retValue && await db.UpdateAsync(mappedToUpdate);
            }
            return retValue;
        }
    }
}