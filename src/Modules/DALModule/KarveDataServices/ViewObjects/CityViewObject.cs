﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    /// CityViewObject. Data Transfer object for the city
    /// </summary>
    public class CityViewObject : BaseViewObject
    {
        /// <summary>
        ///  Code.
        /// </summary>
        [Required]
        [Display(Name ="Codigo")]
        public new string Code { get; set; }
        /// <summary>
        ///  Country
        /// </summary>
        [Display(Name = "Pais")]
        [MaxLength(3)]
        public string Pais { get; set; }
        /// <summary>
        ///  City
        /// </summary>
        [Display(Name ="Poblacion")]
        public string Poblacion { get; set; }
        /// <summary>
        ///  CountryViewObject.
        /// </summary>
        public CountryViewObject Country { get; set; }
        public override bool HasErrors
        {
            get
            { 
                if ((Pais != null) && (Pais.Length > 3))
                {
                    ErrorList.Add("Campo pais demasiado largo");
                    return true;
                }
             
                return false;
            }
        }
    }
}
