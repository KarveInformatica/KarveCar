using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace KarveCommon.Converter
{

    /*
     *  ConvertToCombo.
     */
    public class ConvertToCombo : IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Controls.ComboBoxItem item)
            {
                if (item.Content != null)
                {
                    var content = item.Content as TextBlock;
                    if (content != null)
                    {
                        return content.Text;
                    }
                }
            }
            return string.Empty;
        }
    }
}
