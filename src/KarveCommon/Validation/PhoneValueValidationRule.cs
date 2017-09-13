using System;
using System.Globalization;
using System.Windows.Controls;

namespace KarveCommon.Validation
{
    public class PhoneValueValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string currentValue = value as string;
            Int64 codeNumber;
            if (!Int64.TryParse(currentValue, out codeNumber))
            {
                return new ValidationResult(false, null);
            }
            return new ValidationResult(true, null);
        }
    }
}
