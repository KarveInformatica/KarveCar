using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolConverter = false;
            var stringValue = value as string;

            if (stringValue != null)
            {
                if (stringValue.Length <1)
                {
                    return false;
                }
                if (stringValue[0]== 'T')
                {
                    return true;
                }
                if (stringValue[0] == '1')
                {
                    return true;
                }
            }
            return boolConverter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolConverter = (bool) value;
            var stringValue = value as string;
            if (boolConverter)
            {
                return "1";
            }
            return "0";
        }
    }
}
