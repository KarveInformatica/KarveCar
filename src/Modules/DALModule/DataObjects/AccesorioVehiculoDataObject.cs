using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.Enumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class AccesorioVehiculoDataObject : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public AccesorioVehiculoDataObject() { this.ControlCambio = EControlCambio.Null; }
        public AccesorioVehiculoDataObject(int codigo, string definicion)
        {
            this.codigo = codigo;
            this.definicion = definicion;
        }
        #endregion

        #region Propiedades
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged("Code");
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
