using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This interface maps the fields form the
    ///  view object to the correct domain object.
    /// </summary>
    /// <typeparam name="ViewType"></typeparam>
    /// <typeparam name="DomainType"></typeparam>
    public interface IMapViewObject<ViewType, DomainType>
    {
        /// <summary>
        ///  Map from the domain/business logic entities
        ///  to the view entities
        /// </summary>
        /// <param name="domainObject">Domain object to be mapped</param>
        /// <returns>A view object to be shown.</returns>
        ViewType FromDomain(DomainType domainObject);
        /// <summary>
        /// Map from the view object to the domainObject
        /// </summary>
        /// <param name="viewObject">View object to be used</param>
        /// <returns></returns>
        DomainType FromViewType(ViewType viewObject);

    }
}
