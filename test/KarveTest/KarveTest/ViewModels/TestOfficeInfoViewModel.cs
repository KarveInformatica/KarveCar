using KarveCommon.Services;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestOfficeInfoViewModel
    {
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        private Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private CompanyInfoViewModel _companyInfoViewModel = null;
        public TestOfficeInfoViewModel()
        {
            _companyInfoViewModel = new CompanyInfoViewModel(_eventManager.Object, _configurationService.Object, _dataServices.Object, _regionManager.Object);
        }
        [Test]
        public void Setup()
        {
          //  _eventManager.Setup(x=> x.)
          //  mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

        }
    }
}
