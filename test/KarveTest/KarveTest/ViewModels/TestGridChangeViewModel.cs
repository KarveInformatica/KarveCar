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
        
        private Mock<IDialogService> _dialogService;
        private ProviderInfoViewModel _providerInfoViewModel;
        private CommissionAgentInfoViewModel _commissionAgentViewModel;
        private ClientsInfoViewModel _clientInfoViewModel;
        private CompanyInfoViewModel _companyInfoViewModel;
        private OfficeInfoViewModel officeInfoViewModel;
        private KarveToolBarViewModel _karveToolBarViewModel;
        private IEventManager eventManager = new EventDispatcher();
        private IDataServices _dataServices;

        public TestGridChangeViewModel()
        {
            ISqlExecutor sqlExecutor = SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(sqlExecutor);
            _providerInfoViewModel = new ProviderInfoViewModel(eventManager, _mockConfigurationService.Object,_dataServices, _mockDialogService.Object,_mockAssistService.Object, _mockRegionManager.Object);
            
        }

        IDictionary<string, object> CreateACommand()
        {
            IDictionary<string, object> command = new Dictionary<string, object>();
            return command;
        }
        /// <summary>
        /// This test verify that a collection has been added. 
        /// We suppose that the user send a message through a command, 
        /// inside the command we set the values to be sent and the operation. 
        /// </summary>
        /// <returns></returns>
        public async Task Should_Add_A_Collection_To_Provider_Delegation_Grid()
        {
            
        }
        public async Task Should_Add_A_Single_Item_To_Provider_Delegation_Grid()
        {

        }
        public async Task Should_Delete_A_Single_Item_To_Provider_Delegation_Grid()
        {

        }
        public async Task Should_Delete_Collection_To_A_Provider_Delegation_Grid()
        {

        }
        public async Task Should_Delete_Collection_To_A_CommissionAgent_Delegation_Grid()
        {

        }
    }
}
