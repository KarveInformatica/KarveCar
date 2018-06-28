using System;

namespace KarveDataServices.DataTransferObject
{
    public class CompanyCardDto: BaseDtoDefaultName
    {

        
        
        
        /// <summary>
        ///  Set or get the PRECIO property.
        /// </summary>

        public Decimal? Price { get; set; }

        /// <summary>
        ///  Set or get the CONDICIONES property.
        /// </summary>

        public string Conditions { get; set; }

        /// <summary>
        ///  Set or get the PREFIJO property.
        /// </summary>

        public string Prefix { get; set; }
       
    }
}