using MasterModule.Common;
using System;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using System.ComponentModel;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  Control view model for the clients
    /// </summary>
    public class ClientsControlViewModel: MasterControlViewModuleBase
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
        ///  Container for unity,
        /// </summary>
        private IUnityContainer _container;
        /// <summary>
        ///  Mailbox for this cleint view model.
        /// </summary>
        private string _mailBoxName;
        
        /// <summary>
        ///  Client task notify.
        /// </summary>
        private INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> _clientTaskNotify;
        
        /// <summary>
        ///  This happen when a load event is completed.
        /// </summary>
        private PropertyChangedEventHandler _clientEventTask;
        /// <summary>
        ///  This contains the client load summary.
        /// </summary>
        private IEnumerable<ClientSummaryExtended> _clientSummaryDtos;
        /// <summary>
        ///  Action to be triggered when loaded the data.
        /// </summary>
        private Action<object, PropertyChangedEventArgs> _clientDataLoaded;
        

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
            SortCommand = new DelegateCommand<object>(OnSortCommand);

            _container = container;
            
            InitViewModel();
        }

        /// <summary>
        ///  OnSortCommand 
        /// </summary>
        /// <param name="eventObject">Event Object to be used.</param>
        protected override void OnSortCommand(object eventObject)
        {
            var sortedDictionary = eventObject as Dictionary<string, ListSortDirection>;
            _clientTaskNotify = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetSortedCollectionPagedAsync(sortedDictionary, 1, DefaultPageSize), _clientEventTask);
        }
        private void InitViewModel()
        {
            // each grid needs an unique identifier for setting the grid change in the database.
            GridIdentifier = GridIdentifiers.ClientSummaryGrid;
            _clientEventTask += OnNotifyIncrementalList<ClientSummaryExtended>;
            _clientDataLoaded += OnClientDataLoaded;
            SummaryView = new IncrementalList<ClientSummaryExtended>(LoadMoreItems);
            StartAndNotify();
        }
        /// <summary>
        /// OnPagedEvent allows us to send a paged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            var listCompletion = sender as INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>>;
            if ((listCompletion != null) && (listCompletion.IsSuccessfullyCompleted))
            {
                
                if (SummaryView is IncrementalList<ClientSummaryExtended> summary)
                {
                    summary.LoadItems(listCompletion.Result);
                    SummaryView = summary;
                }
            }

            if ((listCompletion != null) && (listCompletion.IsFaulted))
            {
                DialogService?.ShowErrorMessage("Error Loading data " + listCompletion.ErrorMessage);
            }
        }
        /// <summary>
        /// Event that it has been triggered when we load the data.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Parameters to be used.</param>
        private void OnClientDataLoaded(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<IClientData> notification && notification.IsSuccessfullyCompleted)
            {
              
                var provider = notification.Task.Result;
                var tabName = provider.Value.NUMERO_CLI + "." + provider.Value.NOMBRE;
                var currentPayload = BuildShowPayLoadDo(tabName, provider);
                currentPayload.PrimaryKeyValue = provider.Value.NUMERO_CLI;
                currentPayload.Sender = _mailBoxName;
                try
                {
                    var navigationParameters = new NavigationParameters
                    {
                        { "Id", provider.Value.NUMERO_CLI },
                        { ScopedRegionNavigationContentLoader.DefaultViewName, tabName }
                    };
                    var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
                    _regionManager.RequestNavigate("TabRegion", uri);
                    
                } catch (Exception ex)
                {
                    DialogService?.ShowErrorMessage(ex.Message);
                }
            }
        }

        /// <summary>
        ///  Start and Notify the load of the control view model table.
        /// </summary>
        public void StartAndNotify()
        {
            
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.ClientSummaryVm, MessageHandlerMailBox);
            _clientTaskNotify = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetPagedSummaryDoAsync(1,DefaultPageSize), _clientEventTask);
            // This is needed for the communication between the view model and the toolbar.
            ActiveSubSystem();
        }

        private void DeleteClientHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion completion && completion.IsSuccessfullyCompleted)
            {
                CanDeleteRegion = true;
            }
        }

        /// <summary>
        ///  Craft a new item in the view model. Opening a new form.
        /// </summary>
        protected override void NewItem()
        {
            var name = KarveLocale.Properties.Resources.ClientsControlViewModel_NewItem_NuevoCliente;
            var code = _clientDataServices.GetNewId();
            var viewNameValue = name + "." + code;
            Navigate(code, viewNameValue);
            var currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.ClientSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = code;
            currentPayload.HasDataObject = true;
           // var configServiceDo = _clientDataServices.GetNewDo(code);
           // configServiceDo.Valu
            currentPayload.DataObject = _clientDataServices.GetNewDo(code); 
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
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, viewName}
            };
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
            var clientData = await _clientDataServices.GetDoAsync(clientIndentifier);
            if (clientData == null)
            {
                return false;
            }
            return await _clientDataServices.DeleteDoAsync(clientData);
        }
        private async void OpenCurrentItem(object currentItem)
        {
            var current = currentItem;
            if (current is ClientSummaryExtended summaryItem)
            {
              
                var name = summaryItem.Name;
                var clientId = summaryItem.Code;
                var tabName = clientId + "." + name;
                var loadedClient = await _clientDataServices.GetDoAsync(clientId);
                var currentPayload = BuildShowPayLoadDo(tabName, loadedClient);
                currentPayload.PrimaryKeyValue = loadedClient.Value.NUMERO_CLI;
                currentPayload.Sender = _mailBoxName;
                try
                {
                    var navigationParameters = new NavigationParameters
                    {
                        {"Id", loadedClient.Value.NUMERO_CLI},
                        {ScopedRegionNavigationContentLoader.DefaultViewName, tabName}
                    };
                    var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
                    _regionManager.RequestNavigate("TabRegion", uri);
                    EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, currentPayload);
                }
                catch (Exception ex)
                {
                    DialogService?.ShowErrorMessage("Cannot load: " + ex.Message);
                }
            }
        }
       
        public override void DisposeEvents()
        {
            EventManager.DeleteMailBoxSubscription(EventSubsystem.ClientSummaryVm);
        }

        /// <inheritdoc />
        /// <summary>
        ///  This returns a registration payload for the subsystem.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.ClientSubsystem;
        }
      
        protected override void SetDataObject(object result)
        {
            // there is no single data object. Need for just a control interface and refacto.
        }
        protected override string GetRouteName(string name)
        {
            var routedName =  "ClientModule:" + name;
            return routedName;
        }
        protected override  void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(
                _clientDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
        }
        protected override void SetResult<T>(IEnumerable<T> result)
        {
            _clientSummaryDtos = result as IEnumerable<ClientSummaryExtended>;
            var maxItems = _clientDataServices.NumberItems;
            PageCount = _clientDataServices.NumberPage;
           var summaryList = new IncrementalList<ClientSummaryExtended>(LoadMoreItems) { MaxItemCount = (int)maxItems};
            summaryList.LoadItems(_clientSummaryDtos);
            SummaryView = summaryList;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
