using MasterModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using Moq;
using KarveDataServices;
using Prism.Regions;
using KarveCommonInterfaces;
using System.Windows.Input;
using Prism.Commands;
using KarveDataServices.ViewObjects;
using DataAccessLayer.DataObjects;
using System.ComponentModel;

namespace KarveTest.Mock
{
    /// <summary>
    ///  This class mocks a view model for showing a dialog.     /// </summary>
    public class AssistMockViewModel : MasterInfoViewModuleBase
    {
        
       
        public AssistMockViewModel(IEventManager eventManager,
                                   IConfigurationService configurationService,
                                   IDataServices dataServices,
                                   IDialogService dialogService,
                                   IRegionManager regionManager,
                                   IInteractionRequestController controller) : base(eventManager, configurationService,
                                            dataServices, dialogService, regionManager, controller)
        {
            LaunchContact = new DelegateCommand(OnContactChargeAssist);
            LaunchBranches = new DelegateCommand(OnProvinceAssist);
        }
        private void OnProvinceAssist()
        {
            IList<ProvinceViewObject> provinceDto = new List<ProvinceViewObject>()
            {  new ProvinceViewObject() { Code = "2892", Name="Provincia"}, new ProvinceViewObject() { Code = "2891", Name="Provincia1"} };

            Controller.ShowAssistView<ProvinceViewObject>("Province", provinceDto, "Code, Name");
            if (Controller.SelectionState == SelectionState.OK)
            {
                ProvinceViewObject viewObject = Controller.SelectedItem as ProvinceViewObject;
                SelectedProvince = viewObject;
            }
        }
        private void OnContactChargeAssist()
        {
            Console.WriteLine("New charge");
            IList<ContactsViewObject> contactsDto = new List<ContactsViewObject>()
            {
               new ContactsViewObject() { ContactId = "1", ContactName="Named", Email="giorgio@apache.org"},
               new ContactsViewObject() { ContactId = "2", ContactName="Named1", Email="giorgio1@apache.org"}
            };
            AssistService.ShowAssistView<ContactsViewObject>("Province", contactsDto);
        }
        /// <summary>
        ///  Command to lauch the view of contacts.
        /// </summary>
        public ICommand LaunchContact { set; get; }
        /// <summary>
        ///  COmmand to launch the view of branches
        /// </summary>
        public ICommand LaunchBranches { set; get; }
        /// <summary>
        ///  Result of province selection
        /// </summary>
        public ProvinceViewObject SelectedProvince { set; get; }
        // Result of contacts selection.
        public ContactsViewObject SelectedContact { set; get; }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            
        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsViewObject)
        {
            throw new NotImplementedException();
        }

        internal override Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public override void IncomingPayload(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
