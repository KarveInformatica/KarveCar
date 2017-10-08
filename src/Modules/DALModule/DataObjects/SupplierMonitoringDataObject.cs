using System;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    public class SupplierMonitoringDataObject : ISupplierMonitoringData
    {
        public string Nombre { get; set ; }
        public DateTime Fecha { get; set; }
        public string NumInc { get; set ; }
        public string Observaciones { get; set ; }
        public string Responsable { get ; set ; }
    }
}
