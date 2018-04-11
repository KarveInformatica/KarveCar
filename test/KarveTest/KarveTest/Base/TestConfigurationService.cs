using DataAccessLayer;
using KarveCar.Logic.Generic;
using KarveCommon.Services;
using KarveDataServices;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Threading.Tasks;

namespace KarveTest.Base
{
    [TestFixture]
    class TestConfigurationService: KarveTest.DAL.TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataServices _dataService;
        private IConfigurationService _configurationService = new ConfigurationService();

        [OneTimeSetUp]
        public void Setup()
        {
            _sqlExecutor = SetupSqlQueryExecutor();
            _dataService = new DataServiceImplementation(_sqlExecutor);
        }
        [Test]
        public void Should_LoadUserSetting_TheConfigurationService()
        {
            IUserSettings settings = _configurationService.GetUserSettings();
            Assert.NotNull(settings);
        }

    }
}
