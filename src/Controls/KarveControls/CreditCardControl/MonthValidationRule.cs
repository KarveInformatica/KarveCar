using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KarveControls
{
    class MonthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string month)
            {
                if (month.Length == 2)
                {
                    return new ValidationResult(true, "OK");
                }
            }

            return new ValidationResult(false, "InvalidMonth");
        }
    }
}
