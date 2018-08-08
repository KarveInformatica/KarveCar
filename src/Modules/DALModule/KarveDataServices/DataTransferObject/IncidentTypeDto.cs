﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{

    public class IncidentTypeDto: BaseDtoDefaultName
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name="Codigo")]
        public new string Code { get; set; }
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name="Nombre")]
        public new string Name { get; set; }

     }
}
