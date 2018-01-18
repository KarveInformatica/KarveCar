using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using KarveLocale.Properties;

namespace KarveLocale
{
    /// <summary>
    ///  This interface will have a data provider 
    /// </summary>
    public interface ILocaleDataProvider
    {
        /// <summary>
        ///  This gets the locale data provider
        /// </summary>
        /// <returns></returns>
        Resources GetLocaleLanguageResource(CultureInfo culture);
        /// <summary>
        ///  This is a language resource.
        /// </summary>
        /// <returns></returns>
        Resources GetLanguageResource();
    }
}
