using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Public office data transfer object.
    /// </summary>
    public class OfficeDtos: BaseDto
    {
        [Display(GroupName = "Codigo Oficina")]
        public string Codigo { get; set; }
        [Display(GroupName = "Nombre Oficina")]
        public string Nombre { get; set; }
        /// <summary>
        ///  This returns the dates of holiday of a single office.
        /// </summary>
        public  IEnumerable<HolidayDto> HolidayDates { set; get; }
    }
}
