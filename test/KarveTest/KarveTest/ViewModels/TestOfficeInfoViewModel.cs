using KarveCommon.Services;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using KarveTest.Mock;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestOfficeInfoViewModel
    {
        private const string ID_DEFAULT = "00001";
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private IDataServices _dataServices = new MockDataServices();
        private Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private CompanyInfoViewModel _companyInfoViewModel = null;
        public TestOfficeInfoViewModel()
        {
            _companyInfoViewModel = new CompanyInfoViewModel(_eventManager.Object, _configurationService.Object, _dataServices, _regionManager.Object);
        }
        [Test]
        public void Setup()
        {
          //  _eventManager.Setup(x=> x.)
          //  mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

        }
        [Test]
        public void Shall_Receive_A_Correct_Payload_And_ExposeDataObject()
        {
            DataPayLoad dataPayLoad = new DataPayLoad();
            dataPayLoad.HasDataObject = true;
            dataPayLoad.PrimaryKeyValue = ID_DEFAULT;
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.NotNull(outObject);
            Assert.Equals(outObject.CODIGO, outObject.CODIGO);
        }
        [Test]
        public void Shall_Refuse_An_Incoming_Null_Payload()
        {
            DataPayLoad dataPayLoad = new NullDataPayload();
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.NotNull(outObject);
            Assert.Equals(outObject.CODIGO, outObject.CODIGO);
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
