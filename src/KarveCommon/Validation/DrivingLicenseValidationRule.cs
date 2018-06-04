using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KarveCommon.Validation
{
    /// <summary>
    /// Look for the driving license number validation rule.
    /// </summary>
    public class DrivingLicenseValidationRule : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var language = cultureInfo.TwoLetterISOLanguageName.ToUpper();
            
            switch(language)
            {
                case "ES":
                    {
                        if (value is string drivingLicenseNumber)
                        {
                            return new ValidationResult(true, "No errors");
                        }
                        break;
                    }
            }
            return new ValidationResult(true, "No errors");
            

        }
    }
}
