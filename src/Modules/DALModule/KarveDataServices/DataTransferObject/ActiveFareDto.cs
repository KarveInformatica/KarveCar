using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This is the name for the fares.
    /// </summary>
    public class ActiveFareDto: BaseDto 
    {
        [Display(Name="Tarifa")]
        string Fare { set; get; }
        [Display(Name = "Activa")]
        byte IsActive { set; get; }
        public override bool HasErrors
        {
            get
            {
                if ((Name != null) && (Name.Length > 50))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }

                return false;
            }
        }
    }
}
