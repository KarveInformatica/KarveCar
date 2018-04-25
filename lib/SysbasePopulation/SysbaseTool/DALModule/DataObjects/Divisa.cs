using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.Enumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class Divisa : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public Divisa() { this.ControlCambio = EControlCambio.Null; }
        public Divisa(string codigo, string definicion, decimal compra, decimal venta, string ultimamodificacion, string usuario)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.compra = compra;
            this.venta = venta;
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

        private decimal compra;
        public decimal Compra
        {
            get { return compra; }
            set
            {
                compra = value;
                OnPropertyChanged("Compra");
            }
        }

        private decimal venta;
        public decimal Venta
        {
            get { return venta; }
            set
            {
                venta = value;
                OnPropertyChanged("Venta");
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
