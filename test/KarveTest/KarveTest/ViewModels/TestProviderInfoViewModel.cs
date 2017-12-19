using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    [TestFixture]
    public class TestProviderInfoViewModel: KarveTest.DAL.TestBase
    {
        private IDataServices _dataServices;
        private IConfigurationService _serviceConf;
        private Mock<IEventManager> _eventManager  = new Mock<IEventManager>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(executor);
              //  _supplierDataServices = _dataServices.GetSupplierDataServices();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
           
        }

        [Test]
        public async void Shall_Update_The_View_with_a_new_payload()
        {
            IEnumerable<SupplierSummaryDto> summary = await _dataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _dataServices.GetSupplierDataServices().GetAsyncSupplierDo(value.Codigo);
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, _serviceConf, _dataServices, _regionManager.Object);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            infoViewModel.IncomingPayload(payLoad);
            Assert.AreSame(infoViewModel.DataObject, payLoad.DataObject);
            Assert.AreEqual(infoViewModel.DelegationCollection, dataObject.BranchesDtos);
            Assert.AreEqual(infoViewModel.ContactsCollection, dataObject.ContactsDtos);
           
        }

        [Test]
        public async void Should_Update_View_Item()
        {
            IEnumerable<SupplierSummaryDto> summary = await _dataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _dataServices.GetSupplierDataServices().GetAsyncSupplierDo(value.Codigo);
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, _serviceConf, _dataServices, _regionManager.Object);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            infoViewModel.IncomingPayload(payLoad);
        }
        [Test]
        public async void Should_Insert_A_New_Item()
        {
            IEnumerable<SupplierSummaryDto> summary = await _dataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _dataServices.GetSupplierDataServices().GetAsyncSupplierDo(value.Codigo);
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, _serviceConf, _dataServices, _regionManager.Object);
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Insert;
            infoViewModel.IncomingPayload(payLoad);
        }

        [Test]
        public async void Should_Delete_Item()
        {

            // arrange
            IEnumerable<SupplierSummaryDto> summary = await _dataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _dataServices.GetSupplierDataServices().GetAsyncSupplierDo(value.Codigo);
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            Mock<ISupplierDataServices> supplierDataServices= new Mock<ISupplierDataServices>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            supplierDataServices.Setup(c => c.DeleteAsyncSupplierDo(dataObject)).ReturnsAsync(true);
            _eventManager.Setup(notify => notify.NotifyToolBar(payLoad)).Verifiable();
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            // Act.
            infoViewModel.IncomingPayload(payLoad);

        }

        [Test]
        public async void Should_Avoid_Deletion_From_AnotherSubsystem()
        {
            var dataObject = await ArrangeInfoViewModelTest();
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
            _eventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never);
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            // Act.
            infoViewModel.IncomingPayload(payLoad);

        }

        [Test]
        public async void Should_Avoid_DeletionOf_ANoExistantObject()
        {
            var dataObject = await ArrangeInfoViewModelTest();
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
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            // Act.
            infoViewModel.IncomingPayload(payLoad);

        }
        [Test]
        private async Task<ISupplierData> ArrangeInfoViewModelTest()
        {
            IEnumerable<SupplierSummaryDto> summary = await _dataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _dataServices.GetSupplierDataServices().GetAsyncSupplierDo(value.Codigo);
            return dataObject;
        }
        [Test]
        public async void Should_Detect_A_Change()
        {
            ISupplierData dataObject = await ArrangeInfoViewModelTest();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _eventManager.Setup(notify => notify.NotifyToolBar(payLoad)).Verifiable();
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            IDictionary<string,object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataObject"] = dataObject;
            infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async void Should_Avoid_Notification_WithBad_Keys_During_A_Change()
        {
            ISupplierData dataObject = await ArrangeInfoViewModelTest();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _eventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async void Should_Avoid_Notification_With_BadSubSystem_During_A_Change()
        {
            ISupplierData dataObject = await ArrangeInfoViewModelTest();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.DataObject = dataObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _eventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            ProviderInfoViewModel infoViewModel = new ProviderInfoViewModel(_eventManager.Object, serviceConf.Object, dataServices.Object, _regionManager.Object);
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }
    }
}
