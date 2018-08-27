using MasterModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices.ViewObjects;
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
        private BranchesViewObject _branchesViewObject;
        private bool _showExecuted;
        private IDictionary<string, object> _eventDictionary;
        // set or Get
       
        public TestViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IDialogService dialogService, IRegionManager manager, IInteractionRequestController controller) : base(eventManager, configurationService, dataServices, dialogService, manager, controller)
        {
        }

        public override void Dispose()
        {
           
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CompanySubsystem;
        }
        internal override async Task SetBranchProvince(ProvinceViewObject province, BranchesViewObject branch)
        {
            IList<BranchesViewObject> branchList = new List<BranchesViewObject>();
            var ev = CreateGridEvent<ProvinceViewObject, BranchesViewObject>(province, 
                branch, 
                branchList, new DelegateCommand<object>((_branchesDto)=> 
                {
                    _showExecuted = true;
                }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetClientData(ClientSummaryExtended p, VisitsViewObject b)
        {
            IList<VisitsViewObject> visitList = new List<VisitsViewObject>();
            var ev = CreateGridEvent<ClientSummaryExtended, VisitsViewObject>(p,
              b,
              visitList, new DelegateCommand<object>((_branchesDto) =>
              {
                  _showExecuted = true;
              }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetVisitContacts(ContactsViewObject p, VisitsViewObject b)
        {
            IList<VisitsViewObject> visitList = new List<VisitsViewObject>();
            var ev = CreateGridEvent<ContactsViewObject, VisitsViewObject>(p,
              b,
              visitList, new DelegateCommand<object>((_branchesDto) =>
              {
                  _showExecuted = true;
              }));
            await Task.Delay(1);
            EventDictionary = ev;
        }
        internal override async Task SetVisitReseller(ResellerViewObject p, VisitsViewObject b)
        {
            IList<VisitsViewObject> visitList = new List<VisitsViewObject>();
            var ev = CreateGridEvent<ResellerViewObject, VisitsViewObject>(p,
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
       
    }
}
