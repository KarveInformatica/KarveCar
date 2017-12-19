using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveCommon.Services
{
    public interface IUserSettingsSaver
    {
        /// <summary>
        ///  This is the save magnifier settings
        /// </summary>
        /// <param name="magnifier">The list of magnifier settings</param>
        /// <returns></returns>
        Task<bool> SaveAllMagnifierSettings(IList<IMagnifierSettings> magnifier);
        /// <summary>
        ///  This save a single magnifier setting
        /// </summary>
        /// <param name="magnifier"></param>
        /// <returns></returns>
        Task<bool> SaveMagnifierSettings(IMagnifierSettings magnifier);
    }
}
