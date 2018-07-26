using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    /*
     *  Converter from the included bool to a value converter.
     */
    public class KmIncludedToBoolConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            var i = System.Convert.ToInt32(value);
            if (i < 0)
            {
                return true;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            var res = (bool)value;
            if (res)
            {
                return -1;
            }
            return 0;
        }
    }
}
