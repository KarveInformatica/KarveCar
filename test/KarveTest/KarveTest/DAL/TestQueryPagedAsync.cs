using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.SQL;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;


namespace KarveTest.DAL
{
    /// <summary>
    ///  This test is a test query paged async. 
    /// </summary>
    class TestQueryPagedAsync : TestBase
    {
        private ISqlExecutor _queryExecutor;
        private DataPager<SupplierSummaryDto> _summaryPager;
        [SetUp]
        public void SetUp()
        {
            _queryExecutor = SetupSqlQueryExecutor();
            _summaryPager = new DataPager<SupplierSummaryDto>(_queryExecutor);
           Stopwatch.Start();
        }

        [TearDown]
        public void TearDown()
        {
            Stopwatch.Stop();
            var elapsed = Stopwatch.ElapsedMilliseconds;
            var testName = TestContext.CurrentContext.Test.Name;
            Console.WriteLine("Test "+ testName+" took "+ elapsed.ToString("g"));
        }


        [Test]
        public async Task Should_FetchSupplier_First25Suppliers()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QuerySupplierSummaryPaged, 1, 25);
            Assert.NotNull(pagerData);
            Assert.AreEqual(pagerData.Count(), 25);
        }

        [Test]
        public async Task Should_Fetch_Second25Suppliers()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QuerySupplierSummaryPaged, 25, 25);
            Assert.NotNull(pagerData);
            Assert.AreEqual(pagerData.Count(), 25);
        }

        [Test]
        public async Task Should_Fetch_Third25Suppliers()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QuerySupplierSummaryPaged, 50, 25);
            Assert.AreEqual(pagerData.Count(), 25);
        }

        [Test]
        public async Task Should_FetchClient_First25Items()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QueryClientPagedSummary, 1, 25);
            Assert.AreEqual(25, pagerData.Count());
        }

        [Test]
        public async Task Should_FetchVehicle_First25Items()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QueryVehicleSummaryPaged, 1, 25);
            Assert.AreEqual(25, pagerData.Count());
        }

        [Test]
        public async Task Should_FetchBroker_First25Items()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QueryCommissionAgentPaged, 1, 25);
            Assert.AreEqual(25,pagerData.Count());
        }

        [Test]
        public async Task Should_FetchInvoice_First25Items()
        {
            var pagerData = await _summaryPager.GetPagedSummaryDoAsync(QueryType.QueryInvoiceSummaryPaged, 1, 25);
            Assert.AreEqual(25,pagerData.Count());
        }
    }
}