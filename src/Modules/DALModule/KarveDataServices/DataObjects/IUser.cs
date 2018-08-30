// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUser.cs" company="">
//   
// </copyright>
// <summary>
//   User aggregate interface.
//   The data layer will retrieve this interface
//   and it allows to retrieve to get the view object
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using KarveCar.Model;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    /// User aggregate interface.
    /// The data layer will retrieve this interface
    /// and it allows to retrieve to get the view object
    /// </summary>
    public interface IUserData: IValidDomainObject, IValueObject<UserViewObject>, IMapViewObject<UserViewObject, User>
    {
        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        OfficeViewObject Office { set; get; }
    }
}
