using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;



namespace HelperModule.ViewModels
{
    class VehicleRepostajeReasonViewModel : BaseHelperViewModel, IDisposeEvents
    {
        private VehicleProvisionReasonDto _provisionReason;
        private VehicleProvisionReasonDto _prevProvisionReasonDto;
        private ObservableCollection<VehicleProvisionReasonDto> _listProvision = new ObservableCollection<VehicleProvisionReasonDto>();
        private INotifyTaskCompletion<IEnumerable<VehicleProvisionReasonDto>> _initializationNotifier;
        private HelperLoader<VehicleProvisionReasonDto, MOT_REPOSTAJE> _helperLoader;
        public VehicleRepostajeReasonViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(dataServices, region, manager)
        {
            MailBoxMessageHandler += IncomingMailbox;
            var id = Address.ToString();
            EventManager.RegisterMailBox(id, MailBoxMessageHandler);
            ItemChangedCommand = new DelegateCommand<object>(OnItemChangedCommand);
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            _helperLoader = new HelperLoader<VehicleProvisionReasonDto,MOT_REPOSTAJE>(dataServices);
            _helperLoader.Load(GenericSql.VehicleProvisionReason);
            HelperView = _helperLoader.HelperView;
            var value = HelperView.FirstOrDefault();
            if (value != null)
            {
                VehicleProvisionReason = value;
                PreviousProvisionReasonDto = value;
            }
        }
        private void OnItemChangedCommand(object obj)
        {
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = Address;
            payload.PayloadType = DataPayLoad.Type.Update;
            payload.Subsystem = DataSubSystem.HelperSubsytsem;
            payload.DataObject = _provisionReason;
            payload.HasDataObject = true;
            payload.HasOldValue = true;
            payload.OldValue = _prevProvisionReasonDto;
            EventManager.NotifyToolBar(payload);
        }
        private void OnSelectionChangedCommand(object value)
        {
            VehicleProvisionReasonDto dto = value as VehicleProvisionReasonDto;
            VehicleProvisionReason = dto;
        }
        public VehicleProvisionReasonDto PreviousProvisionReasonDto
        {
            set
            {
                _prevProvisionReasonDto = value;
                 RaisePropertyChanged();
            }
            get { return _provisionReason; }
        }
        public VehicleProvisionReasonDto VehicleProvisionReason
        {
            set
            {
                _prevProvisionReasonDto = _provisionReason;
                _provisionReason = value; RaisePropertyChanged();
            }
            get { return _provisionReason; }
        }
        public ObservableCollection<VehicleProvisionReasonDto> HelperView
        {
            get { return _listProvision; }
            set
            {
                _listProvision = value;
                RaisePropertyChanged();
            }
        }

        public override void Revert(DataPayLoad payLoad)
        {
            var tmp = _provisionReason;
            VehicleProvisionReason = payLoad.DataObject as VehicleProvisionReasonDto;
            PreviousProvisionReasonDto = _provisionReason;
        }
        protected void Update()
        {
            _helperLoader.Load(GenericSql.VehicleProvisionReason);
            HelperView = _helperLoader.HelperView;
            var first = _helperLoader.HelperView.FirstOrDefault();
            if (first!=null)
            {
                VehicleProvisionReason = HelperView.FirstOrDefault();
            }
        }
        public override async Task<bool> DeleteEntity(DataPayLoad payLoad)
        {
            var vehicle = VehicleProvisionReason;
            bool entityDeleted = false;
            if (vehicle != null)
            {
                entityDeleted = await DataServices.GetHelperDataServices()
                    .ExecuteAsyncDelete<VehicleProvisionReasonDto, MOT_REPOSTAJE>(vehicle);
                if (entityDeleted)
                {
                    Update();

                }
                else
                {
                    // replace twith an appropriate popup
                    MessageBox.Show("Error deleting item");
                }

            }
            return entityDeleted;
        }

        public override async Task<bool> InsertEntity(DataPayLoad payLoad)
        {
            bool entityInserted = true;
            // here we shall use navigation for creating a new view.
            VehicleProvisionReasonDto dto = new VehicleProvisionReasonDto();
            var str = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleProvisionReasonDto, MOT_REPOSTAJE>(dto);
            dto.Code = Convert.ToByte(str);
            var lastModification = DateTime.Now;
            dto.LastModification = lastModification.ToString("yyyMMddHH:mm");
            VehicleProvisionReason = dto;
            PreviousProvisionReasonDto = dto;
            State = BaseHelperViewModel.InsertState;
            return entityInserted;
        }
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            DataPayLoad currentPayLoad = payLoad;
            if (currentPayLoad.HasDataObject)
            {
                VehicleProvisionReasonDto vehicleProvisionReasonDto = VehicleProvisionReason;
                if (vehicleProvisionReasonDto == null)
                {
                    vehicleProvisionReasonDto = VehicleProvisionReason;
                }
                var lastModification = DateTime.Now;
                vehicleProvisionReasonDto.LastModification = lastModification.ToString("yyyMMddHH:mm");
                bool value = await DataServices.GetHelperDataServices().ExecuteInsertOrUpdate<VehicleProvisionReasonDto, MOT_REPOSTAJE>(vehicleProvisionReasonDto);
                if (!value)
                {
                    State = "Error in insertion/update";
                }
                SaveState = value;
                State = "";
            }
            return currentPayLoad;
        }
        public override bool UpdateEntity(DataPayLoad payLoad)
        {
            State = BaseHelperViewModel.UpdateState;
            SaveState = false;
            SaveItem(payLoad);
            Update();
            return SaveState;
        }
        public void DisposeEvents()
        {
            var id = Address.ToString();
            EventManager.DeleteMailBoxSubscription(id);
        }
    }
}
