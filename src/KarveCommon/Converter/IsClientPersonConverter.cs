using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class IsClientPersonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string persona)
            {
                var len = persona.Length;
                if (len > 0)
                {
                    var sigla = persona[0];
                    if (sigla == 'F')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool currentValue)
            {
                return "F";
            }
            else
            {
                return "J";
            }
        }
    }
}
