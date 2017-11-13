using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{

public class VisitasComiPoco
{
// <summary>
    ///  Set or get the visIdVisita property.
    /// </summary>
        [Key]    
		public string visIdVisita { get; set; }
 
	/// <summary>
    ///  Set or get the visIdCliente property.
    /// </summary>
    
		public string visIdCliente { get; set; }
 
	/// <summary>
    ///  Set or get the visIdContacto property.
    /// </summary>
    
		public string visIdContacto { get; set; }


    /// <summary>
    ///  Set or get the visIdCliente property.
    /// </summary>

    public int visIdVisitaTipo { get; set; }

        /// <summary>
        ///  Set or get the visFecha property.
        /// </summary>

        public DateTime? visFecha { get; set; }
        /// <summary>
        /// Contactos comi
        /// </summary>
    public CONTACTOS_COMI ContactsComi { get; set; }
        /// <summary>
        ///  Vendedor comi
        /// </summary>
    public VENDEDOR VendedorComi { get; set; }
        public TIPOVISITAS TipoVisitas { get; set; }
    }
}