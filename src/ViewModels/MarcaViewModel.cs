using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KarveCar.Commands.MaestrosCommand;
using KarveCar.Model.Generic;
using KarveCar.Model.SQL;
using KarveCar.Properties;
using KarveCar.Utility;
using KarveCar.View;
using KarveCommon.Generic;
using KarveCommon.Logic.Generic;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveCar.ViewModels
{
    public class MarcaViewModel : BindableBase
    {
        #region Propiedades
        private MarcaUserControl thisusercontrol;        
        private string codigoselecteditem = string.Empty;
        private RecopilatorioEnumerations.EControlCambio statuscontrolcambio = RecopilatorioEnumerations.EControlCambio.Update;

        private DataTable marcadatatable;
        public DataTable MarcaDataTable
        {
            get { return marcadatatable; }
            set
            {
                marcadatatable = value;
                RaisePropertyChanged("MarcaDataTable");
            }
        }

        private Task<DataTable> marcadatatabletask;
        public Task<DataTable> MarcaDataTableTask
        {
            get { return marcadatatabletask; }
            set
            {
                marcadatatabletask = value;
                RaisePropertyChanged("MarcaDataTableTask");
            }
        }

        private MarcaDataObject MarcaSelectedItemOld;

        private MarcaDataObject marcaselecteditem;
        public MarcaDataObject MarcaSelectedItem
        {
            get { return marcaselecteditem; }
            set
            {
                marcaselecteditem = value;
                RaisePropertyChanged("MarcaSelectedItem");
            }
        }

        private DataTable proveedormarcadatatable;
        public DataTable ProveedorMarcaDataTable
        {
            get { return proveedormarcadatatable; }
            set
            {
                proveedormarcadatatable = value;
                RaisePropertyChanged("ProveedorMarcaDataTable");
            }
        }

        private Task<DataTable> proveedormarcadatatabletask;
        public Task<DataTable> ProveedorMarcaDataTableTask
        {
            get { return proveedormarcadatatabletask; }
            set
            {
                proveedormarcadatatabletask = value;
                RaisePropertyChanged("ProveedorMarcaDataTableTask");
            }
        }
        #endregion

        #region Constructor
        public MarcaViewModel()
        {
            this.marcacommand = new MarcaCommand(this); //new DelegateCommand<object>(Marca);
        }
        #endregion

        #region Commands
        private ICommand marcacommand;
        public ICommand MarcaCommand
        {
            get { return marcacommand; }
            set { marcacommand = value; }
        }

        public ICommand InsertMarcaCommand { get; set; }
        public ICommand UpdateMarcaCommand { get; set; }
        public ICommand DeleteMarcaCommand { get; set; }
        public ICommand CancelMarcaCommand { get; set; }
        public ICommand SaveMarcaCommand { get; set; }
        public ICommand ShowMarcaUserControlCommand { get; set; }
        public ICommand MarcaSelectionChanged { get; set; }
        public ICommand CodigoMarcaLostFocus { get; set; }

        public ICommand ProveedorMarcaSelectionChanged { get; set; }
        public ICommand CodigoProveedorMarcaLostFocus { get; set; }
        #endregion

        #region InitDataLayer
        private DataTable InitDataLayerMarcaSync()
        {
            string sql = string.Format(ScriptsSQL.SELECT_MARCA);
            GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(RecopilatorioEnumerations.EOpcion.rbtnMarcas, sql);
            return ManageDataTable.ConvertObsCollectionToDataTable<MarcaDataObject>(obs); //CopyToTable(obs);
            //return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerMarcaAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_MARCA);
            GenericObservableCollection obs = await Task.Run(() => ManageDBGeneric.GetValuesFromDBObsCollection(RecopilatorioEnumerations.EOpcion.rbtnMarcas, sql));
            return ManageDataTable.ConvertObsCollectionToDataTable<MarcaDataObject>(obs); //CopyToTable(obs);
            //return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(sql));
        }
        // TODO: fix the marca view.

        private DataTable InitDataLayerProveedorSync()
        {
            string sql = string.Format(ScriptsSQL.SELECT_PROVEEDOR_MARCA);
            GenericObservableCollection obs = ManageDBGeneric.GetValuesFromDBObsCollection(RecopilatorioEnumerations.EOpcion.rbtnProveedores, sql);
            return new DataTable();
                //ManageDataTable.ConvertObsCollectionToDataTable<SupplierDataObject>(obs); //CopyToTable(obs);
            //return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerProveedorAsync()
        {
            // FIXME: move all this to DataMapper.
            string sql = string.Format(ScriptsSQL.SELECT_PROVEEDOR_MARCA);
            GenericObservableCollection obs = await Task.Run(() => ManageDBGeneric.GetValuesFromDBObsCollection(RecopilatorioEnumerations.EOpcion.rbtnProveedores, sql));
            return new DataTable(); 
                //ManageDataTable.ConvertObsCollectionToDataTable<SupplierDataObject>(obs); //CopyToTable(obs);
            //return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(sql));
        }
        #endregion

        #region EventTriggers
        private void OnMarcaSelectionChanged(object dataRowView)
        {
            DataRowView rowView = dataRowView as DataRowView;
            if (rowView != null)
            {
                this.MarcaSelectedItem = ManageDataTable.ConvertDataRowViewToObject<MarcaDataObject>(rowView);
                this.MarcaSelectedItemOld = (MarcaDataObject)ManageGenericObject.CloneObject(this.MarcaSelectedItem);
                this.codigoselecteditem = this.thisusercontrol.txtCodigo.Text;
                this.thisusercontrol.txtCodigo.IsReadOnly = true;
            }
            else
            {
                this.MarcaSelectedItem = null;
                this.MarcaSelectedItemOld = null;
                this.codigoselecteditem = null;
                this.thisusercontrol.txtCodigo.IsReadOnly = false;
            }
            this.statuscontrolcambio = RecopilatorioEnumerations.EControlCambio.Update;
            this.thisusercontrol.gridsplitter.Visibility = Visibility.Visible;
            this.thisusercontrol.wrpMarca.Visibility = Visibility.Visible;
        }

        private void OnCodigoMarcaLostFocus(object text)
        {
            if (text != null)
            {
                this.thisusercontrol.txtCodigo.IsReadOnly = statuscontrolcambio == RecopilatorioEnumerations.EControlCambio.Update ? true : false;
                if (this.statuscontrolcambio == RecopilatorioEnumerations.EControlCambio.Update)
                {
                    string codigo = (text as string).Replace(" ", string.Empty);
                    OnMarcaSelectionChanged(ManageDataTable.FindDataRowViewInDataTableByString(codigo, this.MarcaDataTable, "Codigo"));                    
                }
            }
        }

        private void OnProveedorMarcaSelectionChanged(object dataRowView)
        {
            if (this.MarcaSelectedItem == null)
            {
                this.MarcaSelectedItem = new MarcaDataObject();
            }
            /*
            if (dataRowView != null)
            {
                DataRowView rowView = dataRowView as DataRowView;
                SupplierDataObject proveedor = ManageDataTable.ConvertDataRowViewToObject<SupplierDataObject>(rowView);
                if (proveedor != null)
                {
                    this.MarcaSelectedItem.ProveedorCodigo = proveedor.Code;
                    this.MarcaSelectedItem.ProveedorDescripcion = proveedor.Name;
                }
            }
            else
            {
                this.MarcaSelectedItem.ProveedorCodigo = null;
                this.MarcaSelectedItem.ProveedorDescripcion = null;
            }*/

        }

        private void OnCodigoProveedorMarcaLostFocus(object text)
        {
            if (text != null)
            {
                string codigo = text as string;
                OnProveedorMarcaSelectionChanged(ManageDataTable.FindDataRowViewInDataTableByString(codigo, this.ProveedorMarcaDataTable, "Code"));
            }
        }
        #endregion

        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        public void Marca(object parameter)
        {
            RecopilatorioEnumerations.EOpcion opcion = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                if (!RecopilatorioCollections.tabitemdictionary.ContainsKey(opcion))
                {                    
                    this.InsertMarcaCommand = new DelegateCommand<object>(InsertMarca);
                    this.UpdateMarcaCommand = new DelegateCommand<object>(UpdateMarca);
                    this.DeleteMarcaCommand = new DelegateCommand<object>(DeleteMarca);
                    this.CancelMarcaCommand = new DelegateCommand<object>(CancelMarca);
                    this.SaveMarcaCommand = new DelegateCommand<object>(SaveMarca);
                    this.ShowMarcaUserControlCommand = new DelegateCommand<object>(ShowMarcaUserControl);
                    this.MarcaSelectionChanged = new DelegateCommand<object>(OnMarcaSelectionChanged);
                    this.CodigoMarcaLostFocus = new DelegateCommand<object>(OnCodigoMarcaLostFocus);

                    this.ProveedorMarcaSelectionChanged = new DelegateCommand<object>(OnProveedorMarcaSelectionChanged);
                    this.CodigoProveedorMarcaLostFocus = new DelegateCommand<object>(OnCodigoProveedorMarcaLostFocus);

                    this.thisusercontrol = new MarcaUserControl();
                    // FIXME: this is a sign of a bad code organization. The use of region prevent all this.        
                    this.thisusercontrol.marcaDataGridUC.dtgrMarcaDataGrid.Items.Clear();
                    TabItemLogic.CreateTabItemUserControl(opcion, this.thisusercontrol);
                    this.MarcaDataTable = InitDataLayerMarcaSync(); //InitDataLayerMarcaAsync();
                    this.ProveedorMarcaDataTable = InitDataLayerProveedorSync();  //InitDataLayerProveedorAsync();
                    UpdateMarca(null);
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    RecopilatorioCollections.tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.TabItem.Focus();
                }
            }
        }

        #region CRUD logic
        private void InsertMarca(object obj)
        {
            EmptyScreen(RecopilatorioEnumerations.EControlCambio.Insert);
        }

        private void UpdateMarca(object obj)
        {
            EmptyScreen(RecopilatorioEnumerations.EControlCambio.Update);
        }

        private void CancelMarca(object obj)
        {
            if (this.statuscontrolcambio == RecopilatorioEnumerations.EControlCambio.Insert)
            {
                InsertMarca(null);
            }
            else if (this.statuscontrolcambio == RecopilatorioEnumerations.EControlCambio.Update && this.MarcaSelectedItem == null)
            {
                UpdateMarca(null);
            }
            else
            {
                this.MarcaSelectedItem = (MarcaDataObject)ManageGenericObject.CloneObject(this.MarcaSelectedItemOld);
            }
        }

        private void DeleteMarca(object obj)
        {
            if (!this.thisusercontrol.txtCodigo.Text.Equals(string.Empty))
            {
                switch (statuscontrolcambio)
                {
                    case RecopilatorioEnumerations.EControlCambio.Insert:
                        InsertMarca(null);
                        break;
                    case RecopilatorioEnumerations.EControlCambio.Update:
                        if (MessageBox.Show(Resources.msgEliminarRegistro, Resources.msgEliminarRegistroTitulo,
                                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (Delete(this.codigoselecteditem) == 0)
                            {
                                MessageBox.Show("NO se ha eliminado el registro");
                            }
                            else
                            {
                                this.MarcaDataTable = InitDataLayerMarcaSync(); //InitDataLayerMarcaAsync();
                                UpdateMarca(null);
                            }
                        }
                        else
                        {
                            this.thisusercontrol.txtCodigo.IsReadOnly = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void SaveMarca(object obj)
        {
            switch (statuscontrolcambio)
            {
                case RecopilatorioEnumerations.EControlCambio.Insert:
                    this.codigoselecteditem = this.thisusercontrol.txtCodigo.Text;
                    DataRowView datarowview = ManageDataTable.FindDataRowViewInDataTableByString(this.codigoselecteditem, this.MarcaDataTable, "Codigo");

                    if (!ManageGenericObject.CheckCodigo(this.codigoselecteditem, datarowview))
                    {
                        if (Insert(this.MarcaSelectedItem) == 0)
                        {
                            MessageBox.Show("NO se ha insertado el registro");
                        }
                        else
                        {
                            this.MarcaSelectedItemOld = (MarcaDataObject)ManageGenericObject.CloneObject(this.MarcaSelectedItem);
                            SaveLogic();
                            this.thisusercontrol.txtCodigo.IsReadOnly = true;
                        }
                    }
                    else
                    {
                        this.thisusercontrol.txtCodigo.Focus();
                    }
                    break;
                case RecopilatorioEnumerations.EControlCambio.Update:
                    if (this.MarcaSelectedItem != null)
                    {
                        if (Update(this.MarcaSelectedItem) == 0)
                        {
                            MessageBox.Show("NO se ha modificado el registro");
                        }
                        else
                        {
                            SaveLogic();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void SaveLogic()
        {
            string codigo = this.MarcaSelectedItem.Codigo; //this.thisusercontrol.txtCodigo.Text;
            this.MarcaDataTable = InitDataLayerMarcaSync(); //InitDataLayerMarcaAsync();
            OnCodigoMarcaLostFocus(codigo);
            this.statuscontrolcambio = RecopilatorioEnumerations.EControlCambio.Update;
        }

        private void EmptyScreen(RecopilatorioEnumerations.EControlCambio controlcambio)
        {
            this.statuscontrolcambio = controlcambio;
            this.MarcaSelectedItem = new MarcaDataObject();
                //(controlcambio == EControlCambio.Insert) ? new MarcaDataObject() : new MarcaDataObject();//null;
            this.MarcaSelectedItemOld = null;
            this.codigoselecteditem = null;
            this.thisusercontrol.txtCodigo.IsReadOnly = false;
            if (!this.thisusercontrol.txtCodigo.IsFocused)
            {
                this.thisusercontrol.txtCodigo.Focus(); 
            }
        }
        #endregion

        #region CRUD sql
        private int Insert(MarcaDataObject obj)
        {
            obj.Codigo = this.codigoselecteditem;
            string fechabaja = ManageGenericObject.GetDateTimeToString(obj.FechaBaja);
            string fechamarca = ManageGenericObject.GetDateTimeToString(obj.FechaMarca);

            string sql = string.Format(ScriptsSQL.INSERT_MARCA, obj.Codigo, ManageGenericObject.GetUsuario(), ManageGenericObject.GetUltModi(),
                                                                obj.Definicion, fechabaja, obj.ProveedorCodigo, obj.Condiciones, 
                                                                obj.Pactadas, obj.Interlocutor, fechamarca, obj.Observaciones);

            return ManageDBGeneric.CRUDRegister(sql);
        }

        private int Update(MarcaDataObject obj)
        {
            string fechabaja = ManageGenericObject.GetDateTimeToString(obj.FechaBaja);
            string fechamarca = ManageGenericObject.GetDateTimeToString(obj.FechaMarca);

            string sql = string.Format(ScriptsSQL.UPDATE_MARCA, ManageGenericObject.GetUsuario(), ManageGenericObject.GetUltModi(), 
                                                                obj.Definicion, fechabaja, obj.ProveedorCodigo, obj.Condiciones, 
                                                                obj.Pactadas, obj.Interlocutor, fechamarca, obj.Observaciones, this.codigoselecteditem);

            return ManageDBGeneric.CRUDRegister(sql);
        }

        private int Delete(string codigo)
        {
            string sql = string.Format(ScriptsSQL.DELETE_MARCA, codigo);

            return ManageDBGeneric.CRUDRegister(sql);
        }
        #endregion

        #region Show Usercontrols   
        /// <summary>
        /// Hace visible/hidden el GridSplitter, MarcaUserControl y ProveedorUserControl según el param
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowMarcaUserControl(object parameter)
        {
            switch (parameter.ToString())
            {
                case "marcaDataGridUserControl":
                    this.thisusercontrol.marcaDataGrid.Visibility = Visibility.Visible;
                    this.thisusercontrol.proveedorMarcaDataGrid.Visibility = Visibility.Hidden;
                    break;
                case "proveedorMarcaDataGridUserControl":
                    this.thisusercontrol.proveedorMarcaDataGrid.Visibility = Visibility.Visible;
                    this.thisusercontrol.marcaDataGrid.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}