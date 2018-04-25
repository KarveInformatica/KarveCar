using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class CreditCardDto: BaseDto
    {
        /// <summary>
        ///  Default mapping for the images.
        /// </summary>
        private string _code;

        private string _name;
        private IDictionary<string, string> ImagePath = new Dictionary<string, string>()
        {
            {"Generic", "/KarveCar;component/Images/genericcard.gif"},
            {"VI", "/KarveCar;component/Images/visa.png"},
            {"MA", "/KarveCar;component/Images/maestro.png"},
            {"MC", "/KarveCar;component/Images/mastercard.png"},
            {"AE", "/KarveCar;component/Images/amex.png"},
            {"VE", "/KarveCar;component/Images/visaelectron.png"}
        };
        public string Image { set; get; }
        /// <summary>
        ///  Code of the card.
        /// </summary>
        public string Code {
            set
            {
                _code = value;
                if (ImagePath.ContainsKey(_code))
                {
                    Image = ImagePath[_code];
                }
                else
                {
                    Image = ImagePath["Generic"];
                }
            }
            get { return _code; }
        }

        /// <summary>
        ///  Name of the card.
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
    }
}
