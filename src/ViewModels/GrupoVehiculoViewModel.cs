using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KarveCar.Commands.MaestrosCommand;
using KarveCar.Model.Generic;
using KarveCar.Model.SQL;
using KarveCar.Utility;
using KarveCar.View;
using KarveCar.Views;
using KarveCommon.Generic;
using KarveCommon.Logic.Generic;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;


namespace KarveCar.ViewModels
{
    public class GrupoVehiculoViewModel : BindableBase
    {

        #region Propiedades
        private GrupoVehiculoUserControl thisusercontrol;
        private IDataServices _dataServices;
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

        private Task<DataTable> grupovehiculodatatabletask;
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

        private Task<DataTable> tipovehiculodatatabletask;
        public Task<DataTable> TipoVehiculoDataTableTask
        {
            get { return tipovehiculodatatabletask; }
            set
            {
                tipovehiculodatatabletask = value;
                RaisePropertyChanged("TipoVehiculoDataTableTask");
            }
        }

        private DataTable preciopordefectodatatable;
        public DataTable PrecioPorDefectoDataTable
        {
            get { return preciopordefectodatatable; }
            set
            {
                preciopordefectodatatable = value;
                RaisePropertyChanged("PrecioPorDefectoDataTable");
            }
        }

        private Task<DataTable> preciopordefectodatatabletask;
        public Task<DataTable> PrecioPorDefectoDataTableTask
        {
            get { return preciopordefectodatatabletask; }
            set
            {
                preciopordefectodatatabletask = value;
                RaisePropertyChanged("PrecioPorDefectoDataTableTask");
            }
        }
        #endregion

        #region Constructor

        public GrupoVehiculoViewModel()
        {
            /* in this case the injection doesnt work because the view model is not injected in the container*/

            this.grupovehiculocommand = new GrupoVehiculoCommand(this);
        }

        #endregion

        #region Commands
        private ICommand grupovehiculocommand;
        private IVehicleDataServices _vehiculosDataServices;

        public ICommand GrupoVehiculoCommand
        {
            get { return grupovehiculocommand; }
            set { grupovehiculocommand = value; }
        }

        public ICommand ShowGrupoVehiculoUserControlCommand { get; set; }
        public ICommand GrupoVehiculoSelectionChanged { get; set; }
        public ICommand CodigoGrupoVehiculoLostFocus { get; set; }

        public ICommand TipoVehiculoSelectionChanged { get; set; }
        public ICommand CodigoTipoVehiculoLostFocus { get; set; }
        #endregion

        #region InitDataLayer
        private DataTable InitDataLayerGrupoVehiculoSync()
        {            
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
           GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnGruposVehiculos, sql);
            return ManageDataTable.ConvertObsCollectionToDataTable<GrupoVehiculoDataObject>(obs); //CopyToTable(obs);
            //return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerGrupoVehiculoAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_GRUPO_VEHICULO);
            GenericObservableCollection obs = await Task.Run(() => ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnGruposVehiculos, sql));
            return ManageDataTable.ConvertObsCollectionToDataTable<GrupoVehiculoDataObject>(obs); //CopyToTable(obs);
            //return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(sql));
        }

        private DataTable InitDataLayerTipoVehiculoSync()
        {
            string sql = string.Format(ScriptsSQL.SELECT_TIPO_VEHICULO);
            GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnTiposVehiculos, sql);
            return ManageDataTable.ConvertObsCollectionToDataTable<TipoVehiculo>(obs); //CopyToTable(obs);
            //return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerTipoVehiculoAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_TIPO_VEHICULO);
            GenericObservableCollection obs = await Task.Run(() => ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnTiposVehiculos, sql));
            return ManageDataTable.ConvertObsCollectionToDataTable<TipoVehiculo>(obs); //CopyToTable(obs);
            //return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(sql));
        }

        private void InitDataLayerPrecioPorDefectoSync(string codigoGrupoVehiculo)
        {
            string sql = string.Format(ScriptsSQL.SELECT_PRECIO_POR_DEFECTO, codigoGrupoVehiculo);
            GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnGrupoVehiculoPrecioPorDefecto, sql);
            this.PrecioPorDefectoDataTable = ManageDataTable.ConvertObsCollectionToDataTable<GrupoVehiculoPrecioPorDefectoDataObject>(obs);
            ShowPrecioPorDefecto(obs.GenericObsCollection.Count);
        }

        private void InitDataLayerPrecioPorDefectoAsync(string codigoGrupoVehiculo)
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_PRECIO_POR_DEFECTO, codigoGrupoVehiculo);
            GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(Enumerations.EOpcion.rbtnGrupoVehiculoPrecioPorDefecto, sql);
            //this.preciopordefectodatatabletask = ManageGenericObject.ConvertObsCollectionToDataTable<GrupoVehiculoPrecioPorDefectoDataObject>(obs);
        }
        #endregion

        #region EventTriggers
        private void OnCodigoGrupoVehiculoLostFocus(object text)
        {
            if (text != null)
            {
                string codigo = text as string;
                DataRowView dataRowView = null;
                foreach (DataRowView tempRowView in this.GrupoVehiculoDataTable.DefaultView)
                {
                    if (tempRowView.Row.Field<string>("Code").ToLower() == codigo.ToLower())
                    {
                        dataRowView = tempRowView;
                        break;
                    }
                }                
                OnGrupoVehiculoSelectionChanged(dataRowView);
            }
        }

        private void OnGrupoVehiculoSelectionChanged(object dataRowView)
        {
            if (dataRowView != null)
            {
                DataRowView rowView = dataRowView as DataRowView;
               // this.GrupoVehiculoSelectedItem = ManageDataTable.ConvertDataRowViewToObject<GrupoVehiculoDataObject>(rowView);
                InitDataLayerPrecioPorDefectoSync(this.GrupoVehiculoSelectedItem.Codigo);
                this.thisusercontrol.gridsplitter.Visibility = Visibility.Visible;
                this.thisusercontrol.wrpGruposVehiculo.Visibility = Visibility.Visible;
            }
        }

        private void OnCodigoTipoVehiculoLostFocus(object text)
        {
            if (text != null)
            {
                string codigo = text as string;
                DataRowView dataRowView = null;
                foreach (DataRowView tempRowView in this.TipoVehiculoDataTable.DefaultView)
                {
                    if (tempRowView.Row.Field<string>("Code").ToLower() == codigo.ToLower())
                    {
                        dataRowView = tempRowView;
                        break;
                    }
                }
                OnTipoVehiculoSelectionChanged(dataRowView);
            }
        }

        private void OnTipoVehiculoSelectionChanged(object dataRowView)
        {              
            /*
            if (dataRowView != null)
            {
                DataRowView rowView = dataRowView as DataRowView;
                TipoVehiculo tipovehiculo = null;
               // TipoVehiculo tipovehiculo = ManageDataTable.ConvertDataRowViewToObject<TipoVehiculo>(rowView);
                if (tipovehiculo != null)
                {
                    if (this.GrupoVehiculoSelectedItem == null)
                    {
                        this.GrupoVehiculoSelectedItem = new GrupoVehiculoDataObject();
                    }
                    this.GrupoVehiculoSelectedItem.TipoVehiculoCodigo = tipovehiculo.Code;//tipo.Code[0];
                    this.GrupoVehiculoSelectedItem.TipoVehiculoDescripcion = tipovehiculo.Definicion;
                }
            }*/

        }
        #endregion

        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        public void GrupoVehiculo(object parameter)
        {
             MainWindow mainWindow = Application.Current.MainWindow as Views.MainWindow;
             IUnityContainer container = mainWindow.UnityContainer;
            // The data services interface is the data services related to the data access layer
            this._dataServices = container.Resolve<IDataServices>();

            Enumerations.EOpcion opcion = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;          
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                if (!RecopilatorioCollections.tabitemdictionary.ContainsKey(opcion))
                {
                    this.ShowGrupoVehiculoUserControlCommand = new DelegateCommand<object>(ShowGrupoVehiculoUserControl);
                    this.GrupoVehiculoSelectionChanged = new DelegateCommand<object>(OnGrupoVehiculoSelectionChanged);
                    this.CodigoGrupoVehiculoLostFocus = new DelegateCommand<object>(OnCodigoGrupoVehiculoLostFocus);

                    this.TipoVehiculoSelectionChanged = new DelegateCommand<object>(OnTipoVehiculoSelectionChanged);
                    this.CodigoTipoVehiculoLostFocus = new DelegateCommand<object>(OnCodigoTipoVehiculoLostFocus);

                    thisusercontrol = new GrupoVehiculoUserControl();
                    // FIXME: this is a sign of a bad code organization. The use of region prevent all this.        
                    thisusercontrol.grupoVehiculoDataGridUC.dtgrGruposVehiculos.Items.Clear();
                    //obj.grupoVehiculoDataGridUC.DataContext = this;
                    TabItemLogic.CreateTabItemUserControl(opcion, thisusercontrol);
                    this.GrupoVehiculoDataTable = InitDataLayerGrupoVehiculoSync(); //InitDataLayerGrupoVehiculoAsync();
                    this.TipoVehiculoDataTable  = InitDataLayerTipoVehiculoSync();  //InitDataLayerTipoVehiculoAsync();
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    RecopilatorioCollections.tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.TabItem.Focus();
                }
            }
        }

        #region Show Usercontrols and DataGrid PreciosPorDefecto        
        /// <summary>
        /// Hace visible/hidden el GridSplitter, GrupoVehiculoUserControl y TipoVehiculoUserControl según el param
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowGrupoVehiculoUserControl(object parameter)
        {
            switch (parameter.ToString())
            {
                case "grupoVehiculoUserControl":
                    this.thisusercontrol.grupoVehiculoDataGrid.Visibility = Visibility.Visible;
                  //  this.thisusercontrol.tipoVehiculoDataGrid.Visibility = Visibility.Hidden;
                    break;
                case "tipoVehiculoUserControl":
                   // this.thisusercontrol.tipoVehiculoDataGrid.Visibility = Visibility.Visible;
                    this.thisusercontrol.grupoVehiculoDataGrid.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Dependiendo de los valores devueltos según el Code de TipoVehiculo, hace visible o hidden el DataGrid PreciosPorDefecto
        /// </summary>
        /// <param name="codigoGrupoVehiculo"></param>
        private void ShowPrecioPorDefecto(int codigoGrupoVehiculo)
        {
            this.thisusercontrol.grbPreciosPorDefecto.Visibility = codigoGrupoVehiculo == 0 ? Visibility.Hidden : Visibility.Visible;
        }
        #endregion
    }
}