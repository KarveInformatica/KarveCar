using System;
using KarveCommon.Services;
using KarveDataServices;
using KarveTest.Mock;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using HelperModule.ViewModels;
using System.Windows.Input;
using KarveDataServices.ViewObjects;

namespace KarveTest.ViewModels
{

    /// <summary>
    ///  This is the test helper view model.
    /// </summary>
    public class TestVehicleTypeViewModel 
    {
        /// <summary>
        ///  EventManager
        /// </summary>
        private static Mock<IEventManager> mockEventManager = new Mock<IEventManager>();
        private IEventManager _eventManager = mockEventManager.Object;
        /// <summary>
        ///  MockDataServices
        /// </summary>
        private MockDataServices _dataServices = new MockDataServices();
        /// <summary>
        ///  Region Manager
        /// </summary>
        private Mock<IRegionManager> _regionManager= new Mock<IRegionManager>();
        /// <summary>
        ///  VehicleTypesViewModel.
        /// </summary>
        private VehicleTypesViewModel _vehicleTypeViewModel;
        
        [OneTimeSetUp]
        public void Setup()
        {
            InitHelper();
        }
 
        /// <summary>
        ///  This test simulate a vehicle type selection.
        /// </summary>
        [Test]
        private void Should_UpdateDto_After_GridSelection()
        {
            // Arrange
            ICommand command =  _vehicleTypeViewModel.SelectionChangedCommand;
            VehicleTypeViewObject viewObject  = new VehicleTypeViewObject();
            viewObject.Code = "5L";
            viewObject.Name = "500P";
            viewObject.WebName = "Fiat 500";
            viewObject.OfferMargin = 1;
            viewObject.TerminationDate = DateTime.Now;
            // Act
            command.Execute(viewObject);
           // Assert.
            VehicleTypeViewObject resultViewObject = _vehicleTypeViewModel.HelperDto;
            Assert.AreEqual(viewObject.Code, resultViewObject.Code);
            Assert.AreEqual(viewObject.Name, resultViewObject.Name);
            Assert.AreEqual(viewObject.WebName, resultViewObject.WebName);
            Assert.AreEqual(viewObject.OfferMargin, resultViewObject.OfferMargin);
            Assert.AreEqual(viewObject.TerminationDate, resultViewObject.TerminationDate);
        }
     
        [Test]
        private void Should_Update_After_ItemChangedCommand()
        {
            // arrange
            ICommand command = _vehicleTypeViewModel.ItemChangedCommand;
            VehicleTypeViewObject viewObject = new VehicleTypeViewObject();
            viewObject.Code = "5L";
            viewObject.Name = "500P";
            viewObject.WebName = "Fiat 500";
            viewObject.OfferMargin = 1;
            viewObject.TerminationDate = DateTime.Now;
            // act
            command.Execute(viewObject);
            VehicleTypeViewObject resultViewObject = _vehicleTypeViewModel.HelperDto;
            // assert
            Assert.AreEqual(viewObject.Code, resultViewObject.Code);
            Assert.AreEqual(viewObject.Name, resultViewObject.Name);
            Assert.AreEqual(viewObject.WebName, resultViewObject.WebName);
            Assert.AreEqual(viewObject.OfferMargin, resultViewObject.OfferMargin);
            Assert.AreEqual(viewObject.TerminationDate, resultViewObject.TerminationDate);
        }
        private void InitHelper()
        {
            // I dont think at this point that the region manager is available.
            _vehicleTypeViewModel =
                new VehicleTypesViewModel(_dataServices, _regionManager.Object, _eventManager, null);
 
        }
    }

}