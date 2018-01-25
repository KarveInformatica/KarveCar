using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    internal class VehicleExtraViewModel: GenericHelperViewModel<VehicleExtraDto, EXTRASVEHI>
    {
        private IEnumerable<VehicleTypeDto> _vehicleTypeDto = new ObservableCollection<VehicleTypeDto>();
        private HelperLoader<VehicleTypeDto, CATEGO> _vehicleTypeLoader;
        public VehicleExtraViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
            _vehicleTypeLoader = new HelperLoader<VehicleTypeDto, CATEGO>(dataServices);
            InitLoad();
        }
        void InitLoad()
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleExtra;
            _vehicleTypeLoader.LoadAll();
            if (_vehicleTypeLoader.HelperView != null)
            {
                VehicleTypeDto = _vehicleTypeLoader.HelperView;
            }
        }
        /// <summary>
        ///  VehicleTypeDto.
        /// </summary>
        private IEnumerable<VehicleTypeDto> VehicleTypeDto
        {
            set { _vehicleTypeDto = value; RaisePropertyChanged();}
            get { return _vehicleTypeDto; }
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VehicleExtraDto dto = payLoad.DataObject as VehicleExtraDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleExtraDto, EXTRASVEHI>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
