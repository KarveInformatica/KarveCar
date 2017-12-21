using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.Enumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class BloqueFacturacion : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public BloqueFacturacion() { this.ControlCambio = EControlCambio.Null; }
        public BloqueFacturacion(string codigo, string definicion)
        {
            this.codigo = codigo;
            this.definicion = definicion;
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

        private EControlCambio controlcambiodatagrid;
        public EControlCambio ControlCambio
        {
            get { return controlcambiodatagrid; }
            set
            {
                controlcambiodatagrid = value;
                OnPropertyChanged("ControlCambio");
            }
        }
        #endregion
    }
}
