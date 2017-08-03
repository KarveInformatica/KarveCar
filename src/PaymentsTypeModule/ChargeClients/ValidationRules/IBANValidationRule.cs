using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PaymentTypeModule.ChargeClients.ValidationRules
{
    public class IbanValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string ibanInputString = value as string;
            StatusData result = Iban.CheckIban(ibanInputString, true);
            if (!result.IsValid)
            {
                return new ValidationResult(false,
                    result.Message);
            }
            return new ValidationResult(true, null);
        }
    }
}
