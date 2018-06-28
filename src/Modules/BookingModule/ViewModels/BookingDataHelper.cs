using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace BookingModule.ViewModels
{
    internal class BookingDataHelper : DataHelperBase
    {
        private IEnumerable<ClientSummaryExtended> _dto = new List<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _driverDto = new List<ClientSummaryExtended>();
        private IEnumerable<ActiveFareDto> _activeFare = new List<ActiveFareDto>();
        private IEnumerable<ContractByClientDto> _contractByClientDto = new List<ContractByClientDto>();
        
        public IEnumerable<ClientSummaryExtended> ClientDto
        {
            get { return _dto; }
            set { _dto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ClientSummaryExtended> DriverDto { get { return _driverDto; }
            set { _driverDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ActiveFareDto> ActiveFareDto {
            get { return _activeFare;  }
            set { _activeFare = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ContractByClientDto> ContractByClientDto
        {
            get { return _contractByClientDto;  }
            set { _contractByClientDto = value; RaisePropertyChanged(); }
        }

    }
}
