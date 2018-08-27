using System;
using System.Runtime.Serialization;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    /// Data transfer object of each vehicle.
    /// </summary>
    public class BrandVehicleViewObject : BaseViewObject
    {
       
        /// <summary>
        ///  Leave date. Fecha baja
        /// </summary>
        public DateTime LeaveDate { set; get; }
        /// <summary>
        ///  Supplier Reference.
        /// </summary>
        public SupplierViewObject Supplier { get; set; }
        /// <summary>
        ///  CurrentDate
        /// </summary>
        public DateTime? CurrentDate { get; set; }
        /// <summary>
        /// Terms/Condiciones.
        /// </summary>
        public string Terms { get; set; }
        /// <summary>
        ///  Observation.
        /// </summary>
        public string Observation { get; set; }

        public override bool HasErrors
        {
            get
            {
                if ((Name != null) && (Name.Length > 60))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }

    }
}