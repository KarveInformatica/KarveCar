using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public static class DateUtils
    {
        /// <summary>
        ///  Historically the karve data base has the ultimodi version.
        ///  It is a timestamp.
        /// </summary>
        /// <returns></returns>
        public static string GetKarveDateTimeNow()
        {
            DateTime ultmodi = DateTime.Now;
            var lastModification = ultmodi.ToString("yyyyMMddHH:mm");
            return lastModification;
        }
    }
}
