using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls.UIObjects;
using KarveDataServices;
using MasterModule.Common;
using MasterModule.Interfaces;
using MasterModule.UIObjects.CommissionAgents;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    class CommissionAgentControlViewModel : MasterViewModuleBase, IEventObserver, ICreateRegionManagerScope
    {
        private const string ComiNameColumn = "Numero";
        private const string ComiColumnCode = "Nombre";
        private UnityContainer _container;
        /// <summary>
        ///  This is the region manager.
        /// </summary>
        private IRegionManager _regionManager;

        private DataTable _extendedSupplierDataTable;
        private const string CommissionAgentSummaryVm = "CommisionAgentSummaryVm";

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
            _extendedSupplierDataTable = new DataTable();
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
            set { _extendedSupplierDataTable = value; RaisePropertyChanged(); }
            get { return _extendedSupplierDataTable; }
        }

        private void InitViewModel()
        {
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
            //    _regionManager.RequestNavigate("TabRegion", MasterModule.CommissionAgentInfoView);

                ICommissionAgentView view = _container.Resolve<ICommissionAgentView>();
                ConfigurationService.AddMainTab(view, tabName);
                // this builds the dimension of the page.
                IList<IUiPageBuilder> builders = new List<IUiPageBuilder>();
                builders.Add(new UiCommissionAgentUpperPartBuilder());
                UiFirstPageBuilder generalPageBuilder = new UiFirstPageBuilder(builders);
                IDictionary<string, ObservableCollection<IUiObject>> pageObjects =
                    generalPageBuilder.BuildPageObjects(null, null);
                ObservableCollection<IUiObject> upperPartObservableCollection = pageObjects[MasterModule.UiUpperPart];
                IList<ObservableCollection<IUiObject>> obsList = new List<ObservableCollection<IUiObject>>();
                obsList.Add(upperPartObservableCollection);
                ObservableCollection<IUiObject> observableCollection = MergeList(obsList);
                IDictionary<string, string> currentQueries =
                    SQLBuilder.SqlBuildSelectFromUiObjects(observableCollection, idNameTuple.Item1, false);
                ICommissionAgentDataServices agentDataServices = DataServices.GetCommissionAgentDataServices();
                DataSet currentSet = await agentDataServices.GetCommissionAgent(currentQueries);
                IDictionary<string, object> componentDictionary =
                    await SetComponentHelpers(currentSet, observableCollection);
                DataSet assistDataSet = componentDictionary[MasterViewModuleBase.Dataset] as DataSet;
                ObservableCollection<IUiObject> componentObjects =
                    componentDictionary[MasterViewModuleBase.Collection] as ObservableCollection<IUiObject>;
                IList<DataSet> dataSet = new List<DataSet>();
                dataSet.Add(currentSet);
                dataSet.Add(assistDataSet);
                DataPayLoad currentPayload = BuildShowPayLoad(tabName, dataSet);
                currentPayload.PrimaryKeyValue = idNameTuple.Item1;
                EventManager.notifyObserverSubsystem(MasterModule.CommissionAgentSystemName, currentPayload);
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
            //  throw new NotImplementedException();
        }

        public override void StartAndNotify()
        {
            MessageHandlerMailBox +=CommissionAgentMailBox;
            EventManager.RegisterMailBox(CommissionAgentControlViewModel.CommissionAgentSummaryVm, MessageHandlerMailBox);
            ICommissionAgentDataServices commissionAgentDataServices = DataServices.GetCommissionAgentDataServices();
            InitializationNotifier = NotifyTaskCompletion.Create<DataSet>(commissionAgentDataServices.GetCommissionAgentSummary());
            InitializationNotifier.PropertyChanged += InitializationNotifierOnPropertyChanged;
        }

        private void CommissionAgentMailBox(DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        public override void NewItem()
        {
            throw new NotImplementedException();
        }

        protected override void SetTable(DataTable table)
        {
            SummaryView = table;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
        }

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
