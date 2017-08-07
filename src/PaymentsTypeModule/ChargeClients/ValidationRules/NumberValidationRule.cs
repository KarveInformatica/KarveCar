using System;
using System.Globalization;
using System.Windows.Controls;

namespace PaymentTypeModule.ChargeClients.ValidationRules
{
    public class NumberValidationRule: ValidationRule
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
