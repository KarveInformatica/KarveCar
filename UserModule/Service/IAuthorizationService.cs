
namespace UserModule.Service
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using KarveCommon.Services;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// The AuthorizationService interface. It is as service that authenticate
    /// the user and retrieve the available accounts in the system.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        ///  Return true or false if the user is present
        /// </summary>
        /// <param name="user">User of the system</param>
        /// <returns>True if we can login and as side effect sets environment variables
        /// in the configuration service.</returns>
        Task<bool> CanAccess(KarveCar.Model.User user, IConfigurationService configuration);

        /// <summary>
        ///  Retrieve the list of users in the system.
        /// </summary>
        /// <returns>Retrieve the list of users in the system.</returns>

        Task<IEnumerable<UserSummaryViewObject>> Users();
        
        /// <summary>
        ///  Return a login aureo.
        /// </summary>
        /// <returns></returns>
        Task<bool> IsLoginAuth();
    }
}
