using System;
using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace KarveCommon.Validation
{
    public class NifValidationRule : ValidationRule
    {
       public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var NIF = value as string;
            if (NIF != null)
            {
                string patron = "[A-HJ-NP-SUVW][0-9]{7}[0-9A-J]|\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{7}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[YZ]\\d{0,7}[TRWAGMYFPDXBNJZSQVHLCKE]";
                string sRemp = "";
                bool ret = false;
                System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(patron);
                sRemp = rgx.Replace(NIF.ToString(), "OK");
                if (sRemp == "OK") ret = true;
                if (ret)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, null);
        }
    }
}
