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
using System.Threading.Tasks;

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
        private long _longId = 3;
        private ISettingsDataService _settings;



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
            IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)
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
                var agent = await _vehicleDataServices.GetVehicleDo(idNameTuple.Item1);
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("id",  idNameTuple.Item1);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(VehicleInfoView).FullName+navigationParameters,UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, agent);
                currentPayload.PrimaryKeyValue = idNameTuple.Item1;
                currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, currentPayload);
                RegisterToolBar();
            }
        }


        private void InitViewModel()
        {
            MagnifierGridName = VehiclesAgentSummaryVm;
            GridId = 3;
            StartAndNotify();          
        }
        public ICommand OpenItem
        {
            get { return OpenItemCommand; }
            set { OpenItemCommand = value; }
        }

        public void LoadMagnifierSettings()
        {
            _settings = DataServices.GetSettingsDataService();
            MagnifierInitializationNotifier =
                NotifyTaskCompletion.Create<IMagnifierSettings>(_settings.GetMagnifierSettings(GridId), InitializationNotifierOnSettingsChanged);

        }
        public override void StartAndNotify()
        {
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.VehichleSummaryVm, MessageHandlerMailBox);
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(_vehicleDataServices.GetVehiclesAgentSummary(0, 0), InitializationNotifierOnPropertyChanged);

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
            string name = KarveLocale.Properties.Resources.VehiclesControlViewModel_NewItem_NuevoVehiculos;
            string codigo = DataServices.GetSupplierDataServices().GetNewId();
            VehicleInfoView view = _container.Resolve<VehicleInfoView>();
            string viewNameValue = name + "." + codigo;
            ConfigurationService.AddMainTab(view, viewNameValue);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            currentPayload.HasDataObject = true;
            currentPayload.DataObject = DataServices.GetVehicleDataServices().GetNewVehicleDo(codigo);
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
        ///  Grid identifier.
        /// </summary>
        public override long GridId { get => _longId; set => _longId = value; }
        /// <summary>
        ///  Magnifier GridName.
        /// </summary>
        public override string MagnifierGridName { get; set; }

        /// <summary>
        /// Set data object
        /// </summary>
        /// <param name="result">This is the data object for this screen</param>
        protected override void SetDataObject(object result)
        {
            // there is no single data object. Need for just a control interface and refacto.
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
 
        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
            LoadMagnifierSettings();
        }
        public override async Task<bool> DeleteAsync(string vehiculeId, DataPayLoad payLoad)
        {
            IVehicleData vehicleData = await DataServices.GetVehicleDataServices().GetVehicleDo(vehiculeId);
            bool retValue = await DataServices.GetVehicleDataServices().DeleteVehicleDo(vehicleData);
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoad);
            return retValue;
        
        }

        public override void DisposeEvents()
        {
        }
    }
}
