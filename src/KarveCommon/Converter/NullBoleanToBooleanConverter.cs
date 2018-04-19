using System;
using System.Globalization;

namespace KarveCommon.Converter
{

    public class NullBoleanToBooleanConverter
    {
        // This convert a value.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = false;
            if (value is bool?)
            {
                bool? currentValue = (bool?)value;
                if (currentValue.HasValue)
                {
                    boolValue = currentValue.Value;
                }
            }
            return boolValue;
        }
        /// <summary>
        /// converet back a value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? ret = null;
            if (value is bool)
            {
                ret = System.Convert.ToBoolean(value); 
            }
            return ret;
        }
    }        
    

}