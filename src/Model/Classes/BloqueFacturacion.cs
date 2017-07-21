using KarveCar.Model.Generic;
using KarveCar.Properties;
using System.Collections.Generic;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Classes
{
    public class BloqueFacturacion : GenericPropertyChanged, lControlCambioDataGrid
    {
        #region Constructores
        public BloqueFacturacion() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public BloqueFacturacion(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        private string codigo;
        public string Codigo
        {
            get  { return codigo; }
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
