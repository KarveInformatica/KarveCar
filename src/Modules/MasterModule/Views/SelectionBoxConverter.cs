using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace MasterModule.Views
{
    /// <summary>
    /// SelectionBox converter.
    /// </summary>
    class SelectionBoxConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)

        {
            
            bool retValue = true;
            ComboBoxItem item = value as ComboBoxItem;
            if (item != null)
            {
                var name = item.Name;
                if (name == "Person")
                {
                    return true;
                }
                if (name == "Company")
                {
                    return false;
                }
            }
            return  retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem retValue = new ComboBoxItem();
            retValue.IsSelected = true;
            retValue.Name = "Persona";
            return value;
        }
    }
}
