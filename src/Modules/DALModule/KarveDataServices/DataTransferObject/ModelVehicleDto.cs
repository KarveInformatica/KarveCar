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
        public string Marca { get; set; }
        /// <summary>
        /// Nome marca
        /// </summary>
        public string NomeMarca { get; set; }
        /// <summary>
        ///  Code
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        ///  Variante
        /// </summary>
        public string Variante { get; set; }
        /// <summary>
        ///  Nombre.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        ///  Categoria.
        /// </summary>
        public string Categoria { get; set; }
        /// <summary>
        /// Chassis.
        /// </summary>
        public string Chassis { get; set; }
    }
}