using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
  
    public class VehicleBrandViewModel : GenericHelperViewModel<BrandVehicleDto, MARCAS>
    {

        private INotifyTaskCompletion<IEnumerable<SupplierSummaryDto>> _initializationNotifier;
        private PropertyChangedEventHandler _loadCompleted;
        private IEnumerable<SupplierSummaryDto> _supplierSummary;

        public VehicleBrandViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager) : base(query, dataServices, region, manager)
        {
            _loadCompleted += OnLoadCompleted;

          //  _initializationNotifier = NotifyTaskCompletion.Create(LoadSuppliers(), _loadCompleted);
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

        public override Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<SupplierSummaryDto>> LoadSuppliers()
        {
            return await DataServices.GetSupplierDataServices().GetSupplierAsyncSummaryDo();
        }

        public IEnumerable<SupplierSummaryDto> SupplierSummary
        {

            set { _supplierSummary = value; RaisePropertyChanged(); }
            get { return _supplierSummary; }
      
        }

    }
}
