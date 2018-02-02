using System;
using System.Globalization;
using System.Windows.Controls;
using DevExpress.Xpo;

namespace KarveCommon.Validation
{

    public class EmptyValidationRule : ValidationRule
    {
        public EmptyValidationRule() : base()
        {
        }
    
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return  new ValidationResult(true, null);
        }
    }

}