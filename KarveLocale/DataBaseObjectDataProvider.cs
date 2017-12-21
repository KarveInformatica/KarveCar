using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Security;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveLocale.Properties;
namespace KarveLocale
{
    /// <summary>
    ///  DataBaseObjectDataProvider. In this case we have a data provider for the resources in the database.
    ///  This code is experimental.
    /// </summary>
    public sealed class DataBaseObjectDataProvider : AbstractLocaleDataProvider
    {
       
        private readonly IDataServices _dataServices;

        public DataBaseObjectDataProvider()
        {
        }
        public DataBaseObjectDataProvider(IDataServices dataServices)
        {
            _dataServices = dataServices;
        }
        /// <summary>
        ///  TODO: fix it.
        /// </summary>
        /// <returns></returns>
        public Resources GetLocaleLanguageResource()
        {
            return new Resources();
        }

        public class ResourceSetDataBase : ResourceSet
        {
            private ILocaleDataServices _localeDataServices;
            public ResourceSetDataBase(ILocaleDataServices dataServices)
            {
                _localeDataServices = dataServices;
            }
        }

        public class ResourceManagerDataBase : ResourceManager
        {
            private readonly ResourceSetDataBase _resourceSet = null;
            private ILocaleDataServices _localeDataServices;

            public ResourceManagerDataBase(ILocaleDataServices localeDataServices)
            {
                _localeDataServices = localeDataServices;
                _resourceSet = new ResourceSetDataBase(localeDataServices);
            }

            /// <summary>
            /// Get the resource set from a culture
            /// </summary>
            /// <param name="culture">Get the resource set from the culture.</param>
            /// <param name="createIfNotExists">not used</param>
            /// <param name="tryParents">not used</param>
            /// <returns></returns>
            [SecuritySafeCritical]
            public override ResourceSet GetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
            {
                return _resourceSet;
            }
        }
        /// <summary>
        ///  This will extend the resource and override 
        /// the resouce for allowing access to the database.
        /// </summary>
        public class ResourceDecorator: Resources
        {
            private Resources _internal;
            private CultureInfo _culture;
            private readonly IDataServices _dataServices;
            private readonly ILocaleDataServices _localeDataServices;

            private static ResourceManager _resourceManager;
            // This is the resource decorator.
            public ResourceDecorator()
            {
                _internal = null;
                _culture = null;
                _dataServices = null;
                _localeDataServices = null;
            }
            /// <summary>
            /// This is a decorator for the resource
            /// </summary>
            /// <param name="res">The value of the resource</param>
            /// <param name="culture">The culture of the resource</param>
            /// <param name="dataServices">The dataservices to trigger and get the resources</param>
            public ResourceDecorator(Resources res, CultureInfo culture, IDataServices dataServices)
            {
                _internal = res;
                 _culture = culture;
                _dataServices = dataServices;
                _localeDataServices = _dataServices.GetDataService<ILocaleDataServices>();
                _resourceManager = new ResourceManagerDataBase(_localeDataServices);
            }
            /// <summary>
            ///  This is because we want a custom resource manager that is able to get the Database resources.
            /// </summary>
            [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
            public new static global::System.Resources.ResourceManager ResourceManager
            {
                get
                {
                    return _resourceManager;
                }
            }

         
        }
        /// <summary>
        /// This will get the resource language
        /// </summary>
        /// <param name="culture">Information about the culture</param>
        /// <returns></returns>
        public override Resources GetLocaleLanguageResource(CultureInfo culture)
        {
            Resources res = new Resources();
            Resources decorator = new ResourceDecorator(res, culture, _dataServices);
            return decorator;
        }

        public override Resources GetLanguageResource()
        {
            return new Resources();
        }
    }
}
