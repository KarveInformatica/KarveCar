using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;

namespace HelperModule.ViewModels
{
    internal class VehicleExtraViewModel: GenericHelperViewModel<VehicleExtraViewObject, EXTRASVEHI>
    {
        private HelperLoader<VehicleTypeViewObject, CATEGO> _vehicleTypeLoader;
        public DelegateCommand<object> ExtraAssistCommand { get; set; }
        private IncrementalList<VehicleTypeViewObject> _vehicleTypeDto;


        
        /// <summary>
        /// Constructor for the vehicleviewextra view model.
        /// </summary>
        /// <param name="dataServices">DataServices to be used</param>
        /// <param name="region">Region manager to be used</param>
        /// <param name="manager">Event manager to be used</param>

        public VehicleExtraViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(string.Empty, dataServices, region, manager, dialogService, config)
        {
            _vehicleTypeLoader = new HelperLoader<VehicleTypeViewObject, CATEGO>(dataServices);
            InitLoad();
        }

        /// <summary>
        /// Initialize the items and the incremental list to be shown in a grid.
        /// </summary>
        private void InitLoad()
        {
            _vehicleTypeDto = new IncrementalList<VehicleTypeViewObject>(LoadMoreItems);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleExtra;
        }
        /// <summary>
        ///  VehicleTypeViewObject.
        /// </summary>
        private IncrementalList<VehicleTypeViewObject> VehicleTypeDto
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
            VehicleExtraViewObject viewObject = payLoad.DataObject as VehicleExtraViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleExtraViewObject, EXTRASVEHI>(viewObject);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
