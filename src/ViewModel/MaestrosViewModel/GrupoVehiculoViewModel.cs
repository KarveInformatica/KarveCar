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
using Prism.Mvvm;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class GrupoVehiculoViewModel : BindableBase
    {
        #region Variables
        private ICommand grupovehiculocommand;

        private DataTable srcdataTable;
        private DataTable dataTable;
        public DataTable SourceDataTable
        {
            get { return dataTable; }
            set
            {
                dataTable = value;
                RaisePropertyChanged();
            }
        }
        public ICommand DataGridSelectionChanged { get; set; }

        #endregion
        private void OnSelectionChanged(object dataRowView)
        {
            DataRowView rowView = dataRowView as DataRowView;
        }

        #region Constructor
        public GrupoVehiculoViewModel()
        {
            this.grupovehiculocommand = new DelegateCommand<object>(GrupoVehiculo);
            this.dataTable = InitDataLayer();
         
        }
        #endregion

        #region Commands
        public ICommand GrupoVehiculoCommand
        {
            get
            {
                return grupovehiculocommand;
            }
            set { grupovehiculocommand = value; }
        }

        #endregion


        private DataTable InitDataLayer()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs = GetValuesFromDBGeneric.GetValuesFromDB(EOpcion.rbtnGruposVehiculos, sql);
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
            return dataTable;
        }
        #region Métodos
        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        private void GrupoVehiculo(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            this.DataGridSelectionChanged = new DelegateCommand<object>(OnSelectionChanged);
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                GrupoVehiculoUserControl obj = new GrupoVehiculoUserControl();
                // FIXME: this is a sign of a bad code organization. The use of region prevent all this.
                obj.grupoVehiculoDataGridUC.dtgrGruposVehiculos.Items.Clear();
                obj.grupoVehiculoDataGridUC.DataContext = this;
                TabItemLogic.CreateTabItemUserControlFromContainer(opcion, obj);
            }
        }
        #endregion
    }
}