using KarveCommon.Services;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using KarveTest.Mock;
using KarveCommonInterfaces;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestOfficeInfoViewModel: TestViewModelBase
    {
        private const string ID_DEFAULT = "00001";
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private IDataServices _dataServices = new MockDataServices();
        private Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private Mock<IInteractionRequestController> _interactionRequest = new Mock<IInteractionRequestController>();
        private CompanyInfoViewModel _companyInfoViewModel = null;
        [OneTimeSetUp]
        public void Setup()
        {
            _companyInfoViewModel = new CompanyInfoViewModel(_eventManager.Object, _configurationService.Object, _dataServices, _mockDialogService.Object,_regionManager.Object, _interactionRequest.Object);
        }
        [Test]
        public void Should_Receive_A_Correct_Payload_And_ExposeDataObject()
        {
            DataPayLoad dataPayLoad = new DataPayLoad();
            dataPayLoad.HasDataObject = true;
            dataPayLoad.PrimaryKeyValue = ID_DEFAULT;
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.NotNull(outObject);
            Assert.Equals(outObject.CODIGO, ID_DEFAULT);
        }
        [Test]
        public void Shall_Refuse_An_Incoming_Null_Payload()
        {
            DataPayLoad dataPayLoad = new NullDataPayload();
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.Null(outObject);
        }
        [Test]
        public void Shall_Refuse_An_Incoming_Payload_WithNullDO()
        {
            DataPayLoad dataPayLoad = new NullDataPayload();
            dataPayLoad.DataObject = null;
            dataPayLoad.HasDataObject = true;
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.Null(outObject.CODIGO);
        }
    }
}
