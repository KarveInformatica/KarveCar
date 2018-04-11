using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Services;
using MasterModule.Common;
using Prism.Regions;
using KarveDataServices;
using KarveCommon.Generic;
using KarveCommonInterfaces;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using Prism.Commands;
using System;

namespace MasterModule.ViewModels
{

    /// <summary>
    ///  This class has the resposability to build the data payload 
    ///  and masking overrides not needed.
    ///  In the MasterModule.ViewModels we have two kind of classes:
    ///  1. ViewModel Controllers.  
    ///     A view model controller starts navigation when the user clicks on a item. 
    ///     It will create child views as in the view-first approach.
    ///  2. ViewModel Info classes. 
    ///     An info view model typically has the resposability 
    ///     to handle logic to is associated view.
    /// </summary>
    public abstract class MasterInfoViewModuleBase : MasterViewModuleBase
    {
        private bool _canDelete = true;

        /// <summary>
        /// The MasterInfoViewModuleBase is a view model that overrides no requested operation in the InfoViewModels.
        /// </summary>
        /// <param name="eventManager">Event Manager.
        ///     It allows the communication throu viewmodel</param>
        /// <param name="configurationService">Configuration Service. It allows the reconfiguration of the view model</param>
        /// <param name="dataServices">DataServices. It allows to fetch the data.</param>
        /// <param name="dialogService">DialogService. It allows spotting the error.</param>
        /// <param name="controller">Interaction Request Contriller. I
        /// It allows the controller to</param>
        /// <param name="manager">RegionManager. It handles the region manager.</param>
        public MasterInfoViewModuleBase(IEventManager eventManager,
                                        IConfigurationService configurationService,
                                        IDataServices dataServices, 
                                        IDialogService dialogService,
                                        IRegionManager manager,
                                        IInteractionRequestController controller) : base(configurationService,eventManager,dataServices, dialogService,manager, controller)
        {
            _canDelete = true;
                DelegationProvinceMagnifierCommand = new DelegateCommand<object>(OnProvinceAssist);
            ContactChargeMagnifierCommand = new DelegateCommand<object>(OnContactChargeAssist);
            ClientMagnifierCommand = new DelegateCommand<object>(OnClientMagnifier);
            ResellerMagnifierCommand = new DelegateCommand<object>(OnResellerMagnifier);
            ContactMagnifierCommand = new DelegateCommand<object>(OnContactMagnifier);
        }

        





        /// <summary>
        ///  Abstract the delete async. Nothing happens in case of the MasterInfoViewModels.
        /// </summary>
        /// <param name="primaryKey">Primary key to be used</param>
        /// <param name="payLoad">Payload that it is coming form the </param>
        /// <returns>In this case returns always false</returns>
        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            await Task.Delay(1);
            return false;
        }
        /// <summary>
        ///  Abstract the new item. Nothing happens in the case of *InfoViewModels since the new item
        ///  is managed by the controller.
        /// </summary>
        public override void NewItem()
        {
        }
        /// <summary>
        ///  Abstract the start and notify. Nothing happens in case of *InfoViewModels.
        /// </summary>
        public override void StartAndNotify()
        {

        }
        /// <summary>
        ///  Returns the branch lists associated to the *InfoViewModels.
        /// </summary>
        public IEnumerable<BranchesDto> BranchesDto { get; protected set; }
        /// <summary>
        ///  Returns the contact list associated to the *InfoViewModels.
        /// </summary>
        public IEnumerable<ContactsDto> ContactsDto { get; protected set; }
        /// <summary>
        ///  ResellerMagnifier of a grid.
        /// </summary>
        public ICommand ResellerMagnifierCommand { get; protected set; }
        /// <summary>
        ///  ClientMagnifierCommand of a grid.
        /// </summary>
        public ICommand ClientMagnifierCommand { get; protected set; }
        /// <summary>
        /// ContactMagnifierCommand of a grid.
        /// </summary>
        public ICommand ContactMagnifierCommand { get; protected set; }
        
        /// <summary>
        /// Client handler. A client has associated a
        /// </summary>
        /// <param name="obj"></param>
        protected async virtual void OnClientMagnifier(object item)
        {
            await OnAssistAsyncClient(KarveLocale.Properties.Resources.ClientsControlViewModel_NewItem_NuevoCliente, "Code,Name", async delegate (ClientSummaryExtended p)
            {
                VisitsDto b = item as VisitsDto;
                await SetClientData(p, b).ConfigureAwait(false);
            }).ConfigureAwait(false);
         }

        private async Task SetClientData(ClientSummaryExtended p, VisitsDto b)
        {
            await Task.Delay(1);
        }

        /// <summary>
        /// Contact Magnifier.
        /// </summary>
        /// <param name="obj">Contact magnifier.</param>
        protected async virtual void OnContactMagnifier(object item)
        {
            await OnAssistAsync<ContactsDto, CONTACTOS_COMI>(
                KarveLocale.Properties.Resources.lcontactos, "ContactsName,Nif,Telefono,Movil,Email", delegate (ContactsDto p)
                 {
                     VisitsDto visitsDto = item as VisitsDto;
                     SetContacts(p, visitsDto);
                 }).ConfigureAwait(false);
        }
        private void SetContacts(ContactsDto p, VisitsDto visitsDto)
        {
            visitsDto.ContactsSource = p;
        }
        /// <summary>
        /// Province handler. A branch has associated a province to be selected.
        /// </summary>
        /// <param name="item">Branches to be associated a province.</param>
        protected async virtual void OnProvinceAssist(object item)
        {
            
            await OnAssistAsync<ProvinciaDto, PROVINCIA>(KarveLocale.Properties.Resources.MasterInfoViewModuleBase_OnProviceAssist_ListadoProvincia, "Code,Name", async delegate (ProvinciaDto p)
            {
                BranchesDto b = item as BranchesDto;
                await SetBranchProvince(p, b).ConfigureAwait(false);     
            }).ConfigureAwait(false);
        }

        private void OnResellerMagnifier(object obj)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Personal Position handler. A contact has associated a personal position in the company to be selected.
        /// </summary>
        /// <param name="item">Contacts to be associated with a position.</param>
        protected async virtual void OnContactChargeAssist(object item)
        {


            await OnAssistAsync<PersonalPositionDto, PERCARGOS>(KarveLocale.Properties.Resources.lrgrPersonal, "Code,Name", async delegate (PersonalPositionDto p)
            {
                ContactsDto b = item as ContactsDto;
                await SetContactsCharge(p, b).ConfigureAwait(false);
            }).ConfigureAwait(false);
            

        }
        /// <summary>
        ///  Callback to be executed. Currently it maskes.
        /// </summary>
        /// <param name="charge">Charge inside a contact</param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task SetContactsCharge(PersonalPositionDto charge, ContactsDto item)
        {
            item.Responsability = charge.Name;
            await Task.Delay(1);
        }
        /// <summary>
        ///  Callback to be executed after retrieving the branch.
        /// </summary>
        /// <param name="province"></param>
        /// <param name="branchesDto"></param>
        /// <returns></returns>
        public async virtual Task SetBranchProvince(ProvinciaDto province, BranchesDto branchesDto)
        {
            await Task.Delay(1);
        }
        /// <summary>
        ///  This command has the resposability to be binded to the assist service 
        ///  in order to see the provinces inside a delegation.
        /// </summary>
        public ICommand DelegationProvinceMagnifierCommand { set; get; }
        /// <summary>
        ///  This command has the responsability to be binded to the 
        ///  contact charge command inside the contact.
        /// </summary>
        public ICommand ContactChargeMagnifierCommand { set; get; } 
        /// <summary>
        ///  This build a data payload, enforcing the value that cames from the UI.
        /// </summary>
        /// <param name="eventDictionary">Dictionary that it cames from the UI components</param>
        /// <returns>A payload to be sent to other view models.</returns>
        protected DataPayLoad BuildDataPayload(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    if (DialogService!=null)
                    {
                        DialogService.ShowErrorMessage("DataObject is null");
                    }
                }
                var data = eventDictionary["DataObject"];
                if (eventDictionary.ContainsKey("Field"))
                {
                    var name = eventDictionary["Field"] as string;
                    GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedValue"]);
                }
                payLoad.DataObject = data;
                eventDictionary["DataObject"] = data;
                payLoad.DataDictionary = eventDictionary;
            }
            return payLoad;
        }
        /// <summary>
        ///  Name of the routing. We overrdie the name to provide a default.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns>Empty string</returns>
        protected override string GetRouteName(string name)
        {
            return "";
        }
        /// <summary>
        ///  Specify if we can delete a region
        /// </summary>
        public override bool CanDeleteRegion
        {
            set { _canDelete = value; }
            get { return _canDelete; }
        }
        /// <summary>
        ///  Deprecated.
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
        }
        /// <summary>
        ///  We override the SetTable to provide a default.
        ///  The use of data table are not 
        /// </summary>
        /// <param name="table">Table to be used.</param>
        protected override void SetTable(DataTable table)
        {
        }
        /// <summary>
        ///  
        /// This configure the show command in case of a province inside the branch/delegations view.
        /// </summary>
        /// <param name="dtos">This is a list of branches.</param>
        protected void ConfigureBranchesCommand(IEnumerable<BranchesDto> dtos)
        {
            foreach (var b in dtos)
            {

                BaseDto v = b.ProvinceSource as BaseDto;

                v.ShowCommand = DelegationProvinceMagnifierCommand;
            }
          
        }
        /// <summary>
        /// This configure the resposabilty in contacts dto list.
        /// </summary>
        /// <param name="dtos">This is a list of contacts dto.</param>
        protected void ConfigureContactsCommand(IEnumerable<ContactsDto> dtos)
        {
            if (dtos != null)
            {
                foreach (var c in dtos)
                {
                    BaseDto v = c.ResponsabilitySource as BaseDto;
                    v.ShowCommand = ContactChargeMagnifierCommand;
                }
            }
        }
        /// <summary>
        ///  This configure the resposability of visit dto list.
        /// </summary>
        /// <param name="dtos">This is a list of dto.</param>
        protected void ConfigureVisitsCommand(IEnumerable<VisitsDto> dtos)
        {
            if (dtos != null)
            {
                foreach (var c in dtos)
                {
                    var contacts = c.ContactsSource as BaseDto;
                    if (contacts != null)
                    {
                        contacts.ShowCommand = ContactMagnifierCommand;
                    }
                    var reseller = c.SellerSource as BaseDto;
                    if (reseller != null)
                    {
                        reseller.ShowCommand = ResellerMagnifierCommand;
                    }
                    var client = c.ClientSource as BaseDto;
                    if (client != null)
                    {
                        client.ShowCommand = ClientMagnifierCommand;
                    }
                }
            }
        }
        protected IDictionary<string, string> ViewModelQueries { get; set; }
    }

}