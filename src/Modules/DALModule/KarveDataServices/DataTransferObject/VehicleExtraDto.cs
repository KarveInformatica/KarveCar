using System;
using DevExpress.Xpo;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  VehcileExtraDto.
    /// </summary>
    public class VehicleExtraDto : BaseDto
    {
        public VehicleExtraDto() 
        {
        }
        /// <summary>
        ///  Code of the extra
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        ///  Name of the extra
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        ///  Reference of the extra
        /// </summary>
        public string Reference { set; get; }
        /// <summary>
        ///  Vehicle Type of the extras.
        /// </summary>
        public string Notes { set; get; }
        public VehicleTypeDto VehicleType { set; get; }
    }

}