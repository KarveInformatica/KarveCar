using KarveCar.Properties;
using System.Globalization;
using System.Windows.Data;

namespace KarveCar.Logic.Generic
{
    public class ChangeLanguageLogic
    {
        private static ObjectDataProvider _objectdataprovider;

        public ChangeLanguageLogic() { }

        /// <summary>
        /// Devuelve una instancia nueva de nuestros recursos
        /// </summary>
        /// <returns></returns>
        public Resources GetResourceLanguage()
        {
            return new Resources();
        }

        /// <summary>
        /// Devuelve el ObjectDataProvider en uso
        /// </summary>
        public static ObjectDataProvider objectdataprovider
        {
            get
            {
                if (_objectdataprovider == null)
                {
                    _objectdataprovider = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
                }
                return _objectdataprovider;
            }
        }

        /// <summary>
        /// Cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        /// </summary>
        /// <param name="culture"></param>
        public static void ChangeCulture(CultureInfo culture)
        {
            Resources.Culture = culture;
            objectdataprovider.Refresh();
        }
    }
}
