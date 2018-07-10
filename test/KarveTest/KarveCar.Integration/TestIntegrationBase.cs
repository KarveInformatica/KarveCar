using DataAccessLayer;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveTest.DAL;
using Moq;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Integration
{
    /// <summary>
    ///  Base class for the integration test.
    /// </summary>
    internal class TestIntegrationBase
    {
        protected readonly TestBase _testBase = new TestBase();
        protected readonly Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        protected readonly Mock<IDialogService> _dialogServices = new Mock<IDialogService>();
        protected readonly Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        protected readonly Mock<IInteractionRequestController> _controller = new Mock<IInteractionRequestController>();
        protected readonly Mock<IConfigurationService> _configuration = new Mock<IConfigurationService>();


        protected IDataServices SetupDataServices()
        {
            var executor = _testBase.SetupSqlQueryExecutor();
            var dataServices = new DataServiceImplementation(executor);
            return dataServices;

        }
    }
}
