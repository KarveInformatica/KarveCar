using MasterModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices.DataTransferObject;
using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Regions;
using NUnit.Framework;
using Prism.Commands;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  TestViewModel.
    /// </summary>
    
    class TestViewModel : MasterInfoViewModuleBase
    {
        private BranchesDto _branchesDto;
        private bool _showExecuted;
        private IDictionary<string, object> _eventDictionary;
        // set or Get
        public IDictionary<string,object> EventDictionary { set; get; }
        public TestViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IDialogService dialogService, IRegionManager manager, IInteractionRequestController controller) : base(eventManager, configurationService, dataServices, dialogService, manager, controller)
        {
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CompanySubsystem;
        }
        internal override async Task SetBranchProvince(ProvinciaDto province, BranchesDto branch)
        {
            IList<BranchesDto> branchList = new List<BranchesDto>();
            var ev = CreateGridEvent<ProvinciaDto, BranchesDto>(province, 
                branch, 
                branchList, new DelegateCommand<object>((_branchesDto)=> 
                {
                    _showExecuted = true;
                }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetClientData(ClientSummaryExtended p, VisitsDto b)
        {
            IList<VisitsDto> visitList = new List<VisitsDto>();
            var ev = CreateGridEvent<ClientSummaryExtended, VisitsDto>(p,
              b,
              visitList, new DelegateCommand<object>((_branchesDto) =>
              {
                  _showExecuted = true;
              }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetVisitContacts(ContactsDto p, VisitsDto b)
        {
            IList<VisitsDto> visitList = new List<VisitsDto>();
            var ev = CreateGridEvent<ContactsDto, VisitsDto>(p,
              b,
              visitList, new DelegateCommand<object>((_branchesDto) =>
              {
                  _showExecuted = true;
              }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetVisitReseller(ResellerDto p, VisitsDto b)
        {
            IList<VisitsDto> visitList = new List<VisitsDto>();
            var ev = CreateGridEvent<ResellerDto, VisitsDto>(p,
              b,
              visitList, new DelegateCommand<object>((_branchesDto) =>
              {
                  _showExecuted = true;
              }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
    }
    [TestFixture]
    class TestMasterInfoViewModuleBase : TestViewModelBase
    {
        private TestViewModel _testViewModel = null;
        [OneTimeSetUp]
        public void Setup()
        {
            _testViewModel = new TestViewModel(_mockEventManager.Object,
                                               _mockConfigurationService.Object,
                                               _mockDataServices.Object,
                                               _mockDialogService.Object,
                                               _mockRegionManager.Object,
                                               _mockRequestController.Object);

        }
        [Test]
        public void Should_Visit_Reseller()
        {
            VisitsDto visitDto = new VisitsDto();
            visitDto.VisitId = "2892982";
            visitDto.SellerId = "0000001";
            _testViewModel.ResellerMagnifierCommand.Execute(visitDto);
            var dictionary = _testViewModel.EventDictionary;
        }
    }
}
