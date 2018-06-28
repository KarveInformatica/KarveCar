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
using AutoMapper;
using DataAccessLayer.Logic;

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
        public async Task Should_UpdateOrInsert_GridSerialized()
        {
            byte[] currentBytes= {0x10, 0xFF, 0x23, 0x25, 0x23, 0x80};
            var base64 = Convert.ToBase64String(currentBytes);
            IMapper mapper = MapperField.GetMapper();
            GridSettingsDto gridSettingsDto = new GridSettingsDto();
            gridSettingsDto.GridIdentifier = 0x800;
            gridSettingsDto.GridName = "Not known";
            gridSettingsDto.XmlBase64 = @"<grid></grid>";

           
            try
            {
               var serialize =  mapper.Map<GridSettingsDto, GRID_SERIALIZATION>(gridSettingsDto);
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var value = false;
                        if (!connection.IsPresent<GRID_SERIALIZATION>(serialize))
                        {
                            value = await connection.InsertAsync<GRID_SERIALIZATION>(serialize) > 0;
                        }
                        else
                        {
                            value = await connection.UpdateAsync<GRID_SERIALIZATION>(serialize);
                        }
                        Assert.IsTrue(value);
                        scope.Complete();
                    }
                }
               
            }
            catch (Exception e)
            {
                var ex = e;
                Assert.Fail(ex.Message);
            }
            // nowe we have to assert this.
          
        }
        [Test]
        public void Should_Fail_LoadMagnifierSettingsWithInvalidId()
        {
            Assert.Throws<DataLayerException>(() => _settingsDataService.GetMagnifierSettings(long.MaxValue));
        }
    }
}
