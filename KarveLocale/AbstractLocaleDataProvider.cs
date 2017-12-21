using System.Globalization;
using KarveDataServices;
using KarveLocale.Properties;
namespace KarveLocale
{
    /// <summary>
    /// The abstract locale data provider.
    /// </summary>
    public abstract class AbstractLocaleDataProvider : ILocaleDataProvider
    {
        /// <summary>
        /// Get the language resource.
        /// </summary>
        /// <param name="culture">The culture of the data language.</param>
        /// <returns> This returns a resource.</returns>
        public abstract Resources GetLocaleLanguageResource(CultureInfo culture);

        public abstract Resources GetLanguageResource();
    }
}