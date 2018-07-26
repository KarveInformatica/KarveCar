using System;
using System.Globalization;
using System.Windows.Data;

namespace KarveCommon.Converter
{

    public class NullBooleanToBooleanConverter: IValueConverter
    {
        // This convert a value.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = false;
            if (value == null)
            {
                return false;
            }
            if (value is string)
            {
                var v = value as string;
                var ret = bool.TryParse(v, out boolValue);
                if (!ret)
                {
                    return false;
                }
            }
            if (value is byte)
            {
                var v = (byte) value;
                
                if (v == 0)
                {
                    return false;
                }
                return true;
            }
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

            string ret = "0";
            if (value == null)
            {
                return "0";
            }
            if (value is bool v)
            {
                ret = v ? "0" : "1"; 
            }
            return ret;
        }
    }        
    

}