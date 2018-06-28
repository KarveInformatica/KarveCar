using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;
using System.Text;

namespace KarveTest.DAL
{
    /// <summary>
    /// This fixuture will craft a query
    /// </summary>
    [TestFixture]
    class TestBuildQuery
    {
        private QueryStoreFactory _storeFactory = new QueryStoreFactory();
        private IQueryStore _store;

        private const string CityLanguageQuery =
            @"SELECT * FROM POBLACIONES WHERE CP = '0001';SELECT * FROM IDIOMAS WHERE CODIGO='0001';";
        private const string Query2 = @"SELECT * FROM POBLACIONES WHERE CP = '1892829';SELECT * FROM OFICINAS WHERE SUBLICEN='282998';";
        private const string Query3 = @"SELECT * FROM OFICINAS WHERE SUBLICEN='282998';";
        private const string Query4 = @"SELECT * FROM OFICINAS WHERE SUBLICEN='282998';";

        [OneTimeSetUp]
        public void Setup()
        {
          _store = _storeFactory.GetQueryStore();
        }
        [Test]
        public void Should_Build_QueryFromQueryStoreWithParameters()
        {
            _store.AddParam(QueryType.QueryCity, "0001");
            _store.AddParam(QueryType.QueryLanguage, "0001");
            var value = _store.BuildQuery();
            Assert.AreEqual(value, CityLanguageQuery);
        }

        [Test]
        public void Should_Build_QueryFromQueryStoreWithParam()
        {
            var dto = new CompanyDto
            {
                CP = "1892829",
                PROVINCIA = "282982",
                Code = "282998"
            };
            var store = _storeFactory.GetQueryStore();
            store.Clear();
            store.AddParam(QueryType.QueryCity, dto.CP);
            store.AddParam(QueryType.QueryProvince, dto.PROVINCIA);
            store.AddParam(QueryType.QueryCompanyOffices, 
                dto.Code);
            var q = store.BuildQuery();

        }

        [Test]
        public void Should_Build_QueryFromQueryStoreWithNullParameters()
        {
            CompanyDto dto = new CompanyDto
            {
                CP = "1892829",
                PROVINCIA = null,
                Code = "282998"
            };
            IQueryStore store = _storeFactory.GetQueryStore();
            store.Clear();
            store.AddParam(QueryType.QueryCity, dto.CP);
            store.AddParam(QueryType.QueryProvince, dto.PROVINCIA);
            store.AddParam(QueryType.QueryCompanyOffices,
                dto.Code);
            var q = store.BuildQuery();
            Assert.AreEqual(q, Query2);
        }
        [Test]
        public void Should_Build_QueryFromQueryStoreWithNullParameters2()
        {
            CompanyDto dto = new CompanyDto
            {
                CP = null,
                PROVINCIA = null,
                Code = "282998"
            };
            IQueryStore store = _storeFactory.GetQueryStore();
            store.Clear();
            store.AddParam(QueryType.QueryCity, dto.CP);
            store.AddParam(QueryType.QueryProvince, dto.PROVINCIA);
            store.AddParam(QueryType.QueryCompanyOffices,
                dto.Code);
            var q = store.BuildQuery();
            Assert.AreEqual(q, Query3);
        }
        [Test]
        public async Task Should_Build_ACorrectBookingMultiQuery()
        {
            var testBase = new TestBase();
            var sqlExecutor = testBase.SetupSqlQueryExecutor();
            var queryStore = _storeFactory.GetQueryStore();
            var code1 = string.Empty;
            var code2 = string.Empty;
            var code3 = string.Empty;
            using (var dbConnection = sqlExecutor.OpenNewDbConnection())
            {
                var dbContract = await dbConnection.GetPagedAsync<CONTRATOS1>(1, 4).ConfigureAwait(false);
                var contract = dbContract.AsList<CONTRATOS1>();
                queryStore.AddParam(QueryType.QueryContractsByClient, contract[0].CLIENTE_CON1);
                queryStore.AddParam(QueryType.QueryClientSummaryExtById, contract[1].CLIENTE_CON1);

               // queryStore.AddParam(QueryType.QueryClientById, contract[2].CLIENTE_CON1);
                var queryValue = queryStore.BuildQuery();
                var builder = new StringBuilder();
                builder.Append(queryValue.TrimEnd());
                var secondStore = _storeFactory.GetQueryStore();
                secondStore.AddParam(QueryType.QueryClientSummaryExtById, contract[2].CLIENTE_CON1);
                builder.Append(";");
                builder.Append(secondStore.BuildQuery().TrimEnd());
                var splittedValue = builder.ToString().Split(';');
                Assert.AreEqual(6,splittedValue.Length);
              
            }
        }
        [Test]
        public async Task Should_Build_AMultiKeyQueryCorrectly()
        {
            // arrange
            var testBase = new TestBase();
            var sqlExecutor = testBase.SetupSqlQueryExecutor();
            var resultQuery = new VEHICULO1();
            using (var connection = sqlExecutor.OpenNewDbConnection())
            {
                resultQuery = await connection.GetRandomEntityAsync<VEHICULO1>();
            }
            var auxQueryStore = new QueryStore();
            auxQueryStore.AddParam(QueryType.QueryVehicleModelWithCount, resultQuery.MAR, resultQuery.MO1, resultQuery.MO2);
            auxQueryStore.AddParamCount(QueryType.QueryBrandByVehicle, resultQuery.MAR, resultQuery.CODIINT);
            auxQueryStore.AddParam(QueryType.QueryVehiclePhoto, resultQuery.CODIINT);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleActivity, resultQuery.ACTIVIDAD);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleOwner, resultQuery.PROPIE);
            auxQueryStore.AddParamCount(QueryType.QueryAgentByVehicle, resultQuery.AGENTE);
            auxQueryStore.AddParam(QueryType.QueryVehicleMaintenance, resultQuery.CODIINT);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleColor, resultQuery.COLOR);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleGroup, resultQuery.GRUPO);
            auxQueryStore.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.PROVEEDOR);
            auxQueryStore.AddParamCount(QueryType.QueryReseller, resultQuery.VENDEDOR_VTA);
            auxQueryStore.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIALEAS);
            var outQuery = auxQueryStore.BuildQuery();


        }
        [Test]
        public async Task Should_Execute_AQueryWithFilters()
        {
            var store = _storeFactory.GetQueryStore();
            var testBase = new TestBase();
            var sqlExecutor = testBase.SetupSqlQueryExecutor();
            var compositeQueryFilter = new QueryCompositeFilter();
            var queryFilter1 = new QueryFilter("NOMBRE", "CIAL.*", Syncfusion.Data.PredicateType.And);
            var queryFilter2 = new QueryFilter("POBLACION", "MAL.*", Syncfusion.Data.PredicateType.And);
            compositeQueryFilter.Add(queryFilter1);
            compositeQueryFilter.Add(queryFilter2);
            store.AddParamFilter(QueryType.QueryClientPagedSummary,compositeQueryFilter);
            var query = store.BuildQuery();
            using (var dbConnection = sqlExecutor.OpenNewDbConnection())
            {
                var value = await dbConnection.QueryAsync<ClientSummaryExtended>(query);
                Assert.NotNull(value);
            }
        }
        
    }
}
