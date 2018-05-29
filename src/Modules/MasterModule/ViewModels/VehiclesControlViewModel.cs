using System;
using System.Collections;
using System.Data;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using KarveCommonInterfaces;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the vehicles control view model.
    /// </summary>
    public class VehiclesControlViewModel: MasterControlViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private readonly IRegionManager _regionManager;
        private readonly UnityContainer _container;

        private IVehicleDataServices _vehicleDataServices;
        private const string VehiclesAgentSummaryVm = "VehiclesAgentSummaryVm";
        private const string VehiclesModuleRoutePrefix = "VehiclesModule:";
        public bool CreateRegionManagerScope => true;
       
        private INotifyTaskCompletion<IEnumerable<VehicleSummaryDto>> _vehicleTaskNotify;

        private IEnumerable<VehicleSummaryDto> _vehicleSummaryDtos;
        private PropertyChangedEventHandler _vehicleEventTask;

        
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
            AllowedGridColumns = GenerateAllowedColumns();
            InitViewModel();
        }
        private async void OpenCurrentItem(object selectedItem)
        {
            if (selectedItem is VehicleSummaryDto summaryItem)
            {
                var idNameTuple = new Tuple<string, string>(summaryItem.Code, summaryItem.Brand);
                var tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
                var agent = await _vehicleDataServices.GetVehicleDo(idNameTuple.Item1);
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("id",  idNameTuple.Item1);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(VehicleInfoView).FullName+navigationParameters,UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                var currentPayload = BuildShowPayLoadDo(tabName, agent);
                currentPayload.PrimaryKeyValue = idNameTuple.Item1;
                currentPayload.Subsystem = DataSubSystem.VehicleSubsystem;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, currentPayload);
                RegisterToolBar();
            }
        }

        private List<string> GenerateAllowedColumns()
        {
            List<string> s = new List<string>()
            { "Code", "Brand", "Model", "EnrollmentNumber",
                "Situation", "Office","Places",
                "CubeMeters",
                "Activity",
                "Color",
                "Owner",
                "OwnerName",
                "AssuranceCompany",
                "Policy",
                "LeasingCompany",
                "StartingDate",
                "EndingDate",
                "ClientNumber",
                "Client",
                "PurchaseInvoice",
                "Frame", "MotorNumber", "ModelYear", "Reference", "KeyCode", "StorageKey"};
            return s;
        }
        private void InitViewModel()
        {
            base.GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleGrid;
            MessageHandlerMailBox += MessageHandler;
            SummaryView = new IncrementalList<VehicleSummaryDto>(LoadMoreItems);
            StartAndNotify();
            _vehicleEventTask += OnNotifyIncrementalList<VehicleSummaryDto>;
            PagingEvent += OnPagedEvent;
            EventManager.RegisterMailBox(EventSubsystem.VehichleSummaryVm, MessageHandlerMailBox);
            StartAndNotify();          
        }
        // FIXME: see if it is possible to get rid of this..
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            if ((sender is INotifyTaskCompletion<IEnumerable<VehicleSummaryDto>> listCompletion) && (listCompletion.IsSuccessfullyCompleted))
            {

                if (SummaryView is IncrementalList<VehicleSummaryDto> summary)
                {
                    summary.LoadItems(listCompletion.Result);
                    SummaryView = summary;
                }
            }
        }
        public ICommand OpenItem
        {
            get => OpenItemCommand;
            set => OpenItemCommand = value;
        }
        
        public override void StartAndNotify()
        {
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            _vehicleTaskNotify = NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryDto>>(_vehicleDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize), _vehicleEventTask);
        
        }
        
        /// <summary>
        ///  This add a new item fresh from zero about vehicles.
        /// </summary>
        protected override void NewItem()
        {
            var name = KarveLocale.Properties.Resources.VehiclesControlViewModel_NewItem_NuevoVehiculos;
            var codigo = DataServices.GetSupplierDataServices().GetNewId();
            var viewNameValue = name + "." + codigo;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", codigo);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof(VehicleInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = BuildShowPayLoadDo(viewNameValue);
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
        /// <param name="payLoad">Name of the payload</param>
        
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
            // there is no single data object. Need for just a control interface and refacto.
        }

        /// <summary>
        /// This gets the routename for the vehicles subsystem.
        /// </summary>
        /// <param name="name">Name of the vehicle subsystem</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            var routedName = VehiclesModuleRoutePrefix + name;
            return routedName;

        }       
        /// <summary>
        ///  Message incoming from different 
        /// </summary>
        /// <param name="payload">Kind of payload coming from the diffent view model</param>
        public void IncomingPayload(DataPayLoad payload)
        {
        }
        /// <summary>
        ///  Set the summary as datatable.
        /// </summary>
        /// <param name="table"></param>
        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
        }
        public override async Task<bool> DeleteAsync(string vehiculeId, DataPayLoad payLoad)
        {
            var vehicleData = await DataServices.GetVehicleDataServices().GetVehicleDo(vehiculeId);
            var retValue = await DataServices.GetVehicleDataServices().DeleteVehicleDo(vehicleData);
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoad);
            return retValue;
        }

        public override void DisposeEvents()
        {
            _vehicleEventTask -= OnNotifyIncrementalList<VehicleSummaryDto>;
            EventManager.DeleteMailBoxSubscription(EventSubsystem.VehichleSummaryVm);
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            _vehicleSummaryDtos = result as IEnumerable<VehicleSummaryDto>;
            var maxItems =_vehicleDataServices.NumberItems;
            PageCount =_vehicleDataServices.NumberPage;
            SummaryView = new IncrementalList<VehicleSummaryDto>(LoadMoreItems) {MaxItemCount = (int) maxItems};
        }

        protected override void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryDto>>(
                _vehicleDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
            
        }
    }
}
