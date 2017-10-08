using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KarveControls.DataGrid.DataGridHelpers;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using DataGridTextBoxColumn = KarveControls.DataGrid.DataGridHelpers.DataGridTextBoxColumn;

namespace KarveControls.DataGrid
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;

    public class KarveGridView : RadGridView
    {


            #region "Variables"

        Telerik.WinControls.UI.GridTableElement tbsElement = new Telerik.WinControls.UI.GridTableElement();
 
        protected bool datasetFiltering = false;
        protected DataGridDefinicion dgdDefinicion = new DataGridDefinicion();
        protected DataGridTables dgtTablas = new DataGridTables();
        protected DataGridColumns dgcColumnas = new DataGridColumns();
        protected DataGridRules dgrClausulas = new DataGridRules();
        protected DataGridOrdenColumnas dgoOrdenes = new DataGridOrdenColumnas();

        protected DataGridColumnGroups dgcgGroups;

        //en esta variable se almacena la columna que relaciona los datos de la grid con los de la cabecera
        private DataGridTextBoxColumn _colRel;

        //en este campo se almacena el codigo de la tabla relacional
        protected string _idRel;

        protected bool _MarcarFilas = false;
        protected GridType _DataGridType = GridType.Search;

        protected string _sColsSelect;
        private bool _bScrolling;
        private RadProgressBarElement _BarraNotifica = new RadProgressBarElement();
        private RadLabelElement _LabelNotifica = new RadLabelElement();
        private bool _bChangeOperator;
        private bool _reloadCons = true;

        private bool requery = false;
        protected event CellValidatingExtraEventHandler CellValidatingExtra;

        protected delegate void CellValidatingExtraEventHandler(object sender, CellValidatingEventArgs e);

        public event LanzaConsultaEventHandler LanzaConsulta;

        public delegate void LanzaConsultaEventHandler(DataGridRules Clausulas);

        public event OpenMenuEventHandler OpenMenu;

        public delegate void OpenMenuEventHandler(object sender, ContextMenuOpeningEventArgs e);

        bool bCargando;
        int IndexRow;
        bool bBtnIzq;

        int OldRow;

        public enum GridType
        {
            Edit,
            Search
        }

        #endregion

        #region "Propiedades"

        public bool Scrolling
        {
            get { return _bScrolling; }
        }

       
        public RadProgressBarElement BarraNotifica
        {
            get { return _BarraNotifica; }
            set { _BarraNotifica = value; }
        }

        public DataGridTables Tablas
        {
            get { return dgtTablas; }
            set { dgtTablas = value; }
        }

        public DataGridColumns Columnas
        {
            get { return dgcColumnas; }
            set { dgcColumnas = value; }
        }

        public DataGridOrdenColumnas Ordenes
        {
            get { return dgoOrdenes; }
            set { dgoOrdenes = value; }
        }

        public bool MarcarFilas
        {
            get { return _MarcarFilas; }
            set { _MarcarFilas = value; }
        }

        public DataGridRules Clausulas
        {
            get { return dgrClausulas; }
            set { dgrClausulas = value; }
        }
   
        public GridType DataGridType
        {
            get { return _DataGridType; }
            set
            {
                _DataGridType = value;
                setGridType();
            }
        }

        public string idRel
        {
            get { return _idRel; }
            set { _idRel = value; }
        }

        public string ColSelectFilter
        {
            get { return _sColsSelect; }
            set { _sColsSelect = value; }
        }

        /*
        public new ASADB.Connection DBConnection
        {
            get { return dgdDefinicion.DBConnection; }
            set { dgdDefinicion.DBConnection = value; }
        }
        */

        public DataGridTextBoxColumn ColRel
        {
            get { return _colRel; }
            set { _colRel = value; }
        }

        public DataGridTable TablaEdit
        {
            get { return dgdDefinicion.TablaEdit; }
            set { dgdDefinicion.TablaEdit = value; }
        }

        #endregion

        public KarveGridView() : base()
        {
            MouseDown += DataGrid_MouseDown;
            MouseUp += DataGrid_MouseUp;
            ContextMenuOpening += DataGrid_ContextMenuOpening;
            MouseWheel += DataGrid_MouseWheel;
            FilterChanged += DataGrid_FilterChanged;
            FilterChanging += DataGrid_FilterChanging;
            SortChanging += DataGrid_SortChanging;
            CellFormatting += DataGrid_CellFormatting;
            RowFormatting += DataGrid_RowFormatting;
            CellValueChanged += DataGrid_CellValueChanged;
            CellValidating += DataGrid_CellValidating;
            UserAddingRow += GridDelegacion_UserAddingRow;
            EditorRequired += DataGrid_EditorRequired;
            CellEditorInitialized += DataGrid_CellEditorInitialized;
            this.ThemeClassName = "Telerik.WinControls.UI.RadGridView";
            RadGridLocalizationProvider.CurrentProvider = new MyTraducRadGrid();
            this.TableElement.VScrollBar.MouseDown += VScrollBar_MouseDown;
        }

        private System.Drawing.Color DameColor(string sAliasCampo)
        {
            object DGT = null;
            /*
            foreach (DictionaryEntry DGTh in dgcColumnas)
            {
                DGT = (object) dgcColumnas(DGTh.Key);
                if (Strings.UCase(DGT.AliasCampo) == Strings.UCase(sAliasCampo))
                {
                    return DGT.BackColor;
                }
            }
            */
        }

        private void DataGrid_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadTextBoxEditor tbEditor = this.ActiveEditor as RadTextBoxEditor;
            if ((tbEditor != null))
            {
                RadTextBoxEditorElement tbElement = (RadTextBoxEditorElement) tbEditor.EditorElement;
                tbElement.KeyDown -= tbElement_KeyDown;
                tbElement.KeyDown += tbElement_KeyDown;
            }
        }

        private void tbElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (_DataGridType == GridType.Search)
            {
                if (this.MasterView.TableFilteringRow.IsCurrent)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        LoadCons();
                    }
                    else if (e.KeyCode == Keys.F4)
                    {
                    }
                }
            }
        }

        private void DataGrid_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            if (object.ReferenceEquals(e.EditorType, typeof(GridBrowseEditor)))
            {
                e.EditorType = typeof(BrowerGridEditorKarve);
            }
        }

        #region "Definicion"

        private void setGridType()
        {
            if (_DataGridType == GridType.Edit)
            {
                this.EnableFiltering = true;
                this.datasetFiltering = true;
                this.AllowEditRow = true;
                this.AllowAddNewRow = true;
                this.AllowDeleteRow = true;
                this.AllowColumnChooser = false;
                this.EnableGrouping = false;
                this.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
                this.MultiSelect = true;
            }
            else if (_DataGridType == GridType.Search)
            {
                this.EnableFiltering = true;
                this.datasetFiltering = false;
                this.AllowEditRow = true;
                this.AllowAddNewRow = false;
                this.AllowDeleteRow = false;
                this.MultiSelect = false;
                this.EnableGrouping = true;
                this.AllowColumnChooser = true;
                this.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            }
        }


        protected virtual void defineGrid()
        {
        }

        public void generateGrid()
        {
            defineGrid();

            foreach (var col in dgcColumnas.ToArray())
            {
                dgdDefinicion.Columnas.Add(col);
            }
            foreach (var tb in dgtTablas.ToArray())
            {
                dgdDefinicion.TablasQuery.Add(tb);
            }
            foreach (var ord in dgoOrdenes.ToArray())
            {
                dgdDefinicion.Ordenes.Add(ord);
            }
            foreach (var Rl_loopVariable in dgrClausulas.Order())
            {
                dgdDefinicion.Clausulas.Add(Rl_loopVariable);
            }
            if ((dgcgGroups != null))
            {
                foreach (var gr in dgcgGroups.ColumnGroups)
                {
                    gr = gr_loopVariable;
                    dgdDefinicion.GruposColumnas.Add(gr);
                }
            }
        }

        #endregion

        public void MarcarFilasEnGrid(bool Value)
        {
            DataTable dtt = new DataTable();
            DataRow dtr = default(DataRow);
            dtt = this.DataSource;
            foreach (var dtr in dtt.Rows)
            {
                dtr.Item(dgdDefinicion.NombreColMarcar) = Value;
            }
        }

        #region "Funciones de Acceso a Datos"

        public void loadGrid()
        {
            _MarcarFilas = false;
            if (_DataGridType == GridType.Edit)
            {
                DataGridRules dgrWhere = new DataGridRules();
                DataGridRule rl = new DataGridRule();
                rl.Criterio = DataGridRule.euCriterio.Igual;
                rl.Tabla = _colRel.Tabla;
                rl.Campo = (!string.IsNullOrEmpty(_colRel.Campo) ? _colRel.Campo : _colRel.AliasCampo);
                rl.Valor = _idRel;
                rl.Name = _colRel.Name;
                dgrWhere.Add(rl);
                dgdDefinicion.Clausulas = dgrWhere;
            }
            dgdDefinicion.LoadGrid(this);
            if (_MarcarFilas)
                SetConditions();
            setGridType();
            loadExtra();

            DataTable dta = default(DataTable);
            dta = this.DataSource;
            dta.RowDeleted += rowDeleted;

        }


        protected virtual void loadExtra()
        {
        }


        protected virtual void rowDeleted()
        {
        }

        private bool Columna_Existe(string Value)
        {
            bool functionReturnValue = false;
            foreach (Telerik.WinControls.UI.GridViewCellInfo CL in this.MasterView.TableFilteringRow.Cells)
            {
                if (CL.ColumnInfo.Name == Value)
                {
                    return true;
                    return functionReturnValue;
                }
            }
            return false;
            return functionReturnValue;
        }

        public void LoadCons(bool bMerge = false)
        {
            bCargando = true;
            requery = false;
            dgdDefinicion.LoadCons(this, bMerge);
            LoadFiltros();
            LoadOrdenes();
            if (LanzaConsulta != null)
            {
                LanzaConsulta(dgrClausulas);
            }
            bCargando = false;

        }

        public void guardar()
        {
            dgdDefinicion.guardar();
        }

        public void setIdRel()
        {
            foreach (var row_loopVariable in this.Rows)
            {
                row = row_loopVariable;
                row.Cells(_colRel.Name).Value = _idRel;
            }
            if (_DataGridType == GridType.Edit)
            {
                DataGridRules dgrWhere = new DataGridRules();
                DataGridRule rl = new DataGridRule();
                rl.Criterio = DataGridRule.euCriterio.Igual;
                rl.Tabla = _colRel.Tabla;
                rl.Campo = (!string.IsNullOrEmpty(_colRel.Campo) ? _colRel.Campo : _colRel.AliasCampo);
                rl.Valor = _idRel;
                rl.Name = _colRel.Name;
                dgrWhere.Add(rl);
                dgdDefinicion.Clausulas.Clear();
                dgdDefinicion.Clausulas = dgrWhere;
            }

            //CType(dgrClausulas.Item(_colRel.Name), DataGridRule).Valor = _idRel
        }

        private void GridDelegacion_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            e.Rows(0).Cells(_colRel.Name).Value = _idRel;
            AddExtra(sender, e);
        }


        protected virtual void AddExtra(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
        }

        public void Clear()
        {
            DataTable dta = this.DataSource;
            dta.Rows.Clear();
        }

        #endregion

        #region "Eventos celdas Browser"

        private void DataGrid_CellValidating(object sender, CellValidatingEventArgs e)
        {
            try
            {
                if (e.Column.GetType == typeof(DataGridBrowseBoxColumn))
                {
                    string OldValue = "";
                    if (Information.IsDBNull(e.OldValue))
                    {
                        OldValue = "";
                    }
                    else
                    {
                        OldValue = e.OldValue;
                    }

                    if (Strings.StrComp(OldValue, e.Value, CompareMethod.Text))
                    {
                        DataGridBrowseBoxColumn col = (DataGridBrowseBoxColumn) e.Column;
                        if ((col.RelatedColumn != null))
                        {
                            if (col.Requery & !this.MasterView.TableFilteringRow.IsCurrent)
                            {
                                e.Row.Cells(col.RelatedColumn.Name).Value = col.QueryDesc(e.Value);
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (this.MasterView.TableFilteringRow.IsCurrent & requery & !bCargando)
                {
                    LoadCons();
                    requery = false;
                }
            }
            catch (Exception ex)
            {
            }

            if (CellValidatingExtra != null)
            {
                CellValidatingExtra(sender, e);
            }
        }

        private void DataGrid_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.GetType == typeof(DataGridBrowseBoxColumn))
            {
                ((DataGridBrowseBoxColumn) e.Column).Requery = true;
            }
            if (this.MasterView.TableFilteringRow.IsCurrent)
            {
                requery = true;
            }
        }

        private void SetConditions()
        {
            //add a couple of sample formatting objects
            ConditionalFormattingObject c1 =
                new ConditionalFormattingObject("Fila Marcada", ConditionTypes.Equal, true, "", true);
            c1.RowBackColor = Color.SkyBlue;
            c1.CellBackColor = Color.SkyBlue;

            this.Columns(dgdDefinicion.NombreColMarcar).ConditionalFormattingObjectList.Add(c1);

            //update the grid view for the conditional formatting to take effect


        }

        private void DataGrid_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (_MarcarFilas)
            {
                if (e.RowElement.IsSelected)
                {
                    e.RowElement.BackColor = Color.BlueViolet;
                }
                else if (e.RowElement.RowInfo.Cells(dgdDefinicion.NombreColMarcar).Value == false)
                {
                    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }
            }
        }


        private void DataGrid_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            System.Drawing.Color Color = DameColor(Strings.UCase(e.CellElement.ColumnInfo.Name));
            //Para las Lupas, desactivamos marcar columnas con colorines
            if (_DataGridType == GridType.Edit)
            {
                if (Color != System.Drawing.Color.Empty)
                {
                    e.CellElement.DrawFill = (e.Row.IsSelected == false);
                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color;
                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }
            }

        }

        #endregion

        #region ".  No Usar.  "

        private System.Drawing.Color DameColor_(string sAliasCampo)
        {
            DataGridColumn DGT = default(DataGridColumn);
            for (iRg = 0; iRg <= dgcColumnas.Count - 1; iRg++)
            {
                DGT = new DataGridColumn();
                DGT = (object) dgcColumnas.Item(iRg);
                if (Strings.UCase(DGT.AliasCampo) == Strings.UCase(sAliasCampo))
                {
                    return DGT.BackColor;
                }
            }
        }

        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize) this).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.MasterTemplate).BeginInit();
            this.SuspendLayout();
            //
            //DataGrid
            //
            ((System.ComponentModel.ISupportInitialize) this.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize) this).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        #region "   . Control Ordenes.    "

        public void LoadOrdenes()
        {
            bCargando = true;
            try
            {
                this.MasterTemplate.SortDescriptors.Clear();
                foreach (DataGridOrdenColumna CL in dgoOrdenes.ToArray)
                {
                    if (Columna_Existe(CL.Name))
                    {
                        int iSort = 0;
                        if (CL.Criterio == DataGridOrdenColumna.euCriterio.Desc)
                            iSort = 1;
                        this.MasterTemplate.SortDescriptors.Add(CL.Name, iSort);
                    }
                }
            }
            catch
            {
            }
            bCargando = false;
        }
        //Revisar en que caso petan los orders

        private void DataGrid_SortChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            DataGridOrdenColumna CL = new DataGridOrdenColumna();
            if (_DataGridType == GridType.Search)
            {
                if (bCargando == false)
                {
                    e.Cancel = true;
                    if (e.NewItems.Count != 0)
                    {
                        var _with1 = CL;
                        dynamic col = dgdDefinicion.Columnas.Item(e.NewItems(0).PropertyName);
                        if ((col != null))
                            _with1.AliasTabla = col.Tabla;
                        _with1.Name = e.NewItems(0).PropertyName;
                        if ((col != null))
                        {
                            _with1.Campo = col.Campo;
                            _with1.AliasCampo = col.AliasCampo;
                            _with1.ExpresionBD = col.ExpresionBD;
                        }
                        if (e.NewItems(0).Direction == 0)
                        {
                            _with1.Criterio = DataGridOrdenColumna.euCriterio.Asc;
                        }
                        else
                        {
                            _with1.Criterio = DataGridOrdenColumna.euCriterio.Desc;
                        }
                        dgoOrdenes.Clear();
                        dgoOrdenes.Add(CL);
                    }
                    else
                    {
                        if (dgoOrdenes(0).criterio == DataGridOrdenColumna.euCriterio.Desc)
                        {
                            dgoOrdenes(0).criterio = DataGridOrdenColumna.euCriterio.Asc;
                        }
                        else
                        {
                            dgoOrdenes(0).criterio = DataGridOrdenColumna.euCriterio.Desc;
                        }
                    }
                    dgdDefinicion.Ordenes = dgoOrdenes;
                    LoadCons();
                }
            }
        }

        #endregion

        #region "   . Control Filtros.    "


        private void DataGrid_FilterChanging(object sender, GridViewCollectionChangingEventArgs e)
        {

            if (!datasetFiltering)
            {
                if (bCargando == false)
                {
                    _bChangeOperator = false;
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Remove:
                            dgrClausulas.Remove(e.PropertyName);
                            _bChangeOperator = true;
                            _reloadCons = false;
                            break;
                        default:
                            switch (e.NewItems(0).GetType)
                            {
                                case typeof(FilterDescriptor):
                                    TextFilter(e.NewItems(0));
                                    break;
                                case typeof(DateFilterDescriptor):
                                    DateFilter(e.NewItems(0));
                                    break;
                                case typeof(CompositeFilterDescriptor):
                                    CompositeFilter(e.NewItems(0));
                                    _bChangeOperator = true;
                                    break;
                                default:
                                    TextFilter(e.NewItems(0));
                                    break;
                            }
                            break;
                    }

                    dgdDefinicion.Clausulas = dgrClausulas;
                    e.Cancel = !_bChangeOperator;
                }
            }
        }

        private void TextFilter(FilterDescriptor filter)
        {
            DataGridRule RL = new DataGridRule();
            dynamic col = dgcColumnas.Item(filter.PropertyName);


            if ((col != null))
            {
                var _with2 = RL;
                //Hay que machearlo con las columnas
                _with2.Tabla = col.Tabla;
                _with2.Name = col.Name;
                _with2.Campo = col.Campo;
                _with2.AliasCampo = col.AliasCampo;
                _with2.ExpresionBD = col.ExpresionBD;
                _with2.Criterio = Correspondencia_Filtro(filter.Operator);
                _with2.Tipo = DataGridRule.TipoFiltro.Texto;
                if (filter.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                {
                    _with2.Valor = "";
                }
                else
                {
                    _with2.Valor = filter.Value;
                }

                //Borra elemento si lo encuentra
                if (string.IsNullOrEmpty(VD.getString(filter.Value)) & !PermiteValueNull(filter.Operator))
                {
                    dgrClausulas.Remove(RL.Name);
                }
                else if (dgrClausulas.Existe(RL.Name))
                {
                    DataGridRule tmp = dgrClausulas(RL.Name);
                    RL.Item = tmp.Item;
                    if (RL.Criterio != tmp.Criterio)
                        _bChangeOperator = true;
                    dgrClausulas.Modify(RL);
                }
                else
                {
                    dgrClausulas.Add(RL);
                }
            }
        }

        private void DateFilter(DateFilterDescriptor filter)
        {
            DataGridRule RL = new DataGridRule();
            dynamic col = dgcColumnas.Item(filter.PropertyName);


            if ((col != null))
            {
                var _with3 = RL;
                //Hay que machearlo con las columnas
                _with3.Tabla = col.Tabla;
                _with3.Name = col.Name;
                _with3.Campo = col.Campo;
                _with3.AliasCampo = col.AliasCampo;
                _with3.ExpresionBD = col.ExpresionBD;
                _with3.Criterio = Correspondencia_Filtro(filter.Operator);
                _with3.Tipo = DataGridRule.TipoFiltro.Fecha;
                if (filter.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                {
                    _with3.Valor = "";
                }
                else
                {
                    _with3.Valor = Convert.ToDateTime(filter.Value).ToString("yyyy-MM-dd");
                }

                //Borra elemento si lo encuentra
                if (string.IsNullOrEmpty(VD.getString(filter.Value)) & !PermiteValueNull(filter.Operator))
                {
                    dgrClausulas.Remove(RL.Name);
                }
                else if (dgrClausulas.Existe(RL.Name))
                {
                    DataGridRule tmp = dgrClausulas(RL.Name);
                    RL.Item = tmp.Item;
                    if (RL.Criterio != tmp.Criterio)
                        _bChangeOperator = true;
                    dgrClausulas.Modify(RL);
                }
                else
                {
                    dgrClausulas.Add(RL);
                }

            }
        }

        private void CompositeFilter(CompositeFilterDescriptor filter)
        {
            DataGridRule RL = new DataGridRule();
            dynamic col = dgcColumnas.Item(filter.PropertyName);
            DataGridRules rlParts = new DataGridRules();

            if ((col != null))
            {
                int i = 0;
                foreach (var fil_loopVariable in filter.FilterDescriptors)
                {
                    fil = fil_loopVariable;
                    DataGridRule rlPart = new DataGridRule();

                    var _with4 = rlPart;
                    //Hay que machearlo con las columnas
                    _with4.Tabla = col.Tabla;
                    _with4.Name = col.Name + i;
                    _with4.Campo = col.Campo;
                    _with4.AliasCampo = col.AliasCampo;
                    _with4.ExpresionBD = col.ExpresionBD;
                    _with4.Criterio = Correspondencia_Filtro(fil.Operator);

                    switch (fil.GetType)
                    {
                        case typeof(FilterDescriptor):
                            _with4.Tipo = DataGridRule.TipoFiltro.Texto;
                            if (fil.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                            {
                                _with4.Valor = "";
                            }
                            else
                            {
                                _with4.Valor = fil.Value;
                            }
                            break;
                        case typeof(DateFilterDescriptor):
                            _with4.Tipo = DataGridRule.TipoFiltro.Fecha;
                            if (fil.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                            {
                                _with4.Valor = "";
                            }
                            else
                            {
                                _with4.Valor = Convert.ToDateTime(fil.Value).ToString("yyyy-MM-dd");
                            }
                            break;
                    }

                    if (string.IsNullOrEmpty(VD.getString(rlPart.Valor)) & !PermiteValueNull(fil.Operator))
                    {
                        //en lugar de eliminar la regla no la creamos
                    }
                    else
                    {
                        rlParts.Add(rlPart);
                        i += 1;
                    }
                }

                var _with5 = RL;
                _with5.Tabla = col.Tabla;
                _with5.Name = col.Name;
                _with5.Campo = col.Campo;
                _with5.AliasCampo = col.AliasCampo;
                _with5.ExpresionBD = col.ExpresionBD;
                _with5.Tipo = DataGridRule.TipoFiltro.Compuesto;
                _with5.Operador = (filter.LogicalOperator == FilterLogicalOperator.And
                    ? DataGridRule.euOperadorRule.eAnd
                    : DataGridRule.euOperadorRule.eOr);
                _with5.Rules = rlParts;
                _with5.Expresion = " " + (filter.NotOperator ? "NOT " : "") + "(";
                foreach (DataGridRule rlPart in _with5.Rules.Order)
                {
                    if (rlPart.Item > 0)
                        _with5.Expresion += _with5.OperadorVal;
                    _with5.Expresion += _with5.Rules.DameClausula(rlPart);
                }
                _with5.Expresion += ") ";

                //si no tiene reglas las eliminamos
                if (RL.Rules.Count == 0)
                {
                    dgrClausulas.Remove(RL.Name);
                }
                else if (dgrClausulas.Existe(RL.Name))
                {
                    RL.Item = dgrClausulas(RL.Name).Item;
                    dgrClausulas.Modify(RL);
                }
                else
                {
                    dgrClausulas.Add(RL);
                }
            }
        }

        private void DataGrid_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (_DataGridType == GridType.Search)
            {
                if (_bChangeOperator)
                {
                    _bChangeOperator = false;
                    //If _reloadCons Then LoadCons()
                    _reloadCons = true;
                }
            }
        }

        private bool PermiteValueNull(Telerik.WinControls.Data.FilterOperator Value)
        {
            switch (Value)
            {
                case Telerik.WinControls.Data.FilterOperator.IsNull:
                case Telerik.WinControls.Data.FilterOperator.IsNotNull:
                    return true;
                default:
                    return false;
            }
        }

        private object BuscaColumna(string Value)
        {
            object functionReturnValue = null;
            foreach (object CL in dgcColumnas.ToArray)
            {
                if (Value == CL.FieldName)
                {
                    return CL;
                    return functionReturnValue;
                }
            }
            return null;
            return functionReturnValue;
        }

        private DataGridRule.euCriterio Correspondencia_Filtro(Telerik.WinControls.Data.FilterOperator Value)
        {
            switch (Value)
            {
                case Telerik.WinControls.Data.FilterOperator.Contains:
                    return DataGridRule.euCriterio.Contiene;
                case Telerik.WinControls.Data.FilterOperator.StartsWith:
                    return DataGridRule.euCriterio.Empieza;
                case Telerik.WinControls.Data.FilterOperator.EndsWith:
                    return DataGridRule.euCriterio.Termina;
                case Telerik.WinControls.Data.FilterOperator.IsEqualTo:
                    return DataGridRule.euCriterio.Igual;
                case Telerik.WinControls.Data.FilterOperator.IsGreaterThan:
                    return DataGridRule.euCriterio.Mayor_Que;
                case Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo:
                    return DataGridRule.euCriterio.MayorIgual_Que;
                case Telerik.WinControls.Data.FilterOperator.IsLessThan:
                    return DataGridRule.euCriterio.Menor_Que;
                case Telerik.WinControls.Data.FilterOperator.IsLessThanOrEqualTo:
                    return DataGridRule.euCriterio.MenorIgual_Que;
                case Telerik.WinControls.Data.FilterOperator.IsNotEqualTo:
                    return DataGridRule.euCriterio.Distinto;
                case Telerik.WinControls.Data.FilterOperator.IsNotNull:
                    return DataGridRule.euCriterio.NoEsNulo;
                case Telerik.WinControls.Data.FilterOperator.IsNull:
                    return DataGridRule.euCriterio.EsNulo;
                case Telerik.WinControls.Data.FilterOperator.NotContains:
                    return DataGridRule.euCriterio.NoContiene;
                default:
                    return DataGridRule.euCriterio.Empieza;
            }
        }

        private Telerik.WinControls.Data.FilterOperator Correspondencia_Filtro_Ret(DataGridRule.euCriterio Value)
        {
            switch (Value)
            {
                case DataGridRule.euCriterio.Contiene:
                    return Telerik.WinControls.Data.FilterOperator.Contains;
                case DataGridRule.euCriterio.Empieza:
                    return Telerik.WinControls.Data.FilterOperator.StartsWith;
                case DataGridRule.euCriterio.Termina:
                    return Telerik.WinControls.Data.FilterOperator.EndsWith;
                case DataGridRule.euCriterio.Igual:
                    return Telerik.WinControls.Data.FilterOperator.IsEqualTo;
                case DataGridRule.euCriterio.Mayor_Que:
                    return Telerik.WinControls.Data.FilterOperator.IsGreaterThan;
                case DataGridRule.euCriterio.MayorIgual_Que:
                    return Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo;
                case DataGridRule.euCriterio.Menor_Que:
                    return Telerik.WinControls.Data.FilterOperator.IsLessThan;
                case DataGridRule.euCriterio.MenorIgual_Que:
                    return Telerik.WinControls.Data.FilterOperator.IsLessThanOrEqualTo;
                case DataGridRule.euCriterio.Distinto:
                    return Telerik.WinControls.Data.FilterOperator.IsNotEqualTo;
                case DataGridRule.euCriterio.EsNulo:
                    return Telerik.WinControls.Data.FilterOperator.IsNull;
                case DataGridRule.euCriterio.NoEsNulo:
                    return Telerik.WinControls.Data.FilterOperator.IsNotNull;
                case DataGridRule.euCriterio.NoContiene:
                    return Telerik.WinControls.Data.FilterOperator.NotContains;
                default:
                    return Telerik.WinControls.Data.FilterOperator.StartsWith;
            }
        }

        public void LoadFiltros()
        {
            this.FilterDescriptors.BeginUpdate();
            this.FilterDescriptors.Clear();


            foreach (DataGridRule CL in dgrClausulas.Order)
            {
                try
                {
                    object s = new object();
                    switch (CL.Tipo)
                    {
                        case DataGridRule.TipoFiltro.Texto:
                            s = LoadTextFilter(CL);
                            break;
                        case DataGridRule.TipoFiltro.Fecha:
                            s = LoadDateFilter(CL);
                            break;
                        case DataGridRule.TipoFiltro.Compuesto:
                            s = LoadCompositeFilter(CL);
                            break;
                    }

                    this.FilterDescriptors.Add(s);
                }
                catch
                {
                }
            }
            this.FilterDescriptors.EndUpdate();
        }

        private FilterDescriptor LoadTextFilter(DataGridRule RL)
        {
            FilterDescriptor functionReturnValue = default(FilterDescriptor);
            functionReturnValue = new FilterDescriptor();

            var _with6 = functionReturnValue;
            _with6.Value = RL.Valor;
            _with6.Operator = Correspondencia_Filtro_Ret(RL.Criterio);
            _with6.IsFilterEditor = true;
            _with6.PropertyName = RL.Name;
            return functionReturnValue;
        }

        private DateFilterDescriptor LoadDateFilter(DataGridRule RL)
        {
            DateFilterDescriptor functionReturnValue = default(DateFilterDescriptor);
            functionReturnValue = new DateFilterDescriptor();

            var _with7 = functionReturnValue;
            _with7.Value = Convert.ToDateTime(RL.Valor);
            _with7.Operator = Correspondencia_Filtro_Ret(RL.Criterio);
            _with7.IsFilterEditor = true;
            _with7.PropertyName = RL.Name;
            return functionReturnValue;
        }

        private CompositeFilterDescriptor LoadCompositeFilter(DataGridRule RL)
        {
            CompositeFilterDescriptor functionReturnValue = default(CompositeFilterDescriptor);
            functionReturnValue = new CompositeFilterDescriptor();
            foreach (var rlPart_loopVariable in RL.Rules.Order)
            {
                rlPart = rlPart_loopVariable;
                object filter = new object();
                switch (rlPart.Tipo)
                {
                    case DataGridRule.TipoFiltro.Texto:
                        filter = LoadTextFilter(rlPart);
                        break;
                    case DataGridRule.TipoFiltro.Fecha:
                        filter = LoadDateFilter(rlPart);
                        break;
                }
                filter.PropertyName = RL.Name;
                functionReturnValue.FilterDescriptors.Add(filter);
            }
            var _with8 = functionReturnValue;
            _with8.Value = RL.Valor;
            _with8.Operator = FilterOperator.Contains;
            _with8.IsFilterEditor = true;
            _with8.PropertyName = RL.Name;
            _with8.LogicalOperator = (RL.Operador == DataGridRule.euOperadorRule.eAnd
                ? FilterLogicalOperator.And
                : FilterLogicalOperator.Or);
            _with8.NotOperator = (RL.Expresion.Substring(1, 3) == "NOT" ? true : false);
            return functionReturnValue;
        }

        #endregion

        #region "   . Control ScrollBar.   "

        private void VScrollBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _bScrolling = true;
            if (this.TableElement.VScrollBar.Maximum - this.TableElement.VScrollBar.Value <=
                (this.TableElement.VScrollBar.LargeChange - 1))
            {
                LoadConsMerge();
            }
            _bScrolling = false;
        }

        private void DataGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_DataGridType == GridType.Search)
            {
                if (this.TableElement.VScrollBar.Maximum - this.TableElement.VScrollBar.Value <=
                    (this.TableElement.VScrollBar.LargeChange - 1))
                {
                    LoadConsMerge();
                }
            }
        }

        private void LoadConsMerge()
        {
            if (_DataGridType == GridType.Search)
            {
                dgdDefinicion.NRegPaginado = dgdDefinicion.NRegPaginado + 40;
                LoadCons(true);
                this.TableElement.ScrollToRow(this.Rows.Count - (this.TableElement.RowsPerPage + 5));
            }
        }

        #endregion

        #region "   . Control Menus Contextuales.   "

        private void DataGrid_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (this.MasterView.TableFilteringRow.IsCurrent | bBtnIzq)
            {
                bBtnIzq = false;
                return;
            }
            if (OpenMenu != null)
            {
                OpenMenu(sender, e);
            }
        }

        private void DataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            bBtnIzq = false;
        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            bBtnIzq = e.Button == Windows.Forms.MouseButtons.Left;
        }

        #endregion

    }
}
