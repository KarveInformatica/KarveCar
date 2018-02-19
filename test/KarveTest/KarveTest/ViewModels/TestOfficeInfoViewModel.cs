using KarveCommon.Services;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    class TestOfficeInfoViewModel
    {
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        private Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();

        private CompanyInfoViewModel _companyInfoViewModel = null;
    }
}
