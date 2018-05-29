using DataAccessLayer.SQL;
using KarveCar.Logic.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveTest.Mock;
using Moq;
using Prism.Mvvm;
using Prism.Regions;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  This is the base class for testing the mechanism between view models.
    /// </summary>
    public class TestBase
    {
        /// <summary>
        ///  MockDataServices
        /// </summary>
        protected MockDataServices DataServices = new MockDataServices();
        /// <summary>
        ///  Region Manager
        /// </summary>
        protected  Mock<IRegionManager> RegionManager = new Mock<IRegionManager>();

        protected IConfigurationService SetupConfigurationService()
        {
            IConfigurationService configurationService = new ConfigurationService();
            return configurationService;
        }

}

   
}