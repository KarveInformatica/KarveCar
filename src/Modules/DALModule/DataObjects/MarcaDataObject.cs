using KarveCar.Model.Generic;
using KarveCommon.Generic;
using System;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class MarcaDataObject : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public MarcaDataObject() { this.ControlCambio = EControlCambio.Null; }
        public MarcaDataObject(string codigo, string definicion, string ultimamodificacion, string usuario,
                               DateTime fechabaja, string proveedorcodigo, string proveedordescripcion, string condiciones,
                               string pactadas, string interlocutor, DateTime fechamarca, string observaciones)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.ultimamodificacion = ultimamodificacion;
            this.usuario = usuario;
            this.fechabaja = fechabaja;
            this.proveedorcodigo = proveedorcodigo;
            this.proveedordescripcion = proveedordescripcion;
            this.condiciones = condiciones;
            this.pactadas = pactadas;
            this.interlocutor = interlocutor;
            this.fechamarca = fechamarca;
            this.observaciones = observaciones;
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

        private DateTime? fechabaja;
        public DateTime? FechaBaja
        {
            get { return fechabaja; }
            set
            {
                fechabaja = value;
                OnPropertyChanged("FechaBaja");
            }
        }

        private string proveedorcodigo;
        public string ProveedorCodigo
        {
            get { return proveedorcodigo; }
            set
            {
                proveedorcodigo = value;
                OnPropertyChanged("ProveedorCodigo");
            }
        }

        private string proveedordescripcion;
        public string ProveedorDescripcion
        {
            get { return proveedordescripcion; }
            set
            {
                proveedordescripcion = value;
                OnPropertyChanged("ProveedorDescripcion");
            }
        }

        private string condiciones;
        public string Condiciones
        {
            get { return condiciones; }
            set
            {
                condiciones = value;
                OnPropertyChanged("Condiciones");
            }
        }

        private string pactadas;
        public string Pactadas
        {
            get { return pactadas; }
            set
            {
                pactadas = value;
                OnPropertyChanged("Pactadas");
            }
        }

        private string interlocutor;
        public string Interlocutor
        {
            get { return interlocutor; }
            set
            {
                interlocutor = value;
                OnPropertyChanged("Interlocutor");
            }
        }

        private DateTime? fechamarca;
        public DateTime? FechaMarca
        {
            get { return fechamarca; }
            set
            {
                fechamarca = value;
                OnPropertyChanged("FechaMarca");
            }
        }

        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set
            {
                observaciones = value;
                OnPropertyChanged("Observaciones");
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
