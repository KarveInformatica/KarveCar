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
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;

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
            IList<ProvinciaDto> provinceDto = new List<ProvinciaDto>()
            {  new ProvinciaDto() { Code = "2892", Name="Provincia"}, new ProvinciaDto() { Code = "2891", Name="Provincia1"} };

            Controller.ShowAssistView<ProvinciaDto>("Province", provinceDto, "Code, Name");
            if (Controller.SelectionState == SelectionState.OK)
            {
                ProvinciaDto dto = Controller.SelectedItem as ProvinciaDto;
                SelectedProvince = dto;
            }
        }
        private void OnContactChargeAssist()
        {
            Console.WriteLine("New charge");
            IList<ContactsDto> contactsDto = new List<ContactsDto>()
            {
               new ContactsDto() { ContactId = "1", ContactName="Named", Email="giorgio@apache.org"},
               new ContactsDto() { ContactId = "2", ContactName="Named1", Email="giorgio1@apache.org"}
            };
            AssistService.ShowAssistView<ContactsDto>("Province", contactsDto);
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
        public ProvinciaDto SelectedProvince { set; get; }
        // Result of contacts selection.
        public ContactsDto SelectedContact { set; get; }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            
        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsDto b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsDto p, VisitsDto visitsDto)
        {
            throw new NotImplementedException();
        }

        internal override Task SetBranchProvince(ProvinciaDto p, BranchesDto b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitReseller(ResellerDto param, VisitsDto b)
        {
            throw new NotImplementedException();
        }
    }
}
