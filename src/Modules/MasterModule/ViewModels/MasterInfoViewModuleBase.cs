﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KarveCommon.Services;
using MasterModule.Common;
using Prism.Regions;
using KarveDataServices;
using KarveCommonInterfaces;
using System.Windows.Input;
using KarveDataServices.ViewObjects;
using DataAccessLayer.DataObjects;
using Prism.Commands;
using System.Linq;
using KarveControls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MasterModule.ViewModels
{

    /// <summary>
    ///  This class has the responsibility to build the data payload 
    ///  and masking overrides not needed.
    ///  In the MasterModule.ViewModels we have two kind of classes:
    ///  1. ViewModel Controllers.  
    ///     A view model controller starts navigation when the user clicks on a item. 
    ///     It will create child views as in the view-first approach.
    ///  2. ViewModel Info classes. 
    ///     An info view model typically has the responsibility 
    ///     to handle logic to is associated view.
    /// </summary>
    public abstract class MasterInfoViewModuleBase : MasterViewModuleBase
    {
        private bool _canDelete = true;
        private IEnumerable<VisitTypeViewObject> _visitTypeDto = new ObservableCollection<VisitTypeViewObject>();
        
    

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
        protected MasterInfoViewModuleBase(IEventManager eventManager,
                                        IConfigurationService configurationService,
                                        IDataServices dataServices,
                                        IDialogService dialogService,
                                        IRegionManager manager,
                                        IInteractionRequestController controller) : base(configurationService, eventManager, dataServices, dialogService, manager, controller)
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
        protected override void NewItem()
        {
        }
       
        /// <summary>
        ///  Abstact the set result after start and notify. Nothing happens in case of *InfoViewModels.
        /// </summary>
        /// <typeparam name="T">Type of the view modle</typeparam>
        /// <param name="result"></param>
        protected override void SetResult<T>(IEnumerable<T> result)
        {

        }
        /// <summary>
        ///  Summary abtravt the result of the event.
        /// </summary>
        /// <param name="value">Value of the event</param>
        /// <param name="arg">Arguments to be used</param>
        protected override void OnPagedEvent(object value, PropertyChangedEventArgs arg)
        {

        }
 
        /// <summary>
        ///  Returns the branch lists associated to the *InfoViewModels.
        /// </summary>
        public IEnumerable<BranchesViewObject> BranchesDto { get; set; }
        /// <summary>
        ///  Returns the contact list associated to the *InfoViewModels.
        /// </summary>
        public IEnumerable<ContactsViewObject> ContactsDto { get; set; }

        /// <summary>
        ///  Map the kind of visit inside the visit grid.
        /// </summary>
        public IEnumerable<VisitTypeViewObject> VisitTypeDto
        {
            get => _visitTypeDto;
            set
            {
                _visitTypeDto = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  ResellerMagnifier of a grid.
        /// </summary>
        public ICommand ResellerMagnifierCommand { get; set; }
        /// <summary>
        ///  ClientMagnifierCommand of a grid.
        /// </summary>
        public ICommand ClientMagnifierCommand { get; set; }
        /// <summary>
        /// ContactMagnifierCommand of a grid.
        /// </summary>
        public ICommand ContactMagnifierCommand { get; set; }



        /// <summary>
        /// Client handler. A client has associated a
        /// </summary>
        /// <param name="obj">Client magnifier</param>
        protected virtual async void OnClientMagnifier(object item)
        {
            if (item == null)
                return;

            await OnAssistAsyncClient(KarveLocale.Properties.Resources.lcliente, "Code,Name", async delegate (ClientSummaryExtended p)
            {
                VisitsViewObject b = item as VisitsViewObject;
                await SetClientData(p, b).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
        /// <summary>
        ///  Data grid handling in the visit data.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal abstract Task SetClientData(ClientSummaryExtended p, VisitsViewObject b);
        /// <summary>
        ///  Data grid handling in  the contacts.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="visitsDto"></param>
        /// <returns></returns>
        internal abstract Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsDto);

        /// <summary>
        /// This set the branch province.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        internal abstract Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b);


        protected IDictionary<string, object> SetContacts(PersonalPositionViewObject personal, 
            ContactsViewObject contactsDto,
            object dataObject, 
            IEnumerable<ContactsViewObject> contacts)
        {
            Dictionary<string, object> ev = new Dictionary<string, object>();
            ev["DataObject"] = dataObject;
            var items = new List<ContactsViewObject>();
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactsDto.ContactId);
            if (contact == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;
                // insert case
                contact = contactsDto;
                contact.IsNew = true;
                contact.IsDirty = true;
            }
            else
            {
                contact = contactsDto;
                ev["Operation"] = ControlExt.GridOp.Update;
                contact.IsChanged = true;
                contact.IsDirty = true;
                contact.IsNew = false;
               
            }
            contact.ResponsabilitySource = personal;
            personal.ShowCommand = this.ContactChargeMagnifierCommand;
            contact.ResponsabilitySource = personal;
            // add the changed value to the branch.
            items.Add(contact);
            ev["ChangedValue"] = items;
            return ev;
        }       
    /// <summary>
    /// Craft the dictionary to send when the magnifier triggers an event. 
    /// </summary>
    /// <param name="province"></param>
    /// <param name="branchesDto"></param>
    /// <param name="DataObject"></param>
    /// <param name="delegation"></param>   
    /// <returns></returns>
internal virtual IDictionary<string, object> SetBranchProvince(ProvinceViewObject province, BranchesViewObject branchesDto, 
            object DataObject, IEnumerable<BranchesViewObject> delegation)
        {

            Dictionary<string, object> ev = new Dictionary<string, object> {["DataObject"] = DataObject};
            var items = new List<BranchesViewObject>();
            var branch = delegation.FirstOrDefault(x => x.BranchId == branchesDto.BranchId);
            if (branch == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;
                // insert case
                branch = branchesDto;
                branch.IsNew = true;
                branch.IsDirty = true;
            }
            else
            {
                ev["Operation"] = ControlExt.GridOp.Update;

                branch = branchesDto;
                branch.IsChanged = true;
                branch.IsDirty = true;
                branch.IsNew = false;
            }
            branch.ProvinceSource = province;
            province.ShowCommand = DelegationProvinceMagnifierCommand;
            branch.ProvinceId = province.Code;
            branch.ProvinceName = province.Name;
            branch.Province = province;
            branch.ProvinceSource = province;
            // add the changed value to the branch.
            items.Add(branch);
            ev["ChangedValue"] = items;
            RaisePropertyChanged("DataObject");
            return ev;
        }

        public IDictionary<string, object> EventDictionary { get; set; }
        internal abstract Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b);

        internal static VisitsViewObject SetDtoCrossReference(ContactsViewObject contacts, VisitsViewObject visit)
        {
            visit.ContactsSource = contacts;
            visit.ContactName = contacts.ContactName;
            visit.ContactId = contacts.ContactId;
            return visit;
        }
        internal static BranchesViewObject SetDtoCrossReference(ProvinceViewObject province, BranchesViewObject branch) 
        {
            branch.ProvinceSource = province;
            branch.ProvinceId = province.Code;
            branch.ProvinceName = province.Name;
            branch.Province = province;
            return branch;
        }
        // TODO: too many things. See if the magnifier handling can be placed in another place.
        /// <summary>
        /// Contact Magnifier.
        /// </summary>
        /// <param name="obj">Contact magnifier.</param>
        protected virtual async void OnContactMagnifier(object item)
        {
            if (item == null)
                return;
            await OnAssistAsync<ContactsViewObject, CONTACTOS_COMI>(
                KarveLocale.Properties.Resources.lcontactos, "ContactId,ContactName,Nif,Telefono,Movil,Email", delegate (ContactsViewObject p)
                 {
                     VisitsViewObject visitsDto = item as VisitsViewObject;
                     SetVisitContacts(p, visitsDto);
                 }).ConfigureAwait(false);
        }
        /// <summary>
        /// Province handler. A branch has associated a province to be selected.
        /// </summary>
        /// <param name="item">Branches to be associated a province.</param>
        protected virtual async void OnProvinceAssist(object item)
        {
            if (item == null)
                return;
            await OnAssistAsync<ProvinceViewObject, PROVINCIA>(KarveLocale.Properties.Resources.MasterInfoViewModuleBase_OnProviceAssist_ListadoProvincia, "Code,Name", async delegate (ProvinceViewObject p)
            {
                BranchesViewObject b = item as BranchesViewObject;
                await SetBranchProvince(p, b).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
        /// <summary>
        ///  ResellerMagnifier.
        /// </summary>
        /// <param name="item"></param>
        protected virtual async void OnResellerMagnifier(object item)
        {
            if (item == null)
                return;
            await OnAssistAsync<ResellerViewObject, VENDEDOR>(KarveLocale.Properties.Resources.lvendidor, "Code,Name,CellPhone", async delegate (ResellerViewObject param)
            {
                VisitsViewObject v = item as VisitsViewObject;
                await SetVisitReseller(param, v).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
        /// <summary>
        /// Personal Position handler. A contact has associated a personal position in the company to be selected.
        /// </summary>
        /// <param name="item">Contacts to be associated with a position.</param>
        protected virtual async void OnContactChargeAssist(object item)
        {
            await OnAssistAsync<PersonalPositionViewObject, PERCARGOS>("Personal", "Code,Name", async delegate (PersonalPositionViewObject p)
            {
                ContactsViewObject b = item as ContactsViewObject;
                await SetContactsCharge(p, b).ConfigureAwait(false);
            }).ConfigureAwait(false);


        }

        protected virtual IDictionary<string, object> CreateGridEvent<InnerDto, OuterDto>(InnerDto innerDto, OuterDto outerDto, IEnumerable<OuterDto> outerDtoList, ICommand showCommand) where InnerDto : BaseViewObject
        where OuterDto : BaseViewObject
        {
            Dictionary<string, object> ev = new Dictionary<string, object>();
            var items = new List<BaseViewObject>();
            var outerDtoCandidate = outerDtoList.FirstOrDefault(x => x.Code == outerDto.Code);
            if (outerDtoCandidate == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;

            }
            else
            {
                ev["Operation"] = ControlExt.GridOp.Update;
                outerDtoCandidate.IsChanged = true;
            }
            outerDtoCandidate = outerDto;
            outerDtoCandidate.IsNew = true;
            outerDtoCandidate.IsDirty = true;
            innerDto.ShowCommand = showCommand;
            var outerDtoPromoted = SetDtoCorrelation<InnerDto,OuterDto>(innerDto, outerDto);
            // add the changed value to the branch.
            items.Add(outerDtoPromoted);
            ev["ChangedValue"] = items;
            return ev;
        }

        private BaseViewObject SetDtoCorrelation<InnerDto, OuterDto>(InnerDto innerDto, OuterDto outerDto)
            where InnerDto : BaseViewObject
            where OuterDto : BaseViewObject
        {
            BaseViewObject dto = new BaseViewObject();
            if ((innerDto.GetType() == typeof(ContactsViewObject)) && (outerDto.GetType() == typeof(VisitsViewObject)))
            {
                var inner = innerDto as ContactsViewObject;
                var outer = outerDto as VisitsViewObject;
                dto =  SetDtoCrossReference(inner, outer);

            }
            if ((innerDto.GetType() == typeof(ResellerViewObject)) && (outerDto.GetType() == typeof(VisitsViewObject)))
            {
                var inner = innerDto as ResellerViewObject;
                var outer = outerDto as VisitsViewObject;
                dto = SetDtoCrossReference(inner, outer);

            }
            if ((innerDto.GetType() == typeof(ClientViewObject)) && (outerDto.GetType() == typeof(VisitsViewObject)))
            {
                var inner = innerDto as ClientViewObject;
                var outer = outerDto as VisitsViewObject;
                dto = SetDtoCrossReference(inner, outer);
            }
            return dto;
        }

        private BaseViewObject SetDtoCrossReference(ClientViewObject inner, VisitsViewObject outer)
        {
            outer.ClientSource = inner;
            outer.ClientId = inner.NUMERO_CLI;
            return outer;
        }

        private BaseViewObject SetDtoCrossReference(ResellerViewObject inner, VisitsViewObject outer)
        {
            outer.SellerId = inner.Code;
            outer.SellerSource = inner;
            return outer;
        }

        /// <summary>
        ///  Callback to be executed. Currently it maskes.
        /// </summary>
        /// <param name="charge">Charge inside a contact</param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task SetContactsCharge(PersonalPositionViewObject charge, ContactsViewObject item)
        {
            item.Responsability = charge.Name;
            item.ResponsabilitySource = new PersonalPositionViewObject
            {
                Code = item.ContactId,
                Name = item.ContactName
            };
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
        ///  
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
        }
        
        /// <summary>
        ///  
        /// This configure the show command in case of a province inside the branch/delegations view.
        /// </summary>
        /// <param name="dtos">This is a list of branches.</param>
        protected void ConfigureBranchesCommand(IEnumerable<BranchesViewObject> dtos)
        {
            foreach (var b in dtos)
            {

                BaseViewObject v = b.ProvinceSource as BaseViewObject;

                v.ShowCommand = DelegationProvinceMagnifierCommand;
            }

        }
        /// <summary>
        /// This configure the responsibility in contacts dto list.
        /// </summary>
        /// <param name="dtos">This is a list of contacts dto.</param>
        protected void ConfigureContactsCommand(IEnumerable<ContactsViewObject> dtos)
        {
            if (dtos == null)
                return;
            foreach (var c in dtos)
            {
                var v = c.ResponsabilitySource as BaseViewObject;
                v.ShowCommand = ContactChargeMagnifierCommand;
            }
        }
        /// <summary>
        ///  This configure the resposability of visit dto list.
        /// </summary>
        /// <param name="dtos">This is a list of dto.</param>
        protected void ConfigureVisitsCommand(IEnumerable<VisitsViewObject> dtos)
        {
            if (dtos == null)
                return;
            foreach (var c in dtos)
            {
                if (c.ContactsSource is BaseViewObject contacts)
                {
                    contacts.ShowCommand = ContactMagnifierCommand;
                }

                if (c.SellerSource is BaseViewObject reseller)
                {
                    reseller.ShowCommand = ResellerMagnifierCommand;
                }

                if (c.ClientSource is BaseViewObject client)
                {
                    client.ShowCommand = ClientMagnifierCommand;
                }
            }
        }
        protected IDictionary<string, string> ViewModelQueries { get; set; }
        /*
protected async Task<string> FetchLocationByAddress(string address, string city, string country)
        {   
           
            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + address + "&sensor=false";
            WebRequest request = WebRequest.Create(url);

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    DataTable dtCoordinates = new DataTable();
                    dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("Latitude",typeof(string)),
                    new DataColumn("Longitude",typeof(string)) });
                    foreach (DataRow row in dsResult.Tables["result"].Rows)
                    {
                        string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                        DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                        dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
                    }
                }
                return dtCoordinates;
            }


        } */

        
    }

}