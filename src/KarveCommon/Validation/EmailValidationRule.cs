using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;


namespace KarveCommon.Validation
{

    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            Regex regEx=new Regex(pattern);
            if (!regEx.IsMatch((string)value))
            {
                return new ValidationResult(false, "You entered an invalid email");
            }
            return new ValidationResult(true, null);
        }
    }
}
