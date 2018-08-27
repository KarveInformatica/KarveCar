using System;
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
using KarveDataServices.ViewObjects;
using System.Collections.Generic;
using System.ComponentModel;
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
       
        private INotifyTaskCompletion<IEnumerable<VehicleSummaryViewObject>> _vehicleTaskNotify;

        private IEnumerable<VehicleSummaryViewObject> _vehicleSummaryDtos;
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
            base.GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleGrid;
            _container = container;
            _regionManager = regionManager;
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            AllowedGridColumns = GenerateAllowedColumns();

            InitViewModel();
        }
        private async void OpenCurrentItem(object selectedItem)
        {
            if (selectedItem is VehicleSummaryViewObject summaryItem)
            {
                var idNameTuple = new Tuple<string, string>(summaryItem.Code, summaryItem.Brand);
                var tabName = idNameTuple.Item1 + "." + idNameTuple.Item2;
                var agent = await _vehicleDataServices.GetDoAsync(idNameTuple.Item1).ConfigureAwait(false);
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("id",  idNameTuple.Item1);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(VehicleInfoView).FullName+navigationParameters,UriKind.Relative);
              //  _navigationService.NavigateAsync<MainPageviewModel>();
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
          
            MessageHandlerMailBox += MessageHandler;
            SummaryView = new IncrementalList<VehicleSummaryViewObject>(LoadMoreItems);
            StartAndNotify();
            _vehicleEventTask += OnNotifyIncrementalList<VehicleSummaryViewObject>;
            PagingEvent += OnPagedEvent;
            EventManager.RegisterMailBox(EventSubsystem.VehichleSummaryVm, MessageHandlerMailBox);
            // Register the current subsystem to the toolbar.
            ActiveSubSystem();
            StartAndNotify();          
        }
        // FIXME: see if it is possible to get rid of this..
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            if ((sender is INotifyTaskCompletion<IEnumerable<VehicleSummaryViewObject>> listCompletion) && (listCompletion.IsSuccessfullyCompleted))
            {

                if (SummaryView is IncrementalList<VehicleSummaryViewObject> summary)
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
        
        public void StartAndNotify()
        {
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            _vehicleTaskNotify = NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryViewObject>>(_vehicleDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev)=> {
                if (task is INotifyTaskCompletion<IEnumerable<VehicleSummaryViewObject>> vehicles)
                {
                    if (vehicles.IsSuccessfullyCompleted)
                    {
                        var collection = vehicles.Result;
                        var maxItems = _vehicleDataServices.NumberItems;
                        PageCount =_vehicleDataServices.NumberPage;
                        var summaryList = new IncrementalList<VehicleSummaryViewObject>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                        summaryList.LoadItems(collection);
                        SummaryView = summaryList;

                    }
                    else
                    {
                        DialogService?.ShowErrorMessage("No puedo cargar datos de vehiculos : " + vehicles.ErrorMessage);
                    }
                }
            });
        }
        
        /// <summary>
        ///  This add a new item fresh from zero about vehicles.
        /// </summary>
        protected override void NewItem()
        {
            var name = KarveLocale.Properties.Resources.VehiclesControlViewModel_NewItem_NuevoVehiculos;
            var codigo = _vehicleDataServices.NewId();
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
            currentPayload.DataObject = _vehicleDataServices.GetNewDo(codigo);
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
            SubSystem = DataSubSystem.VehicleSubsystem;
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
        public override void IncomingPayload(DataPayLoad payload)
        {
        }
       
        public override async Task<bool> DeleteAsync(string vehiculeId, DataPayLoad payLoad)
        {
            var vehicleData = await _vehicleDataServices.GetDoAsync(vehiculeId).ConfigureAwait(false);
            var retValue = await _vehicleDataServices.DeleteAsync(vehicleData).ConfigureAwait(false);
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoad);
            return retValue;
        }

        public override void DisposeEvents()
        {
            _vehicleEventTask -= OnNotifyIncrementalList<VehicleSummaryViewObject>;
            EventManager.DeleteMailBoxSubscription(EventSubsystem.VehichleSummaryVm);
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            _vehicleSummaryDtos = result as IEnumerable<VehicleSummaryViewObject>;
            var maxItems =_vehicleDataServices.NumberItems;
            PageCount =_vehicleDataServices.NumberPage;
            SummaryView = new IncrementalList<VehicleSummaryViewObject>(LoadMoreItems) {MaxItemCount = (int) maxItems};
        }

        protected override void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryViewObject>>(
                _vehicleDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
            
        }
        public override void Dispose()
        {
        }
    }
}
