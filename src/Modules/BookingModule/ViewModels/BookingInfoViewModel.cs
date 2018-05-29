using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using Prism.Commands;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  BookingInfoViewModel
    /// </summary>
    internal class BookingInfoViewModel: HeaderedLineViewModelBase<IBookingData, BookingDto, BookingItemsDto>
    {

        private BookingDto _bookingDtoValue;
        private IBookingDataService _bookingDataService;
        private IEnumerable<BookingItemsDto> _dataSource;

        /// <summary>
        /// BookingInfoViewModel
        /// </summary>
        /// <param name="dataServices"></param>
        /// <param name="dialogServices"></param>
        /// <param name="manager"></param>
        /// <param name="regionManager"></param>
        /// <param name="controller"></param>
        public BookingInfoViewModel(IDataServices dataServices,
            IDialogService dialogServices,
            IEventManager manager,
            IRegionManager regionManager,
            IInteractionRequestController controller) : base(dataServices,
            dialogServices,manager,regionManager,dataServices.GetBookingDataService(), controller)
        {
           
            InitViewModel();
            DefaultPageSize = 200;
        }

        private void InitViewModel()
        {
            _bookingDataService = DataServices.GetBookingDataService();
            MailBoxHandler += IncomingMailBox;
            RegisterMailBox(ViewModelUri.ToString());
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            EventManager.RegisterObserverSubsystem(BookingModule.BookingSubSystem, this);
            ViewModelUri = new Uri("karve://booking/viewmodel?id=" + Guid.ToString());
        }

        private void OpenCurrentItem(object obj)
        {         

        }

        public void OnAssistCommand(object assist)
        {
        }
        public void OnChangedField(object var)
        {
        }
        protected override string GetRouteName(string name)
        {
            return ViewModelUri.ToString();
        }
        /// <summary>
        ///     Data object for the invoice.
        /// </summary>
        public BookingDto DataObject
        {
            set
            {
                _bookingDtoValue = value;
                RaisePropertyChanged();
            }
            get => _bookingDtoValue;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
            payLoad.ObjectPath = ViewModelUri;
            
        }
        protected override void CleanUp(string primarykey, DataSubSystem subsystem, string eventSubsystem)
        {
            DeleteEventCleanup(primarykey, PrimaryKeyValue, DataSubSystem.BookingSubsystem, EventSubsystem.BookingSubsystemVm);
            DeleteRegion();

        }
        protected override void Init(string value, DataPayLoad payload, bool insertion)
        {
            if (!payload.HasDataObject) return;
            if (payload.DataObject is IBookingData data)
            {
                var dataObject = data.Value;
                dataObject.BookingItems = data.ItemsDtos;
                DataObject = dataObject;
                ItemSource = data.ItemsDtos; 
                ActiveSubSystem();
            }

        }
        /// <summary>
        ///  ItemSource.
        /// </summary>
        public IEnumerable<BookingItemsDto> ItemSource
        {
            get => _dataSource;
            set { _dataSource = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Direct messaging from the event manager
        /// </summary>
        /// <param name="payLoad">Kind of payload</param>
        private void IncomingMailBox(DataPayLoad payLoad)
        {

        }
        protected override async Task<bool> DeleteAsync(DataPayLoad payLoad)
        {
            var value = await _bookingDataService.GetDoAsync(payLoad.PrimaryKeyValue);
            if (!value.IsValid) return false;
            var retValue = await _bookingDataService.DeleteAsync(value);
            return retValue;
        }

        public ICommand OpenItemCommand { get; set; }
        public ICommand AssistCommand { get; set; }

       
    }
}
