using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  DeliveringForm. Pending Delivering.
    /// </summary>
   public class DeliveringFormViewObject: BaseViewObject
    {
      public  byte Codigo { set; get; }
      public  string Nombre { set; get; }

    
    public bool IsInvalid()
    {
        if ((Nombre != null) && (Nombre.Length > 100))
        {
            ErrorList.Add(ConstantDataError.NameTooLong);
            return true;
        }
        return false;
     }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}
