using MasterModule.ViewModels;
using NUnit.Framework;
using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using KarveCommon.Services;

namespace KarveCar.Integration
{
    [TestFixture]
    class TestClientInfoViewModel : TestIntegrationBase
    {
        private ClientsInfoViewModel _viewModel;
        private IDataServices _dataServices;
        private IDialogService _dialogService;
        [SetUp]
        public void SetUp()
        {
            _dataServices = SetupDataServices();
            _viewModel = new ClientsInfoViewModel(
                 _eventManager.Object,
                 _configuration.Object,
                _dataServices,
                _dialogServices.Object,
                _regionManager.Object,
                _controller.Object);

        }
        [Test]
        public async Task WhenIntegrated_Should_SaveCreditCardExpirationData()
        {
            var clientService = _dataServices.GetClientDataServices();
            var sampleClient = await clientService.GetPagedSummaryDoAsync(1, 2);
            var firstClient = sampleClient.FirstOrDefault();
            var clientData = await clientService.GetDoAsync(firstClient.Code);
            _viewModel.DataObject = clientData.Value;
            _viewModel.ExpireMonth = "10";
            _viewModel.ExpireYear = "22";
            clientData.Value = _viewModel.DataObject;

            var returnValue = await clientService.SaveAsync(clientData);
            Assert.IsTrue(returnValue);
            var newClient = await clientService.GetDoAsync(firstClient.Code);
            Assert.AreEqual(newClient.Value.TARCADU, "10/22");
        }
        [Test]
        public async Task WhenIntegrated_Should_LoadCreditCardExpirationData()
        {
            var clientService = _dataServices.GetClientDataServices();
            var sampleClient = await clientService.GetPagedSummaryDoAsync(1, 2);
            var firstClient = sampleClient.FirstOrDefault();
            var clientData = await clientService.GetDoAsync(firstClient.Code);
            clientData.Value.CreditCardExpiryMonth = "05";
            clientData.Value.CreditCardExpiryYear= "27";

            var returnValue = await clientService.SaveAsync(clientData);
            var newClient = await clientService.GetDoAsync(firstClient.Code);
            var payLoad = new DataPayLoad();
            payLoad.DataObject = clientData;
            payLoad.HasDataObject = true;
            payLoad.PayloadType = DataPayLoad.Type.Show;
            payLoad.PrimaryKeyValue = clientData.Value.NUMERO_CLI;
            _viewModel.IncomingPayload(payLoad);
            Assert.AreEqual("05",_viewModel.ExpireMonth);
            Assert.AreEqual("27",_viewModel.ExpireYear);
        }

    }
}
