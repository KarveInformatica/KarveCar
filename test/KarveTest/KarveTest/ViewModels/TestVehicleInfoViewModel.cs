using KarveCommon.Services;
using Moq;
using NUnit.Framework;
using MasterModule.ViewModels;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    [TestFixture]
    internal class TestVehiculoInfoViewModel: TestViewModelBase
    {
       
        private VehicleInfoViewModel _vehicleInfoViewModel;
        [OneTimeSetUp]
        public void SetUp()
        {
            _vehicleInfoViewModel = new VehicleInfoViewModel(_mockConfigurationService.Object, _mockEventManager.Object,
                _mockDialogService.Object,
                _mockDataServices.Object, 
                _mockRegionManager.Object, 
                _mockRequestController.Object);
        }
        /// <summary>
        /// Should correct and point out other subsystem.
        /// </summary>
        [Test]
        public void Should_PointOut_NotCorrect_Subsystem()
        {
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                PayloadType = DataPayLoad.Type.Show,
                Subsystem = DataSubSystem.CommissionAgentSubystem
            };
            _vehicleInfoViewModel.IncomingPayload(payLoad);
            Assert.NotNull(_vehicleInfoViewModel.Error);
            Assert.Null(_vehicleInfoViewModel);
        }
        /// <summary>
        /// Shall discard invalid payload.
        /// </summary>
        [Test]
        public void Should_Discard_InvalidVehicle_Payload()
        {
            _vehicleInfoViewModel.IncomingPayload(null);
            Assert.Null(_vehicleInfoViewModel.DataObject);
        }
        /// <summary>
        ///  Shall show correctly the vehicle.
        /// </summary>
        [Test]
        public void Should_ShowCorrectly_TheVehicle()
        {
            DataPayLoad payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.VehicleSubsystem,
                PayloadType = DataPayLoad.Type.Show
            };
            _vehicleInfoViewModel.IncomingPayload(payLoad);
            Assert.NotNull(_vehicleInfoViewModel.DataObject);
        }

    }
}
