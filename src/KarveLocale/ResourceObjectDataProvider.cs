using System.Globalization;
using System.Windows.Data;
using KarveLocale.Properties;

namespace KarveLocale
{
    /// <summary>
    ///  ResourceObjectDataProvider.
    ///  This class has the single responsability of locating 
    ///  the correct object data provider. 
    /// </summary>
    public class ResourceObjectDataProvider: ILocaleDataProvider
    {
        private ObjectDataProvider _objectDataProvider=  null;

        /// <summary>
        ///  ObjectDataProvider.This  set/ get the current data pprovdier 
        /// </summary>
        public ObjectDataProvider ObjectDataProvider
        {
            set { _objectDataProvider = value; }
            get { return _objectDataProvider; }
        }

        public Resources GetLocaleLanguageResource()
        {
            return new Resources();
        }
        /// <summary>
        ///  The locale of the resource language
        /// </summary>
        /// <param name="culture">Culture parameter.</param>
        /// <returns></returns>
        public Resources GetLocaleLanguageResource(CultureInfo culture)
        {
           
            Resources.Culture = culture;
            return new Resources(); 
        }

        public Resources GetLanguageResource()
        {
            if (Resources.Culture == null)
            {
                Resources.Culture = new CultureInfo("es-ES");
            }
            return new Resources();
        }
    }
}
