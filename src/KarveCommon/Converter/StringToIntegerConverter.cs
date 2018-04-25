using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class StringToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Int16 outValue = 0;
            if (value == null)
            {
                return outValue;
            }
            if ((value is string tmp))
            {
                outValue = System.Convert.ToInt16(tmp);
            }

            return outValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v1 = 0;
            if (value != null)
            {
                v1 = System.Convert.ToInt16(value);
            }
            return v1.ToString();
        }
    }
}
