using System.Collections.Generic;
using System.Globalization;
using KarveDataServices.DataTransferObject;
namespace KarveDataServices
{
    /// <summary>
    ///  Locale data services
    /// </summary>
    public interface ILocaleDataServices
    {
        /// <summary>
        ///  Thsi interface return the locale traduction that are present in the database.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        IList<LocaleDataDto> GetLocaleData(CultureInfo info);
    }
}
