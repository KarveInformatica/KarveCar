using KarveCar.Commands.MaestrosCommand;
using KarveCar.Model.SQL;
using KarveCar.Properties;
using KarveCar.Utility;
using KarveCar.View;
using KarveCommon.Generic;
using KarveCommon.Logic.Generic;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MarcaDataTableViewModel : BindableBase
    {
        #region Propiedades
        private MarcaDataTableUserControl thisusercontrol;
        private EControlCambio statuscontrolcambio = EControlCambio.Update;
        private string codigoselecteditem = string.Empty;

        private Tuple<ETopDistinct, int, int> topClause = Tuple.Create(ETopDistinct.TOP, 25, 1);
        private string sqlCRUD;
        private List<string> columnsSqlCRUD;
        private List<string> columnsMarca     = new List<string>() { "MAR.CODIGO, MAR.NOMBRE" };
        private List<string> columnsProveedor = new List<string>() { "PRO.NUM_PROVEE, PRO.NOMBRE" };

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

        private DataRowView marcaselecteditem;
        public DataRowView MarcaSelectedItem
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

        private DataRowView proveedormarcaselecteditem;
        public DataRowView ProveedorMarcaSelectedItem
        {
            get { return proveedormarcaselecteditem; }
            set
            {
                proveedormarcaselecteditem = value;
                RaisePropertyChanged("ProveedorMarcaSelectedItem");
            }
        }
        #endregion

        #region Constructor
        public MarcaDataTableViewModel()
        {
            this.marcacommand = new MarcaDataTableCommand(this);
        }
        #endregion

        #region Commands
        private ICommand marcacommand;
        public ICommand MarcaDataTableCommand
        {
            get { return marcacommand; }
            set { marcacommand = value; }
        }

        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand ShowMarcaUserControlCommand { get; set; }
        public ICommand MarcaSelectionChanged { get; set; }
        public ICommand CodigoMarcaLostFocus { get; set; }

        public ICommand ProveedorMarcaSelectionChanged { get; set; }
        public ICommand CodigoProveedorMarcaLostFocus { get; set; }
        #endregion

        #region EventTriggers
        private void OnMarcaSelectionChanged(object row)
        {
            DataRowView datarowview = row as DataRowView;
            if (datarowview != null)
            {
                this.thisusercontrol.txtCodigo.IsReadOnly = (statuscontrolcambio == EControlCambio.Update) ? true : false;

                if (this.statuscontrolcambio == EControlCambio.Update)
                {
                    string codigo = datarowview.Row["CODIGO"].ToString();
                    SelectMarca(codigo);
                }
            }
        }

        private void OnCodigoMarcaLostFocus(object text)
        {
            if (text != null && statuscontrolcambio == EControlCambio.Update)
            {
                this.thisusercontrol.txtCodigo.IsReadOnly = (statuscontrolcambio == EControlCambio.Update) ? true : false;

                if (this.statuscontrolcambio == EControlCambio.Update)
                {
                    string codigo = (text as string).Replace(" ", string.Empty);
                    SelectMarca(codigo);                  
                }
            }
        }

        private void OnProveedorMarcaSelectionChanged(object row)
        {
            if (this.MarcaSelectedItem != null || this.statuscontrolcambio == EControlCambio.Insert)
            {
                DataRowView datarowview = row as DataRowView;
                if (datarowview != null)
                {
                    string codigo = datarowview.Row["NUM_PROVEE"].ToString();
                    SelectProveedorMarca(codigo);
                }
            }
        }

        private void OnCodigoProveedorMarcaLostFocus(object text)
        {
            if (this.MarcaSelectedItem != null || this.statuscontrolcambio == EControlCambio.Insert)
            {
                if (text != null)
                {
                    string codigo = (text as string).Replace(" ", string.Empty);
                    SelectProveedorMarca(codigo);
                }
            }
            else
            {
                this.MarcaSelectedItem = null;
            }
        }
        #endregion

        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos. Se cargan los datos de la BBDD en el GenericObsCollection del tabitemdictionary
        /// </summary>
        /// <param name="parameter"></param>
        public void Marca(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                if (!tabitemdictionary.ContainsKey(opcion))
                {
                    this.InsertCommand = new DelegateCommand<object>(Insert);
                    this.UpdateCommand = new DelegateCommand<object>(Update);
                    this.DeleteCommand = new DelegateCommand<object>(Delete);
                    this.CancelCommand = new DelegateCommand<object>(Cancel);
                    this.SaveCommand = new DelegateCommand<object>(Save);
                    this.ShowMarcaUserControlCommand = new DelegateCommand<object>(ShowMarcaUserControl);
                    this.MarcaSelectionChanged = new DelegateCommand<object>(OnMarcaSelectionChanged);
                    this.CodigoMarcaLostFocus = new DelegateCommand<object>(OnCodigoMarcaLostFocus);

                    this.ProveedorMarcaSelectionChanged = new DelegateCommand<object>(OnProveedorMarcaSelectionChanged);
                    this.CodigoProveedorMarcaLostFocus = new DelegateCommand<object>(OnCodigoProveedorMarcaLostFocus);

                    this.thisusercontrol = new MarcaDataTableUserControl();
                    // FIXME: this is a sign of a bad code organization. The use of region prevent all this.        
                    this.thisusercontrol.marcaDataGridUC.dtgrMarcaDataGrid.Items.Clear();
                    TabItemLogic.CreateTabItemUserControl(opcion, this.thisusercontrol);

                    SelectSqlCRUD();
                    SelectMarcaDataTable();
                    SelectProveedorMarcaDataTable();
                    Update(null);
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.TabItem.Focus();
                }
            }
        }

        #region CRUD logic
        private void Insert(object obj)
        {
            ClearMarca(EControlCambio.Insert);
        }

        private void Update(object obj)
        {
            ClearMarca(EControlCambio.Update);
        }

        private void Cancel(object obj)
        {
            if (this.statuscontrolcambio == EControlCambio.Insert)
            {
                Insert(null);
            }
            else if (this.statuscontrolcambio == EControlCambio.Update && this.MarcaSelectedItem == null)
            {
                Update(null);
            }
            else
            {
                string codigo = this.thisusercontrol.txtCodigo.Text;
                SelectMarca(codigo);
            }
        }

        private void Delete(object obj)
        {
            if (!this.MarcaSelectedItem.Row["CODIGO"].ToString().Equals(string.Empty))
            {
                switch (statuscontrolcambio)
                {
                    case EControlCambio.Insert:
                        Insert(null);
                        break;
                    case EControlCambio.Update:
                        if (MessageBox.Show(Resources.msgEliminarRegistro, Resources.msgEliminarRegistroTitulo,
                                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (DeleteMarca(this.codigoselecteditem) == 0)
                            {
                                MessageBox.Show("NO se ha eliminado el registro");
                            }
                            else
                            {
                                SelectMarcaDataTable();
                                Update(null);
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

        private void Save(object obj)
        {
            switch (statuscontrolcambio)
            {
                case EControlCambio.Insert:
                    DataRowView dataRowView = null;
                    this.codigoselecteditem = this.MarcaSelectedItem.Row["CODIGO"].ToString().Replace(" ", string.Empty);
                    string whereClause = SQLBuilder.SqlBuilderWhereOneRegister(EWhereLogicOperator.WHITESPACE, "MAR.CODIGO",
                                                                               EWhereComparisson.LIKE, ETipoDato.DBstring, codigoselecteditem);
                    DataTable datatable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsSqlCRUD, "MARCAS", "MAR",
                                                                                                               null, whereClause, null));

                    foreach (DataRowView datarowview in datatable.AsDataView())
                    {
                        dataRowView = datarowview;
                    }

                    if (!ManageGenericObject.CheckCodigo(this.codigoselecteditem, dataRowView))
                    {
                        if (InsertMarca(this.MarcaSelectedItem) == 0)
                        {
                            MessageBox.Show("NO se ha insertado el registro");
                        }
                        else
                        {                            
                            SaveLogic();
                            this.thisusercontrol.txtCodigo.IsReadOnly = true;
                        }
                    }
                    else
                    {
                        this.thisusercontrol.txtCodigo.Focus();
                    }
                    break;
                case EControlCambio.Update:
                    if (this.MarcaSelectedItem != null)
                    {
                        if (UpdateMarca(this.MarcaSelectedItem) == 0)
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
            //string codigo = this.MarcaSelectedItem.Codigo; //this.thisusercontrol.txtCodigo.Text;
            //this.MarcaDataTable = LoadMarcaSync(); //LoadMarcaAsync();
            //OnCodigoMarcaLostFocus(codigo);
            this.statuscontrolcambio = EControlCambio.Update;
        }

        private void ClearMarca(EControlCambio controlcambio)
        {
            this.statuscontrolcambio = controlcambio;
            if (controlcambio == EControlCambio.Insert)
            {
                Tuple<ETopDistinct, int, int> topDistinctClause = Tuple.Create(ETopDistinct.TOP, 1, 0);
                DataTable table = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsSqlCRUD, "MARCAS", "MAR",
                                                                                                           topDistinctClause, string.Empty, null));

                DataTable datatable = table.Clone();
                DataRow dataRow = datatable.NewRow();
                datatable.Columns["CODIGO"].AllowDBNull = true;
                datatable.Columns["NOMBRE"].AllowDBNull = true;
                datatable.Rows.Add(dataRow);
                dataRow = datatable.Rows[0];

                this.MarcaSelectedItem = dataRow.Table.DefaultView[dataRow.Table.Rows.IndexOf(dataRow)];
            }
            else
            {
                this.MarcaSelectedItem = null;
            }

            this.codigoselecteditem = null;
            this.thisusercontrol.txtCodigo.IsReadOnly = false;
            this.ProveedorMarcaSelectedItem = null;
            if (!this.thisusercontrol.txtCodigo.IsFocused)
            {
                this.thisusercontrol.txtCodigo.Focus();
            }
        }
        #endregion

        #region CRUD sql
        /// <summary>
        /// Prepara las variables columnsSqlCRUD y sqlCRUD
        /// </summary>
        private void SelectSqlCRUD()
        {
            this.columnsSqlCRUD = SQLBuilder.SqlBuilderColumns<UserControl>(this.thisusercontrol);
            this.sqlCRUD        = SQLBuilder.SqlBuilderSelect(this.columnsSqlCRUD, "MARCAS", "MAR", null, string.Empty, null);
        }

        /// <summary>
        /// Rellena el DataTable MarcaDataTable
        /// </summary>
        private async Task SelectMarcaDataTable()
        {
            string orderbymarca = SQLBuilder.SqlBuilderOrderByOne("MAR.CODIGO", EOrderBy.ASC);
            this.MarcaDataTable = await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsMarca, "MARCAS", "MAR",
                                                                                                                            this.topClause, null, orderbymarca)));
        }

        /// <summary>
        /// Rellena el DataTable ProveedorMarcaDataTable
        /// </summary>
        private async Task SelectProveedorMarcaDataTable()
        {
            string orderbyproveedor = SQLBuilder.SqlBuilderOrderByOne("PRO.NUM_PROVEE", EOrderBy.ASC);
            this.ProveedorMarcaDataTable = await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsProveedor, "PROVEE1", "PRO",
                                                                                                                this.topClause, null, orderbyproveedor)));
        }

        /// <summary>
        /// Recupera la marca y su correspondiente proveedor según el código pasado por params. 
        /// En caso de no existir la marca en la BBDD, limpia la pantalla.
        /// </summary>
        /// <param name="codigo"></param>
        private void SelectMarca(string codigo)
        {
            DataRowView dataRowView = null;
            if (!codigo.Equals(string.Empty))
            {
                string whereClause =  SQLBuilder.SqlBuilderWhereOneRegister(EWhereLogicOperator.WHITESPACE, "MAR.CODIGO",
                                                                            EWhereComparisson.LIKE, ETipoDato.DBstring, codigo);
                DataTable datatable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsSqlCRUD, "MARCAS", "MAR",
                                                                                                           null, whereClause, null));

                foreach (DataRowView datarowview in datatable.AsDataView())
                {
                    dataRowView = datarowview;
                }
            }

            if (dataRowView != null)
            {                    
                this.MarcaSelectedItem = dataRowView;
                this.codigoselecteditem = this.thisusercontrol.txtCodigo.Text;
                this.thisusercontrol.txtCodigo.IsReadOnly = true;
                SelectProveedorMarca(dataRowView.Row.Table.Rows[0]["PROVEE"].ToString());
            }
            else
            {
                this.MarcaSelectedItem = null;
                this.codigoselecteditem = null;
                this.thisusercontrol.txtCodigo.IsReadOnly = false;                
            }
            
            this.statuscontrolcambio = EControlCambio.Update;
            this.thisusercontrol.wrpMarcaDataTable.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Recupera el proveedor según el código pasado por params. 
        /// En caso de no existir el proveedor en la BBDD, vacía el proveedor.
        /// </summary>
        /// <param name="codigo"></param>
        private void SelectProveedorMarca(string codigo)
        {
            DataRowView dataRowView = null;
            if (!codigo.Equals(string.Empty))
            {
                string whereClause = SQLBuilder.SqlBuilderWhereOneRegister(EWhereLogicOperator.WHITESPACE, "PRO.NUM_PROVEE",
                                                                           EWhereComparisson.LIKE, ETipoDato.DBstring, codigo);

                DataTable datatable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(this.columnsProveedor, "PROVEE1", "PRO", 
                                                                                                           this.topClause, whereClause, null));
                foreach (DataRowView datarowview in datatable.AsDataView())
                {
                    dataRowView = datarowview;
                }
            }

            if (dataRowView != null)
            {
                this.ProveedorMarcaSelectedItem = dataRowView;

                this.MarcaSelectedItem.Row.BeginEdit();
                this.MarcaSelectedItem.Row["PROVEE"] = this.ProveedorMarcaSelectedItem.Row["NUM_PROVEE"];
                this.MarcaSelectedItem.Row.EndEdit();
            }
            else
            {
                this.ProveedorMarcaSelectedItem = null;

                this.MarcaSelectedItem.Row.BeginEdit();
                this.MarcaSelectedItem.Row["PROVEE"] = null;
                this.MarcaSelectedItem.Row.EndEdit();                
            }
        }

        private int InsertMarca(DataRowView datarowview)
        {
            //obj.Codigo = this.codigoselecteditem;
            //string fechabaja = ManageGenericObject.GetDateTimeToString(obj.FechaBaja);
            //string fechamarca = ManageGenericObject.GetDateTimeToString(obj.FechaMarca);

            //string sql = string.Format(ScriptsSQL.INSERT_MARCA, obj.Codigo, ManageGenericObject.GetUsuario(), ManageGenericObject.GetUltModi(),
            //                                                    obj.Definicion, fechabaja, obj.ProveedorCodigo, obj.Condiciones,
            //                                                    obj.Pactadas, obj.Interlocutor, fechamarca, obj.Observaciones);
            string sql = string.Empty;
            return ManageDBGeneric.CRUDRegister(sql);
        }

        private int UpdateMarca(DataRowView datarowview)
        {
            //string fechabaja = ManageGenericObject.GetDateTimeToString();
            //string fechamarca = ManageGenericObject.GetDateTimeToString();

            //string sql = string.Format(ScriptsSQL.UPDATE_MARCA, ManageGenericObject.GetUsuario(), ManageGenericObject.GetUltModi(),
            //                                                    datarowview.Row["NOMBRE"], datarowview.Row["FBAJA"], datarowview.Row["PROVEE"],
            //                                                    datarowview.Row["CONDICIONES"], datarowview.Row["PACTADAS"], datarowview.Row["LOCUTOR"],
            //                                                    datarowview.Row["FECHA"], datarowview.Row["OBS"], this.codigoselecteditem);
            string sql = string.Empty;
            return ManageDBGeneric.CRUDRegister(sql);
        }

        private int DeleteMarca(string codigo)
        {
            string sql = string.Format(ScriptsSQL.DELETE_MARCA, codigo);

            return ManageDBGeneric.CRUDRegister(sql);
        }
        #endregion        
        
        #region Show Usercontrols   
        /// <summary>
        /// Hace visible/hidden el MarcaDataTableUserControl y ProveedorUserControl según el param
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
