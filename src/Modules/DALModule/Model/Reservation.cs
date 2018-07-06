using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  This models the reservation data.
    /// </summary>
    public class Reservation: BindableBase, IBookingData
    {

        public Reservation()
        {
            Value = new BookingDto();
            IsValid = false;
          
            _contracts = new List<ContractSummaryDto>();
            _clients = new List<ClientSummaryExtended>();
            _drivers = new List<ClientSummaryExtended>();
        }

        /// <summary>
        /// Get or Set the booking data. Value to be used.
        /// </summary>
        public BookingDto Value { get; set; }
   
        /// <summary>
        ///  Get or Set if the value is valid.
        /// </summary>
        public bool IsValid { get; set; }

        private IEnumerable<ContractSummaryDto> _contracts;
        private IEnumerable<ClientSummaryExtended> _clients;
        private IEnumerable<ClientSummaryExtended> _drivers;

        
        /// <summary>
        ///  List of Contracts.
        /// </summary>
        public IEnumerable<ContractSummaryDto> Contracts {
            get
            {
                return _contracts;
            }
            set
            {
                _contracts = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Clients.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Clients
        {
          get 
          {
                return _clients;
          }
          set 
          {
                _clients = value;
                RaisePropertyChanged();
          }
        }
       /// <summary>
       ///  Drivers.
       /// </summary>
        public IEnumerable<ClientSummaryExtended> Drivers
        {
          get
          {
                return _drivers;
          }
          set
          {
                _drivers = value;
                RaisePropertyChanged();
          }
                
        }
        public IEnumerable<BookingItemsDto> ItemsDtos { get ; set; }
    }
}
