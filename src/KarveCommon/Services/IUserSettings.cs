using System.Collections.Generic;

namespace KarveCommon.Services
{
    /// <summary>
    ///  User settings interface
    /// </summary>
    public interface IUserSettings
    {
        /// <summary>
        ///  This load the user settings
        /// </summary>
        IUserSettingsLoader UserSettingsLoader { set; get; }
        /// <summary>
        ///  This save the user settings.
        /// </summary>
        IUserSettingsSaver UserSettingsSaver { set; get; }
    }
}