using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCar.Logic.Generic;
using KarveCommon.Services;
using KarveDataServices;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace KarveTest.Base
{
    [TestFixture]
    class TestConfigurationService: KarveTest.DAL.TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataServices _dataService;
        private IUserSettings _settings;
        private IConfigurationService _configurationService = new ConfigurationService();

        [OneTimeSetUp]
        public void Setup()
        {
            _sqlExecutor = SetupSqlQueryExecutor();
            _dataService = new DataServiceImplementation(_sqlExecutor);
        }
        [Test]
        public async void Shall_LoadUserSetting_TheConfigurationService()
        {
            IUserSettings settings = _configurationService.GetUserSettings();
           // IMagnifierSettings magnifierSettings = await settings.UserSettingsLoader.GetMagnifierSettings(2);
           /// Assert.Greater(magnifierSettings.ID,0);
        }

        [Test]
        public async void Shall_Load_And_Save_Settings()
        {
           // IUserSettings settings = _configurationService.GetUserSettings();
           // IMagnifierSettings magnifierSettings = await settings.UserSettingsLoader.GetMagnifierSettings(2);
           // DateTime system = DateTime.Now;
           // magnifierSettings.ULTIMOD = DateTime.Now.ToLongTimeString();
           // magnifierSettings.NOMBRE = "ProviderControlViewModel";
            //bool saved = await settings.UserSettingsSaver.SaveMagnifierSettings(magnifierSettings);
        }
    }
}
