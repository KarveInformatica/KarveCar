using KarveCar.Model.Generic;
<<<<<<< HEAD
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;
=======
using KarveCar.Properties;
using System.Collections.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;
using KarveCar.Model;
using KarveCommon.Generic;
>>>>>>> bdf210e7656c4e8dc0e53d6bdd0ef6e2db226d10

namespace KarveCar.Model.Classes
{
    public class Banco : GenericPropertyChanged, IDataGridRowChange
    {
        #region Constructores
        public Banco() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public Banco(string codigo, string definicion, string swift, string ultimamodificacion, string usuario)
        {
            this.codigo = codigo;
            this.definicion = definicion;
            this.swift  = swift;
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


        private string swift;
        public string Swift
        {
            get { return swift; }
            set
            {
                swift = value;
                OnPropertyChanged("Swift");
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
