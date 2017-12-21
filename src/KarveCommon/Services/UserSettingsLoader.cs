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
        ///  Get all magnifier settings
        /// </summary>
        /// <returns>A list of settings foreach magnifier.</returns>
        public async Task<IList<IMagnifierSettings>> GetAllMagnifierSettings()
        {
           IList<IMagnifierSettings> settings = await _dataService.GetAllMagnifiersSettings();
           return settings;
        }
        /// <summary>
        ///  This returns the ADO.NET connection string.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///  This returns the locale type. For now the locale is available in the 
        /// </summary>
        /// <returns></returns>
        public Enumerations.ResourceSource GetLocaleType()
        {
            return Enumerations.ResourceSource.File;
        }

        /// <summary>
        ///  Get the list of magnifier settings.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IMagnifierSettings> GetMagnifierSettings(long id)
        {
            IMagnifierSettings magnifierSettings =  await _dataService.GetMagnifierSettings(id);
            return magnifierSettings;
        }
    }
}
