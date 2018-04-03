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
    internal class TestVehiculoInfoViewModel: TestViewModelBase
    {
       
        private VehicleInfoViewModel _vehicleInfoViewModel;
        [OneTimeSetUp]
        public void SetUp()
        {
            _vehicleInfoViewModel = new VehicleInfoViewModel(_mockConfigurationService.Object, _mockEventManager.Object,
                _mockDialogService.Object,
                _mockAssistService.Object,
                _mockDataServices.Object, 
                _mockRegionManager.Object);
        }
        /// <summary>
        /// Should correct and point out other subsystem.
        /// </summary>
        public void Should_Point_Not_Correct_Subsystem()
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
            _vehicleInfoViewModel.IncomingPayload(payLoad);
            Assert.NotNull(_vehicleInfoViewModel.Error);
            Assert.Null(_vehicleInfoViewModel);
        }
        /// <summary>
        /// Shall discard invalid payload.
        /// </summary>
        public void Should_Discard_Invalid_Payload()
        {
            DataPayLoad payLoad = null;
            _vehicleInfoViewModel.IncomingPayload(payLoad);
            Assert.Null(payLoad);
        }
        /// <summary>
        ///  Shall show correctly the vehicle.
        /// </summary>
        public void Shall_ShowCorrectly_TheVehicle()
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            _vehicleInfoViewModel.IncomingPayload(payLoad);
            Assert.NotNull(_vehicleInfoViewModel.DataObject);
        }

    }
}
