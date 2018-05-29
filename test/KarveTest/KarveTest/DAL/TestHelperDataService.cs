using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using KarveDataServices.DataTransferObject;
using System.Data;
using KarveDataServices;
using KarveDapper;
using KarveDapper.Extensions;
using DataAccessLayer;
using DataAccessLayer.DataObjects;

namespace KarveTest.DAL
{
    /// <summary>
    ///  TestHelperDataService is an helper data services.
    /// </summary>
    class TestHelperDataService : TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataServices _dataServices;
        [OneTimeSetUp]
        public void Setup()
        {
          _sqlExecutor = SetupSqlQueryExecutor();
          _dataServices = new DataServiceImplementation(_sqlExecutor);
        }
       [Test]
       public async Task Should_Load_PersonalPositionCorrectly()
        {
            IHelperDataServices helperData =  _dataServices.GetHelperDataServices();
            var help= await helperData.GetMappedAllAsyncHelper<PersonalPositionDto,PERCARGOS>();
            Assert.Greater(help.Count(), 0);
        }
        [Test]
        public async Task Should_Load_PagedHelperCorrectly()
        {
            IHelperDataServices helperData = _dataServices.GetHelperDataServices();
            for (int i = 1; i < 100; i+=25)
            {
                var help = await helperData.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(i, 25);
                var count = help.Count<CityDto>();
                Assert.AreEqual(count, 25);
            }
        }
        [Test]
        public void Should_Throws_PagedHelperServiceWhenBadIndex()
        {
            var helperData = _dataServices.GetHelperDataServices();
            Assert.ThrowsAsync<ArgumentException>(async () => await helperData.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(-1, -1));
        }
        

    }
}
