using KarveCommon.Generic;
using System;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    /// <summary>
    ///  User settings interface. 
    ///  This is  container where each setting has been stored with uri.
    ///  You can refere every object in the world with a uri.
    /// </summary>
    public interface IUserSettings
    {
        /// <summary>
        ///  Found a setting with a uri supposing to have a value T
        /// </summary>
        /// <typeparam name="T">Type of the setting</typeparam>
        /// <param name="uri">URI of the setting</param>
        /// <returns>A setting</returns>
        T FindSetting<T>(Uri uri) where T : class;
        /// <summary>
        ///  This save the settings
        /// </summary>
        /// <typeparam name="T">Type of the setting</typeparam>
        /// <param name="uri">Unique uri identifier of the setting</param>
        /// <param name="value">Value of the setting</param>
        void SaveSetting<T>(Uri uri, T value) where T : class;
        /// <summary>
        ///  This user setting returns the type of the locale.
        /// </summary>
        /// <returns></returns>
        Enumerations.ResourceSource GetLocaleType();
        
    }
}