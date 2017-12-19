using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveCommon.Services
{
    public interface IUserSettingsLoader
    {
        Task<IList<IMagnifierSettings>> GetAllMagnifierSettings();
        Task<IMagnifierSettings> GetMagnifierSettings(long id);
        //IConnectionSettings LoadConnectionSettings();
    }
}
