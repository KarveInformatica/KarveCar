using System;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Base class for each kind of data object in the AUX.
    /// </summary>
    public class BaseAuxDataObject : GenericPropertyChanged, IDataGridRowChange
    {
        private string _codigo;
        private string _definicion;
        private string _ultimamodificacion;
        private string _usuario;
        private string _nombre;
        private EControlCambioDataGrid _controlcambiodatagrid;

        public BaseAuxDataObject()
        {
            this.ControlCambioDataGrid = EControlCambioDataGrid.Null;
        }
        public BaseAuxDataObject(string codigo, string definicion, string ultimamodificacion, string usuario)
        {
            this._codigo = codigo;
            this._definicion = definicion;
            this._ultimamodificacion = ultimamodificacion;
            this._usuario = usuario;
        }
        public string Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
                OnPropertyChanged("Codigo");
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Definicion
        {
            get { return _definicion; }
            set
            {
                _definicion = value;
                OnPropertyChanged("Definicion");
            }
        }
        public string UltimaModificacion
        {
            get { return _ultimamodificacion; }
            set
            {
                _ultimamodificacion = value;
                OnPropertyChanged("UltimaModificacion");
            }
        }
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged("Usuario");
            }
        }
        public EControlCambioDataGrid ControlCambioDataGrid
        {
            get { return _controlcambiodatagrid; }
            set
            {
                _controlcambiodatagrid = value;
                OnPropertyChanged("ControlCambioDataGrid");
            }
        }
    }
  
}
