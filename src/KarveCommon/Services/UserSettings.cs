using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using System.Runtime.Serialization;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This is a container class for user setting and split the resposability from the loader and saver.
    /// </summary>
    public class UserSettings: IUserSettings
    {
        private IUserSettingsLoader _settingsLoader;
        private IUserSettingsSaver _settingsSaver;
        private IDictionary<Uri, object> settingDictionary = new Dictionary<Uri, object>()
        {
            { UserSettingConstants.BookingClientGridColumnsKey, "Code,Name,Nif,Direction,Telefono,Movil,Email,CreditCardType, NumberCreditCard,AccountableAccount,Zip,City,Sector,Reseller,Oficina,Falta"},
             { UserSettingConstants.BookingDriverGridColumnsKey, "Code,Name,Nif,Direction,Telefono,Movil,Email,CreditCardType, NumberCreditCard,AccountableAccount,Zip,City,Sector,Reseller,Oficina,Falta"}
        };

        [DataMember]
        public IDictionary<Uri, object> GridColumnSetting
        {
            get; set;
        }
        public UserSettings(IUserSettingsLoader loader, IUserSettingsSaver saver)
        {
            _settingsLoader = loader;
            _settingsSaver = saver;
        }
        /// <summary>
        ///  Find a settings for given uri.
        /// </summary>
        /// <typeparam name="T">Type of the setting</typeparam>
        /// <param name="uri">Uri of the setting</param>
        /// <returns>A value of T</returns>
        public T FindSetting<T>(Uri uri) where T : class
        {
            var returnCouple = settingDictionary.FirstOrDefault(x => x.Key == uri);
            var value = returnCouple.Value as T;
            if (value==null)
            {
                return Activator.CreateInstance<T>();
            }
            return value;
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public Enumerations.ResourceSource GetLocaleType()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Save a given setting for the uri.
        /// </summary>
        /// <typeparam name="T">Type of the setting</typeparam>
        /// <param name="uri">Uri of the setting</param>
        /// <param name="value">Value of the setting</param>
        public void SaveSetting<T>(Uri uri, T value) where T : class
        {
            if (settingDictionary.ContainsKey(uri))
            {
                settingDictionary.Remove(uri);

            }
            settingDictionary.Add(uri, value);
        }
    }
}
