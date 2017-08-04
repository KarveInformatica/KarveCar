using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace PaymentTypeModule.ChargeClients.ValidationRules
{
    class SwiftValidationRule : ValidationRule
    {
        private string regExp = "^([a-zA-Z]){4}([a-zA-Z]){2}([0-9a-zA-Z]){2}([0-9a-zA-Z]{3})?$";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string swiftInputString = value as string;
            if (swiftInputString != null)
            {
                bool validRes = Regex.IsMatch(swiftInputString, regExp);
                if (validRes)
                {
                    return new ValidationResult(true, null);
                }
            }
        return new ValidationResult(false, null);
        }
    }
}
