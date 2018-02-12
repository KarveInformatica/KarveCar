using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    [Table("CliContactos")]
    class CliContactsPoco
    {

        [Key]
        public string ccoIdContacto { get; set; }
        public string ccoContacto { get; set; }
        public string idDelegacion { get; set; }
        public string nombreDelegacion { get; set; }
        public string NIF { get; set; }
        public string ccoCargo { get; set; }
        public string ccoTelefono { get; set; }
        public string ccoMovil { get; set; }
        public string ccoFax { get; set; }
        public string ccoMail { get; set; }
        public string ULTMODI { get; set; }
        public string USUARIO { get; set; }
    }
}
