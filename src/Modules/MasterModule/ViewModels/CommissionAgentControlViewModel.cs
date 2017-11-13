using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls.UIObjects;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.Interfaces;
using MasterModule.UIObjects.CommissionAgents;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{

    public class CommissionAgentControlViewModel : MasterViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private const string ComiNameColumn = "Numero";
        private const string ComiColumnCode = "Nombre";
        private readonly UnityContainer _container;
        private readonly IDataServices _dataServices;
       
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
            IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services)
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
        ///  SummaryView data table.
        /// </summary>
        public DataTable SummaryView
        {
            set { ExtendedDataTable = value; RaisePropertyChanged(); }
            get { return ExtendedDataTable; }
        }
        /// <summary>
        /// Init the view model.
        /// </summary>
        private void InitViewModel()
        {
            MessageHandlerMailBox += CommissionAgentMailBox;
            EventManager.RegisterMailBox(EventSubsystem.CommissionAgentSummaryVm, MessageHandlerMailBox);
            StartAndNotify();
        }

        /// <summary>
        ///  This function load a new item selected from the main grid.
        /// </summary>
        /// <param name="currentItem"></param>
        private async void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                Tuple<string, string> idNameTuple = ComputeIdName(rowView, ComiNameColumn, ComiColumnCode);
                string tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
                ICommissionAgent agent = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentDo(idNameTuple.Item2);
                CommissionAgentInfoView view = _container.Resolve<CommissionAgentInfoView>();
                ConfigurationService.AddMainTab(view, tabName);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, agent);

                currentPayload.PrimaryKeyValue = idNameTuple.Item2;
                EventManager.NotifyObserverSubsystem(MasterModule.CommissionAgentSystemName, currentPayload);
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

        public void incomingPayload(DataPayLoad payload)
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
                EventManager.NotifyObserverSubsystem(MasterModule.CommissionAgentSystemName, payLoad);
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
            string codigo = "";
            // move this to the configuration service.
            ICommissionAgentView view = _container.Resolve<CommissionAgentInfoView>();
            // TODO: use the navigation service.
            ConfigurationService.AddMainTab(view, name);
            DataPayLoad currentPayload = BuildShowPayLoadDo(name);
            currentPayload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            EventManager.NotifyObserverSubsystem(MasterModule.CommissionAgentSystemName, currentPayload);
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
        /// <param name="name"></param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            return "CommisionAgentModule:" + name;
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
