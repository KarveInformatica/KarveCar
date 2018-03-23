using MasterModule.Common;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using NLog;
using Prism.Commands;
using Prism.Regions;
using System.ComponentModel;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using Syncfusion.UI.Xaml.Grid;
using System.Linq;
using DataAccessLayer.Model;

namespace MasterModule.ViewModels
{
    class ClientsControlViewModel: MasterControlViewModuleBase
    {
        /// <summary>
        ///  Data layer to the the services
        /// </summary>
        private IClientDataServices _clientDataServices;
        /// <summary>
        ///  Region manager to the region
        /// </summary>
        private IRegionManager _regionManager;

        private IUnityContainer _container;
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

        private INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> _clientTaskNotify;
        private INotifyTaskCompletion<IClientData> _clientDataLoader;

        private PropertyChangedEventHandler _clientEventTask;
        private PropertyChangedEventHandler _clientDataLoaded;

        private IEnumerable<ClientSummaryExtended> _clientSummaryDtos;

        /// <summary>
        ///  Client control view model. View Model to get the client.
        /// </summary>
        /// <param name="configurationService">Configuration service. This service is used to reconfigure dynamically the view model and get enviroment variables</param>
        /// <param name="eventManager">The event manager implements the mediator design pattern</param>
        /// <param name="services">Data access layer interface. It provide an abstraction to database access</param>
        /// <param name="regionManager">The region manager is useful to manage regions and navigate/create new views.</param>
        public ClientsControlViewModel(IUnityContainer container, IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)

        {
            _clientDataServices = services.GetClientDataServices();
            _regionManager = regionManager;
            _mailBoxName = EventSubsystem.ClientSummaryVm;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            _container = container;
            InitViewModel();
        }

        private void InitViewModel()
        {
            // each grid needs an unique identifier for setting the grid change in the database.
            GridIdentifier = GridIdentifiers.ClientSummaryGrid;
            _clientEventTask += OnNotifyClient;
            _clientDataLoaded += OnClientDataLoaded;
            StartAndNotify();
            
            //Navigate("new","new");
        }

        private void OnClientDataLoaded(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IClientData> notification = sender as INotifyTaskCompletion<IClientData>;
            if (notification.IsSuccessfullyCompleted)
            {
              
                IClientData provider = notification.Task.Result;
                var tabName = provider.Value.NUMERO_CLI + "." + provider.Value.NOMBRE;

                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);
                currentPayload.PrimaryKeyValue = provider.Value.NUMERO_CLI;
                currentPayload.Sender = _mailBoxName;
                try
                {
                    var navigationParameters = new NavigationParameters();
                    navigationParameters.Add("Id", provider.Value.NUMERO_CLI);
                    navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                    var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
                    _regionManager.RequestNavigate("TabRegion", uri);

                    EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, currentPayload);
                } catch (Exception ex)
                {
                    var value = ex.Message; 
                }
            }
        }

        private void OnNotifyClient(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> notification = sender as INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>>;
            if (notification.IsSuccessfullyCompleted)
            {
                _clientSummaryDtos = notification.Task.Result;
                SummaryView = new IncrementalList<ClientSummaryExtended>(LoadMoreItems) { MaxItemCount = _clientSummaryDtos.Count() };
            }
            if (notification.IsFaulted)
            {
                if (DialogService!=null)
                {
                    DialogService.ShowErrorMessage("Error loading the main screen");
                }
            }
        }
        
        /// <summary>
        ///  Start and Notify the load of the control view model table.
        /// </summary>
        public override void StartAndNotify()
        {
            
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.ClientSummaryVm, MessageHandlerMailBox);
            _clientTaskNotify = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetAsyncAllClientSummary(), _clientEventTask);
            // This is needed for the communication between the view model and the toolbar.
            ActiveSubSystem();
        }

        private void DeleteClientHandler(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion completion = sender as INotifyTaskCompletion;
            if (completion.IsSuccessfullyCompleted)
            {
                CanDeleteRegion = true;
            }
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
            currentPayload.Subsystem = DataSubSystem.ClientSubsystem;
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
            var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.
                RequestNavigate("TabRegion", uri);
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
            if (clientData == null)
            {
                return false;
            }
            bool retValue = await _clientDataServices.DeleteClientAsyncDo(clientData);
            return retValue;
        }
        private void OpenCurrentItem(object currentItem)
        {
            object current = currentItem;
          
            
            ClientSummaryExtended summaryItem = current as ClientSummaryExtended;
            if (summaryItem != null)
            {
              
                string name = summaryItem.Name;
                string clientId = summaryItem.Code;
                string tabName = clientId + "." + name;
                _clientDataLoader = NotifyTaskCompletion.Create(_clientDataServices.GetAsyncClientDo(clientId), this._clientDataLoaded);
                
                
               
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

        private void LoadMoreItems(uint count, int baseIndex)
        {
            var list = _clientSummaryDtos.Skip(baseIndex).Take(100).ToList();
            var summary = SummaryView as IncrementalList<ClientSummaryExtended>;
            summary.LoadItems(list);
        }
    }
}
