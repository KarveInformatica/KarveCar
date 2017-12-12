using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Moq;
using NUnit.Framework;
using MasterModule.ViewModels;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    [TestFixture]
    public class TestVehiculoInfoViewModel
    {
        private Mock<IConfigurationService> _mockConfigurationService = new Mock<IConfigurationService>();
        private Mock<IDataServices> _mockDataServices = new Mock<IDataServices>();
        private Mock<IEventManager> _mockEventManager = new Mock<IEventManager>();
        private Mock<IRegionManager> _mockRegionManager = new Mock<IRegionManager>();

        [OneTimeSetUp]
        public void SetUp()
        {

         // _mockDataServices.Setup(foo => foo.Name).Returns("bar");
        }

        /// <summary>
        /// Should correct and point out other subsystem.
        /// </summary>
        public void Should_Point_Not_Correct_Subsystem()
        {
            VehicleInfoViewModel vehicleInfoView = new VehicleInfoViewModel(_mockConfigurationService.Object,
                _mockEventManager.Object, _mockDataServices.Object, _mockRegionManager.Object);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
            vehicleInfoView.IncomingPayload(payLoad);
            Assert.NotNull(vehicleInfoView.Error);
            Assert.Null(vehicleInfoView);
        }
        /// <summary>
        /// Shall discard invalid payload.
        /// </summary>
        public void Should_Discard_Invalid_Payload()
        {
            VehicleInfoViewModel vehicleInfoView = new VehicleInfoViewModel(_mockConfigurationService.Object,
                _mockEventManager.Object, _mockDataServices.Object, _mockRegionManager.Object);
            DataPayLoad payLoad = null;
            vehicleInfoView.IncomingPayload(payLoad);
            Assert.Null(payLoad);
        }
        /// <summary>
        ///  Shall show correctly the vehicle.
        /// </summary>
        public void Shall_ShowCorrectly_TheVehicle()
        {
            VehicleInfoViewModel vehicleInfoView = new VehicleInfoViewModel(_mockConfigurationService.Object,
                _mockEventManager.Object, _mockDataServices.Object, _mockRegionManager.Object);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            vehicleInfoView.IncomingPayload(payLoad);
            Assert.NotNull(vehicleInfoView.DataObject);
        }
        
    }
}
