using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  clients summary dto.
    /// </summary>
    public class ClientsSummaryDto
    {
        public string Codigo { set; get; }
        public string Nombre { set; get; }
        public string Nif { set; get; }
        public string Direccion { set; get; }
        public string Poblacion { set; get; }
        public string Provincia { set; get; }
        public string Pais { set; get; }
        public string Telefono { set; get; }
        public string Movil { set; get; }
    }
}
