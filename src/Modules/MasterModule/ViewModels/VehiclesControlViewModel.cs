using System;
using System.Data;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using KarveCommonInterfaces;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the vehicles control view model.
    /// </summary>
    public class VehiclesControlViewModel: MasterViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private IVehicleDataServices _vehicleDataServices;
        private const string VehicleNameColumn = "Marca";
        private const string VehicleColumnCode = "Numero";
        private readonly UnityContainer _container;
        private IRegionManager _regionManager;
        private const string VehiclesAgentSummaryVm = "VehiclesAgentSummaryVm";
        private const string VehiclesModuleRoutePrefix = "VehiclesModule:";
        public bool CreateRegionManagerScope => true;
        /// <summary>
        ///  This is the vehicle control view model. 
        /// This is responsable for the opening new tabs.
        /// </summary>
        /// <param name="configurationService">Configuration service. It give us the global configuration</param>
        /// <param name="eventManager">EventManager. This is the eventManager</param>
        /// <param name="services">DataServices. This are the dataservices for this stuff.</param>
        /// <param name="container"></param>
        /// <param name="regionManager"></param>
        public VehiclesControlViewModel(IConfigurationService configurationService, 
            IEventManager eventManager,
            IDataServices services,
            UnityContainer container,
            IRegionManager regionManager) : base(configurationService, eventManager, services)
        {
            _container = container;
            _regionManager = regionManager;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
        }
        private async void OpenCurrentItem(object currentItem)
        {
        
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                Tuple<string, string> idNameTuple = ComputeIdName(rowView, VehicleNameColumn, VehicleColumnCode);
                string tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
                IVehicleData agent = await _vehicleDataServices.GetVehicleDo(idNameTuple.Item1);

               
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("id",  idNameTuple.Item1);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(VehicleInfoView).FullName+navigationParameters,UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                 
                // replace this with navigation.
                /*VehicleInfoView view = _container.Resolve<VehicleInfoView>();
                ConfigurationService.AddMainTab(view, tabName);
                */
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, agent);
                currentPayload.PrimaryKeyValue = idNameTuple.Item1;
                currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, currentPayload);
                RegisterToolBar();
            }
        }

        private void InitViewModel()
        {
            MessageHandlerMailBox += VehicleAgentMailBox;
            StartAndNotify();
            
        }
        private void VehicleAgentMailBox(DataPayLoad payLoad)
        {
            if ((payLoad.PayloadType == DataPayLoad.Type.UpdateView) && (NotifyState == 0))
            {
                StartAndNotify();
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                NewItem();
            }
        }

        public ICommand OpenItem
        {
            get { return OpenItemCommand; }
            set { OpenItemCommand = value; }
        }
        public override void StartAndNotify()
        {
            // the message handler is resposible to receive messages from the different view models.
       //     MessageHandlerMailBox += VehicleMessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.VehichleSummaryVm, MessageHandlerMailBox);
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(_vehicleDataServices.GetVehiclesAgentSummary(0,0), InitializationNotifierOnPropertyChanged);

          }
        protected void VehicleMessageHandler(DataPayLoad payLoad)
        {
            if ((payLoad.PayloadType == DataPayLoad.Type.UpdateView) && (NotifyState == 0))
            {
                lock (_notifyStateObject)
                {
                    NotifyState = 1;
                }
                StartAndNotify();
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                // forward data to the current payload.
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                NewItem();
            }
        }
        /// <summary>
        ///  This returns the summary view for vehicles.
        /// </summary>
        public DataTable SummaryView
        {
            set { ExtendedDataTable = value; RaisePropertyChanged(); }
            get { return ExtendedDataTable; }
        }
        /// <summary>
        ///  This add a new item fresh from zero about vehicles.
        /// </summary>
        public override void NewItem()
        {
            string name = "NuevoVehiculo";
            string codigo = DataServices.GetVehicleDataServices().GetNewId();
            VehicleInfoView view = _container.Resolve<VehicleInfoView>();
            string viewNameValue = name + "." + codigo;
            ConfigurationService.AddMainTab(view, viewNameValue);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = "";
            currentPayload.Sender = EventSubsystem.VehichleSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, currentPayload);
        }
        /// <summary>
        ///  This method is called after the notification from the base class to set the table after the load summary mechanism 
        ///  has been launched. 
        /// </summary>
        /// <param name="table"></param>
        
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
        }
        /// <summary>
        /// Set data object
        /// </summary>
        /// <param name="result">This is the data object for this screen</param>
        protected override void SetDataObject(object result)
        {
            //_dataObject = result;
        }

        /// <summary>
        /// This gets the routename for the vehicles subsystem.
        /// </summary>
        /// <param name="name">Name of the vehicle subsystem</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            string routedName = VehiclesModuleRoutePrefix + name;
            return routedName;

        }

        public string UniqueId { get; set; }

        /// <summary>
        ///  Message incoming from different 
        /// </summary>
        /// <param name="payload">Kind of payload coming from the diffent view model</param>
        public void IncomingPayload(DataPayLoad payload)
        {
        }
        
        public void Dispose()
        {
           // MessageHandlerMailBox.
           //     -= VehicleMessageHandler;
        }

        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
        }
    }
}
