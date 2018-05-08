using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon;
using KarveCommon.Services;
using KarveCommonInterfaces;
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
        private Mock<IDialogService> _dialogService = new Mock<IDialogService>();
        private Mock<IConfigurationService> _configurationService;
        private bool _messageErrorCalled = false;
        private void InitToolBar()
        {
            _carveBarViewModel = new KarveToolBarViewModel(_dataServices.Object, 
                                                           _eventManager.Object, 
                                                           _careKeeperService.Object,
                                                           _regionManager.Object,
                                                           _dialogService.Object,
                                                           _configurationService.Object
                                                           );
            _dialogService.Setup(x => x.ShowErrorMessage(It.IsAny<string>())).Callback(() =>
                {
                    _messageErrorCalled = true;
                });


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
        public void Should_ReceiveAVehicle_UpdateMessage()
        {
            // arrange
            IDictionary<string, string> viewModelQueries = new Dictionary<string, string>();
            IVehicleData data = _veichleDataServices.Object.GetNewVehicleDo("1234");
            KarveCommon.ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(_eventManager.Object,DataSubSystem.VehicleSubsystem);
            DataPayLoad payLoad = new DataPayLoad
            {
                HasDataObject = true,
                DataObject = data
            };
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
              // act.        
            handlerDo.OnUpdate(payLoad, eventDictionary);
            // assert
            Assert.AreSame(payLoad, _carveBarViewModel.CurrentPayLoad);
        }

        [Test]
        public void Should_ReceiveAVehicle_InsertMessage()
        {
            // arrange
            var data = _veichleDataServices.Object.GetNewVehicleDo("123"); 

            IDictionary<string, string> viewModelQueries = new Dictionary<string, string>();
            var handlerDo = new ChangeFieldHandlerDo<IVehicleData>(_eventManager.Object,
                viewModelQueries, DataSubSystem.VehicleSubsystem);
            var payLoad = new DataPayLoad();
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            // act.        
            handlerDo.OnInsert(payLoad, eventDictionary);
            // assert
            Assert.AreSame(payLoad, _carveBarViewModel.CurrentPayLoad);
        }

        [Test]
        public void Should_ReceiveAUpdateTheData()
        {
            var data = _veichleDataServices.Object.GetNewVehicleDo("123");
            var payLoad = new DataPayLoad
            {
                DataObject = data,
                PayloadType = DataPayLoad.Type.Update,
                Subsystem = DataSubSystem.VehicleSubsystem
            };
            _carveBarViewModel.IncomingPayload(payLoad);
            // ok we can execute now as the user send a save command.
            _carveBarViewModel.SaveCommand.Execute();
            Assert.Fail();
        }

        [Test]
        public void Should_UncorrectVehicle_UpdateRefuse()
        {
            var data = _veichleDataServices.Object.GetNewVehicleDo("123");
            var payLoad = new DataPayLoad {DataObject = data};
            data.Value.CODIINT = null;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            _carveBarViewModel.IncomingPayload(payLoad);
            _carveBarViewModel.SaveCommand.Execute();
            // the value shall avoid saving 
            Assert.Fail();
        }
       

    }
}
