using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  This is a null reservation to be used.
    /// </summary>
    public class NullReservation : IBookingData
    {
        private BookingDto _bookingDto;
        private bool _isValid;
        private IHelperBase _base;
        private IEnumerable<BookingItemsDto> _bookingItems;
        private IEnumerable<ContractSummaryDto> _contracts;
        private IEnumerable<ClientSummaryExtended> _clients;
        private IEnumerable<ClientSummaryExtended> _drivers;
        public NullReservation()
        {
            _bookingDto = new BookingDto();
            _isValid = false;
            _bookingItems = new List<BookingItemsDto>();
            _base = new HelperBase();
            _contracts = new ObservableCollection<ContractSummaryDto>();
            _clients = new ObservableCollection<ClientSummaryExtended>();
            _drivers = new ObservableCollection<ClientSummaryExtended>();
        }
        /// <summary>
        ///  Set or Get the Value.
        /// </summary>
        public BookingDto Value { get => new BookingDto(); set => _bookingDto = value; }
        /// <summary>
        ///  Thi
        /// </summary>
        public IHelperBase Helper { get => _base; set => _base= value; }
        /// <summary>
        ///  Set or Get the value if it is valid
        /// </summary>
        public bool IsValid { get => _isValid; set => _isValid = value; }
        /// <summary>
        ///  Set or Get the items dto.
        /// </summary>
        public IEnumerable<BookingItemsDto> ItemsDtos { get => _bookingItems; set => _bookingItems = value; }
        /// <summary>
        ///  Set or Get Contracts
        /// </summary>
        public IEnumerable<ContractSummaryDto> Contracts { get => _contracts; set => _contracts = value; }
        /// <summary>
        ///  Set or Get Clients.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Clients { get => _clients; set => _clients =value; }
        /// <summary>
        ///  Ser or Get Drivers.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Drivers { get => _drivers; set => _drivers = value; }
    }
}
