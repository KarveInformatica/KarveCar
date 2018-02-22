using System;
using System.Data;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.Interfaces;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using System.Threading.Tasks;
using NLog;
using System.Diagnostics;

namespace MasterModule.ViewModels
{

    public class CommissionAgentControlViewModel : MasterControlViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private const string ComiNameColumn = "Numero";
        private const string ComiColumnCode = "Nombre";
        private readonly UnityContainer _container;
        private readonly IDataServices _dataServices;
        private IUserSettings _settings;
        

        /// <summary>
        ///  This is the region manager.
        /// </summary>
        private IRegionManager _regionManager;

        private object _dataObject;

        /// <summary>
        /// This is the commission agent view model.
        /// </summary>
        /// <param name="configurationService">Configuration service for the commission agent</param>
        /// <param name="eventManager">Event manager used for communicating between view models</param>
        /// <param name="services">Data Access layer services</param>
        /// <param name="regionManager">Region manager for navigation</param>
        public CommissionAgentControlViewModel(IConfigurationService configurationService,
            IEventManager eventManager,
            UnityContainer container,
            IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)
        {
            _regionManager = regionManager;
            _container = container;
            _dataServices = services;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();

        }
        /// <summary>
        ///  This allows to opena a new item.
        /// </summary>
        public ICommand OpenItem
        {
            set { OpenItemCommand = value; RaisePropertyChanged();}

        get { return OpenItemCommand; }

        }
        
        /// <summary>
        /// Init the view model.
        /// </summary>
        private void InitViewModel()
        {
            _settings = ConfigurationService.GetUserSettings();
            GridIdentifier = GridIdentifiers.CommissionAgent;
            GridId = GridIdentifiers.CommissionAgent;
            MagnifierGridName = MasterModuleConstants.CommissionAgentControlVm;
            MessageHandlerMailBox += CommissionAgentMailBox;
            EventManager.RegisterMailBox(EventSubsystem.CommissionAgentSummaryVm, MessageHandlerMailBox);
           
            StartAndNotify();
        }

        public override void DisposeEvents()
        {
            EventManager.DeleteMailBoxSubscription(EventSubsystem.CommissionAgentSummaryVm);
        }


        /// <summary>
        ///  This function load a new item selected from the main grid.
        /// </summary>
        /// <param name="currentItem"></param>
        private async void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            Stopwatch watch = new Stopwatch();
            if (rowView != null)
            {
                Tuple<string, string> idNameTuple = ComputeIdName(rowView, ComiNameColumn, ComiColumnCode);
                string tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
                ICommissionAgent agent = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentDo(idNameTuple.Item2);
                var navigationParameters = new NavigationParameters();
                var id = idNameTuple.Item1;
                navigationParameters.Add("Id", id);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);

                var uri = new Uri(typeof(CommissionAgentInfoView).FullName + navigationParameters, UriKind.Relative);
                Logger.Log(LogLevel.Debug, "[UI] CommissionInfoViewModel. Before navigation: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                RegionManager.RequestNavigate("TabRegion", uri);
                Logger.Log(LogLevel.Debug, "[UI] CommisionInfoViewModel. Data before: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
               
               
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, agent);

                currentPayload.PrimaryKeyValue = idNameTuple.Item2;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, currentPayload);
                ActiveSubSystem();
           }
        }

        /// <summary>
        ///  Navigation support.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        /// <summary>
        ///  Navigation support 
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public void IncomingPayload(DataPayLoad payload)
        {
        }

     
        public override void StartAndNotify()
        {
            ICommissionAgentDataServices commissionAgentDataServices = DataServices.GetCommissionAgentDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(commissionAgentDataServices.GetCommissionAgentSummary(), InitializationNotifierOnPropertyChanged);
        }
        /// <summary>
        ///  Each viewmodel uses the event manager for handling messages and has unique id.
        ///  Each viewmodel has a mailbox. This is the message handler for the mailbox.
        ///  
        /// </summary>
        /// <param name="payLoad">Data payload that specifies the operation to be handled</param>
        private void CommissionAgentMailBox(DataPayLoad payLoad)
        {
            if ((payLoad.PayloadType == DataPayLoad.Type.UpdateView) && (NotifyState == 0))
            {
                StartAndNotify();
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
                DeleteItem(payLoad);
               // EventManager.NotifyObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                NewItem();
            }
        }
        /// <summary>
        /// Create an instance a new view and its associated view model. 
        /// It is a view first scenario.
        /// </summary>
        public override void NewItem()
        {
            string name = "NuevoCommisionista";
            string codigo = DataServices.GetCommissionAgentDataServices().GetNewId();
            // move this to the configuration service.
            ICommissionAgentView view = _container.Resolve<CommissionAgentInfoView>();
            // TODO: use the navigation service.
            string viewNameValue = name + "." + codigo;


            var navigationParameters = new NavigationParameters();
            var id = codigo;
            navigationParameters.Add("Id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);

            var uri = new Uri(typeof(CommissionAgentInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            currentPayload.DataObject = DataServices.GetCommissionAgentDataServices().GetNewCommissionAgentDo(codigo);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.CommissionAgentSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, currentPayload);
        }

        
        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
           
        }

        /// <summary>
        /// Set the registation payload for the event manager and the toolbar module.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
        }

        public  long GridId { get; set; }
        public  string MagnifierGridName { get; set; }

        /// <summary>
        /// Set the current data object for the toolbar
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
            _dataObject = result;
        }
        /// <summary>
        ///  Get the routed name for the toolbar.
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            return "CommisionAgentModule:" + name;
        }

        /// <summary>
        /// Delete a single commission agent/broker
        /// </summary>
        /// <param name="commissionId"></param>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        public override async Task<bool> DeleteAsync(string commissionId, DataPayLoad payLoad)
        {
            ICommissionAgent comisio = await DataServices.GetCommissionAgentDataServices().GetCommissionAgentDo(commissionId);
            bool retValue = await DataServices.GetCommissionAgentDataServices().DeleteCommissionAgent(comisio);
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, payLoad);
            return retValue;
        }

        
        // create a scope for navigation.
        public bool CreateRegionManagerScope {
            get
            {
                return true;
            }
        }

    }
}
