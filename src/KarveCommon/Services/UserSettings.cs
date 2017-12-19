using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This is a container class for user setting and split the resposability from the loader and saver.
    /// </summary>
    public class UserSettings: IUserSettings
    {
        private IUserSettingsLoader _settingsLoader;
        private IUserSettingsSaver _settingsSaver;
        public UserSettings(IUserSettingsLoader loader, IUserSettingsSaver saver)
        {
            _settingsLoader = loader;
            _settingsSaver = saver;
        }

        public IUserSettingsLoader UserSettingsLoader
        {
            get { return _settingsLoader; }
            set { _settingsLoader = value; }
        }
        public IUserSettingsSaver UserSettingsSaver
        {
            get { return _settingsSaver; }
            set { _settingsSaver = value; }
        }
    }
}
