using System.Collections.Generic;
using System.Threading.Tasks;
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
