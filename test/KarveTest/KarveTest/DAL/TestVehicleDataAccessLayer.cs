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
            IEnumerable<VehicleSummaryDto> summary = await _vehicleDataServices.GetAsyncVehicleSummary();
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
                    var vehicleList = await dbConnection.GetAsyncAll<VEHICULO1>();
                    var vehicleValue = vehicleList.FirstOrDefault();
                    Assert.NotNull(vehicleValue);
                    var codeInt = vehicleValue.CODIINT;
                    if (!string.IsNullOrEmpty(codeInt))
                    {
                        var vehicle = new Vehicle(_sqlExecutor);
                        var dictionary = new Dictionary<string, string>();
                        var value = await vehicle.LoadValue(dictionary, codeInt);
                        Assert.IsTrue(value);
                        Assert.NotNull(vehicle.BrandDtos);
                        Assert.Greater(0, vehicle.BrandDtos.Count());
                        Assert.Greater(0, vehicle.ModelDtos.Count());
                        Assert.Greater(0, vehicle.ColorDtos.Count());

                     }
                }
            }
        }

        /// <summary>
        ///  Vehicles1.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Get_A_Paged_List_Of_Vehicules_And_Iterate()
        {
            var count = 0;
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                var allVehicles = await conn.GetAsyncAll<VEHICULO1>();
                count = allVehicles.Count<VEHICULO1>();
            }
            var step = 100;
            for (var i = 1; i < count; i = i + step)
            {
                var summary = await _vehicleDataServices.GetPagedSummaryDoAsync(i, step);
                foreach (var v in summary)
                {
                    Assert.NotNull(v.Code);
                }

            }
        }
    }
}
