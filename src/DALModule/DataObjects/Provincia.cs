using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace DataAccessLayer.DataObjects
{
    public class Provincia : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public Provincia() { this.ControlCambio = EControlCambio.Null; }
        public Provincia(string codigo, string definicion, string prefijo, string abreviatura, 
                         string capital, string ultimamodificacion, string usuario)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.prefijo    = prefijo;
            this.abreviatura = abreviatura;
            this.capital = capital;
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

        private string prefijo;
        public string Prefijo
        {
            get { return prefijo; }
            set
            {
                prefijo = value;
                OnPropertyChanged("Prefijo");
            }
        }

        private string abreviatura;
        public string Abreviatura
        {
            get { return abreviatura; }
            set
            {
                abreviatura = value;
                OnPropertyChanged("Abreviatura");
            }
        }

        private string capital;
        public string Capital
        {
            get { return capital; }
            set
            {
                capital = value;
                OnPropertyChanged("Capital");
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
