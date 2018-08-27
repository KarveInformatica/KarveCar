﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DtoWrapper;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using KarveTest.Mock;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Prism.Regions;
using KarveDapper;
using KarveDapper.Extensions;
using Dapper;
using DataAccessLayer.DataObjects;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  TODO: Test supplier info view model in isolation.
    /// </summary>
    [TestFixture]
    internal class TestProviderInfoViewModel: TestViewModelBase
    {
        /*
        private ProviderInfoViewModel _infoViewModel;
        private readonly Mock<ISupplierDataServices> _supplierDataServices = new Mock<ISupplierDataServices>();
        [OneTimeSetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public async void Should_Update_SupplierViewWithANewPayload()
        {
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
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
            Assert.AreEqual(_infoViewModel.DelegationCollection, dataObject.BranchesViewObject);
            Assert.AreEqual(_infoViewModel.ContactsCollection, dataObject.ContactsViewObject);
           
        }

        [Test]
        public async Task Should_Update_ViewItem()
        {
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.SupplierSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Update
            };
            _infoViewModel.IncomingPayload(payLoad);
        }
        [Test]
        public async Task Should_Insert_NewProvider()
        {
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            var dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.SupplierSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Insert
            };
            _infoViewModel.IncomingPayload(payLoad);
        }

        [Test]
        public async Task Should_Delete_SupplierItem()
        {

            ISupplierData data = new Supplier();
            data.Value = new SupplierViewObject();
            string validCodeSupplier = string.Empty;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var asyncValue = await dbConnection.GetPagedAsync<PROVEE1>(8, 20);
                var currentValue = asyncValue.FirstOrDefault();
                validCodeSupplier = currentValue.NUM_PROVEE;
            }
                   
           data.Value.NUM_PROVEE = validCodeSupplier;
            var dataServices = new Mock<IDataServices>();
            var supplierDataServices = new Mock<ISupplierDataServices>();
            supplierDataServices.Setup(x=>x.GetAsyncSupplierDo(It.IsAny<string>())).ReturnsAsync(data);
            supplierDataServices.Setup(c => c.DeleteAsyncSupplierDo(It.IsAny<ISupplierData>())).ReturnsAsync(true);
            dataServices.Setup(x=>x.GetSupplierDataServices()).Returns(supplierDataServices.Object);
            // arrange
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.SupplierSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Delete
            };
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
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.VehicleSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Delete
            };
            supplierDataServices.Verify(c => c.DeleteAsyncSupplierDo(dataObject), Times.Never);
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never);
            // Act.
            _infoViewModel.IncomingPayload(payLoad);

        }

        [Test]
        public async Task Should_Load_A_Supplier_Correctly()
        {
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            Assert.AreEqual(value, dataObject.Value.NUM_PROVEE);
           
        }
        public async Task<ISupplierData> ArrangeDataObject()
        {
            IEnumerable<SupplierSummaryViewObject> summary = await _supplierDataServices.Object.GetSupplierAsyncSummaryDo();
            var value = summary.FirstOrDefault();
            Assert.NotNull(value);
            ISupplierData dataObject = await _supplierDataServices.Object.GetAsyncSupplierDo(value.Codigo);
            return dataObject;
        }
        [Test]
        public void ShouldProviderViewModel_Detect_ToolbarAChange()
        {
            var dataObject = ArrangeDataObject();
            Mock<IDataServices> dataServices = new Mock<IDataServices>();
            Mock<IConfigurationService> serviceConf = new Mock<IConfigurationService>();
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.SupplierSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Update
            };
            _mockEventManager.Setup(notify => notify.NotifyToolBar(payLoad)).Verifiable();
            IDictionary<string,object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataObject"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async Task Should_Avoid_Notification_WithBad_Keys_During_A_Change()
        {
            var dataObject = await ArrangeDataObject();
            var dataServices = new Mock<IDataServices>();
            var serviceConf = new Mock<IConfigurationService>();
            DataPayLoad payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.SupplierSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Update
            };
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }

        [Test]
        public async Task Should_Avoid_NotificationWith_BadSubSystemDuringAChange()
        {
            ISupplierData dataObject = await ArrangeDataObject();
            var payLoad = new DataPayLoad
            {
                HasDataObject = true,
                Subsystem = DataSubSystem.VehicleSubsystem,
                DataObject = dataObject,
                PayloadType = DataPayLoad.Type.Update
            };
            _mockEventManager.Verify(notify => notify.NotifyToolBar(payLoad), Times.Never());
            IDictionary<string, object> eventDictionary = new Dictionary<string, object>();
            eventDictionary["DataParameters"] = dataObject;
            _infoViewModel.ItemChangedCommand.Execute(eventDictionary);
        }
        */
    }
}
