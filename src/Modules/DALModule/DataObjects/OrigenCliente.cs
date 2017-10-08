using KarveCar.Model.Generic;
using KarveCommon.Generic;

namespace DataAccessLayer.DataObjects
{
    public class OrigenCliente : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public OrigenCliente() { this.ControlCambio = RecopilatorioEnumerations.EControlCambio.Null; }
        public OrigenCliente(int codigo, string definicion, string ultimamodificacion, string usuario)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.ultimamodificacion = ultimamodificacion;
            this.usuario = usuario;
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

        public string  Clave { get; set; }
        public string  Grupo { get; set; }
        public string  Telefono { get; set; }

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

        private RecopilatorioEnumerations.EControlCambio controlcambiodatagrid;
        public RecopilatorioEnumerations.EControlCambio ControlCambio
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
