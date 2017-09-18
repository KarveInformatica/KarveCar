using KarveCar.Commands.MaestrosCommand;
using KarveCar.Model.SQL;
using KarveCar.Properties;
using KarveCar.Utility;
using KarveCar.View;
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
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MarcaDataTableViewModel : BindableBase
    {
        #region Propiedades
        private static MarcaDataTableUserControl thisusercontrol;
        private string codigoselecteditem = string.Empty;
        private EControlCambio statuscontrolcambio = EControlCambio.Update;

        private List<string> columnsMarca;
        private List<string> columnsProveedor = new List<string>() { "PRO.NUM_PROVEE, PRO.NOMBRE" }; //SqlBuilderColumns<UserControl>(thisusercontrol.marcaDataGridUC);
        private Tuple<ETopDistinct, int, int> topClause = Tuple.Create(ETopDistinct.TOP, 25, 1);
        private string sqlCRUD;

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
            List<string> columns = SQLBuilder.SqlBuilderColumns<UserControl>(thisusercontrol.wrpMarcaDataTable);
            string sql = SQLBuilder.SqlBuilderSelect(columns, "MARCAS", "MAR", 
                                                     Tuple.Create(ETopDistinct.TOP, 25, 0), null, 
                                                     new List<Tuple<string, EOrderBy>> { Tuple.Create("MAR.CODIGO", EOrderBy.ASC) });

            return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private DataTable InitDataLayerMarcaByCodigoSync()
        {
            List<string> columns = SQLBuilder.SqlBuilderColumns<UserControl>(thisusercontrol.wrpMarcaDataTable);
            string sql = SQLBuilder.SqlBuilderSelect(columns, "MARCAS", "MAR", null, 
                                                     new List<Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string>>()
                                                    {
                                                         Tuple.Create(EWhereLogicOperator.WHITESPACE, "MAR.CODIGO", EWhereComparisson.LIKE, 
                                                                      ETipoDato.DBstring, thisusercontrol.txtCodigo.Text)                                                        
                                                    }, null);

            return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }

        private async Task<DataTable> InitDataLayerMarcaAsync()
        {
            return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(string.Format(ScriptsSQL.SELECT_MARCA)));
        }

        private DataTable InitDataLayerProveedorSync()
        {
            List<string> columnsProveedor = new List<string>() {"PRO.NUM_PROVEE, PRO.NOMBRE"}; //SqlBuilderColumns<UserControl>(thisusercontrol.marcaDataGridUC);
            Tuple<ETopDistinct, int, int> topDistinctClauseProveedor = Tuple.Create(ETopDistinct.TOP, 25, 0);
            List<Tuple<string, EOrderBy>> orderByClauseProveedor = new List<Tuple<string, EOrderBy>> {Tuple.Create("PRO.NUM_PROVEE", EOrderBy.ASC)};

            string sql = SQLBuilder.SqlBuilderSelect(columnsProveedor, "PROVEE1", "PRO", topDistinctClauseProveedor, null, orderByClauseProveedor);

            return ManageDBGeneric.GetValuesFromDbDataTable(sql);
        }


        private async Task<DataTable> InitDataLayerProveedorAsync()
        {
            return await Task.Run(() => ManageDBGeneric.GetValuesFromDbDataTable(string.Format(ScriptsSQL.SELECT_PROVEEDOR_MARCA)));
        }
        #endregion

        #region EventTriggers
        private void OnMarcaSelectionChanged(object datarowview)
        {
            DataRowView row = datarowview as DataRowView;
            if (row != null)
            {
                this.MarcaSelectedItem = row;
                this.codigoselecteditem = thisusercontrol.txtCodigo.Text;
                thisusercontrol.txtCodigo.IsReadOnly = true;
                OnProveedorMarcaUpdateDefinicion((string)row.Row.Table.Rows[0]["PROVEE"].ToString());
            }
            else
            {
                this.MarcaSelectedItem = null;
                this.codigoselecteditem = null;
                thisusercontrol.txtCodigo.IsReadOnly = false;
            }
            this.statuscontrolcambio = EControlCambio.Update;
            thisusercontrol.wrpMarcaDataTable.Visibility = Visibility.Visible;
        }

        private void OnCodigoMarcaLostFocus(object text)
        {
            if (text != null)
            {
                thisusercontrol.txtCodigo.IsReadOnly = statuscontrolcambio == EControlCambio.Update ? true : false;
                if (this.statuscontrolcambio == EControlCambio.Update)
                {
                    string codigo = (text as string).Replace(" ", string.Empty);
                    string valueText = codigo == string.Empty ? thisusercontrol.txtProveedorCodigo.Text : codigo;
                    string whereClause = SQLBuilder.SqlBuilderWhereOne(EWhereLogicOperator.WHITESPACE, "MAR.CODIGO",
                                                                       EWhereComparisson.LIKE, ETipoDato.DBstring, valueText);
                    DataTable datatable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(
                                                                                   columnsMarca, "MARCAS", "MAR", topClause, whereClause, null));
                    DataRowView dataRowView = null;
                    foreach (DataRowView datarowview in datatable.AsDataView())
                    {
                        dataRowView = datarowview;
                    }
                    OnMarcaSelectionChanged(dataRowView);                    
                }
            }
        }

        private void OnProveedorMarcaUpdateDefinicion(string text)
        {
            string valueText = text == string.Empty || text == null ? thisusercontrol.txtProveedorCodigo.Text : text;
            string whereClause = SQLBuilder.SqlBuilderWhereOne(EWhereLogicOperator.WHITESPACE, "PRO.NUM_PROVEE",
                                                               EWhereComparisson.LIKE, ETipoDato.DBstring, valueText);

            DataTable datatable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(columnsProveedor, "PROVEE1", "PRO", topClause, whereClause, null));
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRowView datarow in datatable.AsDataView())
                {
                    this.ProveedorMarcaSelectedItem = datarow;
                }                
            }
            else
            {                
                this.ProveedorMarcaSelectedItem = null;

                this.MarcaSelectedItem.Row.BeginEdit();
                this.MarcaSelectedItem.Row["PROVEE"] = null;
                this.MarcaSelectedItem.Row.EndEdit();
            }
        }

        private void OnProveedorMarcaSelectionChanged(object datarowview)
        {
            if (this.MarcaSelectedItem != null)
            {
                DataRowView row = datarowview as DataRowView;
                if (row != null)
                {
                    this.ProveedorMarcaSelectedItem = row;   
                                     
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
        }

        private void OnCodigoProveedorMarcaLostFocus(object text)
        {
            if (text != null)
            {
                OnProveedorMarcaUpdateDefinicion(text.ToString());
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

                    thisusercontrol = new MarcaDataTableUserControl();;
                    // FIXME: this is a sign of a bad code organization. The use of region prevent all this.        
                    thisusercontrol.marcaDataGridUC.dtgrMarcaDataGrid.Items.Clear();
                    TabItemLogic.CreateTabItemUserControl(opcion, thisusercontrol);


                    columnsMarca = SQLBuilder.SqlBuilderColumns<UserControl>(thisusercontrol);
                    string orderbymarca = SQLBuilder.SqlBuilderOrderByOne("MAR.CODIGO", EOrderBy.ASC);
                    this.sqlCRUD = SQLBuilder.SqlBuilderSelect(columnsMarca, "MARCAS", "MAR", null, string.Empty, null);
                    this.MarcaDataTable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(
                                                                                   columnsMarca, "MARCAS", "MAR", topClause, null, orderbymarca));

                    string orderbyproveedor = SQLBuilder.SqlBuilderOrderByOne("PRO.NUM_PROVEE", EOrderBy.ASC);
                    this.ProveedorMarcaDataTable = ManageDBGeneric.GetValuesFromDbDataTable(SQLBuilder.SqlBuilderSelect(
                                                                                            columnsProveedor, "PROVEE1", "PRO", topClause, null, orderbyproveedor));
                    UpdateMarca(null);
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.TabItem.Focus();
                }
            }
        }

        #region CRUD logic
        private void InsertMarca(object obj)
        {
            EmptyScreen(EControlCambio.Insert);
        }

        private void UpdateMarca(object obj)
        {
            EmptyScreen(EControlCambio.Update);
        }

        private void CancelMarca(object obj)
        {
            if (this.statuscontrolcambio == EControlCambio.Insert)
            {
                InsertMarca(null);
            }
            else if (this.statuscontrolcambio == EControlCambio.Update && this.MarcaSelectedItem == null)
            {
                UpdateMarca(null);
            }
            else
            {
                string codigo = thisusercontrol.txtCodigo.Text;
                OnMarcaSelectionChanged(ManageDataTable.FindDataRowViewInDataTableByString(codigo, this.MarcaDataTable, "CODIGO"));
            }
        }

        private void DeleteMarca(object obj)
        {
            if (!thisusercontrol.txtCodigo.Text.Equals(string.Empty))
            {
                switch (statuscontrolcambio)
                {
                    case EControlCambio.Insert:
                        InsertMarca(null);
                        break;
                    case EControlCambio.Update:
                        if (MessageBox.Show(Resources.msgEliminarRegistro, Resources.msgEliminarRegistroTitulo,
                                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (Delete(this.codigoselecteditem) == 0)
                            {
                                MessageBox.Show("NO se ha eliminado el registro");
                            }
                            else
                            {
                                //this.MarcaDataTable = InitDataLayerMarcaSync(); //InitDataLayerMarcaAsync();
                                UpdateMarca(null);
                            }
                        }
                        else
                        {
                            thisusercontrol.txtCodigo.IsReadOnly = true;
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
                case EControlCambio.Insert:
                    this.codigoselecteditem = thisusercontrol.txtCodigo.Text;
                    DataRowView datarowview = ManageDataTable.FindDataRowViewInDataTableByString(this.codigoselecteditem, this.MarcaDataTable, "Codigo");

                    if (!ManageGenericObject.CheckCodigo(this.codigoselecteditem, datarowview))
                    {
                        if (Insert(this.MarcaSelectedItem) == 0)
                        {
                            MessageBox.Show("NO se ha insertado el registro");
                        }
                        else
                        {
                            //this.MarcaSelectedItemOld = this.MarcaSelectedItem; //(MarcaDataObject)ManageGenericObject.CloneObject(this.MarcaSelectedItem);
                            SaveLogic();
                            thisusercontrol.txtCodigo.IsReadOnly = true;
                        }
                    }
                    else
                    {
                        thisusercontrol.txtCodigo.Focus();
                    }
                    break;
                case EControlCambio.Update:
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
            //string codigo = this.MarcaSelectedItem.Codigo; //thisusercontrol.txtCodigo.Text;
            //this.MarcaDataTable = InitDataLayerMarcaSync(); //InitDataLayerMarcaAsync();
            //OnCodigoMarcaLostFocus(codigo);
            this.statuscontrolcambio = EControlCambio.Update;
        }

        private void EmptyScreen(EControlCambio controlcambio)
        {
            this.statuscontrolcambio = controlcambio;
            this.MarcaSelectedItem = null; //(controlcambio == EControlCambio.Insert) ? new MarcaDataObject() : null;
            //this.MarcaSelectedItemOld = null;
            this.codigoselecteditem = null;
            thisusercontrol.txtCodigo.IsReadOnly = false;
            if (!thisusercontrol.txtCodigo.IsFocused)
            {
                thisusercontrol.txtCodigo.Focus();
            }
        }
        #endregion

        #region CRUD sql
        private int Insert(DataRowView obj)
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

        private int Update(DataRowView row)
        {
            //string fechabaja = ManageGenericObject.GetDateTimeToString();
            //string fechamarca = ManageGenericObject.GetDateTimeToString();

            //string sql = string.Format(ScriptsSQL.UPDATE_MARCA, ManageGenericObject.GetUsuario(), ManageGenericObject.GetUltModi(),
            //                                                    row.Row["NOMBRE"], row.Row["FBAJA"], row.Row["PROVEE"], row.Row["CONDICIONES"],
            //                                                    row.Row["PACTADAS"], row.Row["LOCUTOR"], row.Row["FECHA"], row.Row["OBS"], this.codigoselecteditem);
            string sql = string.Empty;
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
        /// Hace visible/hidden el MarcaDataTableUserControl y ProveedorUserControl según el param
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowMarcaUserControl(object parameter)
        {
            switch (parameter.ToString())
            {
                case "marcaDataGridUserControl":
                    thisusercontrol.marcaDataGrid.Visibility = Visibility.Visible;
                    thisusercontrol.proveedorMarcaDataGrid.Visibility = Visibility.Hidden;
                    break;
                case "proveedorMarcaDataGridUserControl":
                    thisusercontrol.proveedorMarcaDataGrid.Visibility = Visibility.Visible;
                    thisusercontrol.marcaDataGrid.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
