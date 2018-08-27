using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IFareDataServices: IPageCounter, IDataProvider<FareViewObject, FareSummaryViewObject>
    {

        /// <summary>
        ///  This returns the number of active fares.
        /// </summary>
        /// <returns>Number</returns>
        Task<int> GetNumberOfActiveFares();
        /// <summary>
        ///  Retrieve the active summary fare with a code.
        /// </summary>
        /// <param name="code">Client code to provide</param>
        /// <returns>Return a list of the client active fares</returns>
        Task<IEnumerable<ActiveFareViewObject>> GetActiveSummaryFarePaged(string code, int index, int pageSize); 
    }
}
