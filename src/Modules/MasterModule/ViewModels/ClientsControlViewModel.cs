using MasterModule.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Views;
using NLog;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    class ClientsControlViewModel: MasterViewModuleBase
    {
        /// <summary>
        ///  Data layer to the the services
        /// </summary>
        private IClientDataServices _clientDataServices;
        /// <summary>
        ///  Region manager to the region
        /// </summary>
        private IRegionManager _regionManager;
        /// <summary>
        ///  Mailbox for this cleint view model.
        /// </summary>
        private string _mailBoxName;
        /// <summary>
        ///  Code key field
        /// </summary>
        private const string ClientColumnCode = "Codigo";
        /// <summary>
        ///  Name key field.
        /// </summary>
        private const string ClientNameColumn = "Nombre";
        /// <summary>
        ///  This is the client subsystem prefix module.
        /// </summary>
        private const string ClientModuleRoutePrefix = "ClientsSubsystem";

        /// <summary>
        ///  Client control view model. View Model to get the client.
        /// </summary>
        /// <param name="configurationService">Configuration service. This service is used to reconfigure dynamically the view model and get enviroment variables</param>
        /// <param name="eventManager">The event manager implements the mediator design pattern</param>
        /// <param name="services">Data access layer interface. It provide an abstraction to database access</param>
        /// <param name="regionManager">The region manager is useful to manage regions and navigate/create new views.</param>
        public ClientsControlViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)

        {
            _clientDataServices = services.GetClientDataServices();
            _regionManager = regionManager;
            _mailBoxName = EventSubsystem.ClientSummaryVm;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
        }

        private void InitViewModel()
        {   
            // each grid needs an unique identifier for setting the grid change in the database.
            GridIdentifier = GridIdentifiers.ClientSummaryGrid;
            StartAndNotify();
        }

        /// <summary>
        ///  Start and Notify the load of the control view model table.
        /// </summary>
        public override void StartAndNotify()
        {
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.ClientSummaryVm, MessageHandlerMailBox);
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(_clientDataServices.GetAsyncAllClientSummary(), InitializationNotifierOnPropertyChanged);
            // This is needed for the communication between the view model and the toolbar.
            ActiveSubSystem();
        }
        /// <summary>
        ///  Craft a new item in the view model. Opening a new form.
        /// </summary>
        public override void NewItem()
        {
            string name = KarveLocale.Properties.Resources.ClientsControlViewModel_NewItem_NuevoCliente;
            string code = _clientDataServices.GetNewId();
            string viewNameValue = name + "." + code;
            Navigate(code, viewNameValue);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = code;
            currentPayload.HasDataObject = true;
            currentPayload.DataObject = _clientDataServices.GetNewClientAgentDo(code); 
            currentPayload.Sender = EventSubsystem.ClientSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, currentPayload);
        }
        /// <summary>
        /// Navigate to the view
        /// </summary>
        /// <param name="code">Code of the view to navigate</param>
        /// <param name="viewName">Viewname to view</param>
        private void Navigate(string code, string viewName)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", code);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewName);
            var uri = new Uri(typeof(VehicleInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
        }
        /// <summary>
        ///  Delete Async a new item.
        /// </summary>
        /// <param name="clientIndentifier">PrimaryKey of the view model.</param>
        /// <param name="payLoad">Payload that comes from the event manager to get a value.</param>
        /// <returns></returns>
        public override async Task<bool> DeleteAsync(string clientIndentifier, DataPayLoad payLoad)
        {
            IClientData clientData = await _clientDataServices.GetAsyncClientDo(clientIndentifier);              
            bool retValue = await _clientDataServices.DeleteClientAsyncDo(clientData);
            return retValue;
        }
        /// <summary>
        ///  It opens a selected item, the infrastructure up to know just handle summary views as data tables for the rational:
        /// 1. no explicity mapping is needed.
        /// 2. it is just readonly summary.
        /// </summary>
        /// <param name="currentItem">Opened item</param>
        private async void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                DataRow row = rowView.Row;
                string name = row[ClientNameColumn] as string;
                string clientId = row[ClientColumnCode] as string;
                string tabName = clientId + "." + name;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("Id", clientId);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                IClientData provider = await _clientDataServices.GetAsyncClientDo(clientId);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);
                currentPayload.PrimaryKeyValue = clientId;
                currentPayload.Sender = _mailBoxName;
                Logger.Log(LogLevel.Debug, "[UI] ClientsControlViewModel. Opening Client Tab: " + clientId);
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, currentPayload);
            }
        }
        /// <summary>
        ///  Set the table to be views. It get called from the master. TODO: see if it possible unify this.
        /// </summary>
        /// <param name="table"></param>
        protected override void SetTable(DataTable table)
        {
            SummaryView = table;  
        }
        public override void DisposeEvents()
        {
            EventManager.DeleteMailBoxSubscription(EventSubsystem.ClientSummaryVm);
        }
        /// <summary>
        ///  This returns a registration payload for the subsystem.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.ClientSubsystem;
        }
        // TODO: refactor this.
        protected override void SetDataObject(object result)
        {
            // there is no single data object. Need for just a control interface and refacto.
        }
        protected override string GetRouteName(string name)
        {
            string routedName = ClientModuleRoutePrefix + name;
            return routedName;
        }
    }
}
