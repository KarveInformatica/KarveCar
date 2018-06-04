using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveControls.HeaderedWindow
{
    class BillToConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !value.ToString().Equals("1"))
            {
                return "Clientes";
            }
            else
            {
                return "Conductores";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte tmpByte = 1;
            if (value is string currentValue)
            {
                if (!string.IsNullOrEmpty(currentValue))
                {
                    
                    if (currentValue == "Clientes")
                        return tmpByte;
                    else
                    {
                        tmpByte = 0;
                        return tmpByte;
                    }
                }
            }
            return 0;
        }
    }
}
