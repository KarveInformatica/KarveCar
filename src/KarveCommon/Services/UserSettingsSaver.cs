using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveCommon.Services
{
    public class UserSettingsSaver: IUserSettingsSaver
    {
        private readonly ISettingsDataService _dataService;

        /// <summary>
        ///  This inject the data service interface to the magnifier.
        /// </summary>
        /// <param name="dataServices"></param>
        public UserSettingsSaver(IDataServices dataServices)
        {
            _dataService = dataServices.GetSettingsDataService();
        }

        public async Task<bool> SaveAllMagnifierSettings(IList<IMagnifierSettings> magnifier)
        {
            bool ret = await _dataService.SaveAllMagnifierSettings(magnifier);
            return ret;
        }
        public async Task<bool> SaveMagnifierSettings(IMagnifierSettings magnifier)
        {
           bool ret = await _dataService.SaveMagnifierSettings(magnifier);
           return ret;
        }
    }
}
