using DataAccessLayer.SQL;
using KarveCar.Logic.Generic;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Mvvm;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  This is the base class for testing the mechanism between view models.
    /// </summary>
    public class TestBase
    {
       
        protected IConfigurationService SetupConfigurationService()
        {
            IConfigurationService configurationService = new ConfigurationService();
            return configurationService;
        }

}
}