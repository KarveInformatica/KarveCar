using System;
using System.Globalization;
using System.Windows.Data;
namespace KarveCommon.Converter
{

    /*
     *  Convert the bill to the ui value. 
     */
    public class BillToBookConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
            byte? bill = (byte?)value;
            if (!bill.HasValue)
            {
                return -1;
            }
            */
            return 1;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = 0;

            /*
            int v = (int)value;
            if (v == -1)
            {
                return null;
            }
            try
            {
                b = System.Convert.ToByte(v);
#pragma warning disable 0168
            }
            catch (Exception e)
            {
                return null;
            }*/
#pragma warning restore 0168
            return b;
        }
    }
}
