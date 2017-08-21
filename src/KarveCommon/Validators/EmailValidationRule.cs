using System;
using System.Collections.Generic;
using System.Text;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.ValidationRules;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KarveCommon
{

    public class EmailValidationRule : IValidationRule
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
