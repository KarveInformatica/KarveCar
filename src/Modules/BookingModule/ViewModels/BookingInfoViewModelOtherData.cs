using KarveControls.ViewModels;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BookingModule.ViewModels
{

    /// <summary>
    /// Related part to the handling of the other data tab
    /// </summary>
    internal sealed partial class BookingInfoViewModel  : HeaderedLineViewModelBase<IBookingData, BookingDto, BookingItemsDto>
    {
        private ObservableCollection<GeneralInfo> _generalInfoCollection;
        private ICommand _printCommand;
        private IEnumerable<OrigenDto> _origin = new ObservableCollection<OrigenDto>();
        private IEnumerable<BookingMediaDto> _media = new ObservableCollection<BookingMediaDto>();
        private IEnumerable<BookingTypeDto> _bookingType = new ObservableCollection<BookingTypeDto>();
        public  IEnumerable<AgencyEmployeeDto> _agencyEmployees = new ObservableCollection<AgencyEmployeeDto>();
        private IEnumerable<ContactsDto> _bookingContacts = new ObservableCollection<ContactsDto>();
        private IEnumerable<PaymentFormDto> _bookingPaymentForm = new ObservableCollection<PaymentFormDto>();
        private IEnumerable<VehicleActivitiesDto> _bookingVehicleActivity = new ObservableCollection<VehicleActivitiesDto>();
        private IEnumerable<PrintingTypeDto> _printingTypeDto = new ObservableCollection<PrintingTypeDto>();
      
        /// <summary>
        ///  Creating an observable collection for other data.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<GeneralInfo> CreateCollectionForOtherData()
        {
            var builder = new GeneralInfoCollectionBuilder(AssistCommand, CreateCommand, ItemChangedCommand);
            builder.Add(KarveLocale.Properties.Resources.StringConstants_Origen,"ORIGEN_RES", "BOOKING_ORIGIN_ASSIST", "BOOKING_ORIGIN_CREATE", "Code, Name");
            builder[0].SourceView = BookingOrigen;
            
            builder.Add(KarveLocale.Properties.Resources.lbookingmedia, "MEDIO_RES", "BOOKING_MEDIO_ASSIST", "BOOKING_MEDIO_CREATE", "Name,Code");
            builder[1].SourceView = BookingMedia;
            builder.Add(KarveLocale.Properties.Resources.lbookingtype, "TIPORES_RES1", "BOOKING_TYPE_ASSIST", "BOOKING_TYPE_CREATE", "Name,Code");
            builder[2].SourceView = BookingType;
            builder.Add(KarveLocale.Properties.Resources.lagencyemployee,"EMPLEAGE_RES2", "EMPLEAGE_ASSIST", "EMPLEAGE_CREATE", "Name,Code");
            builder[3].SourceView = BookingAgencyEmployee;
            builder.Add(KarveLocale.Properties.Resources.lcontacto,"CONTACTO_RES2", "BOOKING_CONTACTO_ASSIST", "BOOKING_CONTACTO_CREATE", "Name,Code");
            builder[4].SourceView = BookingContacts;
            builder.Add(KarveLocale.Properties.Resources.lformadecobro,"FCOBRO_RES1", "BOOKING_FCOBRO_ASSIST", "BOOKING_FCOBRO_CREATE", "Name,Code");
            builder[5].SourceView = BookingPaymentFormDto;
            builder.Add(KarveLocale.Properties.Resources.lprintingtype,"CONTRATIPIMPR_RES", "BOOKING_CONTRATIPIMPR_ASSIST", "BOOKING_CONTRATIPIMPR_CREATE", "Name,Code");
            builder[6].SourceView = PrintingTypeDto;
            builder.Add(KarveLocale.Properties.Resources.lrbtnActividadesVehiculos, "ACTIVEHI_RES1", "BOOKING_ACTIVEHI_RES1_ASSIST", "BOOKING_ACTIVEHI_RES1_CREATE", "Name,Code");
            builder[7].SourceView = BookingVehicleActivity;
            return builder.AsObservable();
        }



        /// <summary>
        ///  Set or Get the booking origin.
        /// </summary>
        public IEnumerable<OrigenDto> BookingOrigen
        {
            set
            {
                _origin = value;
                RaisePropertyChanged();
            }
            get
            {
                return _origin;
            }
        }
        /// <summary>
        ///  Set or Get the medium reservation.
        /// </summary>
        public IEnumerable<BookingMediaDto> BookingMedia
        {
            set
            {
                _media = value;
                RaisePropertyChanged();
            }
            get
            {
                return _media;
            }
        }


        /// <summary>
        ///  Set or Get the booking type
        /// </summary>
        public IEnumerable<BookingTypeDto> BookingType
        {
            set
            {
                _bookingType = value;
            }
            get
            {
                return _bookingType;
            }
        }
        /// <summary>
        ///  Set or get the booking contacts
        /// </summary>
        public IEnumerable<ContactsDto> BookingContacts
        {
            set
            {
                _bookingContacts = value;
            }
            get
            {
                return _bookingContacts;
            }
        }    
        /// <summary>
        ///  Set or Get the booking payment form
        /// </summary>
        public IEnumerable<PaymentFormDto> BookingPaymentFormDto
        {
            set
            {
                _bookingPaymentForm = value;
            }
            get
            {
                return _bookingPaymentForm;
            }
        }
        public IEnumerable<AgencyEmployeeDto> BookingAgencyEmployee
        {
            set
            {
                _agencyEmployees = value;
                RaisePropertyChanged();
            }
            get
            {
                return _agencyEmployees;
            }
        }
        /// <summary>
        ///  Set or get the vehicle activity.
        /// </summary>
        public IEnumerable<VehicleActivitiesDto> BookingVehicleActivity
        {
            set
            {
                _bookingVehicleActivity = value;
                RaisePropertyChanged();
            }
            get
            {
                return _bookingVehicleActivity;
            }
        }
        /// <summary>
        ///  Set pr get Printing type dto.
        /// </summary>
        public IEnumerable<PrintingTypeDto> PrintingTypeDto
        {
            set
            {
                _printingTypeDto = value;
                RaisePropertyChanged();
            }
            get
            {
                return _printingTypeDto;
            }
        }
        /// <summary>
        /// Set the data object inside. 
        /// </summary>
        /// <param name="dataObject">Data object to be used</param>
        /// <param name="otherData">General info data to be used.</param>
        private ObservableCollection<GeneralInfo> SetDataObject(object dataObject,  ObservableCollection<GeneralInfo> otherData)
        {
            // map 
            otherData.ToList<GeneralInfo>().ForEach(i => i.DataSource = dataObject);
            return new ObservableCollection<GeneralInfo>(otherData);
        }
        /// <summary>
        ///  SourceView to be used.
        /// </summary>
        /// <param name="dataObject">Data object</param>
        /// <param name="otherData">Other data view to be used.</param>
        private void SetSourceView(object dataObject, ref ObservableCollection<GeneralInfo> otherData)
        {
            otherData.ToList<GeneralInfo>().ForEach(i => i.SourceView = dataObject);
        }


        /// <summary>
        ///  GeneralInfo collection. Collection for the general info searchbox.
        /// </summary>
        public ObservableCollection<GeneralInfo> GeneralInfoCollection
        {
            set
            {
                 _generalInfoCollection = value;
                RaisePropertyChanged();
            }
            get
            {
                return _generalInfoCollection;
            }
        }
        /// <summary>
        ///  Print command for the Reservation label.
        /// </summary>
        public ICommand PrintCommand
        {
            set
            {
                _printCommand = value;
                RaisePropertyChanged();
            }
            get
            {
                return _printCommand;
            }
        }
    }
}
