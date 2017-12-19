using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.ViewModels;
using MasterModule.Views;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using ToolBarModule;

namespace KarveTest.ViewModels
{
    public class TestKarveToolbarViewModel
    {
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        private Mock<VehicleInfoViewModel> _vehicleInfoViewModel = new Mock<VehicleInfoViewModel>();
        private Mock<ICareKeeperService> _careKeeperService = new Mock<ICareKeeperService>();
        private Mock<IVehicleDataServices> _veichleDataServices = new Mock<IVehicleDataServices>();
        private KarveToolBarViewModel _carveBarViewModel;
        private Mock<IRegionManager> _regionManager;
        private Mock<IConfigurationService> _configurationService;

        private void InitToolBar()
        {
            _carveBarViewModel = new KarveToolBarViewModel(_dataServices.Object, 
                                                           _eventManager.Object, 
                                                           _careKeeperService.Object,
                                                           _regionManager.Object,
                                                           _configurationService.Object
                                                           );
            
        }
        /// <summary>
        ///  Ok setup 
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
              InitToolBar();
        }
        /// <summary>
        ///  This tells us if a vehicle has received a data.
        /// </summary>
        [Test]
        public void ShallReceiveAVehicleUpdateMessage()
        {
            // arrange
            IDictionary<string, string> viewModelQueries = new Dictionary<string, string>();
            IVehicleData data = _veichleDataServices.Object.GetNewVehicleDo("1234");
            ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(_eventManager.Object,
                viewModelQueries, DataSubSystem.VehicleSubsystem);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.DataObject = data;
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
              // act.        
            handlerDo.OnUpdate(payLoad, eventDictionary);
            // assert
            Assert.AreSame(payLoad, _carveBarViewModel.CurrentPayLoad);
        }

        [Test]
        public void ShallReceiveAnInsertMessage()
        {
            // arrange
            IVehicleData data = _veichleDataServices.Object.GetNewVehicleDo("123"); 

            IDictionary<string, string> viewModelQueries = new Dictionary<string, string>();
            ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(_eventManager.Object,
                viewModelQueries, DataSubSystem.VehicleSubsystem);
            DataPayLoad payLoad = new DataPayLoad();
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            // act.        
            handlerDo.OnInsert(payLoad, eventDictionary);
            // assert
            Assert.AreSame(payLoad, _carveBarViewModel.CurrentPayLoad);
        }

        [Test]
        public void ShouldReceiveAndUpdateTheData()
        {
            IVehicleData data = _veichleDataServices.Object.GetNewVehicleDo("123");
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = data;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            _carveBarViewModel.IncomingPayload(payLoad);
            // ok we can execute now as the user send a save command.
            _carveBarViewModel.SaveCommand.Execute();
            
        }

        [Test]
        public void ShouldReceiveAndRefuseUpdate()
        {
            IVehicleData data = _veichleDataServices.Object.GetNewVehicleDo("123");
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = data;
            data.Value.CODIINT = null;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            _carveBarViewModel.IncomingPayload(payLoad);
            _carveBarViewModel.SaveCommand.Execute();
        }
       

    }
}
