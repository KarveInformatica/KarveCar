using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using KarveCommon.Generic;
using MasterModule.Views;
using MasterModule.Common;
using KarveDataServices.DataObjects;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics.Contracts;
using Prism.Commands;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using NLog;
using Syncfusion.UI.Xaml.Grid;
using KarveCommonInterfaces;
using System.Windows.Input;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  View of control for the office.
    /// </summary>
   public sealed class OfficesControlViewModel : MasterControlViewModuleBase
    {
        /// <summary>
        ///  Control view for the office
        /// </summary>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="eventManager">Event manager</param>
        /// <param name="services">Data Services</param>
        /// <param name="regionManager">Region manager</param>
        /// 
        public OfficesControlViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IInteractionRequestController interactionService, IDialogService dialogService, IRegionManager regionManager) :
            base(configurationService, eventManager, services, interactionService, dialogService, regionManager)
        {
           
            _officeDataServices = services.GetOfficeDataServices();
            ItemName = "Oficinas";
            InitViewModel();
        }
        protected override void OnSortCommand(object obj)
        {
            var sortedDictionary = obj as Dictionary<string, ListSortDirection>;
            _initializationNotifierOffice = NotifyTaskCompletion.Create<IEnumerable<OfficeSummaryDto>>(_officeDataServices.GetSortedCollectionPagedAsync(sortedDictionary, 1, DefaultPageSize), _officeEventTask);
        }

 
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
            {
                if ((sender is INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>> listCompletion) && (listCompletion.IsSuccessfullyCompleted))
                {

                    if (SummaryView is IncrementalList<OfficeSummaryDto> summary)
                    {
                        summary.LoadItems(listCompletion.Result);
                        SummaryView = summary;
                    }
                }
            }
        

        /// <summary>
        ///  Grid of the offices in the database.
        /// </summary>
        public IEnumerable<OfficeSummaryDto> SourceView
        {
            get => _sourceView;
            set { _sourceView = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Delete asynchronously an office
        /// </summary>
        /// <param name="primaryKey">Primary Key</param>
        /// <param name="payLoad">Data payload</param>
        /// <returns>True or false</returns>
        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            var service = DataServices.GetOfficeDataServices();
            var data = await service.GetAsyncOfficeDo(primaryKey);
            bool retValue = await service.DeleteOfficeAsyncDo(data);
            if (retValue)
            {
                payLoad.PayloadType = DataPayLoad.Type.Delete;
                payLoad.Subsystem = DataSubSystem.OfficeSubsystem;
                payLoad.PrimaryKey = primaryKey;
                EventManager.NotifyObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, payLoad);
            }
            return retValue;
        }
        
        private void NewOffice()
        {
            string name = "NuevaOficina";
            string officeId = DataServices.GetOfficeDataServices().GetNewId();
            string viewNameValue = officeId + "." + name;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters
            {
                { "Id", officeId },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue }
            };
            var uri = new Uri(typeof(OfficeInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.OfficeSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = officeId;
            currentPayload.DataObject = _officeDataServices.GetNewOfficeDo(officeId);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.OfficeSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, currentPayload);

        }
        /// <inheritdoc />
        /// <summary>
        ///  NewItem. This is a new item for the office.
        /// </summary>
        protected override void NewItem()
        {
           
            
        }
        /// <inheritdoc />
        /// <summary>
        ///  This initalize the view model.
        /// </summary>
        public override void StartAndNotify()
        {
            IOfficeDataServices officeDataService = DataServices.GetOfficeDataServices();
            InitializationNotifierOffice = NotifyTaskCompletion.Create<IEnumerable<OfficeSummaryDto>>(officeDataService.GetPagedSummaryDoAsync(1, DefaultPageSize), 
                (task, ev)=> 
                {
                    if (task is INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>> vehicles)
                    {
                        if (vehicles.IsSuccessfullyCompleted)
                        {
                            var collection = vehicles.Result;
                            var maxItems = officeDataService.NumberItems;
                            PageCount = officeDataService.NumberPage;
                            var summaryList = new IncrementalList<OfficeSummaryDto>(LoadMoreItems) { MaxItemCount = (int)maxItems };
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

        private void InitViewModel()
        {
            ViewModelUri = new Uri("karve://office/viewmodel?id=" + Guid.ToString());
            PagingEvent += OnPagedEvent;
            _newOfficeCommand = new DelegateCommand(NewOffice);
            OpenItemCommand = new DelegateCommand<object>(OnOpenItemCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.OfficeSummaryGrid;
            InitEventHandler += LoadNotificationHandler;
            _officeEventTask += OnNotifyIncrementalList<OfficeSummaryDto>;
            DeleteEventHandler += OfficeDeleteHandler;
            _mailBoxName = EventSubsystem.OfficeSummaryVm;
            MessageHandlerMailBox += MessageHandler;
            EventManager.RegisterMailBox(_mailBoxName, MessageHandlerMailBox);
            StartAndNotify();
            
        }
        private void OfficeDeleteHandler(object sender, PropertyChangedEventArgs ev)
        {
            if (!(sender is INotifyTaskCompletion<bool> value))
            {
                return;
            }
            if (value.IsSuccessfullyCompleted)
            {
                    
                var result = value.Task.Result;
                if (!result)
                {
                    DialogService?.ShowErrorMessage("Error during delete");
                        
                }
                // ok in this case we can
            }
            else if (value.IsFaulted)
            {
                var exc = value.InnerException;
                DialogService?.ShowErrorMessage("Exception: "+exc);
            }
        }
        public override void DisposeEvents()
        {  
           
            UnregisterToolBar(PrimaryKey, _newOfficeCommand, null, null);
            MessageHandlerMailBox -= MessageHandler;
            InitEventHandler -= LoadNotificationHandler;
            DeleteEventHandler -= OfficeDeleteHandler;
            PagingEvent -= OnPagedEvent;
            _officeEventTask -= OnNotifyIncrementalList<OfficeSummaryDto>;
            DeleteMailBox(_mailBoxName);
            base.DisposeEvents();
        }
        /// <summary>
        ///  Open a new item.
        ///  When know that Async void is bad. Speaking with Dan Kegel and Briand Lagunas explained the rational that in case of a command there is no bad
        ///  thing.
        /// </summary>
        /// <param name="selectedItem">Selected command</param>
        private async void OnOpenItemCommand(object selectedItem)
        {
            OfficeSummaryDto summaryItem = selectedItem as OfficeSummaryDto;
            
            if (selectedItem != null)
            {
                if (summaryItem != null)
                {
                    Stopwatch  watch = new Stopwatch();
                    string name = summaryItem.Name;
                    string id = summaryItem.Code;
                    string tabName = id + "." + name;
                    var navigationParameters = new NavigationParameters();
                    navigationParameters.Add("Id", id);
                    navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                    var uri = new Uri(typeof(OfficeInfoView).FullName + navigationParameters, UriKind.Relative);
                    Logger.Log(LogLevel.Debug, "[UI] OfficeInfoViewModel. Before navigation: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                    RegionManager.RequestNavigate("TabRegion", uri);
                    Logger.Log(LogLevel.Debug, "[UI] OfficeInfoViewModel. Data before: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                    IOfficeData provider = await DataServices.GetOfficeDataServices().GetAsyncOfficeDo(id);
                    provider.Value.Empresa = summaryItem.CompanyName;
                    Logger.Log(LogLevel.Debug, "[UI] OfficeInfoViewModel. Data loaded: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                    DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);
                    currentPayload.PrimaryKeyValue = id;
                    currentPayload.Sender = _mailBoxName;
                    watch.Stop();
                    Logger.Log(LogLevel.Debug, "[UI] OfficeInfoViewModel. Opening Office Tab: " + id + "Elapsed time: " + watch.ElapsedMilliseconds);
                    EventManager.NotifyObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, currentPayload);
                }
            }
        }

        /// <summary>
        ///  FIXME: i repeat myself.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="ev">Office name</param>
        private void LoadNotificationHandler(object sender, PropertyChangedEventArgs ev)
        {
            INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>> value = sender as INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>>;
            string propertyName = ev.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (value.IsSuccessfullyCompleted)
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
                if (value.IsFaulted)
                {
                    DialogService?.ShowErrorMessage(value.ErrorMessage);
                }
            }
            Contract.Ensures(SourceView != null, "SourceView shall be present");
        }

        /// <summary>
        ///  This swet the routename for the event mailbox.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            var route = @"master://" + MasterModuleConstants.OfficeSubSytemName + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        /// <summary>
        ///  DataPayload
        /// </summary>
        /// <param name="payLoad">Registration payload for the office.</param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.OfficeSubsystem;
            payLoad.HasNewCommand = true;
            payLoad.NewCommand = _newOfficeCommand;
            payLoad.Sender = ViewModelUri.ToString();
            payLoad.ObjectPath = ViewModelUri;
        }
        protected override void SetDataObject(object result)
        {
            
        }
       
        // TODO eliminate this.
        protected override void SetTable(DataTable table)
        {
            
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            var maxItems = _officeDataServices.NumberItems;
            PageCount = _officeDataServices.NumberPage;
            var officeList = new IncrementalList<OfficeSummaryDto>(LoadMoreItems) { MaxItemCount = (int)PageCount };
            officeList.LoadItems(result as IEnumerable<OfficeSummaryDto>);
            SummaryView = officeList;
        }

        protected override void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<OfficeSummaryDto>>(
                _officeDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);

        }
        #region Private Fields

        private INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>> InitializationNotifierOffice;
        private IEnumerable<OfficeSummaryDto> _sourceView;
        private string _mailBoxName;
        private readonly IOfficeDataServices _officeDataServices;
        private IUnityContainer _container;
        private INotifyTaskCompletion<IEnumerable<OfficeSummaryDto>> _initializationNotifierOffice;
        private PropertyChangedEventHandler _officeEventTask;
        private ICommand _newOfficeCommand;

        #endregion
    }
}
