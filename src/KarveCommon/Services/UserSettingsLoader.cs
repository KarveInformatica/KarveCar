using System.Collections.Generic;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace KarveCommon.Services
{
    /// <summary>
    /// UserSettingsLoader. This load the setting from the user.
    /// </summary>
    public class UserSettingsLoader: IUserSettingsLoader
    {
        private readonly ISettingsDataService _dataService;
     
        /// <summary>
        ///  This inject the data service interface to the magnifier.
        /// </summary>
        /// <param name="dataServices"></param>
        public UserSettingsLoader(IDataServices dataServices)
        {
            _dataService = dataServices.GetSettingsDataService();
        }
        
        /// <summary>
        ///  This returns the ADO.NET connection string.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return string.Empty;
        }

        /// <summary>
        ///  This returns the locale type. For now the locale is available in the 
        /// </summary>
        /// <returns></returns>
        public Enumerations.ResourceSource GetLocaleType()
        {
            return Enumerations.ResourceSource.File;
        }

    }
}
