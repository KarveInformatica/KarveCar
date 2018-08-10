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
    public class UserSettings : IUserSettings
    {
        private IUserSettingsLoader _settingsLoader;
        private IUserSettingsSaver _settingsSaver;
        
        /*
        *  We put the settings in a dictionary in order to be able to override.
        *  This provide a safe default.
        */
        private IDictionary<Uri, object> _settingDictionary = new Dictionary<Uri, object>()
        {
            { UserSettingConstants.BookingClientGridColumnsKey, "Code,Name,Nif,Direction,Telefono,Movil,Email,CreditCardType, NumberCreditCard,AccountableAccount,Zip,City,Sector,Reseller,Oficina,Falta"},
             { UserSettingConstants.BookingDriverGridColumnsKey, "Code,Name,Nif,Direction,Telefono,Movil,Email,CreditCardType, NumberCreditCard,AccountableAccount,Zip,City,Sector,Reseller,Oficina,Falta"},
            { UserSettingConstants.VehicleSummaryGridColumnsKey, "Code,Brand,Model,Matricula,VehicleGroup,Situation,Office,Places,CubeMeters,Activity,Color,Owner,OwnerName,Policy,LeasingCompany,StartingDate,EndingDate,ClientNumber,Client,PurchaseInvoice,Frame,MotorNumber,Reference,KeyCode,StorageKey,User,LastModification" },
            { UserSettingConstants.ClientDriverGridColumnsKey, "Code,Name,Nif,Phone,Movil,Email,Card,ReplacementCar,Zip,City,CreditCardType,NumberCreditCard, PaymentForm,AccountableAccount,Sector,Zona,Origin,Office,Falta,BirthDate,DrivingLicence"
             },
            { UserSettingConstants.DefaultEmailAddress, "root@karveinformatica.com" },   
    { UserSettingConstants.DefaultConnectionString, "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45:5225" }
        };

        [DataMember]
        public IDictionary<Uri, object> GridColumnSetting
        {
            get; set;
        }
        /// <summary>
        ///  Default behaviour is a not persitent setting.
        /// </summary>
        public UserSettings()
        {

        }
        /// <summary>
        ///  The recommended behaviour is to provide a loader or a saver in case we want
        ///  to save the settings to database.
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="saver"></param>
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
            
            var returnCouple = _settingDictionary.FirstOrDefault(x => x.Key == uri);
            var value = returnCouple.Value as T;
            if (value==null)
            {
                return Activator.CreateInstance<T>();
            }
            return value;
        }

        public string GetConnectionString()
        {
            object value = string.Empty;
            _settingDictionary.TryGetValue(UserSettingConstants.DefaultConnectionString, out value);
            return (string) value;
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
            if (_settingDictionary.ContainsKey(uri))
            {
                _settingDictionary.Remove(uri);

            }
            _settingDictionary.Add(uri, value);
        }
    }
}
