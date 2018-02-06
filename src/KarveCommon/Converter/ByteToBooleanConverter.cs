using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace KarveCommon.Converter
{
    public class ByteToBooleanConverter: IValueConverter
    {
        // This convert a value.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = false;
            if ((value is Int16) || (value is Byte))
            {
                boolValue = System.Convert.ToBoolean(value);
            }
            return boolValue;
        }
        /// <summary>
        /// converet back a value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte ret = 0;
            if (value is bool)
            {

                var tmpValue = (bool) value;
                ret = tmpValue ? (byte)0 : (byte)1;
            }
            return ret;

        }
    }
}
