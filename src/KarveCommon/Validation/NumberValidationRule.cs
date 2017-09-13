using System;
using System.Globalization;
using System.Windows.Controls;

namespace KarveCommon.Validation
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(true, null);
        }
    }
}
