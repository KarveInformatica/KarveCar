﻿using System.Collections.Generic;
using KarveDapper.Extensions;
using KarveDataServices;
namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  This is the entity of the magnifier.
    /// </summary>
    [System.ComponentModel.DataAnnotations.Schema.Table("USER_LUPAS")]
    public class MagnifierSettings: IMagnifierSettings
    {

        /// <summary>
        ///  Columnas of the magnifier.
        /// </summary>
        public IEnumerable<IMagnifierColumns> MagnifierColumns { set; get; }
        /// <summary>
        ///  Identification
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        ///  User
        /// </summary>
        public string USUARIO { get; set; }
        // Magnifier 
        public string LUPA { get; set; }
        // Name
        public string NOMBRE { get; set; }
        /// <summary>
        ///  Defect
        /// </summary>
        public byte? DEFECTO { get; set; }
        /// <summary>
        ///  Public
        /// </summary>
        public byte? PUBLICA { get; set; }
        /// <summary>
        ///  LastModification.
        /// </summary>
        public string ULTIMOD { get; set; }
    }
}
