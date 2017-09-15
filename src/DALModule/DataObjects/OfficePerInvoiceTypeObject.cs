namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Data Object with fields that are available in an invoice.
    /// </summary>
    class OfficePerInvoiceTypeObject: BaseAuxDataObject
    {
        private string _oficina;
        private string _telefono;
        private string _empresa;
        private object _fechaBaja;
        private object _zona;
        private string _direccion;
        private object _codigoPostal;
        private string _poblacion;
        /// <summary>
        ///  Office Code Property 
        /// </summary>
        public string Oficina
        {
            set { _oficina = value; }
            get { return _oficina; }
        }
        /// <summary>
        ///  Phone number property
        /// </summary>
        public string Telefono
        {
            set { _telefono = value; }
            get { return _telefono; }
        }
        /// <summary>
        ///  Company property
        /// </summary>
        public string Empresa
        {
            set { _empresa = value; }
            get { return _empresa; }
        }
        /// <summary>
        ///  Withdrawn date
        /// </summary>
        public object FechaBaja
        {
            set { _fechaBaja = value; }
            get { return _fechaBaja; }
        }
        /// <summary>
        ///  Zone 
        /// </summary>
        public object Zona
        {
            set { _zona = value; }
            get { return _zona; }
        }
        /// <summary>
        ///  Office Direction
        /// </summary>
        public string Direccion
        {
            set { _direccion = value; }
            get { return _direccion; }
        }
        /// <summary>
        ///  Postal code
        /// </summary>
        public object CodigoPostal
        {
            set { _codigoPostal = value; }
            get { return _codigoPostal; }  
        }
        /// <summary>
        ///  City
        /// </summary>
        public string Poblacion
        {
            set { _poblacion = value; }
            get { return _poblacion; }
        }
    }
}
