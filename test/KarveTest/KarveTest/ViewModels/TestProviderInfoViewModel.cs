using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveTest.Mock;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    [TestFixture]
    internal class TestProviderInfoViewModel: TestViewModelBase
    {
        private ProviderInfoViewModel _infoViewModel;
        private readonly Mock<ISupplierDataServices> _supplierDataServices = new Mock<ISupplierDataServices>();
        [OneTimeSetUp]
        public void SetUp()
        {
            _infoViewModel = new ProviderInfoViewModel(_mockEventManager.Object,
            _mockConfigurationService.Object,
            _mockDataServices.Object,
            _mockDialogService.Object,
            _mockRegionManager.Object, 
            _mockRequestController.Object);
           // _supplierDataServices.Setup(x=>x.GetAsyncSupplierDo())
         
        }

        [Test]
        public async void Should_Update_SupplierViewWithANewPayload()
        {
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
           
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            _infoViewModel.IncomingPayload(payLoad);
            Assert.AreSame(_infoViewModel.DataObject, payLoad.DataObject);
            Assert.AreEqual(_infoViewModel.DelegationCollection, dataObject.BranchesDto);
            Assert.AreEqual(_infoViewModel.ContactsCollection, dataObject.ContactsDto);
           
        }

        [Test]
        public async void Should_Update_ViewItem()
        {
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _infoViewModel.IncomingPayload(payLoad);
        }
        [Test]
        public async Task Should_Insert_NewProvider()
        {
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Insert;
            _infoViewModel.IncomingPayload(payLoad);
        }

        [Test]
        public async Task Should_Delete_SupplierItem()
        {

            ISupplierData data = new Supplier();
            data.Value = new SupplierDto();
            data.Value.NUM_PROVEE = "01";
            var dataServices = new Mock<IDataServices>();
            var supplierDataServices = new Mock<ISupplierDataServices>();
            supplierDataServices.Setup(x=>x.GetAsyncSupplierDo(It.IsAny<string>())).ReturnsAsync(data);
            supplierDataServices.Setup(c => c.DeleteAsyncSupplierDo(It.IsAny<ISupplierData>())).ReturnsAsync(true);
            dataServices.Setup(x=>x.GetSupplierDataServices()).Returns(supplierDataServices.Object);
            // arrange
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            _mockEventManager.Setup(notify => notify.NotifyToolBar(payLoad)).Verifiable();
           
            // Act.
            _infoViewModel.IncomingPayload(payLoad);

        }

        [Test]
        public async Task Should_AvoidDeletion_FromAnotherSubsystem()
        {
            var dataObject = await ArrangeDataObject();
            Assert.NotNull(dataObject);
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            Mock<ISupplierDataServices> supplierDataServices = new Mock<ISupplierDataServices>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            supplierDataServices.Verify(c => c.DeleteAsyncSupplierDo(dataObject), Times.Never);
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never);
            // Act.
            _infoViewModel.IncomingPayload(payLoad);

        }

        [Test]
        public async void Should_Avoid_DeletionOf_ANoExistantObject()
        {
            var dataObject = await ArrangeDataObject();
            Assert.NotNull(dataObject);
            // Arrange.
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            Mock<ISupplierDataServices> supplierDataServices = new Mock<ISupplierDataServices>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            dataObject.Value.NUM_PROVEE = "-233133";
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            // Act.
            _infoViewModel.IncomingPayload(payLoad);

        }
        [Test]
        private async Task<ISupplierData> Should_Load_A_Supplier_Correctly()
        {
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            Assert.AreEqual(value, dataObject.Value.NUM_PROVEE);
            return dataObject;
        }
        private async Task<ISupplierData> ArrangeDataObject()
        {
            IEnumerable<SupplierSummaryDto> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            return dataObject;
        }
        [Test]
        public void Should_Detect_ToolbarAChange()
        {
            var dataObject = ArrangeDataObject();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
           _mockEventManager.Setup(notify => notify.NotifyToolBar(payLoad)).Verifiable();
            IDictionary<string,object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataObject"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async Task Should_Avoid_Notification_WithBad_Keys_During_A_Change()
        {
            ISupplierData dataObject = await ArrangeDataObject();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async Task Should_Avoid_Notification_With_BadSubSystem_During_A_Change()
        {
            ISupplierData dataObject = await ArrangeDataObject();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }
    }
}
