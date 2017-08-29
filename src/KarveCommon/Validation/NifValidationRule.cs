using System;
using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace KarveCommon.Validation
{
    public class NifValidationRule : ValidationRule
    {
        private string regExp = "^([A-Z]{6}[A-Z2-9][A-NP-Z1-9])(X{3}|[A-WY-Z0-9][A-Z0-9]{2})?$";

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
