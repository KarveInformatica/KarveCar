using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class ChargeTypeObject: BaseAuxDataObject
    {
        private object nombre;
        private object numero;
        public object Numero
        {
            get { return numero; }
            set
            {
                numero =  value;
                OnPropertyChanged("Numero");
            }
        }
    }
}
