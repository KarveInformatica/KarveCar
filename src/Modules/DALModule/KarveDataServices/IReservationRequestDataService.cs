using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
namespace KarveDataServices
{
    // interface for the reservation request data service.

    public interface IReservationRequestDataService: IPageCounter, IIdentifier, IDataProvider<IReservationRequest, ReservationRequestSummary>, ISorterData<ReservationRequestSummary>
    {
    }
}
