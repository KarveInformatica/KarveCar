using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    public class CommissionTypeViewObject : BaseViewObject
    {

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public override bool HasErrors
        {
            get
            {
                if ((Nombre != null) && (Nombre.Length > 40))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }
    }
}