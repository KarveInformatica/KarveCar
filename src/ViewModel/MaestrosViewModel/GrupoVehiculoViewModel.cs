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
using System.Threading.Tasks;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;
using KarveCommon.Logic.Generic;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class GrupoVehiculoViewModel : BindableBase
    {
        #region Variables
        private ICommand grupovehiculocommand;

        private DataTable dataTable;
      
        public DataTable SourceDataTable
        {
            get { return dataTable; }
            set
            {
                dataTable = value;
                RaisePropertyChanged("SourceDataTable");
            }
        }
       
        private void SetTable(DataTable newTable)
        {
            this.SourceDataTable = newTable;
        }

        #endregion

        #region Constructor
        public GrupoVehiculoViewModel()
        {
            this.grupovehiculocommand = new DelegateCommand<object>(GrupoVehiculo);
            this.dataTable = InitDataLayerSync();
        }
        #endregion

        #region Commands
        public ICommand DataGridSelectionChanged { get; set; }
        public ICommand GrupoVehiculoCommand
        {
            get
            {
                return grupovehiculocommand;
            }
            set { grupovehiculocommand = value; }
        }
        #endregion

        private DataTable CopyToTable(GenericObservableCollection obs)
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Codigo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Definicion", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Acriss", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Modelo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("TipoVehiculoCodigo", typeof(char)));

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

        private DataTable InitDataLayerSync()
        {
            DataTable table = new DataTable();
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs =  GetValuesFromDBGeneric.GetValuesFromDB(EOpcion.rbtnGruposVehiculos, sql);
            table = CopyToTable(obs);
            return table;
        }

        private async Task<DataTable> InitDataLayer()
        {
            // FIXME: move all this to DataMapper.
            DataTable table = new DataTable();
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs = await Task.Run(() => GetValuesFromDBGeneric.GetValuesFromDB(EOpcion.rbtnGruposVehiculos, sql));
            table = CopyToTable(obs);
            return table;
        }
        #region Métodos
        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        private void GrupoVehiculo(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
         //   this.DataGridSelectionChanged = new DelegateCommand<object>(OnSelectionChanged);

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