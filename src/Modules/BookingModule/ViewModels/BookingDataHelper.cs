using KarveDataServices;
using System.Collections.Generic;
using KarveDataServices.ViewObjects;

namespace BookingModule.ViewModels
{
    internal class BookingDataHelper : DataHelperBase
    {
        private IEnumerable<ClientSummaryExtended> _dto = new List<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _driverDto = new List<ClientSummaryExtended>();
        private IEnumerable<ActiveFareViewObject> _activeFare = new List<ActiveFareViewObject>();
        private IEnumerable<ContractByClientViewObject> _contractByClientDto = new List<ContractByClientViewObject>();
        
        public IEnumerable<ClientSummaryExtended> ClientDto
        {
            get { return _dto; }
            set { _dto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ClientSummaryExtended> DriverDto { get { return _driverDto; }
            set { _driverDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ActiveFareViewObject> ActiveFareDto {
            get { return _activeFare;  }
            set { _activeFare = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ContractByClientViewObject> ContractByClientDto
        {
            get { return _contractByClientDto;  }
            set { _contractByClientDto = value; RaisePropertyChanged(); }
        }

    }
}
