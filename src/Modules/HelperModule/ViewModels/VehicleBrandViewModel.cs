//-----------------------------------------------------------------------------------------
// <copyright file="VehicleBrandViewModel.cs" company="KarveInformatica S.L">
//   
// </copyright>
// <summary>
//   The vehicle brand view model.
// </summary>
// ----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// The vehicle brand view model.
    /// </summary>
    public class VehicleBrandViewModel : GenericHelperViewModel<BrandVehicleViewObject, MARCAS>
    {
        private INotifyTaskCompletion<IEnumerable<SupplierSummaryViewObject>> _initializationNotifier;
        private PropertyChangedEventHandler _loadCompleted;

        /// <summary>
        /// The _supplier summary.
        /// </summary>
        private IEnumerable<SupplierSummaryViewObject> _supplierSummary;

        public VehicleBrandViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService configurationService) : base(query, dataServices, region, manager, dialogService, configurationService)
        {
            _loadCompleted += OnLoadCompleted;
        }

        private void OnLoadCompleted(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (_initializationNotifier.IsSuccessfullyCompleted)
                {
                    SupplierSummary = _initializationNotifier.Task.Result;


                }
            }
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            _loadCompleted -= OnLoadCompleted;
        }
        public override Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<SupplierSummaryViewObject>> LoadSuppliers()
        {
            return await DataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
        }

        public IEnumerable<SupplierSummaryViewObject> SupplierSummary
        {

            set { _supplierSummary = value; RaisePropertyChanged(); }
            get { return _supplierSummary; }
      
        }

    }
}
