using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    public interface IBookingIncidentDataService:
                                          IPageCounter,
                                          IIdentifier,
                                          IDataProvider<IBookingIncidentData, BookingIncidentSummaryViewObject>,
                                          IDataSearch<IBookingIncidentData, BookingIncidentSummaryViewObject>,
                                          ISorterData<BookingIncidentSummaryViewObject>
    {

    }
}
