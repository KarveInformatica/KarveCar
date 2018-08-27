using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using Dapper;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.DtoWrapper;
using AutoMapper;
using DataAccessLayer.SQL;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using DataAccessLayer.Exception;


namespace DataAccessLayer
{
    /// <summary>
    ///  InvoiceDataServices has the reposability to manage the crud of an invoice.
    ///  Due to simplicity isses i dont want to split the loading/saving/deleting
    /// </summary>
    internal class InvoiceDataServices : AbstractDataAccessLayer, IInvoiceDataServices
    {
       
        private readonly IMapper _mapper;
       
       
        ///  Constructor.
        /// </summary>
        /// <param name="sqlExecutor">Sql executor interface. This interface is the boundary between a dataservice and the ADO.NET </param>
        public InvoiceDataServices(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _mapper = MapperField.GetMapper();
            TableName = "FACTURAS";

        }
        /// <inheritdoc />
        /// <summary>
        /// Retrieve an invoice from the code in asynchronous way.
        /// </summary>
        /// <param name="code">Code of the invoice</param>
        /// <returns>The invoice.</returns>
        public async Task<IInvoiceData> GetDoAsync(string code)
        {
            var invoice = new Invoice(code, new InvoiceViewObject()) {Valid = false};
            //  check if the code is a valid integer.
           
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {

                var store = QueryStoreFactory.GetQueryStore();
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

                    var dto = _mapper.Map<FACTURAS, InvoiceViewObject>(invoices);
                    if (dto == null)
                    {
                        return new NullInvoice();
                    }

                    // move this to sql store.
                    IEnumerable<ClientSummaryExtended> clientDto = new List<ClientSummaryExtended>();
                    if (!string.IsNullOrEmpty(invoices.CLIENTE_FAC))
                    {
                        var storeClient = new QueryStore();
                        storeClient.AddParam(QueryType.QueryClientSummaryExtById, invoices.CLIENTE_FAC);
                        var query = storeClient.BuildQuery();
                        clientDto = await connection.QueryAsync<ClientSummaryExtended>(query);
                    }

                    invoice = new Invoice(code, dto)
                    {
                        InvoiceItems = _mapper.Map<IEnumerable<LIFAC>, IEnumerable<InvoiceSummaryViewObject>>(invoiceItems),
                        Valid = true,
                        Value = dto,
                        ClientSummary = clientDto,
                        Code = dto.NUMERO_FAC
                    };
                    var pageCount = await connection.GetPageCount<CLIENTES1>(1000);
                    invoice.NumberOfClients = pageCount.Item1;
                     
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
        public async Task<IEnumerable<InvoiceSummaryValueViewObject>> GetSummaryAllAsync()
        {
            using (var db = SqlExecutor.OpenNewDbConnection())
            {
                var store = QueryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QueryInvoiceSummaryExtended);
                var query = store.BuildQuery();
                var invoice = await db.QueryAsync<InvoiceSummaryValueViewObject>(query);
                return invoice;
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///  Return the a new fresh invoice 
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>A new fresh invoice</returns>
        public IInvoiceData GetNewDo(string code)
        {
            var dto = new InvoiceViewObject() {NUMERO_FAC = code};
            var invoice = new Invoice(code, dto);
            invoice.ClientSummary = new List<ClientSummaryExtended>();
            invoice.ContractSummary = new List<ContractViewObject>();
            invoice.Code = code;
            invoice.Coste = 0;
            invoice.Cantidad = 0;
            return invoice;

        }
        /// <summary>
        ///  Invoice summary value data object
        /// </summary>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        public async Task<IEnumerable<InvoiceSummaryValueViewObject>> GetPagedSummaryDoAsync(int pageIndex, int pageSize)
        {
            var pager = new DataPager<InvoiceSummaryValueViewObject>(SqlExecutor);
            var startIndex = (pageIndex <= 0) ? 1 : pageIndex;
            NumberPage = await GetPageCount(pageSize);
            var summary = await pager.GetPagedSummaryDoAsync(QueryType.QueryInvoiceSummaryPaged, startIndex, pageSize);
            return summary;
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
            

            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {

                        var facturas = _mapper.Map<InvoiceViewObject, FACTURAS>(invoice.Value);


                        retValue = await dbConnection.DeleteAsync(facturas);
                        if ((invoice.Value.InvoiceItems == null) || (!invoice.Value.InvoiceItems.Any()))
                        {
                            return retValue;
                        }

                        var lineas =
                            _mapper.Map<IEnumerable<InvoiceSummaryViewObject>, IEnumerable<LIFAC>>(invoice.Value.InvoiceItems);
                        var entityToDelete = lineas.ToArray();
                        retValue = retValue && await dbConnection.DeleteCollectionAsync(entityToDelete);
                        scope.Complete();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new DataAccessLayerException(ex.Message, ex);
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
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return uniqueId;
                }
                var facturas = new FACTURAS();
                uniqueId = dbConnection.UniqueId<FACTURAS>(facturas);
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
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    throw  new DataLayerException("Cannot open the database during save");
                }
                // we are sure that the database is open here.
                var invoice = _mapper.Map<InvoiceViewObject, FACTURAS>(item);
                try
                {
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        if (dbConnection.IsPresent<FACTURAS>(invoice))
                        {
                            // update case.
                            retValue = await dbConnection.UpdateAsync(invoice).ConfigureAwait(false);
                            if ((item.InvoiceItems!=null) && (item.InvoiceItems.Any()))
                            {
                                retValue = retValue && await SaveLines(dbConnection,item.InvoiceItems);
                            }
                        }
                        else
                        {
                            // insert case
                            retValue = await dbConnection.InsertAsync(invoice).ConfigureAwait(false) > 0;
                            if ((item.InvoiceItems!=null) && (item.InvoiceItems.Any()))
                            {
                                retValue = retValue && await SaveLines(dbConnection,item.InvoiceItems);
                            }
                        }
                        if (retValue)
                        {
                            scope.Complete();
                        }
                        else
                        {
                            scope.Dispose();
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
        private async Task<bool> SaveLines(IDbConnection dbConnection, IEnumerable<InvoiceSummaryViewObject> lines)
        {
            var retValue = true;
            if (lines == null)
            {
                return false;
            }
            var invoiceSummaryValueDtos = lines as InvoiceSummaryViewObject[] ?? lines.ToArray();
            var selectNew = invoiceSummaryValueDtos.Where(x => (x.IsNew == true));
            var selectDirty = invoiceSummaryValueDtos.Where(x => x.IsDirty == true);
            var selectDeleted = invoiceSummaryValueDtos.Where(x => x.IsDeleted == true);
            var toBeUpdated = selectDirty.Except(selectNew);
          
            var mappedToInsert = _mapper.Map<IEnumerable<InvoiceSummaryViewObject>, IEnumerable<LIFAC>>(selectNew);
            var mappedToUpdate = _mapper.Map<IEnumerable<InvoiceSummaryViewObject>, IEnumerable<LIFAC>>(toBeUpdated);
            var mappedToDelete = _mapper.Map<IEnumerable<InvoiceSummaryViewObject>, IEnumerable<LIFAC>>(selectDeleted);
            try
            {
                if (mappedToInsert.Any())
                {
                    retValue = (await dbConnection.InsertAsync(mappedToInsert).ConfigureAwait(false) > 0);
                }
                if (mappedToUpdate.Any())
                {
                    retValue = retValue && await dbConnection.UpdateAsync(mappedToUpdate).ConfigureAwait(false);
                }
            }
            catch (System.Exception ex)
            {

                throw new DataLayerException("Exception while saving lines",ex);
            }

            return retValue;
        }

        public Task<IEnumerable<InvoiceSummaryViewObject>> GetInvoiceSummaryAsync()
        {
          throw new System.NotImplementedException();
        }
        
        public Task<IEnumerable<IInvoiceData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new System.NotImplementedException();
        }
    }
}