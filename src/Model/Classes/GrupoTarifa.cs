using KarveCar.Model.Generic;
using KarveCar.Properties;
using System.Collections.Generic;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Classes
{
    public class GrupoTarifa : GenericPropertyChanged, lControlCambioDataGrid
    {       
        #region Constructores
        public GrupoTarifa() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public GrupoTarifa(string codigoAux, string nombre, string ultmodi)
        {
            this.codigo = codigoAux;
            this.nombre = nombre;
            this.ultmodi = ultmodi;
        }
        #endregion

        #region Propiedades
        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        private string ultmodi;
        public string UltModi
        {
            get { return ultmodi; }
            private set
            {
                ultmodi = value;
                OnPropertyChanged("UltModi");
            }
        }

        private EControlCambioDataGrid controlcambiodatagrid;
        public EControlCambioDataGrid ControlCambioDataGrid
        {
            get { return controlcambiodatagrid; }
            set
            {
                controlcambiodatagrid = value;
                OnPropertyChanged("ControlCambioDataGrid");
            }
        }
        #endregion
    }
}
