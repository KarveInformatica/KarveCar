using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace KarveCommon.Converter
{

    public class CharToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var current = System.Convert.ToByte(value);
            int v = 0;
           
            v = System.Convert.ToInt32(current);
           
            return v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (Int32) value ;
            byte c = 0;
            if (v!=null)
            {
                
                c = System.Convert.ToByte(v);
            }
            return c;
        
        }
    }

}