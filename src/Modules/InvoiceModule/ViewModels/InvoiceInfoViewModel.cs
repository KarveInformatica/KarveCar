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
        }

        #region Private fields.
        private IDataServices _dataServices;
        private IDialogService _dialogService;
        private IEventManager _eventManager;
        private IRegionManager _regionManager;
        #endregion
    }
}
