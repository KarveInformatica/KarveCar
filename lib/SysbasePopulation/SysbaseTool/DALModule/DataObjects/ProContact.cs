using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class ProContact
    {

        public Int32? ccoIdCargo { get; set; }
        public string ccoIdContacto { get; set; }
        public string ccoIdCliente { get; set; }
        public string Nombre { set; get; }
        public string Cargo { set; get; }
        public string Nif { set; get; }
        public string Dipartimento { set; get; }
        public string Telefono { set; get; }
        public string Movil { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string UltimaModifica { set; get; }

    }
}
