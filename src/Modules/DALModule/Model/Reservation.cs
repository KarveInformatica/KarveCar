using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Wrapper that allows us to deliver  its dto and a set of related things for the searchboxes.
    /// </summary>
    public class Reservation: BindableBase, IBookingData
    {
        public Reservation()
        {
            Value = new BookingDto();
            Valid = true;
          
            _contracts = new List<ContractSummaryDto>();
            _clients = new List<ClientSummaryExtended>();
            _drivers = new List<ClientSummaryExtended>();
        }

        /// <summary>
        /// Get or Set the booking data. Value to be used.
        /// </summary>
        public BookingDto Value { get; set; }
   
        /// <summary>
        ///  Contract summary
        /// </summary>
        private IEnumerable<ContractSummaryDto> _contracts;
        /// <summary>
        ///  Client summary
        /// </summary>
        private IEnumerable<ClientSummaryExtended> _clients;
        /// <summary>
        ///  Drivers summary
        /// </summary>
        private IEnumerable<ClientSummaryExtended> _drivers;
        /// <summary>
        ///  Valid summary.
        /// </summary>
        private bool _valid;

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
        /// <summary>
        ///  Set the validity of the domain object. In case of any error this gets false
        /// </summary>
        public bool Valid {
            get
            {
                return _valid;
            }
            set
            {
                _valid = true;
            }
        }
    }
}
