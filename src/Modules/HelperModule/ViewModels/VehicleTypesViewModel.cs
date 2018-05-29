using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  FIXME this is too complex. Refactor as other identifiers.
    /// </summary>
    public class VehicleTypesViewModel : BaseHelperViewModel, IDisposeEvents
    {
        private IncrementalList<VehicleTypeDto> _listOfVehicles;
        private VehicleTypeDto _vehicleType = new VehicleTypeDto();
        private VehicleTypeDto _prevVehicleType;
        private readonly HelperLoader<VehicleTypeDto, CATEGO> _loader;
        private readonly HelperSaver<VehicleTypeDto, CATEGO> _saver;
        private bool _saveState;

        /// <summary>
        /// VehicleTypes
        /// </summary>
        /// <param name="dataServices">Data services to be used</param>
        /// <param name="region">Region Manager to be used</param>
        /// <param name="eventManager">Event manager to be used</param>
        /// <param name="dialogService">Dialog service to be used</param>
        public VehicleTypesViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager, IDialogService dialogService) : base(dataServices, region, eventManager, dialogService)
        {
            ExecutedLoadHandler+= ExecutedLoadHandlerMethod;
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnItemChangedCommand);
            SaveState = false;
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleTypes;
            _listOfVehicles = new IncrementalList<VehicleTypeDto>(LoadMoreItems);
            _loader = new HelperLoader<VehicleTypeDto, CATEGO>(dataServices);
            _loader.Load(GenericSql.VehicleTypes);
            _loader.PageEvent += OnPagedEvent;
            _saver = new HelperSaver<VehicleTypeDto, CATEGO>(dataServices);            
            MailBoxMessageHandler += IncomingMailbox;
            EventManager.RegisterMailBox(Address.ToString(), MailBoxMessageHandler);
            InitVehicle();
        }
        /// <summary>
        ///  This is meant to be overriden only when the PageEvent is needed
        /// </summary>
        /// <param name="sender">Sender of the paging</param>
        /// <param name="e">Event handler</param>
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                var currentVehicleTypes = _loader.
                    FetchPage(sender, e);
            }
            catch (Exception ex)
            {
                DialogService?.ShowErrorMessage(ex.Message);
            }
        }
        private void LoadMoreItems(uint arg1, int offset)
        {
           
            _loader.LoadPaged(offset, DefaultPageSize);
        }

        private void InitVehicle()
        {
            
            _vehicleType.Code = "0";
            _vehicleType.Name = "";
            _vehicleType.OfferMargin = 0;
            _vehicleType.TerminationDate = DateTime.Now;
            _vehicleType.WebName = "";
        }
        private void OnSelectionChangedCommand(object value)
        {
            VehicleTypeDto dto = value as VehicleTypeDto;
            VehicleType = dto;
        }

        protected void Update()
        {
             _loader.Load(GenericSql.VehicleTypes);
            HelperView = _loader.HelperView;
            PrevVehicleType = VehicleType;
            VehicleType = HelperView.FirstOrDefault();
        }

      
        
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            DataPayLoad currentPayLoad = payLoad;
            if (currentPayLoad.HasDataObject)
            {
                VehicleTypeDto vehicleTypeDto = VehicleType;
                if (vehicleTypeDto == null)
                {
                    vehicleTypeDto = VehicleType;
                }
                var lastModification = DateTime.Now;
                vehicleTypeDto.LastModification = lastModification.ToString("yyyMMddHH:mm");
                bool value=  await _saver.SaveDto(vehicleTypeDto);
                if (!value)
                {
                    State = "Error in insertion/update";
                }
                _saveState = value;
                State = "";
            }
            return currentPayLoad;
        }
        /// <summary>
        ///  This dispse the events.
        /// </summary>
        public override void DisposeEvents()
        {
            _loader.PageEvent -= OnPagedEvent;
            EventManager.DeleteMailBoxSubscription(Address.ToString());
        }
        private void OnItemChangedCommand(object obj)
        {
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = Address;
            payload.PayloadType = DataPayLoad.Type.Update;
            payload.Subsystem = DataSubSystem.HelperSubsytsem;
            payload.DataObject = _vehicleType;
            payload.HasDataObject = true;
            payload.HasOldValue = true;
            payload.OldValue = _prevVehicleType;
            EventManager.NotifyToolBar(payload);     
        }

        private void ExecutedLoadHandlerMethod(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var completion = sender as INotifyTaskCompletion;
            // check if there are errors.
            if ((completion !=null) && (completion.Status == TaskStatus.Faulted))
            {
                // ok we need an interaction service a la prism.
                // https://www.codeproject.com/Articles/269364/MVVM-PRISM-Modal-Windows-by-using-Interaction-Requ

                MessageBox.Show("Error loading the data!");
            }
        }
        public VehicleTypeDto VehicleType
        {
            set { _vehicleType = value; RaisePropertyChanged();}
            get { return _vehicleType; }

        }
        public VehicleTypeDto PrevVehicleType
        {
            set { _prevVehicleType = value; RaisePropertyChanged(); }
            get { return _prevVehicleType; }

        }
        public IncrementalList<VehicleTypeDto> HelperView
        {
            set
            {
                _listOfVehicles = value; RaisePropertyChanged();
            }
            get
            {
                return _listOfVehicles;

            }
        }

        public override void Revert(DataPayLoad payLoad)
        {
            if (payLoad.HasOldValue)
            {
                var newValue = VehicleType;
                VehicleType = payLoad.OldValue as VehicleTypeDto;
                PrevVehicleType = newValue;
            }
        }

        public override  async  Task<bool> DeleteEntity(DataPayLoad payLoad)
        {
            var vehicle = VehicleType;
            bool entityDeleted = false;
            if (vehicle != null)
            {
                entityDeleted = await DataServices.GetHelperDataServices()
                    .ExecuteAsyncDelete<VehicleTypeDto, CATEGO>(vehicle);
                if (entityDeleted)
                {
                    Update();

                }
                else
                {
                    MessageBox.Show("Error deleting item");
                }
            }
            return entityDeleted;
        }
        /// <summary>
        ///  This returns the identifier generated for inserting an entity.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        public override async Task<bool> InsertEntity(DataPayLoad payLoad)
        {
            bool identifierGenerated = false;
            // here we shall use navigation for creating a new view.
            VehicleTypeDto dto = new VehicleTypeDto();
            dto.Code = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleTypeDto, CATEGO>(dto);
            if (!string.IsNullOrEmpty(dto.Code))
            {
                dto.Code = dto.Code.Substring(0, 2);
                var lastModification = DateTime.Now;
                dto.LastModification = lastModification.ToString("yyyyMMddHHmmss");
                VehicleType = dto;
                PrevVehicleType = dto;
                State = BaseHelperViewModel.InsertState;
                identifierGenerated = true;
            }
            return identifierGenerated;
        }
        public override bool UpdateEntity(DataPayLoad payLoad)
        {
            State = BaseHelperViewModel.UpdateState;
            _saveState = false;
            SaveItem(payLoad);
            Update();
            return _saveState;

        }

       
    }
}
