using System;
using System.Collections.Generic;

namespace KarveDataServices
{
    public interface IMagnifierSettings
    {
        /// <summary>
        ///  Columnas of the magnifier.
        /// </summary>
         IEnumerable<IMagnifierColumns> MagnifierColumns { set; get; }
        //private USER_LUPAS _lupas;
        /// <summary>
        ///  Set or get the ID property.
        /// </summary>

         int ID { get; set; }
        /// <summary>
        ///  User
        /// </summary>
         string USUARIO { get; set; }
        // Magnifier 
         string LUPA { get; set; }
        // Name
         string NOMBRE { get; set; }
        /// <summary>
        ///  Defect
        /// </summary>
         byte? DEFECTO { get; set; }
        /// <summary>
        ///  Public
        /// </summary>
        byte? PUBLICA { get; set; }
        /// <summary>
        ///  LastModification.
        /// </summary>
         string ULTIMOD { get; set; }
    }
}