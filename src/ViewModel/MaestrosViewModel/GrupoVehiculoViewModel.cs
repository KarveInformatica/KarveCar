using DataAccessLayer.DataObjects;
using KarveCar.Commands.MaestrosCommand;
using KarveCar.Logic.Generic;
using KarveCar.Model.SQL;
using KarveCar.Utility;
using KarveCar.View;
using KarveCommon.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class GrupoVehiculoViewModel : GenericPropertyChanged
    {
        #region Variables
        private GrupoVehiculoCommand grupovehiculocommand;

        
        private DataTable grupovehiculodatatable;
        public DataTable GrupoVehiculoDataTable
        {
            get { return grupovehiculodatatable; }
            set
            {
                grupovehiculodatatable = value;
                OnPropertyChanged("GrupoVehiculoDataTable");
            }
        }
        public ICommand DataGridSelectionChanged { get; set; }



        //private GrupoVehiculoDataObject grupovehiculoselecteditem;
        //public GrupoVehiculoDataObject GrupoVehiculoSelectedItem
        //{
        //    get { return grupovehiculoselecteditem; }
        //    set
        //    {
        //        grupovehiculoselecteditem = value;
        //        OnPropertyChanged("GrupoVehiculoSelectedItem");
        //    }
        //}
        #endregion
        private void OnSelectionChanged(object dataRowView)
        {
            DataRowView rowView = dataRowView as DataRowView;
        }

        #region Constructor
        public GrupoVehiculoViewModel()
        {
            this.grupovehiculocommand = new GrupoVehiculoCommand(this);
        }
        #endregion

        #region Commands
        public ICommand GrupoVehiculoCommand
        {
            get
            {
                return grupovehiculocommand;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        public void GrupoVehiculo(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            this.DataGridSelectionChanged = new DelegateCommand<object>(OnSelectionChanged);
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                GrupoVehiculoUserControl obj = new GrupoVehiculoUserControl();
                TabItemLogic.CreateTabItemUserControl(opcion, obj);
                string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
                GenericObservableCollection obs = GetValuesFromDBGeneric.GetValuesFromDB(opcion, sql);
                //tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.GenericObsCollection = GetValuesFromDBGeneric.GetValuesFromDB(opcion, sql);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("Codigo", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Definicion", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Acriss", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Modelo", typeof(string)));
                dataTable.Columns.Add(new DataColumn("TipoVehiculoCodigo", typeof(string)));

                foreach (var item in obs.GenericObsCollection)
                {
                    GrupoVehiculoDataObject dataObject = item as GrupoVehiculoDataObject;
                    if (dataObject != null)
                    {
                        var row = dataTable.NewRow();
                        row["Codigo"] = dataObject.Codigo;
                        row["Definicion"] = dataObject.Definicion;
                        row["Acriss"] = dataObject.Acriss;
                        row["Modelo"] = dataObject.Modelo;
                        row["TipoVehiculoCodigo"] = dataObject.TipoVehiculoCodigo;
                        dataTable.Rows.Add(row);
                        dataTable.AcceptChanges();
                    }
                }

                this.GrupoVehiculoDataTable = dataTable;
                    //ManageGenericObject.ToDataTable<GrupoVehiculoDataObject>(GetValuesFromDBGeneric.GetValuesFromDB(opcion, sql));
            }
        }
        #endregion
    }
}