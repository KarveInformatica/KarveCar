using System;

namespace KarveDataServices.DataTransferObject
{
    
    /// <summary>
    /// Date time of the holiday date. It allows to say which holiday is possible. 
    /// </summary>
    public class HolidayDto
    {

        /// <summary>
        ///  Set or get the OFICINA property.
        /// </summary>

        public string OFICINA { get; set; }

        /// <summary>
        ///  Set or get the FESTIVO property.
        /// </summary>

        public DateTime FESTIVO { get; set; }

        /// <summary>
        ///  Set or get the PARTE_DIA property.
        /// </summary>

        public byte? PARTE_DIA { get; set; }

        /// <summary>
        ///  Set or get the HORA_DESDE property.
        /// </summary>

        public TimeSpan? HORA_DESDE { get; set; }
    
        /// <summary>
        ///  Set or get the HORA_HASTA property.
        /// </summary>

        public TimeSpan? HORA_HASTA { get; set; }
        public ProvinciaDto Province { set; get; }
    }
}