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
        

    }
}
