using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using Prism.Commands;
using KarveCommon.Generic;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics.Contracts;
using MasterModule.Views;
using System.Diagnostics;
using System.Linq;
using NLog;
using MasterModule.Common;
using KarveCommonInterfaces;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.ViewModels
{

    /// <inheritdoc />
    /// <summary>
    /// CompanyControlBViewModel.
    /// </summary>
    public sealed class CompanyControlViewModel : MasterControlViewModuleBase
    {
        
        /// <summary>
        /// Controller View Model for the company.
        /// </summary>
        /// <param name="configurationService">Configuration Service for the view model.</param>
        /// <param name="eventManager">EvenManager for the view model.</param>
        /// <param name="dialogService">DialogService for spotting errors.</param>
        /// <param name="services">Data Services to fetch/store data.</param>
        /// <param name="regionManager">Region manager for navigating to the child</param>
        public CompanyControlViewModel(IConfigurationService configurationService, IEventManager eventManager, IDialogService dialogService,IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, null, dialogService, regionManager)
        {
            OpenItemCommand = new DelegateCommand<object>(OnOpenItemCommand);
            InitEventHandler += LoadNotificationHandler;
            _mailBoxName = EventSubsystem.CompanySummaryVm;
            _companyDataServices = DataServices.GetCompanyDataServices();
            InitViewModel();
            
            ItemName = "Empresas";
            ActiveSubSystem();
        }

        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
           var listCompletion = sender as INotifyTaskCompletion<IEnumerable<CompanySummaryDto>>;
            if ((listCompletion != null) && (listCompletion.IsSuccessfullyCompleted))
            {

                if (SummaryView is IncrementalList<CompanySummaryDto> summary)
                {
                    summary.LoadItems(listCompletion.Result);
                    SummaryView = summary;
                }
            }

            if ((listCompletion != null) && (listCompletion.IsFaulted))
            {
                DialogService?.ShowErrorMessage("Error Loading data " + listCompletion.ErrorMessage);
            }
        }


        #region Public Properties
        public IEnumerable<CompanySummaryDto> SourceView
        {
            get { return _sourceView; }
            set { _sourceView = value; RaisePropertyChanged(); }
        }
        #endregion
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CompanySubsystem;
        }
        /// <summary>
        ///  Delete a company given its primary key
        /// </summary>
        /// <param name="primaryKey">Delete a single company</param>
        /// <param name="payLoad">Payload received</param>
        /// <returns></returns>
        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            
            var data = await _companyDataServices.GetAsyncCompanyDo(primaryKey);
            var retValue = await _companyDataServices.DeleteCompanyAsyncDo(data);
            return retValue;
        }
        protected override void OnSortCommand(object obj)
        {
            var sortedDictionary = obj as Dictionary<string, ListSortDirection>;
            _initializationNotifierCompany = NotifyTaskCompletion.Create<IEnumerable<CompanySummaryDto>>(_companyDataServices.GetSortedCollectionPagedAsync(sortedDictionary, 1, DefaultPageSize), _companyEventTask);
        }

        protected override string GetRouteName(string name)
        {
            var route = @"master://" + MasterModuleConstants.CompanySubSystemName + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        /// <summary>
        ///  We dont use this. Review where it is used.
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
        }
        /// <summary>
        /// Navigate to the view
        /// </summary>
        /// <param name="code">Code of the view to navigate</param>
        /// <param name="viewName">Viewname to view</param>
        private void Navigate(string code, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                { "id", code },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewName }
            };
            var uri = new Uri(typeof(CompanyInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.
                RequestNavigate("TabRegion", uri);
        }
        // since company we dont use anymore data tables for performance issues.
        protected override void SetTable(DataTable table)
        {
        }
        private void LoadNotificationHandler(object sender, PropertyChangedEventArgs ev)
        {
            if (!(sender is INotifyTaskCompletion<IEnumerable<CompanySummaryDto>> value))
            {
                return;
            }
            var propertyName = ev.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (value.IsSuccessfullyCompleted)
                {
                    SetResult(value.Task.Result);

                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                var result = value.Task.Result;
                SetResult(value.Task.Result);
            }
            else
            {
                if (value.IsFaulted)
                {
                    MessageBox.Show(value.ErrorMessage);
                }
            }
            Contract.Ensures(SourceView != null, "SourceView shall be present");   
        }

        protected override void NewItem()
        {
            string name = "Nueva Empresa"; 
                //KarveLocale.Properties.Resources.CompanyControlViewModel_NewItem_NuevaEmpresa;
            string companyId = _companyDataServices.GetNewId();
            string viewNameValue = name + "." + companyId;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters
            {
                { "id", companyId },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue }
            };
            var uri = new Uri(typeof(CompanyInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.CompanySubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = companyId;
            currentPayload.DataObject = _companyDataServices.GetNewCompanyDo(companyId);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.CompanySummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.CompanySubSystemName, currentPayload);
        }
        /// <summary>
        /// This is async void. Async void is bad because of clumsy way to handle exception.
        /// Speaking with Brian Lagunas, 
        /// he pointed me http://brianlagunas.com/prism-delegatecommand-fromasynchandler-is-obsolete/. 
        /// So basically in this case makes sense. We can skip using NotificationTask.Create
        /// </summary>
        /// <param name="selectedItem">The item from the grid.</param>
        private async void OnOpenItemCommand(object selectedItem)
        {
            var summaryItem = selectedItem as CompanySummaryDto;
            var watch = new Stopwatch();
            if (selectedItem != null)
            {
                if (summaryItem == null)
                    return;

                watch.Start();
                var name = summaryItem.Name;
                var id = summaryItem.Code;
                var tabName = id + "." + name;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("Id", id);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(CompanyInfoView).FullName + navigationParameters, UriKind.Relative);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Before navigation: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                RegionManager.RequestNavigate("TabRegion", uri);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Data before: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                var provider = await DataServices.GetCompanyDataServices().GetAsyncCompanyDo(id);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Data loaded: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                var currentPayload = BuildShowPayLoadDo(tabName, provider);
                currentPayload.PrimaryKeyValue = id;
                currentPayload.Sender = _mailBoxName;
                watch.Stop();
                Logger.Log(LogLevel.Debug, "[UI] ClientsControlViewModel. Opening Company Tab: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.CompanySubSystemName, currentPayload);
            }
        }
        private void InitViewModel()
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.CompanySummaryGrid;
            _companyEventTask += OnNotifyIncrementalList<CompanySummaryDto>;
            StartAndNotify();
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            // TODO: fix this correctly. This shall call the company paged configuration.
            var maxItems = result.Count();
            PageCount = (_companyDataServices.NumberPage == 0) ? 1: _companyDataServices.NumberPage;
            SummaryView = new IncrementalList<CompanySummaryDto>(LoadMoreItems) { MaxItemCount = (int)maxItems };
        }

        protected override void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<CompanySummaryDto>>(
                _companyDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
        }

        public override void StartAndNotify()
        {
            _initializationNotifierCompany = NotifyTaskCompletion.Create<IEnumerable<CompanySummaryDto>>(_companyDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize), _companyEventTask);
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.CompanySummaryVm, MessageHandlerMailBox);
            ActiveSubSystem();
        }

        


        #region Private Fields

        private INotifyTaskCompletion<IEnumerable<CompanySummaryDto>> _initializationNotifierCompany;
        private IEnumerable<CompanySummaryDto> _sourceView;
        private readonly string _mailBoxName;
        private IConfigurationService _configurationService;
        private IEventManager object1;
        private IDataServices _dataServices;
        private IRegionManager object2;
        private readonly ICompanyDataServices _companyDataServices;
        private PropertyChangedEventHandler _companyEventTask;

        #endregion

    }
}
