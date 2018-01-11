using System;
using System.Data;
using System.Windows.Input;
using KarveDataServices;
using KarveCommon.Services;
using Prism.Commands;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Diagnostics;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.Interfaces;
using MasterModule.Views;
using Prism.Regions;
using KarveDataServices.DataTransferObject;
using System.Threading.Tasks;
using NLog;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This is the control view model for the suppliers.
    /// It shows the summary of the suppliers that are present in the system and on a click from the view fires a info view model.
    /// In the current system there are two type of view model:
    /// 1. ControlViewModels. This kind of view model is responsible for: 
    /// a. fire up all the tabs needed foreach item.
    /// b. delete  
    ///     It exposes a summary data trasnsfer object 
    /// 
    /// 2. InfoViewModels. This kind of view model is responsible for show the value of each specific item.
    /// </summary>
    public class ProvidersControlViewModel : MasterViewModuleBase, IProvidersViewModel
    {
        private const string ProviderNameColumn = "Nombre";
        private const string ProviderColumnCode = "Codigo";
        private const string ProviderModuleRoutePrefix = "ProviderModule:";
        private const int GridIdentifier = 1; 
        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private readonly IUnityContainer _container;
        private static string PROVIDER_SUMMARY_VM = "ProvidersControlViewModel";
        private DataTable _extendedSupplierDataTable;

        private IRegionManager _regionManager;
        private Stopwatch _timing = new Stopwatch();
        private IEnumerable<SupplierSummaryDto> _summaryCollection = new List<SupplierSummaryDto>();
        private static long _uniqueIdentifier = 0;

        private ISettingsDataService _settings;
        private string _mailBoxName;

        // Yes it violateds SRP it does two things. Show the main and fireup a new ui.

        public ProvidersControlViewModel(IConfigurationService configurationService,
            IUnityContainer container,
            IDataServices services,
            IRegionManager regionManager,
            IEventManager eventManager) : base(configurationService, eventManager, services, regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            _extendedSupplierDataTable = new DataTable();
            _uniqueIdentifier = _uniqueIdentifier % Int64.MaxValue;
            _mailBoxName = PROVIDER_SUMMARY_VM;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
        }
        /// <summary>
        ///  Property that return the summary of Suppliers.
        /// </summary>
        public IEnumerable<SupplierSummaryDto> SummaryCollection
        {
            set
            {
                _summaryCollection = value;
                RaisePropertyChanged();
            }
            get => _summaryCollection;
        }

        private void InitViewModel()
        {
            MagnifierGridName = PROVIDER_SUMMARY_VM;
            GridId = 1;
            StartAndNotify();
        }
        /// <summary>
        ///  Command to open a new view for each detailed supplier.
        /// </summary>
       
        public ICommand OpenItem
        {
            get { return OpenItemCommand; }
            set { OpenItemCommand = value; }
        }

        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
            LoadMagnifierSettings();
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
        }
        /// <summary>
        ///  This returns a long value.
        /// </summary>
        public override long GridId { get; set; }
        /// <summary>
        ///  This returns a grid name.
        /// </summary>
        public override string MagnifierGridName { get; set; }

        protected override void SetDataObject(object result)
        {
            // we dont use here any data object.
        }

        public void LoadMagnifierSettings()
        {
            _settings = DataServices.GetSettingsDataService();
             MagnifierInitializationNotifier =
                NotifyTaskCompletion.Create<IMagnifierSettings>(_settings.GetMagnifierSettings(GridId),InitializationNotifierOnSettingsChanged);

        }
        /// <summary>
        ///  Return the selected columns summary view for the suppliers. It might be paged.
        /// </summary>
        public DataTable SummaryView
        {
            get
            {

                return _extendedSupplierDataTable;

            }
            private set { _extendedSupplierDataTable = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This route a name.
        /// </summary>
        /// <param name="name">This write a name to be sent as routring</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            string routedName = ProviderModuleRoutePrefix + name;
            return routedName;

        }
        /// <summary>
        /// This method creates a new item using prsim scope navigation.
        ///    
        /// </summary>
        public override void NewItem()
        {
            string name = KarveLocale.Properties.Resources.ProvidersControlViewModel_NewItem_NuevoProveedor;
            string supplierId = DataServices.GetSupplierDataServices().GetNewId();
            string viewNameValue = name + "." + supplierId;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("supplierId", supplierId);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof(ProviderInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.SupplierSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = supplierId;
            currentPayload.DataObject = DataServices.GetSupplierDataServices().GetNewSupplierDo(supplierId);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.SuppliersSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.ProviderSubsystemName, currentPayload);
        }
       
        private async void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                DataRow row = rowView.Row;
                string name = row[ProviderNameColumn] as string;
                string supplierId = row[ProviderColumnCode] as string;
                string tabName = supplierId + "." + name;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("supplierId", supplierId);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(ProviderInfoView).FullName+navigationParameters,UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                ISupplierData provider = await DataServices.GetSupplierDataServices().GetAsyncSupplierDo(supplierId);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);                
                currentPayload.PrimaryKeyValue = supplierId;
                currentPayload.Sender = _mailBoxName;
                Logger.Log(LogLevel.Debug, "[UI] ProviderControlViewModel. Opening Supplier Tab: " + supplierId);
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.ProviderSubsystemName, currentPayload);
            }
        }
        // This override the notification and start for the v
        public override void StartAndNotify()
        {
            MessageHandlerMailBox += MessageHandler;
            _mailBoxName = ProvidersControlViewModel.PROVIDER_SUMMARY_VM;
            EventManager.RegisterMailBox(_mailBoxName, MessageHandlerMailBox);
            ISupplierDataServices supplier = DataServices.GetSupplierDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(supplier.GetAsyncAllSupplierSummary(), InitializationNotifierOnPropertyChanged);
          
        }
        public override async Task<bool> DeleteAsync(string supplierId, DataPayLoad payLoad)
        {
            ISupplierData provider = await DataServices.GetSupplierDataServices().GetAsyncSupplierDo(supplierId);
            bool retValue = await DataServices.GetSupplierDataServices().DeleteAsyncSupplierDo(provider);
            return retValue;
        }

        public override void DisposeEvents()
        {
           // this save the columns settings.
           base.DisposeEvents();
           DeleteMailBox(_mailBoxName);
        }
    }
}
