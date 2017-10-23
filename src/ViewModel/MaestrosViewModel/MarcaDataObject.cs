using System;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MarcaDataObject
    {
        public object ProveedorCodigo { get; set; }
        public object ProveedorDescripcion { get; set; }
        public string Codigo { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaMarca { get; set; }
        public object Definicion { get; internal set; }
        public object Pactadas { get; set; }
        public object Condiciones { get; set; }
        public object Interlocutor { get; set; }
        public object Observaciones { get; set; }
    }
}