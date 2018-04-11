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

namespace KarveTest.DAL
{
    /// <summary>
    ///  Test for the Test Vehicle Data Services. 
    ///  It tests the functionality out of the box for the data services.
    /// </summary>
    class TestVehicleDataAccessLayer : TestBase
    {
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
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
        [Test]
        public async Task Should_Get_AListOfVehicles()
        {
            IEnumerable<VehicleSummaryDto> summary = await _vehicleDataServices.GetAsyncVehicleSummary();
            Assert.Greater(summary.Count(), 0);
            // code shall not be null.
            foreach (var v in summary)
            {
                Assert.NotNull(v.Code);
            }
        }
        /// <summary>
        ///  Vehicles1.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Get_A_Paged_List_Of_Vehicules_And_Iterate()
        {
            int count = 0;
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                var allVehicles = await conn.GetAsyncAll<VEHICULO1>();
                count = allVehicles.Count<VEHICULO1>();
            }
            var step = 5;
            for (int i = 0; i < count; i = i + step)
            {
                var summary = await _vehicleDataServices.GetVehiclesAgentSummary(step, i);
                foreach (var v in summary)
                {
                    Assert.NotNull(v.Code);
                }
            }
        }
    }
}
