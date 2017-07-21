using KarveCar.Model.Generic;
using KarveCar.Properties;
using System.Collections.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;
using KarveCar.Model;
using KarveCommon.Generic;

namespace KarveCar.Model.Classes
{
    public class Banco : GenericPropertyChanged, lControlCambioDataGrid
    {
        #region Constructores
        public Banco() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public Banco(string codigo, string nombre, string swift)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.swift  = swift;
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
