using System;
using System.Collections.Generic;

namespace KarveDataServices
{
    public interface IMagnifierSettings
    {
        
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