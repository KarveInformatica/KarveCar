using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class StringToByteConverter : IValueConverter
    {
        /// <summary>
        /// Convert.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string v = value as string;
            byte b = 0;
            if (v!=null)
            {
                b = Byte.Parse(v);
            }
            return b;
        }
        /// <summary>
        /// ConvertBack. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = "";
            if (value is byte)
            {
                str = value.ToString();
            }
            return str;
        }
    }
}
