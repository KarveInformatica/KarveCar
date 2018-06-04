using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using InvoiceModule.ViewModels;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices.DataObjects;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Moq;
using Prism.Regions;

namespace KarveCar.Integration
{
    [TestFixture]
    /*
     *  Integration on a test base.
     */
    internal class IntegrateTestInvoiceInfoViewModel: TestIntegrationBase
    {
      
        [Test]
        public async Task ShouldIntegrate_Assist_InvoiceOnInvoiceSummary()
        {
            // prepare
            var dataServices = SetupDataServices();
            var invoiceDs = dataServices.GetInvoiceDataServices();
            var summaryDs = await invoiceDs.GetPagedSummaryDoAsync(1,10);
            var viewModel = new InvoiceInfoViewModel(dataServices, _dialogServices.Object, _eventManager.Object,
                _regionManager.Object, _controller.Object);
            IDictionary<string, string>  controlDictionary = new Dictionary<string, string>();
            controlDictionary["AssistTable"] = InvoiceInfoViewModel.InvoiceAssist;
            // act
            viewModel.AssistCommand.Execute(controlDictionary);
            // assert.

            var invoiceDtos = viewModel.InvoiceDtos;
            Assert.NotNull(invoiceDtos);
            var codesDtomInvoiceDs = invoiceDtos.Select(l=>l.InvoiceCode);
            var codesFromSummaryDs = summaryDs.Select(l => l.InvoiceCode).ToList();
            // filtering just the codes and see that are equal.
            var currentValue = codesDtomInvoiceDs.Except(codesFromSummaryDs);
            Assert.AreEqual(0,currentValue.Count());
        }
        /// <summary>
        /// This is checking and loading a client from the invoice. 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegrateShould_Load_ClientInvoice()
        {
            var dataServices = SetupDataServices();
            var dialogServices = new Mock<IDialogService>();
            var eventManager = new Mock<IEventManager>();
            var regionManager = new Mock<IRegionManager>();
            var controller = new Mock<IInteractionRequestController>();
            var invoiceServices = dataServices.GetInvoiceDataServices();
            var invoiceSummary = await invoiceServices.GetPagedSummaryDoAsync(1, 10);
            var singleInvoice = invoiceSummary.FirstOrDefault();
            if (singleInvoice != null)
            {
                var invoiceDto = await invoiceServices.GetDoAsync(singleInvoice.InvoiceName);
                var dataPayLoad = new DataPayLoad()
                {
                    PayloadType = DataPayLoad.Type.Show,
                    PrimaryKeyValue = invoiceDto.Value.NUMERO_FAC,
                    DataObject = invoiceDto,
                    HasDataObject = true
                };
                var viewModel = new InvoiceInfoViewModel(dataServices, 
                    dialogServices.Object, 
                    eventManager.Object, 
                    regionManager.Object,
                    controller.Object);
                viewModel.IncomingPayload(dataPayLoad);
                Assert.Greater(viewModel.ClientDto.Count(),0);
            }
            else
            {
                Assert.Fail("No invoice in the system");
            }
        }

        
        [Test]
        public void WhenIntegrateShould_ChangeItem_InvoiceSummary()
        {
            var dataServices = SetupDataServices();
            // this setup the toolbar.
            int state = 0;
            var eventManager = new Mock<IEventManager>();
            eventManager.Setup(x =>
                x.NotifyToolBar(It.IsAny<DataPayLoad>())).Callback((DataPayLoad p) =>
            {
                if (state == 0)
                {
                    Assert.AreEqual(DataPayLoad.Type.RegistrationPayload, p.PayloadType);
                    ++state;
                }
                else
                {
                    Assert.AreEqual(DataPayLoad.Type.Update, p.PayloadType);
                    Assert.IsTrue(p.HasDataObject);
                    Assert.NotNull(p.DataObject);
                }
                Assert.IsNotEmpty(p.PrimaryKeyValue);
                Assert.AreEqual(DataSubSystem.InvoiceSubsystem, p.Subsystem);
               
            });
            IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
            valueDictionary["AssitTableName"] = "CLIENT_ASSIST";
            valueDictionary["DataFieldFirst"] = "CLIENT_FAC";
            valueDictionary["DataFieldSecond"] = string.Empty;
            valueDictionary["DataObject"] = new InvoiceDto();
            valueDictionary["Field"] = "CLIENT_FAC";
            valueDictionary["ChangedCode"] = "2881";
            valueDictionary["ChangedValue"] = "2881";
            valueDictionary["ChangedValue2"] = "05";
            var viewModel = new InvoiceInfoViewModel(dataServices, _dialogServices.Object, eventManager.Object,
                _regionManager.Object, _controller.Object);
            var invoiceDto = new InvoiceDto();
            invoiceDto.NUMERO_FAC = "28289";
            var dataPayLoad = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.Update,
                PrimaryKeyValue = "28289",
                DataObject = new Invoice("28289",invoiceDto),
                HasDataObject = true
            };
            viewModel.IncomingPayload(dataPayLoad);
            viewModel.ItemChangedCommand.Execute(valueDictionary);
        }
        [Test]
        public async Task  ShouldIntegrate_Assist_InvoiceOnClientSummary()
        {
            var dataServices = SetupDataServices();
            var clientDs = dataServices.GetClientDataServices();
            var summaryDs = await clientDs.GetPagedSummaryDoAsync(1,2);
            var viewModel = new InvoiceInfoViewModel(dataServices, _dialogServices.Object, _eventManager.Object,
                _regionManager.Object, _controller.Object);
            IDictionary<string, string> controlDictionary = new Dictionary<string, string>();
            controlDictionary["AssistTable"] = InvoiceInfoViewModel.ClientAssist;
            // act
            viewModel.AssistCommand.Execute(controlDictionary);
            // assert.
            var clientsDto = viewModel.ClientDto;
            Assert.NotNull(clientsDto);
            var codesFromDataService = summaryDs.Select(l => l.Codigo).ToList();
            var codesFromClientService = clientsDto.Select(l => l.Code).ToList();
            var clientValue = codesFromDataService.Except(codesFromClientService);
            Assert.AreEqual(clientValue.Count(), 0);

        }

        [Test]
        public void ShouldIntegrate_AddClient_OnInvoice()
        {
            var dataServices = SetupDataServices();
            var eventManager = new Mock<IEventManager>();
            var regionManager = new Mock<IRegionManager>();
            eventManager.Setup(x =>
                x.NotifyObserverSubsystem(It.IsAny<string>(), It.IsAny<DataPayLoad>())).Callback((string s, DataPayLoad p) =>
            {
                Assert.AreEqual(s, EventSubsystem.ClientSummaryVm);
                Assert.AreEqual(p.PayloadType, DataPayLoad.Type.Insert);
                Assert.AreEqual(p.Subsystem, DataSubSystem.ClientSubsystem);
                Assert.IsNotEmpty(p.PrimaryKeyValue);
                Assert.IsTrue(p.HasDataObject);
                Assert.NotNull(p.DataObject);
            });
            regionManager.Setup(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>()))
                .Callback((string first, Uri second) =>
                {
                    Assert.AreEqual(first, "TabRegion");
                    Assert.NotNull(second);
                });
            var viewModel = new InvoiceInfoViewModel(dataServices, _dialogServices.Object, eventManager.Object,
                regionManager.Object, _controller.Object);
            viewModel.AddNewClientCommand.Execute(null);

        }

    }
}
