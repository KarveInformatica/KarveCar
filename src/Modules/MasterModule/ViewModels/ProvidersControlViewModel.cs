using System.Data;
using System.Windows.Input;
using KarveDataServices;
using KarveCommon.Services;
using Prism.Commands;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Interfaces;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This is the view model for suppliers.
    /// </summary>
    public class ProvidersControlViewModel : MasterViewModuleBase, IProvidersViewModel
    {
        private const string ProviderNameColumn = "Nombre";
        private const string ProviderColumnCode = "Codigo";
        private const string ProviderModuleRoutePrefix = "ProviderModule:";
        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private readonly IUnityContainer _container;
        private static string PROVIDER_SUMMARY_VM = "ProvidersControlViewModel";
        private DataTable _extendedSupplierDataTable;
        private ICommand _pagedItemCommand;
        private Stopwatch _timing = new Stopwatch();

        // Yes it violateds SRP it does two things. Show the main and fireup a new ui.

        public ProvidersControlViewModel(IConfigurationService configurationService,
            IUnityContainer container,
            IDataServices services,
            IEventManager eventManager) : base(configurationService, eventManager, services)
        {
            _container = container;
            _extendedSupplierDataTable = new DataTable();
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
        }

        private void InitViewModel()
        {
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
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
        }

        protected override void SetDataObject(object result)
        {
           /// throw new System.NotImplementedException();
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
        /**
         *  This creates a new item with relatives datasets.
         */
        public override void NewItem()
        {
            string name = Properties.Resources.ProvidersControlViewModel_OpenNewItem_NewSupplier;
            string codigo = "";

            // move this to the configuration service.
            ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
            // TODO: use the navigation service.
            ConfigurationService.AddMainTab(view, name);
            IList<DataSet> dataSet = new List<DataSet>();
            dataSet.Add(new DataSet());
            dataSet.Add(new DataSet());
            DataPayLoad currentPayload = BuildShowPayLoad(name, dataSet);
            currentPayload.SubsystemViewModel = "ProvidersControlViewModel";
            currentPayload.Subsystem = DataSubSystem.SupplierSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            EventManager.NotifyObserverSubsystem(MasterModule.ProviderSubsystemName, currentPayload);
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
                ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
                ConfigurationService.AddMainTab(view, tabName);
                IList<IUiPageBuilder> list = new List<IUiPageBuilder>();
                list.Add(new UIObjects.Suppliers.UiSuppliersUpperPartPageBuilder());
                list.Add(new UIObjects.Suppliers.UiMiddlePartPageBuilder(null));
                UiFirstPageBuilder generalPageBuilder = new UiFirstPageBuilder();
                IDictionary<string, ObservableCollection<IUiObject>> pageObjects = generalPageBuilder.BuildPageObjects(null, null);
                ObservableCollection<IUiObject> upperPartObservableCollection = pageObjects[MasterModule.UiUpperPart];
                ObservableCollection<IUiObject> middlePageObservableCollection = pageObjects[MasterModule.UiMiddlePartPage];
                IList<ObservableCollection<IUiObject>> obsList = new List<ObservableCollection<IUiObject>>();
                obsList.Add(upperPartObservableCollection);
                obsList.Add(middlePageObservableCollection);
                ObservableCollection<IUiObject> observableCollection = MergeList(obsList);
                IDictionary<string, string> current = SqlBuilder.SqlBuildSelectFromUiObjects(observableCollection, supplierId, false);
                DataSet currentSet = await DataServices.GetSupplierDataServices().GetAsyncSupplierInfo(current);
                IDictionary<string, string> assistQueries = new Dictionary<string, string>();
                FillViewModelAssistantQueries(observableCollection, currentSet, ref assistQueries);
                DataSet assitDataSet = await DataServices.GetHelperDataServices().GetAsyncHelper(assistQueries);
                IList<DataSet> dataSet = new List<DataSet>();
                             
                dataSet.Add(currentSet);
                dataSet.Add(assitDataSet);
                DataPayLoad currentPayload = BuildShowPayLoad(tabName, dataSet);                
                currentPayload.PrimaryKeyValue = supplierId;
                currentPayload.Sender = PROVIDER_SUMMARY_VM;
                EventManager.NotifyObserverSubsystem(MasterModule.ProviderSubsystemName, currentPayload);
            }
        }
        // This override the notification and start for the v
        public override void StartAndNotify()
        {
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(ProvidersControlViewModel.PROVIDER_SUMMARY_VM, MessageHandlerMailBox);
            ISupplierDataServices supplier = DataServices.GetSupplierDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(supplier.GetAsyncAllSupplierSummary(), InitializationNotifierOnPropertyChanged);
        }

        /// <summary>
        ///  Command to be triggeed from the control to support paging
        /// </summary>
        public ICommand PageChangedCommand { set; get; }
      


    }
}
