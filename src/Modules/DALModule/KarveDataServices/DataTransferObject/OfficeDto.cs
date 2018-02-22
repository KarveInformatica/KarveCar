using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    public class OfficeOpenClose
    {
        public TimeSpan? Open { set; get; }
        public TimeSpan? Close { set; get; }
    }
    /// <summary>
    ///  Daily open for the open.
    /// </summary>
    public struct DailyTime
    {
        /// <summary>
        ///  Morning daily office open.
        /// </summary>
        public OfficeOpenClose Morning { set; get; }
        /// <summary>
        ///  Afternoon daily office open.
        /// </summary>
        public OfficeOpenClose Afternoon { set; get;}
    }
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
        /// <summary>
        ///  Weekly time table in the morning
        /// </summary>
        public IList<DailyTime> TimeTable { set; get; }
      
    }
}
