using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    /* In the current database there are may problems with values. The field persona shall be 
     * a bool, so we move this as a simple comverter. In case it is a company it is  J char,
     * if it is a person it is just a F char.
     */
    public class IsClientCompanyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string persona)
            {
                var len = persona.Length;
                if (len > 0)
                {
                    var sigla = persona[0];
                    if (sigla == 'J')
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int currentValue)
            {
                if (currentValue == 1)
                {
                    return "J";
                }
                else
                {
                    return "F";
                }
               
            }
            return "J";
        }
    }
}
