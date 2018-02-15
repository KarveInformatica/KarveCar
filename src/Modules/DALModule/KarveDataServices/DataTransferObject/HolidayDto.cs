using System;

namespace KarveDataServices.DataTransferObject
{
    
    /// <summary>
    /// Date time of the holiday date. It allows to say which holiday is possible. 
    /// </summary>
    public class HolidayDto
    {
        public DateTime Date { set; get; }
        public ProvinciaDto Province { set; get; }
    }
}