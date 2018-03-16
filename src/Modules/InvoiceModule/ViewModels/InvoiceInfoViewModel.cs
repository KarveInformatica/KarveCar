using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using KarveCommon.Generic;
using KarveDataServices;
using KarveCommonInterfaces;
using KarveCommon.Services;
using Prism.Regions;
using System.Collections.ObjectModel;
using KarveDataServices.DataTransferObject;
using System.Windows.Input;
using KarveControls.Behaviour.Grid;
using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///  View model for the info view.
    /// </summary>
    public class InvoiceInfoViewModel : KarveViewModelBase
    {
        /// <summary>
        /// InvoiceInfoViewModel is a view model for creating invoice view.
        /// </summary>
        /// <param name="dataServices">Data Service. Shared service for retrieving data.</param>
        /// <param name="dialogServices">Dialog service. Shared service for spotting custom error dialog.</param>
        /// <param name="manager">EventManager service. Shared service for communication between view models.</param>
        /// <param name="regionManager">RegionManager service. Shared service for the region manager.</param>
        /// 
        public InvoiceInfoViewModel(IDataServices dataServices,
                                    IDialogService dialogServices,
                                    IEventManager manager,
                                    IRegionManager regionManager)
        {
            _dataServices = dataServices;
            _dialogService = dialogServices;
            _eventManager = manager;
            _regionManager = regionManager;
            var genericInovice = new InvoiceSummaryDto();
            SourceView = new ObservableCollection<InvoiceSummaryDto>();
            ItemChangedCommand = new DelegateCommand<IDictionary<string,object>>(OnGridChanged);
            var colList = new List<string>();
            foreach (var value in genericInovice.GetType().GetProperties())
            {
                colList.Add(value.Name);
            }
         
            GridColumns = new List<string>()
            {
                "AgreementCode","VehicleCode", "Opciones", "Description", "Quantity", "Price", "Discount", "Subtotal",
                "Unity", "FileNumber", "Iva"
            };
            /*
             * This is a cell grid presentation item 
             */
           var presenter = new ObservableCollection<CellPresenterItem>()
            {
                new NavigationAwareItem() { DataTemplateName="NavigateInvoiceItem", MappingName="AgreementCode", RegionName=RegionNames.LineRegion},
                new NavigationAwareItem() { DataTemplateName="NavigateInvoiceItem", MappingName="VehicleCode", RegionName=RegionNames.LineRegion}
            };
           CellGridPresentation= presenter;
        }
        /// <summary>
        ///  Notification Request.
        /// </summary>
        public InteractionRequest<INotification> NotificationRequest
        {
            get
            {
                return _notificationRequest;
            }
            set
            {
                _notificationRequest = value;
                RaisePropertyChanged("NotificationRequest");
            }
        }
        private void OnGridChanged(IDictionary<string, object> dict)
        {
         
        }

        /// <summary>
        ///  Items to be shown in the lower grid.
        /// </summary>
        public object SourceView
        {
            set
            {
                _sourceView = value;
                RaisePropertyChanged("SourceView");
            }
            get
            {
                return _sourceView;
            }
        }
        /// <summary>
        ///  Columns of the grid.
        /// </summary>
        public List<string> GridColumns {
            set
            {
                _gridView = value;
                RaisePropertyChanged("GridColumns");
            }
            get
            {
                return _gridView;
            }
        }
        /// <summary>
        ///  Opciones to be loaded in the grid.
        /// </summary>
        public ObservableCollection<CellPresenterItem> CellGridPresentation
        {
            get
            {
                return _cellNavigationAware;
            }
            set
            {
                _cellNavigationAware = value;
                RaisePropertyChanged("CellGridPresentation");
            }
        }
        #region Private fields.
        private IDataServices _dataServices;
        private IDialogService _dialogService;
        private IEventManager _eventManager;
        private IRegionManager _regionManager;
        private object _sourceView;
        private List<string> _gridView;
        private InteractionRequest<INotification> _notificationRequest;
        private ObservableCollection<CellPresenterItem> _cellNavigationAware;
        #endregion
    }
}
