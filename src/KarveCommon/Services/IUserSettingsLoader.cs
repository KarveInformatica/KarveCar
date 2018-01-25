using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;


namespace KarveCommon.Services
{
    /// <summary>
    ///  This is the user settings loader. It is useful for loading different configuration settings.
    /// </summary>
    public interface IUserSettingsLoader
    {
        
        Enumerations.ResourceSource GetLocaleType();
        string GetConnectionString();

    }
}
