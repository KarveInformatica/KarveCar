using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    public interface IBookingIncidentDataService:
                                          IPageCounter,
                                          IIdentifier,
                                          IDataProvider<IBookingIncidentData, BookingIncidentSummaryDto>,
                                          IDataSearch<IBookingIncidentData, BookingIncidentSummaryDto>,
                                          ISorterData<BookingIncidentSummaryDto>
    {

    }
}
