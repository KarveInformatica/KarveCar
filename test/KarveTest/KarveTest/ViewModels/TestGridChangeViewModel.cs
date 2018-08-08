using DataAccessLayer;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBarModule;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestGridChangeViewModel : TestViewModelBase
    {
        
       
        private ProviderInfoViewModel _providerInfoViewModel;
        private IEventManager eventManager = new EventDispatcher();
        private IDataServices _dataServices;

        public TestGridChangeViewModel()
        {
            ISqlExecutor sqlExecutor = SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(sqlExecutor);
            _providerInfoViewModel = new ProviderInfoViewModel(eventManager,     _mockConfigurationService.Object,
              _dataServices,
              _mockDialogService.Object, 
              _mockRegionManager.Object, 
              _mockRequestController.Object);
            
        }

        IDictionary<string, object> CreateACommand()
        {
            IDictionary<string, object> command = new Dictionary<string, object>();
            return command;
        }
        
    }
}
