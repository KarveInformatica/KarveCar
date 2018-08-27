using System;

namespace KarveDataServices.ViewObjects
{
    public class CompanyCardViewObject: BaseViewObjectDefaultName
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