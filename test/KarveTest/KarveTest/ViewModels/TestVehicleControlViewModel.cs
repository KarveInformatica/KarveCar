using KarveCommon.Services;
using KarveDataServices;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterModule;
using MasterModule.ViewModels;
using Microsoft.Practices.Unity;
using KarveDataServices.ViewObjects;
using MasterModule.Common;
using KarveCommon.Generic;
using MasterModule.Views;
using System.Windows.Input;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  This test in isolation the control view model.
    /// </summary>
    class TestVehicleControlViewModel
    {
        private Mock<IConfigurationService> _mockConfigurationService = new Mock<IConfigurationService>();
        private Mock<IDataServices> _mockDataServices = new Mock<IDataServices>();
        private Mock<IEventManager> _mockEventManager = new Mock<IEventManager>();
        private Mock<IRegionManager> _mockRegionManager = new Mock<IRegionManager>();
        private Mock<UnityContainer> _mockUnityContainer = new Mock<UnityContainer>();
        private VehiclesControlViewModel _vehicleControlViewModel;
        private DataPayLoad currentPayload = new DataPayLoad();

        [OneTimeSetUp]
        public void SetUp()
        {
            // This code simulate the return from the data base of a list of vehicles.
            _mockDataServices.Setup(x => x.GetVehicleDataServices().GetSummaryAllAsync()).ReturnsAsync(
                (() => new List<VehicleSummaryViewObject>()
                {
                            new VehicleSummaryViewObject(){ Code = "12920", Brand="FIAT" },
                            new VehicleSummaryViewObject(){ Code=  "12892", Brand="FIAT" },
                            new VehicleSummaryViewObject(){ Code = "12282", Brand="FIAT" },
                            new VehicleSummaryViewObject(){ Code = "12289", Brand="FIAT" }
                }));
            _vehicleControlViewModel = new VehiclesControlViewModel( _mockConfigurationService.Object, _mockEventManager.Object, _mockDataServices.Object, _mockUnityContainer.Object, _mockRegionManager.Object);
            _mockEventManager.Setup(x => x.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, currentPayload));
            _mockRegionManager.Setup(x => x.RequestNavigate("TabRegion", ""));
         
        }
        [Test]
        public void Should_Load_Vehicle_Summary_Correctly()
        {
            // you shall load the summary correctly.
            _vehicleControlViewModel.StartAndNotify();
            Assert.NotNull(_vehicleControlViewModel.SummaryView);
            var viewModel = _vehicleControlViewModel.SummaryView as List<VehicleSummaryViewObject>;
            Assert.NotNull(viewModel);
            Assert.AreSame(viewModel.Count<VehicleSummaryViewObject>(),4);
        }
        [Test]
        public void Should_Open_AVehicleCorrectly()
        {
            bool navigateCalled = false;
            // arrange
            Tuple<string, string> idNameTuple = new Tuple<string, string>("12920", "FIAT");
            string tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", idNameTuple.Item1);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
            var uri = new Uri(typeof(VehicleInfoView).FullName + navigationParameters, UriKind.Relative);
            _mockRegionManager.Setup(foo => foo.RequestNavigate("TabRegion", uri)).Callback(() => navigateCalled = true);
            // act.
            Assert.NotNull(_vehicleControlViewModel.OpenItem);
            ICommand command = _vehicleControlViewModel.OpenItem;
            VehicleSummaryViewObject summaryItem = new VehicleSummaryViewObject();
            summaryItem.Code = "12920";
            summaryItem.Brand = "FIAT";
            command.Execute(summaryItem);
            // assert
            Assert.IsTrue(navigateCalled);
        }
    }
}
