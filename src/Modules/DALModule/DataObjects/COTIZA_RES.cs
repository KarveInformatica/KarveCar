
namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// The cotiz a_ res.
    /// </summary>
    public class COTIZA_RES
    {
        /// <summary>
        /// Gets or sets the tarifa.
        /// </summary>
        public string TARIFA { set; get; }

        /// <summary>
        /// Gets or sets the grupo.
        /// </summary>
        public string GRUPO { set; get; }

        /// <summary>
        /// Gets or sets the nom concep.
        /// </summary>
        public string nomConcep { set; get; }

        /// <summary>
        /// Gets or sets the cod concep.
        /// </summary>
        public int codConcep { set; get; }

        /// <summary>
        /// Gets or sets the ind_ facturar.
        /// </summary>
        public int Ind_Facturar { set; get; }

        /// <summary>
        /// Gets or sets the incluido.
        /// </summary>
        public int Incluido { set; get; }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        public int Tipo { set; get; }

        /// <summary>
        /// Gets or sets the unidad.
        /// </summary>
        public string Unidad { set; get; }

        /// <summary>
        /// Gets or sets the cant.
        /// </summary>
        public int Cant { set; get; }

        /// <summary>
        /// Gets or sets the extras.
        /// </summary>
        public short Extras { set; get; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        public decimal Precio { set; get; }

        /// <summary>
        /// Gets or sets the dto.
        /// </summary>
        public decimal Dto { set; get; }

        /// <summary>
        /// Gets or sets the importe.
        /// </summary>
        public decimal Importe { set; get; }

        /// <summary>
        /// Gets or sets the minimo.
        /// </summary>
        public int Minimo { set; get; }

        /// <summary>
        /// Gets or sets the maximo.
        /// </summary>
        public int Maximo { set; get; }
    }
}
