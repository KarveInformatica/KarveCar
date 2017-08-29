using System;
using System.Globalization;
using System.Windows.Controls;

namespace KarveCommon.Validation
{
    public class PercentageValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string currentValue = value as string;
            Int16 codeNumber;
            if (!Int16.TryParse(currentValue, out codeNumber))
            {
                return new ValidationResult(false, null);
            }
            if ((codeNumber < 0) || (codeNumber > 100))
            {
                return new ValidationResult(false, null);
            }
            return new ValidationResult(true, null);
        }
        
    }
}
