using KarveControls.ViewModels;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BookingModule.ViewModels
{

    /// <inheritdoc />
    /// <summary>
    /// Related part to the handling of the other data tab
    /// </summary>
    internal sealed partial class BookingInfoViewModel  : HeaderedLineViewModelBase<IBookingData, BookingViewObject, BookingItemsViewObject>
    {
        private ObservableCollection<GeneralInfo> _generalInfoCollection;
        private ICommand _printCommand;
        private IEnumerable<OrigenViewObject> _origin = new ObservableCollection<OrigenViewObject>();
        private IEnumerable<BookingMediaViewObject> _media = new ObservableCollection<BookingMediaViewObject>();
        private IEnumerable<BookingTypeViewObject> _bookingType = new ObservableCollection<BookingTypeViewObject>();
        public  IEnumerable<AgencyEmployeeViewObject> _agencyEmployees = new ObservableCollection<AgencyEmployeeViewObject>();
        private IEnumerable<ContactsViewObject> _bookingContacts = new ObservableCollection<ContactsViewObject>();
        private IEnumerable<PaymentFormViewObject> _bookingPaymentForm = new ObservableCollection<PaymentFormViewObject>();
        private IEnumerable<VehicleActivitiesViewObject> _bookingVehicleActivity = new ObservableCollection<VehicleActivitiesViewObject>();
        private IEnumerable<PrintingTypeViewObject> _printingTypeDto = new ObservableCollection<PrintingTypeViewObject>();
      
        /// <summary>
        ///  Creating an observable collection for other data.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<GeneralInfo> CreateCollectionForOtherData()
        {
            var builder = new GeneralInfoCollectionBuilder(AssistCommand, CreateCommand, ItemChangedCommand);
            builder.Add(KarveLocale.Properties.Resources.StringConstants_Origen,"ORIGEN_RES2", "BOOKING_ORIGIN_ASSIST", "BOOKING_ORIGIN_CREATE", "Code, Name");
            builder[0].SourceView = BookingOrigen;
            builder[0].Name = "BookingOrigin";
            builder.Add(KarveLocale.Properties.Resources.lbookingmedia, "MEDIO_RES1", "BOOKING_MEDIO_ASSIST", "BOOKING_MEDIO_CREATE", "Code,Name");
            builder[1].SourceView = BookingMedia;
            builder[1].Name = "BookingMedia";

            builder.Add(KarveLocale.Properties.Resources.lbookingtype, "TIPORES_RES1", "BOOKING_TYPE_ASSIST", "BOOKING_TYPE_CREATE", "Code,Name");
            builder[2].SourceView = BookingType;
            builder[2].Name = "BookingType";

            builder.Add(KarveLocale.Properties.Resources.lagencyemployee,"EMPLEAGE_RES2", "EMPLEAGE_ASSIST", "EMPLEAGE_CREATE", "Code,Name");
            builder[3].SourceView = BookingAgencyEmployee;
            builder[3].Name = "BookingAgencyEmployee";

            builder.Add(KarveLocale.Properties.Resources.lcontacto,"CONTACTO_RES2", "BOOKING_CONTACTO_ASSIST", "BOOKING_CONTACTO_CREATE", "Code,Name");
            builder[4].SourceView = BookingContacts;
            builder[4].Name = "BookingContacts";
            builder.Add(KarveLocale.Properties.Resources.lformadecobro,"FCOBRO_RES1", "BOOKING_FCOBRO_ASSIST", "BOOKING_FCOBRO_CREATE", "Codigo,Nombre");
            builder[5].SourceView = BookingPaymentFormDto;
            builder[5].Name = "BookingPaymentForm";
            builder.Add(KarveLocale.Properties.Resources.lprintingtype,"CONTRATIPIMPR_RES", "BOOKING_CONTRATIPIMPR_ASSIST", "BOOKING_CONTRATIPIMPR_CREATE", "Code,Name");
            builder[6].SourceView = PrintingTypeDto;
            builder[6].Name = "BookingContract";
            builder.Add(KarveLocale.Properties.Resources.lrbtnActividadesVehiculos, "ACTIVEHI_RES1", "BOOKING_ACTIVEHI_RES1_ASSIST", "BOOKING_ACTIVEHI_RES1_CREATE", "Code,Activity");
            builder[7].SourceView = BookingVehicleActivity;
            builder[7].Name = "BookingVehicleActivity";
            return builder.AsObservable();
        }



        /// <summary>
        ///  Set or Get the booking origin.
        /// </summary>
        public IEnumerable<OrigenViewObject> BookingOrigen
        {
            set
            {
                _origin = value;
                RaisePropertyChanged("BokingOrigen");
            }
            get => _origin;
        }
        /// <summary>
        ///  Set or Get the medium reservation.
        /// </summary>
        public IEnumerable<BookingMediaViewObject> BookingMedia
        {
            set
            {
                _media = value;
                RaisePropertyChanged();
            }
            get => _media;
        }


        /// <summary>
        ///  Set or Get the booking type
        /// </summary>
        public IEnumerable<BookingTypeViewObject> BookingType
        {
            set
            {
                _bookingType = value;
                RaisePropertyChanged("BookingType");
            }
            get => _bookingType;
        }
        /// <summary>
        ///  Set or get the booking contacts
        /// </summary>
        public IEnumerable<ContactsViewObject> BookingContacts
        {
            set
            {
                _bookingContacts = value;
                RaisePropertyChangeAfterInit("BookingContacts");
            }
            get => _bookingContacts;
        }    
        /// <summary>
        ///  Set or Get the booking payment form
        /// </summary>
        public IEnumerable<PaymentFormViewObject> BookingPaymentFormDto
        {
            set
            {
                _bookingPaymentForm = value;
                RaisePropertyChangeAfterInit("BookingPaymentFormDto");
            }
            get => _bookingPaymentForm;
        }
        public IEnumerable<AgencyEmployeeViewObject> BookingAgencyEmployee
        {
            set
            {
                _agencyEmployees = value;
                RaisePropertyChanged("BookingAgencyEmployee");
            }
            get
            {
                return _agencyEmployees;
            }
        }
        /// <summary>
        ///  Set or get the vehicle activity.
        /// </summary>
        public IEnumerable<VehicleActivitiesViewObject> BookingVehicleActivity
        {
            set
            {
                _bookingVehicleActivity = value;
                RaisePropertyChanged("BookingVehicleActivity");
            }
            get
            {
                return _bookingVehicleActivity;
            }
        }
        /// <summary>
        ///  Set pr get Printing type dto.
        /// </summary>
        public IEnumerable<PrintingTypeViewObject> PrintingTypeDto
        {
            set
            {
                _printingTypeDto = value;
                RaisePropertyChanged("PrintingTypeDto");
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
        ///  GeneralInfo collection. Collection for the general info search box.
        /// </summary>
        public ObservableCollection<GeneralInfo> GeneralInfoCollection
        {
            set
            {
                 _generalInfoCollection = value;
                RaisePropertyChanged("GeneralInfoCollection");
            }
            get => _generalInfoCollection;
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
            get => _printCommand;
        }
    }
}
