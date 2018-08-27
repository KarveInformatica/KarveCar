using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Value of the OfficeData.
    /// </summary>
    public interface IOfficeData : IHelperBase, IValidDomainObject, IValueObject<OfficeViewObject>
    {
        
        /// <summary>
        ///   CurrenciesViewObject.
        /// </summary>
        IEnumerable<CurrenciesViewObject> CurrenciesDto { get ; set ; }

    }
}
