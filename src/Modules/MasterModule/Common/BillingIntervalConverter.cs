using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MasterModule.Common
{
    /// <summary>
    ///  This convert the value of a string to a template.
    /// </summary>
    public class BillingIntervalConverter : IValueConverter
    {
        /// <summary>
        ///  From a string convert the value of the template
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = value as StackPanel;
            try
            {
                var t = (ControlTemplate)canvas.FindResource(path);
                return t;
            }
            catch (NullReferenceException e)
            {
                
            }

        }
        /// <summary>
        ///  This convert back the value of the template.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
