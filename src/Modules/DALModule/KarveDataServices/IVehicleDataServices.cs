using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  Interface for the vehicle data services.
    /// </summary>
    public interface IVehicleDataServices: IPageCounter, IDataProvider<IVehicleData, VehicleSummaryViewObject>, IIdentifier
    {

    }
}
