using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class BookingUnitToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectionIndex = 0;
            if (value is string selectedIndex)
            {
                selectedIndex = selectedIndex.ToUpper();
                switch (selectedIndex)
                {
                    case "DIA":
                        {
                            selectionIndex = 1;
                            break;
                        }
                    case "SEMANA":
                        {
                            selectionIndex = 2;
                            break;
                        }
                    case "MES":
                        {
                            selectionIndex = 3;
                            break;
                        }
                    case "QUINCENA":
                        {
                            selectionIndex = 4;
                            break;
                        }
                    case "UNICO":
                        {
                            selectionIndex = 5;
                            break;
                        }
                    case "FIN DE SEMAN":
                        {
                            selectionIndex = 6;
                            break;
                        }
                }
            }
            return selectionIndex;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object dbValue = null;
            if (value is int currentIndex)
            {
                switch (currentIndex)
                {
                    case 1:
                        {
                            dbValue = "DIA";
                            break;
                        }
                    case 2:
                        {
                            dbValue = "SEMANA";
                            break;
                        }
                    case 3:
                        {
                            dbValue = "MES";
                            break;
                        }
                    case 4:
                        {
                            dbValue = "QUINCENA";
                            break;
                        }
                    case 5:
                        {
                            dbValue = "UNICO";
                            break;
                        }
                    case 6:
                        {
                            dbValue = "FIN DE SEMANA";
                            break;
                        }
                }
            }
            return dbValue;
        }
    }
}
