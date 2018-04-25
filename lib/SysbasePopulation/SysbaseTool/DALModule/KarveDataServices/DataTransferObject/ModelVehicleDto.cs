
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Data transfer object.
    /// </summary>
    public class ModelVehicleDto
    {
        /// <summary>
        ///  brand
        /// </summary>
        [Display(Name = "Codigo Marca")]
        public string Marca { get; set; }
        /// <summary>
        /// Nome marca
        /// </summary>
        [Display(Name = "Nombre Marca")]
        public string NomeMarca { get; set; }
        /// <summary>
        ///  Code
        /// </summary>
        [Display(Name = "Codigo Modelo")]
        public string Codigo { get; set; }
        /// <summary>
        ///  Variante
        /// </summary>
        [Display(Name = "Variante")]
        public string Variante { get; set; }
        /// <summary>
        ///  Nombre.
        /// </summary>
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        /// <summary>
        ///  Categoria.
        /// </summary>
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        /// <summary>
        /// Chassis.
        /// </summary>
        [Display(Name = "Chassis")]
        public string Chassis { get; set; }
        /// <summary>
        ///  Referencia modelo.
        /// </summary>
        [Display(Name = "Referencia")]
        public string Referencia { get; set; }

    }
}