using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the vehicles control view model.
    /// </summary>
    public class VehiclesControlViewModel: MasterViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private IVehicleDataServices _vehicleDataServices;
        private const string ComiNameColumn = "Codeint";
        private const string ComiColumnCode = "Nombre";
        private UnityContainer _container;
        /// <summary>
        ///  This is the region manager.
        /// </summary>
        private IRegionManager _regionManager;
        /// <summary>
        ///  TODO: move to a common class.
        /// </summary>
        private DataTable _extendedSupplierDataTable;

        private const string VehiclesAgentSummaryVm = "VehiclesAgentSummaryVm";
        private const string VehiclesModuleRoutePrefix = "VehiclesModule:";

        public bool CreateRegionManagerScope => throw new NotImplementedException();
        /// <summary>
        ///  This is the veichle control view model. This is responsable for the opening new tabs.
        /// </summary>
        /// <param name="configurationService">Configuration service. It give us the global configuration</param>
        /// <param name="eventManager"></param>
        /// <param name="services"></param>
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
           _extendedSupplierDataTable = new DataTable();
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();

        }

        private void OpenCurrentItem(object obj)
        {
           
        }

        private void InitViewModel()
        {
            StartAndNotify();
            
        }

        public ICommand OpenItem
        {
            get { return OpenItemCommand; }
            set { OpenItemCommand = value; }
        }
        public override void StartAndNotify()
        {
            // the message handler is resposible to receive messages from the different view models.
            MessageHandlerMailBox += VehicleMessageHandler;
            EventManager.RegisterMailBox(VehiclesControlViewModel.VehiclesAgentSummaryVm, MessageHandlerMailBox);
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(_vehicleDataServices.GetVehiclesAgentSummary(0));
            InitializationNotifier.PropertyChanged += InitializationNotifierOnPropertyChanged;
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
                EventManager.notifyObserverSubsystem(MasterModule.VehiclesSystemName, payLoad);
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
            set { _extendedSupplierDataTable = value; RaisePropertyChanged(); }
            get { return _extendedSupplierDataTable; }
        }
        /// <summary>
        ///  This add a new item fresh from zero about vehicles.
        /// </summary>
        public override void NewItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  This method is called after the notification from the base class to set the table after the load summary mechanism 
        ///  has been launched. 
        /// </summary>
        /// <param name="table"></param>
        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
        }
        /// <summary>
        /// This gets the routename for the vehicles subsystem.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            string routedName = VehiclesModuleRoutePrefix + name;
            return routedName;

        }
        /// <summary>
        ///  Message incoming from different 
        /// </summary>
        /// <param name="payload">Kind of payload coming from the diffent view model</param>
        public void incomingPayload(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }
    }
}
