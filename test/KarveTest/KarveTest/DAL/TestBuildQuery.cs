using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using Dapper;
using KarveDapper;
using System.Threading.Tasks;
using KarveCommon.Generic;

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
