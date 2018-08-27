using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    public class MonthsViewObject: BaseViewObject
    {
        /// <summary>
        ///  Set or get the NUMERO_MES property.
        /// </summary>

        public Int32 NUMERO_MES { get; set; }

        /// <summary>
        ///  Set or get the MES property.
        /// </summary>

        public string MES { get; set; }

        public bool IsInvalid()
        {
            if ((MES != null) && (MES.Length > 12))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}
