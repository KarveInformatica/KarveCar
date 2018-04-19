using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using System.IO;
using System.Transactions;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestMagnifierSetting: TestBase
    {
        private IConfigurationService _serviceConf;
        private ISqlExecutor _sqlExecutor;
        private ISettingsDataServices _settingsDataService;
      
        [OneTimeSetUp]
        public void SetUp()
        {
            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _settingsDataService = new SettingsDataService(_sqlExecutor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private GridSettingsDto LoadFileFromSettings(string path, int id)
        {
            GridSettingsDto dto = new GridSettingsDto();
            using (FileStream stream = File.OpenRead(path))
            {
                long fSize = stream.Length;
                byte[] fileValue = new byte[fSize];
                stream.Read(fileValue, 0, fileValue.Length);
                // now we save into the setting
                var valueStringEncoded = Convert.ToBase64String(fileValue);
                dto.XmlBase64 = valueStringEncoded;
                dto.GridIdentifier = id;
                dto.GridName = "Suppliers";
                dto.User = "CV";
                dto.LastModification = DateTime.Now;
            }
            return dto;
        }
        [Test]
        public async Task Should_Add_MagnifierCurrentSettings()
        {
            // prepare
            string path = @"TestSetting.xml";
            
            GridSettingsDto dto = new GridSettingsDto();
            try
            {
                dto = LoadFileFromSettings(path, 2);
            }
            catch (IOException e)
            {
                Assert.Fail(e.Message);
            }
            // act
            try
            {
                bool currentValue = await _settingsDataService.SaveMagnifierSettings(dto);
                // check if the value has been added
                GridSettingsDto dataValue = await _settingsDataService.GetMagnifierSettings(dto.GridIdentifier);
                // assert
                Assert.AreEqual(currentValue, true);
                Assert.AreEqual(dataValue.GridIdentifier, dto.GridIdentifier);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Shall_Update_OrInsert_Grid_Serialized()
        {
            byte[] currentBytes= {0x10, 0xFF, 0x23, 0x25, 0x23, 0x80};
            var base64 = Convert.ToBase64String(currentBytes);
           
            try
            {
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        GRID_SERIALIZATION serialize = new GRID_SERIALIZATION();
                        serialize.GRID_ID = 1;
                        serialize.GRID_NAME = "Named";
                        serialize.SERILIZED_DATA = base64;
                        bool value = false;
                        if (!connection.IsPresent<GRID_SERIALIZATION>(serialize))
                        {
                            value = await connection.InsertAsync<GRID_SERIALIZATION>(serialize) > 0;
                        }
                        else
                        {
                            value = await connection.UpdateAsync<GRID_SERIALIZATION>(serialize);
                        }
                        Assert.IsTrue(value);
                    }
                }
            }
            catch (Exception e)
            {
                var ex = e;
                Assert.Fail(ex.Message);
            }
          
        }
        [Test]
        public async Task Should_Fail_Load_Magnifier_Settings()
        {
            GridSettingsDto dataValue = await _settingsDataService.GetMagnifierSettings(long.MaxValue);
            Assert.AreEqual(null, dataValue.GridName);            
        }
    }
}
