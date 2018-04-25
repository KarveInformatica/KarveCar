using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{

    /// <summary>
    ///  This is the supplier monitoring data for evaluation.
    /// </summary>
    public interface ISupplierMonitoringData
    {
        /// <summary>
        ///  Supplier Code
        /// </summary>
        string Nombre { get; set; }
        /// <summary>
        ///  Date of the Supplier
        /// </summary>
        DateTime Fecha { get; set; }
        /// <summary>
        /// Number of inc.
        /// </summary>
        string NumInc { get; set; }
        /// <summary>
        ///  Observation of the provider
        /// </summary>
        string Observaciones { get; set; }
        /// <summary>
        ///  Responsable.
        /// </summary>
        string Responsable { get; set; }
    }
}
