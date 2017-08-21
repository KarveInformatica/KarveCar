using DataAccessLayer.DataObjects;
using KarveCar.Logic.Generic;
using KarveCar.Model.SQL;
using KarveCar.Utility;
using KarveCar.View;
using KarveCommon.Generic;
using Prism.Commands;
using Prism.Mvvm;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class GrupoVehiculoViewModel : BindableBase
    {
        #region Propiedades
        private DataTable grupovehiculodatatable;
        public DataTable GrupoVehiculoDataTable
        {
            get { return grupovehiculodatatable; }
            set
            {
                grupovehiculodatatable = value;
                RaisePropertyChanged("GrupoVehiculoDataTable");
            }
        }

        public Task<DataTable> grupovehiculodatatabletask;
        public Task<DataTable> GrupoVehiculoDataTableTask
        {
            get { return grupovehiculodatatabletask; }
            set
            {
                grupovehiculodatatabletask = value;
                RaisePropertyChanged("GrupoVehiculoDataTableTask");
            }
        }

        private GrupoVehiculoDataObject grupovehiculoselecteditem;
        public GrupoVehiculoDataObject GrupoVehiculoSelectedItem
        {
            get { return grupovehiculoselecteditem; }
            set
            {
                grupovehiculoselecteditem = value;
                RaisePropertyChanged("GrupoVehiculoSelectedItem");
            }
        }

        private DataTable tipovehiculodatatable;
        public DataTable TipoVehiculoDataTable
        {
            get { return tipovehiculodatatable; }
            set
            {
                tipovehiculodatatable = value;
                RaisePropertyChanged("TipoVehiculoDataTable");
            }
        }

        public Task<DataTable> tipovehiculodatatabletask;
        public Task<DataTable> TipoVehiculoDataTableTask
        {
            get { return tipovehiculodatatabletask; }
            set
            {
                tipovehiculodatatabletask = value;
                RaisePropertyChanged("TipoVehiculoDataTableTask");
            }
        }
        #endregion

        #region Delegate - Event        
        private delegate void NotifyOnLoad(DataTable newTable);

        private event NotifyOnLoad notifyOnLoad;
        #endregion

        #region Constructor
        public GrupoVehiculoViewModel()
        {
            this.grupovehiculocommand = new DelegateCommand<object>(GrupoVehiculo);
            this.showgrupovehiculousercontrolcommand = new DelegateCommand<object>(ShowGrupoVehiculoUserControl);
            this.showtipovehiculousercontrolcommand = new DelegateCommand<object>(ShowTipoVehiculoUserControl);
            this.GrupoVehiculoSelectionChanged = new DelegateCommand<object>(OnSelectionChangedGrupoVehiculo);
            this.TipoVehiculoSelectionChanged = new DelegateCommand<object>(OnSelectionChangedTipoVehiculo);
            this.GrupoVehiculoSelectedItem = new GrupoVehiculoDataObject();
            //this.grupovehiculodatatable = InitDataLayerGrupoVehiculoSync();
            //this.grupovehiculodatatabletask = InitDataLayerGrupoVehiculoAsync();
        }
        #endregion

        #region Commands
        public ICommand GrupoVehiculoSelectionChanged { get; set; }
        public ICommand TipoVehiculoSelectionChanged { get; set; }

        private ICommand grupovehiculocommand;
        public ICommand GrupoVehiculoCommand
        {
            get
            {
                return grupovehiculocommand;
            }
            set { grupovehiculocommand = value; }
        }

        private ICommand showgrupovehiculousercontrolcommand;
        public ICommand ShowGrupoVehiculoUserControlCommand
        {
            get
            {
                return showgrupovehiculousercontrolcommand;
            }
            set { showgrupovehiculousercontrolcommand = value; }
        }

        private ICommand showtipovehiculousercontrolcommand;
        public ICommand ShowTipoVehiculoUserControlCommand
        {
            get
            {
                return showtipovehiculousercontrolcommand;
            }
            set { showtipovehiculousercontrolcommand = value; }
        }
        #endregion

        private DataTable CopyToTable(GenericObservableCollection obs)
        { // FIXME: possibly this method can be deleted, it is used generic method instead
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

        private DataTable InitDataLayerGrupoVehiculoSync()
        {            
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs = GetValuesFromDBGeneric.GetValuesFromDBObsCollection(EOpcion.rbtnGruposVehiculos, sql);
            return ManageGenericObject.ObsCollectionToDataTable<GrupoVehiculoDataObject>(obs); //CopyToTable(obs);
            //return GetValuesFromDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerGrupoVehiculoAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs = await Task.Run(() => GetValuesFromDBGeneric.GetValuesFromDBObsCollection(EOpcion.rbtnGruposVehiculos, sql));
            return ManageGenericObject.ObsCollectionToDataTable<GrupoVehiculoDataObject>(obs); //CopyToTable(obs);
            //return await Task.Run(() => GetValuesFromDBGeneric.GetValuesFromDbDataTable(sql));
        }

        private DataTable InitDataLayerTipoVehiculoSync()
        {
            string sql = string.Format(ScriptsSQL.SELECT_TIPO_VEHICULO);
            GenericObservableCollection obs = GetValuesFromDBGeneric.GetValuesFromDBObsCollection(EOpcion.rbtnTiposVehiculos, sql);
            return ManageGenericObject.ObsCollectionToDataTable<TipoVehiculo>(obs); //CopyToTable(obs);
            //return GetValuesFromDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerTipoVehiculoAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_TIPO_VEHICULO);
            GenericObservableCollection obs = await Task.Run(() => GetValuesFromDBGeneric.GetValuesFromDBObsCollection(EOpcion.rbtnTiposVehiculos, sql));
            return ManageGenericObject.ObsCollectionToDataTable<TipoVehiculo>(obs); //CopyToTable(obs);
            //return await Task.Run(() => GetValuesFromDBGeneric.GetValuesFromDbDataTable(sql));
        }

        private void SetTable(DataTable newTable)
        {
            this.GrupoVehiculoDataTable = newTable;
        }

        private void OnSelectionChangedGrupoVehiculo(object dataRowView)
        {
            DataRowView rowView = dataRowView as DataRowView;
            this.GrupoVehiculoSelectedItem = ManageGenericObject.DataRowViewToObject<GrupoVehiculoDataObject>(rowView);
        }

        private void OnSelectionChangedTipoVehiculo(object dataRowView)
        {
            DataRowView rowView = dataRowView as DataRowView;
            TipoVehiculo tipo = ManageGenericObject.DataRowViewToObject<TipoVehiculo>(rowView);
            if (tipo != null)
            {
                this.GrupoVehiculoSelectedItem.TipoVehiculoCodigo = tipo.Codigo[0];
                this.GrupoVehiculoSelectedItem.TipoVehiculoDescripcion = tipo.Definicion;
            }
        }

        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        private void GrupoVehiculo(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;            
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                GrupoVehiculoUserControl obj = new GrupoVehiculoUserControl();
                // FIXME: this is a sign of a bad code organization. The use of region prevent all this.        
                obj.grupoVehiculoDataGridUC.dtgrGruposVehiculos.Items.Clear();
                //obj.grupoVehiculoDataGridUC.DataContext = this;
                TabItemLogic.CreateTabItemUserControl(opcion, obj);
                this.grupovehiculodatatable = InitDataLayerGrupoVehiculoSync();
                this.tipovehiculodatatable = InitDataLayerTipoVehiculoSync();
            }
        }

        public void ShowGrupoVehiculoUserControl(object parameter)
        {
            GrupoVehiculoUserControl obj = parameter as GrupoVehiculoUserControl;
            if (obj != null)
            {
                obj.gridsplitter.Visibility = Visibility.Visible;
                obj.grupoVehiculoDataGrid.Visibility = Visibility.Visible;
                obj.tipoVehiculoDataGrid.Visibility = Visibility.Hidden;
            }
        }
        
        public void ShowTipoVehiculoUserControl(object parameter)
        {
            GrupoVehiculoUserControl obj = parameter as GrupoVehiculoUserControl;
            if (obj != null)
            {
                obj.gridsplitter.Visibility = Visibility.Visible;
                obj.tipoVehiculoDataGrid.Visibility = Visibility.Visible;
                obj.grupoVehiculoDataGrid.Visibility = Visibility.Hidden;
            }
        }
        #endregion
    }
}