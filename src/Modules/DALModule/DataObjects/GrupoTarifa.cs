using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace DataAccessLayer.DataObjects
{
    public class GrupoTarifa : GenericPropertyChanged, IDataGridRowChange
    {       
        #region Constructores
        public GrupoTarifa() { this.ControlCambio = EControlCambio.Null; }
        public GrupoTarifa(string codigo, string definicion, string ultimamodificacion, string usuario)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.ultimamodificacion = ultimamodificacion;
            this.usuario = usuario;
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
