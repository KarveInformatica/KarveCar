using System.Linq;
using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using KarveTest.Mock;
using KarveCommonInterfaces;
using System.Threading.Tasks;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestOfficeInfoViewModel: TestViewModelBase
    {
        private DAL.TestBase _testBase = new DAL.TestBase();

        private const string IdDefault = "00001";
        private readonly Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private readonly Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        private readonly Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private readonly Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private readonly Mock<IInteractionRequestController> _interactionRequest = new Mock<IInteractionRequestController>();
        private CompanyInfoViewModel _companyInfoViewModel = null;
        private bool _subSystemRegistered = false;
 

        [OneTimeSetUp]
        public void Setup()
        {
            _eventManager.Setup(x => x.RegisterObserverSubsystem(
                    It.IsAny<string>(),
                    It.IsAny<IEventObserver>()))
                .Callback<string, IEventObserver>((x, x1) => { _subSystemRegistered = true; });
            _companyInfoViewModel = new CompanyInfoViewModel(_eventManager.Object, _configurationService.Object, _dataServices.Object, _mockDialogService.Object,_regionManager.Object, _interactionRequest.Object);
            _dataServices.Setup(x => x.GetHelperDataServices()).Returns<IHelperDataServices>(x =>
            {
                IHelperDataServices hds = new MockHelperDataServices();
                return hds;
            });
            _dataServices.Setup(x => x.GetAssistDataServices()).Returns<IAssistDataService>(x=>
            {
               var dt = new AssistDataService(_dataServices.Object);
               return dt;
            });
        }
        [Test]
        public async Task Should_Receive_ACorrectPayloadAndExposeDataObject()
        {
            IConfigurationService configurationService = _testBase.SetupConfigurationService();
            ISqlExecutor queryExecutor = _testBase.SetupSqlQueryExecutor();
            IDataServices dataServices = new DataServiceImplementation(queryExecutor);
            var value = dataServices.GetOfficeDataServices();
            var offices = await value.GetAsyncAllOfficeSummary();
            var dataObject = offices.FirstOrDefault();
            DataPayLoad dataPayLoad = new DataPayLoad
            {
                HasDataObject = true,
                PrimaryKeyValue = IdDefault,
                DataObject = dataObject 
            };
            _companyInfoViewModel.IncomingPayload(dataPayLoad);
            var outObject = _companyInfoViewModel.DataObject;
            Assert.NotNull(outObject);
            Assert.Equals(outObject.CODIGO, IdDefault);
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
