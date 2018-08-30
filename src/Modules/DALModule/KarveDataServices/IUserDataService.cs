
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    using KarveDataServices.DataObjects;

    /// <summary>
    /// IUserDataService. Service to be used for the users retrieving.
    /// </summary>
    
    public interface IUserDataService : IPageCounter,
        IIdentifier,
        IDataProvider<IUserData, UserSummaryViewObject>,
        IDataSearch<IUserData, UserSummaryViewObject>
    {
        /// <summary>
        /// Get the user by name
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <returns>The user data fro the user</returns>
        Task<IUserData> GetUserByName(string name);
    }
}
