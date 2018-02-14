using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using KarveLocale.Properties;
using KarveCommon;
using KarveCommon.Generic;
using Prism.Mvvm;

namespace KarveLocale
{
    /// <summary>
    ///  This class provide a common interface for the language translation 
    ///  and localization of the entire application
    /// </summary>
    public class LocaleResourceFactory
    {
        /// <summary>
        ///  This is the dictionary of resource and the resource data provider.
        /// </summary>
        private static Dictionary<Enumerations.ResourceSource, ILocaleDataProvider> _resourceDataProviders =
            new Dictionary<Enumerations.ResourceSource, ILocaleDataProvider>()
            {
                {Enumerations.ResourceSource.DataBase, new DataBaseObjectDataProvider()},
                {Enumerations.ResourceSource.File, new ResourceObjectDataProvider()}
            };


        private static ObjectDataProvider _objectDataProvider = null;

        /*
           <ObjectDataProvider x:Key="Resources" ObjectType="{x:Type resource:CultureResources}" MethodName="GetResourceInstance" />
             */
        private static ObjectDataProvider BuildObjectDataProvider()
        {
            LocaleResourceFactory locale = new LocaleResourceFactory();
            _objectDataProvider = new ObjectDataProvider();
            _objectDataProvider.ObjectType = locale.GetType();
            _objectDataProvider.MethodName = "GetResourceLanguage";
            _objectDataProvider.ObjectInstance = locale;
            return _objectDataProvider;
        }
        public static ObjectDataProvider ResourceProvider
        {
            get
            {
                if (_objectDataProvider == null)
                {
                    _objectDataProvider = (ObjectDataProvider)Application.Current.FindResource("ResourceLanguage");
                   // _objectDataProvider =  FindResource(ResourceLanguage);
                }
                return _objectDataProvider;
            }
        }
        public static ObjectDataProvider ObjectDataProvider
        {
            get
            {
                if (_objectDataProvider == null)
                {
                    _objectDataProvider = (ObjectDataProvider)Application.Current.FindResource("ResourceLanguage");
//                    _objectDataProvider = BuildObjectDataProvider();
                }
                return _objectDataProvider;
            }
        }

        /// <summary>
        /// Cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        /// </summary>
        /// <param name="culture"></param>
        public static void ChangeCulture(CultureInfo culture)
        {
            Resources.Culture = culture;
         //   _objectDataProvider.Refresh();
        }

        /// <summary>
        /// Devuelve una instancia nueva de nuestros recursos
        /// </summary>
        /// <returns></returns>
        public Resources GetResourceLanguage()
        {
            Resources res;

            if (_objectDataProvider == null)
            {
                var value =  Application.Current.FindResource("ResourceLanguage");

              _objectDataProvider = (ObjectDataProvider) Application.Current.FindResource("ResourceLanguage");
              //  _objectDataProvider = LocaleResourceFactory.BuildObjectDataProvider();
            }
            ILocaleDataProvider localeDataProvider = _resourceDataProviders[Enumerations.ResourceSource.File];
            res = localeDataProvider.GetLanguageResource();
            return res;
        }
        public static KarveLocale.Properties.Resources GetLanguageLocale(CultureInfo info)
        {
            Resources resources = new KarveLocale.Properties.Resources();
            if (_resourceDataProviders.ContainsKey(Enumerations.ResourceSource.File))
            {
                ILocaleDataProvider localeDataProvider = _resourceDataProviders[Enumerations.ResourceSource.File];
                return localeDataProvider.GetLocaleLanguageResource(info);
            }
            return resources;
        }
        /// <summary>
        /// Language locale of the resource
        /// </summary>
        /// <param name="info">Information about the culture of the resource</param>
        /// <param name="source">Source of the resource can be </param>
        /// <returns></returns>
        public static KarveLocale.Properties.Resources GetLanguageLocale(CultureInfo info, Enumerations.ResourceSource source)
        {
            Resources resources = new KarveLocale.Properties.Resources();
            if (_resourceDataProviders.ContainsKey(source))
            {
                ILocaleDataProvider localeDataProvider = _resourceDataProviders[source];
                resources = localeDataProvider.GetLocaleLanguageResource(info);
               
                _objectDataProvider?.Refresh();
                return resources;
            }
            return resources;
        }
    }
}
