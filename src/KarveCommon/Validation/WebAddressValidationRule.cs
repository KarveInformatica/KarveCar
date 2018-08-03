using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KarveCommon.Validation
{

    public class WebAddressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string uri)
            {
                Uri outValue = null;
                if (Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out outValue))
                {
                    return new ValidationResult(true, null);
                }

            }
            return new ValidationResult(false, "You entered an invalid web address");   
        }
    }
}
