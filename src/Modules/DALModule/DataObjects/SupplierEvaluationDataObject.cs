using System;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
 
    public class SupplierEvaluationDataObject : ISupplierEvaluationNoteData
    {
        public string Nombre { get ; set ; }
        public decimal Precio { get; set; }
        public decimal CumplePrevision { get; set; }
        public decimal RespondePedido { get ; set ; }
        public decimal SuministraInfo { get; set ; }
        public DateTime Fecha { get ; set ; }
        public decimal Trato { get; set; }
        public decimal AttRecibida { get; set; }
        public decimal Presentacion { get; set; }
        public decimal Suma { get; set; }
        public decimal Media { get; set ; }
    }
}
