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
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;

namespace HelperModule.ViewModels
{
    internal class VehicleExtraViewModel: GenericHelperViewModel<VehicleExtraDto, EXTRASVEHI>
    {
        private HelperLoader<VehicleTypeDto, CATEGO> _vehicleTypeLoader;

        public DelegateCommand<object> ExtraAssistCommand { get; set; }

        private IncrementalList<VehicleTypeDto> _vehicleTypeDto;


        private ObservableCollection<VehicleTypeDto> _vehicleTypeCollection;


        public VehicleExtraViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
            _vehicleTypeLoader = new HelperLoader<VehicleTypeDto, CATEGO>(dataServices);
            InitLoad();
        }


        void InitLoad()
        {
            _vehicleTypeDto = new IncrementalList<VehicleTypeDto>(LoadMoreItems);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleExtra;
           
        }
        /// <summary>
        ///  VehicleTypeDto.
        /// </summary>
        private IncrementalList<VehicleTypeDto> VehicleTypeDto
        {
            set { _vehicleTypeDto = value; RaisePropertyChanged();}
            get { return _vehicleTypeDto; }
        }
        private void LoadMoreItems(uint count, int baseIndex)
        {
            _vehicleTypeLoader.LoadAll();
            if (_vehicleTypeLoader.HelperView != null)
            {
                var vehicleTypes = _vehicleTypeLoader.HelperView;
                var list = vehicleTypes.Skip(baseIndex).Take(200).ToList();
                VehicleTypeDto.LoadItems(list);
            }
            RaisePropertyChanged("");
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
