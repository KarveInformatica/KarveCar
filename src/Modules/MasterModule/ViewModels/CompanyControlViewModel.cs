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
using NLog;
using KarveDataServices.DataObjects;
using MasterModule.Common;

namespace MasterModule.ViewModels
{

    /// <summary>
    /// CompanyControlBViewModel.
    /// </summary>
    internal class CompanyControlViewModel : MasterControlViewModuleBase
    {
        
        public CompanyControlViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)
        {
            OpenItemCommand = new DelegateCommand<object>(OnOpenItemCommand);
            InitEventHandler += LoadNotificationHandler;
            _mailBoxName = EventSubsystem.CompanySummaryVm;
            InitViewModel();
            ActiveSubSystem();
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
            ICompanyDataService service = DataServices.GetCompanyDataServices();
            ICompanyData data = await service.GetAsyncCompanyDo(primaryKey);
            bool retValue = await service.DeleteCompanyAsyncDo(data);
            return retValue;
        }
        /// <summary>
        ///  This start the control grid creation.
        /// </summary>
        public override void StartAndNotify()

        {
            ICompanyDataService companyDataService = DataServices.GetCompanyDataServices();
            InitializationNotifierCompany = NotifyTaskCompletion.Create<IEnumerable<CompanySummaryDto>>(companyDataService.GetAsyncAllCompanySummary(), InitEventHandler);
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(EventSubsystem.CompanySummaryVm, MessageHandlerMailBox);
            ActiveSubSystem();
        }

        protected override string GetRouteName(string name)
        {
            var route = @"master://" + MasterModuleConstants.CompanySubSystemName + "//" + name;
            string routedName = new Uri(route).AbsoluteUri;
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
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", code);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewName);
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
            INotifyTaskCompletion<IEnumerable<CompanySummaryDto>> value = sender as INotifyTaskCompletion<IEnumerable<CompanySummaryDto>>;
            string propertyName = ev.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (InitializationNotifierCompany.IsSuccessfullyCompleted)
                {
                    if (value != null)
                    {
                        SourceView = value.Task.Result;
                    }

                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                var result = value?.Task.Result;
                SourceView = result;
            }
            else
            {
                if (InitializationNotifierCompany.IsFaulted)
                {
                    MessageBox.Show(InitializationNotifierCompany.ErrorMessage);
                }
            }
            Contract.Ensures(SourceView != null, "SourceView shall be present");   
        }

        public override void NewItem()
        {
            string name = KarveLocale.Properties.Resources.CompanyControlViewModel_NewItem_NuevaEmpresa;
            string companyId = DataServices.GetCompanyDataServices().GetNewId();
            string viewNameValue = name + "." + companyId;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", companyId);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof(CompanyInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.CompanySubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = companyId;
            currentPayload.DataObject = DataServices.GetCompanyDataServices().GetNewCompanyDo(companyId);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.CompanySummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.CompanySubSystemName, currentPayload);
        }
        private async void OnOpenItemCommand(object selectedItem)
        {
            CompanySummaryDto summaryItem = selectedItem as CompanySummaryDto;
            Stopwatch watch = new Stopwatch();
            if (selectedItem != null)
            {
                watch.Start();
                string name = summaryItem.Name;
                string id = summaryItem.Code;
                string tabName = id + "." + name;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("Id", id);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(CompanyInfoView).FullName + navigationParameters, UriKind.Relative);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Before navigation: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                RegionManager.RequestNavigate("TabRegion", uri);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Data before: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                ICompanyData provider = await DataServices.GetCompanyDataServices().GetAsyncCompanyDo(id);
                Logger.Log(LogLevel.Debug, "[UI] CompanyControlViewModel. Data loaded: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);
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
            StartAndNotify();
        }

        
        #region Private Fields

        private INotifyTaskCompletion<IEnumerable<CompanySummaryDto>> InitializationNotifierCompany;
        private IEnumerable<CompanySummaryDto> _sourceView;
        private string _mailBoxName;
        /// <summary>
        ///  This is the client subsystem prefix module.
        /// </summary>
        private const string ClientModuleRoutePrefix = MasterModuleConstants.ClientSubSystemName;


        #endregion

    }
}
