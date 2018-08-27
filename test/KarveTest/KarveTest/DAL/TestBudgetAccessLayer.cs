using KarveDataServices;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KarveDapper.Extensions;
using KarveDapper;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using DataAccessLayer.DataObjects;
using System.Collections.ObjectModel;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestBudgetAccessLayer : TestBase
    {
        private ISqlExecutor _executor;
        private IBudgetDataService _budgetServices;

        [OneTimeSetUp]
        public void Setup()
        {
            _executor = SetupSqlQueryExecutor();
            _budgetServices = DataServices.GetBudgetDataServices();
        }
        /// <summary>
        ///  This test load a valid client.
        /// </summary>

        [Test]
        public async Task Should_Load_AValidBudget()
        {
            
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                // Arrange value
                IEnumerable<PRESUP1> value =  await dbConnection.GetPagedAsync<PRESUP1>(1,2).ConfigureAwait(false);
                Assert.NotNull(value);
                var singleValue = value.FirstOrDefault();
                Assert.NotNull(singleValue);
                // Act.
                IBudgetData data = await _budgetServices.GetDoAsync(singleValue.NUMERO_PRE);
                // Assert
                Assert.NotNull(data.Value);
                Assert.NotNull(data.Value.NUMERO_PRE);
                Assert.NotNull(data.Value.Code);
                Assert.AreEqual(data.Value.NUMERO_PRE, singleValue.NUMERO_PRE);
            }
        }
        [Test]
        public async Task Should_LoadABudgetSummary()
        {
            List<PRESUP1> pres = new List<PRESUP1>();
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var list = await dbConnection.GetPagedAsync<PRESUP1>(1, 100).ConfigureAwait(false);
                pres.AddRange(list);

            }
            var sinkData = await _budgetServices.GetPagedSummaryDoAsync(1, 100);
            sinkData = sinkData.OrderBy(x=>x.BudgetNumber);
            var sourceData =  pres.OrderBy(x => x.NUMERO_PRE);
            for (int i = 0; i < 100; ++i)
            {
                Assert.AreEqual(sourceData.ElementAt(i).NUMERO_PRE, sinkData.ElementAt(i).BudgetNumber);
                Assert.AreEqual(sourceData.ElementAt(i).FSALIDA_PRE1, sinkData.ElementAt(i).DepartureDate);
 
            }
        }
 

    }
}
