using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class CardTypeImageConverter : IValueConverter
    {
        private const string visaCode = "VI";
        private const string fourB = "4B";
        private const string maestro = "MA";
        private const string mastercard = "MC";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cardtype = value as string;
            string vpath = string.Empty;
            switch (cardtype)
            {
                case visaCode:
                    {
                       vpath = "/KarveControls;component/Images/visa.png"; 
                        break;
                    }
                case fourB:
                    {
                        vpath = "/KarveControls;component/Images/fourb.png";
                        break;
                    }
                case mastercard:
                    {
                        vpath = "/KarveControls;component/Images/fourb.png";
                        break;
                    }
                case maestro:
                    {
                        vpath = "/KarveControls;component/Images/maestro.png";
                        break;
                    }
                case "SX":
                    {
                        vpath = "/KarveControls;component/Images/sxexpresscard.jpg";
                        break;
                    }
                default:
                    {
                        vpath = "/KarveControls;component/Images/maestro.png";
                        break;
                    }
                
            }
            return vpath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
