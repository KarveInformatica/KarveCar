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
        private IUserSettingsLoader _loader;
        private IUserSettingsSaver _saver;
        private IConfigurationService _configurationService;

        [OneTimeSetUp]
        public void Setup()
        {
            
            _sqlExecutor = SetupSqlQueryExecutor();
            _dataService = new DataServiceImplementation(_sqlExecutor);
            _loader = new UserSettingsLoader(_dataService);
            _saver = new UserSettingsSaver(_dataService);
            var settings = new UserSettings(_loader, _saver);
            _configurationService = new ConfigurationService(settings);
        }
        [Test]
        public void Should_LoadUserSetting_TheConfigurationService()
        {
            IUserSettings settings = _configurationService.GetUserSettings();
            Assert.NotNull(settings);
        }

    }
}
