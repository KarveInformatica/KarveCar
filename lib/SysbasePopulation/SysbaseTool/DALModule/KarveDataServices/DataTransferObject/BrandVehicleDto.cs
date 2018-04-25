using System;
using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Data transfer object of each vehicle.
    /// </summary>
    public class BrandVehicleDto : BaseDto
    {
        /// <summary>
        /// This is the code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Leave date. Fecha baja
        /// </summary>
        public DateTime LeaveDate { set; get; }
        /// <summary>
        ///  Supplier Reference.
        /// </summary>
        public SupplierDto Supplier { get; set; }
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
    }
}