using KarveDataServices;
using NUnit.Framework;
using System;
using KarveCommon.Services;
using System.Collections.Generic;
using KarveDataServices.DataTransferObject;
using System.Threading.Tasks;
using System.Linq;
using DataAccessLayer;
using System.Data;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using KarveDataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;

namespace KarveTest.DAL
{
    /// <summary>
    ///  Test for the Test Vehicle Data Services. 
    ///  It tests the functionality out of the box for the data services.
    /// </summary>
    class TestVehicleDataAccessLayer : TestBase
    {
        
        private IDataServices _dataServices;
        private IConfigurationService _serviceConf;
        private IVehicleDataServices _vehicleDataServices;
        private IVehicleDataServices _vehicleServicesMocked;
        private ISqlExecutor _sqlExecutor;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _vehicleDataServices = _dataServices.GetVehicleDataServices();

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        ///  We should get a list of vehicles.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Get_AListOfVehicles()
        {
            IEnumerable<VehicleSummaryDto> summary = await _vehicleDataServices.GetSummaryAllAsync();
            var vehicleSummaryDtos = summary as VehicleSummaryDto[] ?? summary.ToArray();
            Assert.Greater(vehicleSummaryDtos.Count(), 0);
            // code shall not be null.
            foreach (var v in vehicleSummaryDtos)
            {
                Assert.NotNull(v.Code);
            }
        }
        /// <summary>
        /// Get a vehicle correctly.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_AVehicleAndHelpersCorrectly()
        {
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var vehicleList = await dbConnection.GetPagedAsync<VEHICULO1>(1,2).ConfigureAwait(false);
                    var vehicleValue = vehicleList.FirstOrDefault();
                    Assert.NotNull(vehicleValue);
                    var codeInt = vehicleValue.CODIINT;
                    if (!string.IsNullOrEmpty(codeInt))
                    {
                        var vehicle = await _vehicleDataServices.GetDoAsync(codeInt).ConfigureAwait(false);
                        Assert.IsTrue(vehicle.Valid);
                        Assert.NotNull(vehicle.BrandDtos);
                        Assert.Greater(vehicle.BrandDtos.Count(),0);
                        Assert.Greater(vehicle.ModelDtos.Count(), 0);
                        Assert.Greater(vehicle.ColorDtos.Count(), 0);
                    }
                }
            }
        }

        [Test]
        public async Task Should_Update_AValidVehicle()
        {
            // arrange.
            var vehicles = await _vehicleDataServices.GetPagedSummaryDoAsync(1, 2).ConfigureAwait(false);
            var vehicle = vehicles.FirstOrDefault();
            var code = vehicle.Code;
            var currentVehicle = await _vehicleDataServices.GetDoAsync(code).ConfigureAwait(false);
            // act 
            currentVehicle.Value.DANOS = "UpperData not corrected";
            var configure = await _vehicleDataServices.SaveAsync(currentVehicle).ConfigureAwait(false);
            // now we can see if the currentVehicle is correct or not.
            var savedCheck = await _vehicleDataServices.GetDoAsync(vehicle.Code).ConfigureAwait(false);
            Assert.AreEqual(currentVehicle.Value.DANOS, savedCheck.Value.DANOS);
        }
        [Test]
        public async Task Should_Insert_AValidVehicle()
        {
            var id = _vehicleDataServices.NewId();
            var vehicle = _vehicleDataServices.GetNewDo(id);
            vehicle.Value.DANOS = "Todo roto";
            var configure = await _vehicleDataServices.SaveAsync(vehicle).ConfigureAwait(false);
            // now we can see if the currentVehicle is correct or not.
            var savedCheck = await _vehicleDataServices.GetDoAsync(vehicle.Value.CODIINT).ConfigureAwait(false);
            Assert.AreEqual(vehicle.Value.DANOS, savedCheck.Value.DANOS);
        }
        /// <summary>
        ///  Vehicles1.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Get_APagedListOfVehiculesAndIterate()
        {
            var step = 2000;
            var count = _vehicleDataServices.GetPageCount(2000);
            var numberOfVehicles = _vehicleDataServices.NumberItems;
            for (var i = 1; i < numberOfVehicles; i = i + step)
            {
                var summary = await _vehicleDataServices.GetPagedSummaryDoAsync(i, step);
                foreach (var v in summary)
                {
                    Assert.IsTrue(v.IsValid);
                    Assert.NotNull(v.Code);
                }
            }
        }

    }
}
