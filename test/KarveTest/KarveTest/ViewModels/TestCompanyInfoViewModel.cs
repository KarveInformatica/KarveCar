using KarveCommon.Services;
using KarveDataServices;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using KarveTest.ViewModels;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    [TestFixture]
    class TestCompanyInfoViewModel : TestViewModelBase
    {
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        private Mock<IConfigurationService> _configurationService = new Mock<IConfigurationService>();
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private CompanyInfoViewModel _companyInfoViewModel = null;
   
        [OneTimeSetUp]
        public void Setup()
        {
           /* _companyInfoViewModel = new CompanyInfoViewModel(_eventManager.Object, 
                                                            _configurationService.Object, 
                                                            _dataServices.Object, 
                                                           _regionManager.Object);
                                                           */
        }
        [Test]
        public void Should_Handle_Correctly_Magnifier_Assist()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            //_companyInfoViewModel.AssistCommand
        }


    }
}
