using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace KarveCommon.Converter
{
    /// <summary>
    ///  Convert to allow a percetuage of maximum screen. It might be used from the main window 
    ///  to set himself.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class RatioScreenConverter : MarkupExtension, IValueConverter
    {
        private static RatioScreenConverter _instance;

        public RatioScreenConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { // do not let the culture default to local to prevent variable outcome re decimal syntax
            double size = System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
            return size.ToString("G0", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { // readonly converter
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new RatioScreenConverter());
        }

    }
}

