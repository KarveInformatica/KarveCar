using KarveDataServices.DataObjects;

namespace UserModule.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KarveCar.Model;
    using KarveCommon.Generic;
    using KarveCommon.Services;
    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    /// <summary>
    ///  AuthorizationService to be used.
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        /// <summary>
        /// DataService to be used.
        /// </summary>
        private readonly IDataServices _dataServices;

        /// <summary>
        ///  UserDataService to be used.
        /// </summary>
        private readonly IUserDataService _userDataService;

        /// <summary>
        ///  Company data services.
        /// </summary>

        private readonly IOfficeDataServices _officeDataService;

        /// <summary>
        ///  Configuration service.
        /// </summary>
        /// 
        private readonly IConfigurationService _configurationService;

        /// <summary>
        /// Authorization service.
        /// </summary>
        /// <param name="dataService">Data service to be used.</param>
        /// <param name="configurationService">Configuration service to be used.</param>
        /// 

        public AuthorizationService(IDataServices dataService, IConfigurationService configurationService)
        {
            _dataServices = dataService;
            _userDataService = dataService.GetUserDataService();
            _officeDataService = dataService.GetOfficeDataServices();
            _configurationService = configurationService;
        }

        /// <summary>
        ///   Returns true or false in case of the user.
        /// </summary>
        /// <param name="user">User to be accessed in the system.</param>
        /// <param name="configuration">Configuration service to be used.</param>
        /// <returns>Return true or false if we can or not access to the system.</returns>

        public async Task<bool> CanAccess(User user, IConfigurationService configuration)
        {
            try
            {
                IUserData userData = await _userDataService.GetUserByName(user.Name).ConfigureAwait(false);

                if (userData == null)
                {
                    return false;
                }


                if ((user.Office == null) || (string.IsNullOrEmpty(user.Office.Code)))
                {
                    return false;
                }

                var office = await this._officeDataService.GetAsyncOfficeDo(user.Office.Code).ConfigureAwait(false);
                var userObject = userData.Value;
                if ((user.Name == userObject.CODIGO)
                    && (userObject.PASS == user.Password))
                {
                    configuration.EnviromentVariables.SetKey(EnvironmentConfig.KarveConfiguration,
                        EnvironmentKey.CurrentOffice, user.Office);
                    configuration.EnviromentVariables.SetKey(EnvironmentConfig.KarveConfiguration,
                        EnvironmentKey.ConnectedCompany, office.Value.SUBLICEN);
                    configuration.EnviromentVariables.SetKey(EnvironmentConfig.KarveConfiguration,
                        EnvironmentKey.CurrentUser, userObject.CODIGO);

                    return true;
                }
            }
            catch (System.Exception ex)
            {
                var exception = false;
            }
          

            return false;
        }
        /// <summary>
        ///  Check if yje 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsLoginAuth()
        {
            // we need to check at the a
            return true;
        }
        /// <summary>
        ///  Returns the list of users.
        /// </summary>
        /// <returns>list of the users to be saved.</returns>
        public async Task<IEnumerable<UserSummaryViewObject>> Users()
        {
            var summaryData = await this._userDataService.GetSummaryAllAsync().ConfigureAwait(false);
            return summaryData;
        }
    }
}
