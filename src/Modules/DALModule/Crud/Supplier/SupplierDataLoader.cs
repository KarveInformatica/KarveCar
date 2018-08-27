using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;
using DataAccessLayer.SQL;
using KarveDataServices;
using DataAccessLayer.DtoWrapper;
using KarveDapper;
using Dapper;
using KarveDapper.Extensions;
using KarveDataServices.DataObjects;
using DataAccessLayer.Logic;
using AutoMapper;

namespace DataAccessLayer.Crud.Supplier
{

    public class SupplierDataLoader : IDataLoader<ISupplierData>
    {
        private QueryStoreFactory _queryStoreFactory;
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        public SupplierDataLoader(ISqlExecutor sqlExecutor) : base()
        {
            _queryStoreFactory = new QueryStoreFactory();
            _sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
        }        
        public Task<IEnumerable<ISupplierData>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        private void fillMonths(ref DtoWrapper.Supplier supplier)
        {
            supplier.MonthsDtos = new List<MonthsViewObject>()
            {
                new MonthsViewObject() {NUMERO_MES = 1, MES= "Enero"},
                new MonthsViewObject() {NUMERO_MES = 2, MES= "Febrero"},
                new MonthsViewObject() {NUMERO_MES = 3, MES= "Marzo"},
                new MonthsViewObject() {NUMERO_MES = 4, MES= "Avril"},
                new MonthsViewObject() {NUMERO_MES = 5, MES= "Mayo"},
                new MonthsViewObject() {NUMERO_MES = 6, MES= "Junio"},
                new MonthsViewObject() {NUMERO_MES = 7, MES= "Julio"},
                new MonthsViewObject() {NUMERO_MES = 8, MES= "Agosto"},
                new MonthsViewObject() {NUMERO_MES = 9, MES= "Septiembre"},
                new MonthsViewObject() {NUMERO_MES = 10, MES= "Octubre"},
                new MonthsViewObject() {NUMERO_MES = 11, MES= "Noviembre"},
                new MonthsViewObject() {NUMERO_MES = 12, MES= "Diciembre"}

            };

        }

        private IQueryStore CreateQueryStore(SupplierPoco queryResult)
        {

            // QueryType.QuerySuppliersBranches, code
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParamCount(QueryType.QuerySuppliersBranches, "ProDelega", "ccoIdCliente", queryResult.NUM_PROVEE);
            store.AddParamCount(QueryType.QuerySuppliersContacts, "ProContactos", "ccoIdCliente", queryResult.NUM_PROVEE);
            store.AddParamCount(QueryType.QueryProvince, queryResult.PROV);
            store.AddParamCount(QueryType.QueryCity, queryResult.POBLACION);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CUGASTO);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CONTABLE);
            store.AddParamCount(QueryType.QueryAccount, queryResult.RETENCION);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CTAPAGO);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CTALP);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CTACP);
            store.AddParamCount(QueryType.QueryAccount, queryResult.CTAINTRACOP);
            store.AddParamCount(QueryType.QueryAccount, queryResult.ctaintracoPRep);
            store.AddParamCount(QueryType.QueryLanguage, "IDIOMAS", "CODIGO", queryResult.IDIOMA);
            store.AddParamCount(QueryType.QueryCountry, "PAIS", "SIGLAS", queryResult.PAIS_DEVO);
            store.AddParamCount(QueryType.QueryCountry, "PAIS", "SIGLAS", queryResult.PAIS_PAGO);
            store.AddParamCount(QueryType.QueryCountry, "PAIS", "SIGLAS", queryResult.PAIS_RECLAMA);
            store.AddParamCount(QueryType.QueryOffice, queryResult.OFICINA);
            store.AddParamCount(QueryType.QueryCompany, queryResult.SUBLICEN);
            store.AddParamCount(QueryType.QueryCurrency, queryResult.DIVISA);
            store.AddParamCount(QueryType.QueryDeliveringFrom, ValueToString(queryResult.FORMA_ENVIO));
            return store;
        }

        private string ValueToString(byte? pago)
        {
            if (pago.HasValue)
            {
                return "";
            }
            return string.Format("{0}", pago);
        }

      

        public async Task<ISupplierData> LoadValueAsync(string code)
        {
            var model = new DtoWrapper.Supplier();
            fillMonths(ref model);
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var queryStore = _queryStoreFactory.GetQueryStore();
                    queryStore.AddParam(QueryType.QuerySupplierById, code);
                    var currentQuery = queryStore.BuildQuery();
                    var queryResult = await connection.QueryFirstOrDefaultAsync<SupplierPoco>(currentQuery).ConfigureAwait(false);
                    if (queryResult != null)
                    {
                        var internalQueryStore = _queryStoreFactory.GetQueryStore();
                        

        


                    }
                }
            }
            return model;
        }
      
        public Task<IEnumerable<SupplierViewObject>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ISupplierData>> IDataLoader<ISupplierData>.LoadValueAtMostAsync(int n, int back)
        {
            throw new NotImplementedException();
        }
    }

}