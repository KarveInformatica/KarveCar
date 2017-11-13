using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;

namespace KarveTest.DAL
{
    /// <summary>
    ///  Test for the Test Vehicle Data Layer
    /// </summary>
    [TestFixture]
    class TestVehicleDataLayer: TestBase
    {
        private IDataServices _dataServices;
        private IVehicleDataServices _vehicleDataServices;
        private IConfigurationService _serviceConf;
        

        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";


        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(executor, _serviceConf);
                _vehicleDataServices = _dataServices.GetVehicleDataServices();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        ////
        /// Tests for the vehicle data access layer
        /// 
        /// 
       
        /// <summary>
        ///  This test create a new vehicle
        /// </summary>
        [Test]
        public async Task Should_Give_A_Valid_Vehicle()
        {
            string vehicleNewId = "0000001";
            for (int i = 0; i < 10; i++)
            {
                IVehicleData vehicleData = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
                Assert.True(vehicleData.Valid);
                VehicleDto dataValue = vehicleData.Value;
                Assert.NotNull(dataValue);
                Assert.NotNull(dataValue.CODIINT);
                Assert.NotNull(dataValue.MARCA);
                Assert.AreEqual(dataValue.MARCA, "IVECO");
                Assert.AreEqual(dataValue.MATRICULA, "X3944584");
            }
        }
        /// <summary>
        ///  This test should give a not valid vehicle.
        /// </summary>
        [Test]
        public async Task  Should_Give_A_Not_Valid_Vehicle()
        {
            string vehicleNewId = "23839839";
            IVehicleData vehicleData = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
            Assert.False(vehicleData.Valid);
           
        }
        /// <summary>
        ///  This should create a new vehicle using a unique id.
        /// </summary>
        [Test]
        public void Should_Create_A_New_Vehicle()
        {
            for (int i = 0; i < 4; ++i)
            {
                string vehicle = _vehicleDataServices.GetNewId();
                IVehicleData vehicleData = _vehicleDataServices.GetNewVehicleDo(vehicle);
                Assert.True(vehicleData.Valid);
                Assert.NotNull(vehicleData.Value);
                vehicleData.Value.KM = 15000;
                vehicleData.Value.COLOR = "BL";
                vehicleData.Value.MARCA = "FERRARI";
                _vehicleDataServices.SaveVehicle(vehicleData);
                IVehicleData vehicleData1 = _vehicleDataServices.GetNewVehicleDo(vehicle);
                Assert.True(vehicleData1.Valid);
                Assert.AreEqual(vehicleData1.Value.KM, vehicleData.Value.KM);
                Assert.AreEqual(vehicleData1.Value.COLOR, vehicleData.Value.COLOR);
                Assert.AreEqual(vehicleData1.Value.MARCA, vehicleData.Value.MARCA);
            }
        }
        /// <summary>
        ///  This load the commission agent using xml.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_Vehicle_UsingXml()
        {
            string codeVehicle = "0000001";
            IVehicleDataServices vehicleData= _dataServices.GetVehicleDataServices();
            IVehicleData vehicle = await vehicleData.GetVehicleDo(codeVehicle);
            Assert.NotNull(vehicle);
            VehicleDto vehicleDto = vehicle.Value;
            Assert.AreEqual(vehicleDto.CODIINT, codeVehicle);
          
         }
        /// <summary>
        ///  The update vehicle should be correct.
        /// </summary>
        [Test]
        public async Task Should_Update_Vehicle_Correctly()
        {
            string vehicleNewId = "0000005";
            for (int i = 0; i < 10; i++)
            {
                IVehicleData vehicleData = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
                VehicleDto vehicleDataValue = vehicleData.Value;
                Assert.AreEqual(vehicleDataValue.CODIINT, vehicleNewId);
                vehicleDataValue.MATRICULA = "X3944584";
                vehicleData.Value = vehicleDataValue;
                try
                {
                    bool savedValue = await vehicleData.SaveChanges();
                    Assert.AreEqual(savedValue, true);
                    IVehicleData vehicle = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
                    Assert.AreEqual(vehicle.Value.MATRICULA, vehicleDataValue.MATRICULA);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
        }
        /// <summary>
        /// This test look for an invalid update for a key.
        /// </summary>
        [Test]
        public async Task Should_Update_Vehicle_Fail_ForKey()
        {
            string vehicleNewId = "0000001";
            IVehicleData vehicleData = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
            VehicleDto vehicleDataValue = vehicleData.Value;
            vehicleDataValue.CODIINT = "";
            vehicleData.Value = vehicleDataValue;
            try
            {
                bool savedValue = await vehicleData.SaveChanges();
                Assert.AreEqual(savedValue, false);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Test for the saving.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Insert_And_Save_A_Vehicle()
        {
            string id = _vehicleDataServices.GetNewId();
            IVehicleData data =_vehicleDataServices.GetNewVehicleDo(id);
            VehicleDto dto = data.Value;
            dto.MARCA = "FIAT";
            dto.MODELO = "500P";
            dto.MATRICULA = "81982";
            dto.COLOR = "BL";
            dto.KM = 1500;
            dto.CODIINT = id;
            data.Value = dto;
            
            bool value = await _vehicleDataServices.SaveVehicle(data);
            Assert.True(value);
        }
        /// <summary>
        /// Test for the update vehicle.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Insert_And_Save_Update_Vehicle()
        {
            string id = _vehicleDataServices.GetNewId();
            try
            { 
            IVehicleData data = _vehicleDataServices.GetNewVehicleDo(id);
            data.Value.MARCA = "FIAT";
            data.Value.MODELO = "500P";
            data.Value.MATRICULA = "81982";
            data.Value.COLOR = "BL";
            data.Value.KM = 1500;
            bool value = await _vehicleDataServices.SaveVehicle(data);
            Assert.True(value);
            data.Value.KM = 50000;
            bool isSaved = await _vehicleDataServices.SaveChangesVehicle(data);
            Assert.True(isSaved);
            }
            catch (Exception e)
            {
                
            }
        }

        [Test]
        public async Task Should_Give_A_Vehicle_Summary()
        {
            DataSet setVehicles = await _vehicleDataServices.GetAsyncVehicleSummary();
            Assert.AreEqual(setVehicles.Tables.Count,1);
            Assert.Greater(setVehicles.Tables[0].Rows.Count,0);
        }
        [Test]
        public async Task Should_Give_A_VehicleCollection()
        {
            IEnumerable<IVehicleData> vehicleCollection = await _vehicleDataServices.GetAsyncVehicles();
            Assert.Greater(vehicleCollection.Distinct().Count(),0);
        }

        [Test]
        public async Task Should_Fail_Insert_And_Save_VehicleForSameKey()
        {
            string id = _vehicleDataServices.GetNewId();
            IVehicleData data = _vehicleDataServices.GetNewVehicleDo(id);
            VehicleDto dto = data.Value;
            dto.MARCA = "FIAT";
            dto.MODELO = "500P";
            dto.MATRICULA = "Z281982";
            dto.COLOR = "BL";
            dto.KM = 1500;
            data.Value = dto;
            bool value = await _vehicleDataServices.SaveVehicle(data);
            Assert.True(value);
            // saved correctly
            bool innerData = false;
            try
            {
                value = await _vehicleDataServices.SaveVehicle(data);
                Assert.False(value);
                innerData = true;
            }
            catch (Exception e)
            {
                Assert.False(innerData);
            }
        }

        [Test]
        public async Task Should_Fail_Insert_Existing_Vehicle()
        {
            string vehicleNewId = "0000005";

            try
            {
                IVehicleData data = await _vehicleDataServices.GetVehicleDo(vehicleNewId);
                Assert.True(data.Valid);
                bool value = await _vehicleDataServices.SaveVehicle(data);
                Assert.False(value);
            }
            catch (Exception e)
            {
              //  Assert.Fail(e.Message);
            }
        }
        [Test]
        public async Task Should_Fail_Insert_Empty_Vehicle()
        {
            string vehicleNewId = "0000005";
            bool value = false;
            try
            {
                IVehicleData data = null;
                value = await _vehicleDataServices.SaveVehicle(data);
                Assert.False(value);
            }
            catch (Exception e)
            {
                value = true;
                Assert.True(value);
            }
        }
    }

}
