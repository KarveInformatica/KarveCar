using System.Globalization;
using System.Windows.Controls;

namespace KarveCommon.Validation
{
    public class IbanValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string ibanInputString = value as string;
            StatusData result = Iban.CheckIban(ibanInputString, true);
            if (!result.IsValid)
            {
                return new ValidationResult(false, result.Message);
            }
            return new ValidationResult(true, null);
        }
    }
}
