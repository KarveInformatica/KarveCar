using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class TarjetaEmpresa : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public TarjetaEmpresa() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public TarjetaEmpresa(string codigo, string definicion, double precio, string condicion)
        {
            this.codigo     = codigo;
            this.definicion = definicion;
            this.precio    = precio;
            this.condicion = condicion;
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

        private string definicion;
        public string Definicion
        {
            get { return definicion; }
            set
            {
                definicion = value;
                OnPropertyChanged("Definicion");
            }
        }

        private double precio;
        public double Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged("Precio");
            }
        }

        private string condicion;
        public string Condicion
        {
            get { return condicion; }
            set
            {
                condicion = value;
                OnPropertyChanged("Condicion");
            }
        }

        private string ultimamodificacion;
        public string UltimaModificacion
        {
            get { return ultimamodificacion; }
            set
            {
                ultimamodificacion = value;
                OnPropertyChanged("UltimaModificacion");
            }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged("Usuario");
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
