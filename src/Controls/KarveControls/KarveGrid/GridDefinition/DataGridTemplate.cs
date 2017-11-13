using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KarveControls.KarveGrid.Column;
using KarveControls.KarveGrid.Column.Types;
using KarveControls.KarveGrid.ColumnVirtual;
using KarveControls.KarveGrid.GridOrder;
using KarveControls.KarveGrid.GridTable;

namespace KarveControls.KarveGrid.GridDefinition
{
    public class DataGridTemplate
    {

        #region "Variables"
        private string _stringSql;
        private DataGridTable _tableEdit;
        private DataGridTables _tables = new DataGridTables();
        private DataGridColumns _columns = new DataGridColumns();
        private DataGridColumnGroups _columnasGrupos = new DataGridColumnGroups();
        private DataGridRules _clausulas = new DataGridRules();
        private DataGridOrderedColumns _ordenes = new DataGridOrderedColumns();
        private bool _gridEditable;
        private KarveGridView _gridView;
        private int _pageSize;
        //ASADB.Connection db;
        private DataSet dts = new DataSet();
        private const string _markName = "MARCAR_GRID";
        #endregion
        protected string _whereClause;
        private string _columnsName;

        #region events
        public delegate void QueryDataTableHandler(string table, string alias, bool isMergeNeeded);

        public delegate void QueryUpdateHandler(DataSet table, string sqlQuery);
        public QueryDataTableHandler QueryDataTable;
        public QueryUpdateHandler UpdateData;
        public delegate void QueryColumnsNameHandler(string sql, string table, string alias);
        public QueryColumnsNameHandler QueryColumnsName;
        private string _currentOrdering;


        #endregion


        #region "Propiedades"

        public string ColMarkName {
            get { return _markName; }
        }

        public string CurrentOrdering
        {
            get { return _currentOrdering; }
            set { _currentOrdering = value; }
           
        }
        public bool EnforceConstrains {
            get { return dts.EnforceConstraints; }
            set { dts.EnforceConstraints = value; }
        }

        public string ColumnsName
        {
            get { return _columnsName; }
            set { _columnsName = value; }
        }
        public bool Editable {
            get { return _gridEditable; }
            set { _gridEditable = value; }
        }

        public int PagedRegisterNumber {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public DataGridTables QueryTables {
            get { return _tables; }
            set { _tables = value; }
        }

        public DataGridColumns Columns {
            get { return _columns; }
            set { _columns = value; }
        }

        public DataGridTable TableEdit {
            get { return _tableEdit; }
            set { _tableEdit = value; }
        }

        public DataGridRules Clausulas {
            get { return _clausulas; }
            set { _clausulas = value; }
        }

        public DataGridOrderedColumns Ordenes {
            get { return _ordenes; }
            set { _ordenes = value; }
        }

        public DataGridColumnGroups GruposColumnas {
            get { return _columnasGrupos; }
            set { _columnasGrupos = value; }
        }

        #endregion

        public void LoadGrid(ref KarveGridView grid)
        {
            _gridView = grid;
           // GiveMeListPkTable(dataGridTable.Table, sAlias);
            _stringSql = BuildSql();
            ClearGrid();
            BuildCols();
            DataSource();
            //Construye Criterios Filtros 
            GridEditable();
        }

        public void LoadQueries(ref KarveGridView karveGridView, bool bMerge = false)
        {
            _gridView = karveGridView;
            _stringSql = BuildSql();
            DataSource(bMerge);
        }

        public void Save()
        {
            try {
                dynamic saveSQL = BuildSqlSave();
                DataSet saveDTS = new DataSet();
                IList<DataColumn> deleteCols = new List<DataColumn>();
               // _gridView.EndEdit();

                string columns_extract = "";
                saveDTS = dts.Copy();
                if (saveDTS.Tables.Count > 0)
                { 

                foreach (DataGridColumn col in _columns.Ordered()) {

                        if (saveDTS.Tables[0].Columns.Contains(col.AliasField))
                        {
                            saveDTS.Tables[0].Columns[col.AliasField].ColumnName = col.ExtendedFieldName;
                        }

                    if (col.Table != _tableEdit.AliasTable)
                    {
                        columns_extract += col.ExtendedFieldName + " ";

                    }

                }
                
                foreach (DataColumn col in saveDTS.Tables[0].Columns) {

                    if (columns_extract.Contains(col.ColumnName))
                    {
                        deleteCols.Add(col);
                    }
                    
                }

                foreach (DataColumn c in deleteCols) {
                    
                    saveDTS.Tables[0].Columns.Remove(c);
                }
               }
                // here we trigger the update.
                UpdateData?.Invoke(saveDTS, saveSQL);

            } catch (Exception ex) {
                throw ex;
            }
        }

        private void DataSource(bool bMerge = false)
        {
            DataGridTable dataGridTable = new DataGridTable();
            IList<DataGridTable> currentTables = _tables.Ordered();
            if (currentTables.Count > 0)
            {
                dataGridTable = currentTables[0];
            }   

            /*
             * this invokes an delegate to the upper level for triggering an event to the view model
             */
            QueryDataTable?.Invoke(dataGridTable.Table, dataGridTable.AliasTable, bMerge);
         }

        private void BuildCols()
        {
           
         
            foreach (DataGridColumn col in _columns.Ordered())
            {
                
                _gridView.Columns.Add(col);
                ModifyDataColumn(col);
            }
            //grupos aqui
            if (_columnasGrupos.ColumnGroups.Count > 0) {
                _gridView.ViewDefinition = _columnasGrupos;
            }
        }

        private DataGridCheckBoxColumn MarkColumn()
        {

            DataGridCheckBoxColumn col = default(DataGridCheckBoxColumn);
            col = new DataGridCheckBoxColumn();
            col.HeaderText = "Marcar";
            col.AliasCampo = _markName;
            col.Name = _markName;
            col.Width = 80;
            col.AllowFiltering = false;
            col.ReadOnly = false;
            col.AllowHide = false;
            col.AllowReorder = false;
            col.AllowResize = false;
            return col;

        }

        private void ClearGrid()
        {
               _gridView.Columns.Clear();
                _gridView.DataSource = null;

            
        }

        private void ModifyDataColumn(object col)
        {
            if (col is DataGridDateColumn)
            {
                DataGridDateColumn dataGridDateColumn = (DataGridDateColumn) col;
                dataGridDateColumn.Format = DateTimePickerFormat.Custom;
                dataGridDateColumn.FormatString = "{0:dd/MM/yyyy}";
                _gridView.Columns[dataGridDateColumn.Name].Width = 130;
                _gridView.Columns[dataGridDateColumn.Name].AllowResize = false;

            }
        }

        private void GridEditable()
        {
            _gridView.AllowAddNewRow = _gridEditable;
            _gridView.AllowEditRow = _gridEditable;
            _gridView.AllowDeleteRow = _gridEditable;
        }

        private string BuildSql()
        {

            string sCols = ColumnasGridSQL();
            string sSQL = BeginSql(_tables, "", sCols);
            string sOrder = this.GiveMeMainOrder(this.Ordenes.SortingString());
            if (!Editable)
                sOrder = GiveMeMainOrder(sOrder);
            _whereClause = _clausulas.ComputeWhereClause();
            if (!string.IsNullOrEmpty(_whereClause))
                sSQL += "\n" + _whereClause;
            if (!string.IsNullOrEmpty(sOrder))
                sSQL += "\n" + sOrder;
            return sSQL;
        }

        public string BuildSql(int idReg, string sPk)
        {
            string sCols = " SELECT TOP 1 START AT " + idReg + " " + sPk;
            string sSQL = BeginSql(_tables, "", sCols);
            string sOrder = Ordenes.SortingString();
            if (_gridEditable == false)
                sOrder = GiveMeMainOrder(sOrder);
            _whereClause = this.Clausulas.ComputeWhereClause();
            if (!string.IsNullOrEmpty(_whereClause))
                sSQL += "\n" + _whereClause;
            if (!string.IsNullOrEmpty(sOrder))
                sSQL += "\n" + sOrder;
            return sSQL;
        }

        public string ConstruyeSQLDesplaza(string sPk, string sPkCriterio = " ASC ")
        {
            string sOrder = Ordenes.SortingString();
            string sCols = "";
            if (!_gridEditable)
                sOrder = GiveMeMainOrder(sOrder);
            if (!string.IsNullOrEmpty(sOrder)) {
                sCols = " SELECT ROW_NUMBER() OVER (" + sOrder + ") X, " + sPk + " VALOR ";
            }
            string sSQL = BeginSql(this._tables, "", sCols);
            _whereClause = Clausulas.ComputeWhereClause();
            if (!string.IsNullOrEmpty(_whereClause))
                sSQL += "\n" + _whereClause;
            return sSQL;
        }

        private string GiveMeMainOrder(string sOrder)
        {
            DataGridTable dataGridTable;
            string sAlias = "";
            dataGridTable = _tables.Ordered()[0];
            if (!string.IsNullOrEmpty(dataGridTable.AliasTable))
                sAlias = dataGridTable.AliasTable + ".";
            string sOrdPpal = this.ColumnsName;
            QueryForColumnsName(dataGridTable.Table, dataGridTable.AliasTable);
            if (!string.IsNullOrEmpty(sOrdPpal)) {
                if (string.IsNullOrEmpty(sOrder)) {
                    sOrder = " ORDER BY " + sOrdPpal + " ASC ";
                } else {
                    sOrder = sOrder + ", " + sOrdPpal + " ASC ";
                }
            }
            return sOrder;
        }

        private void QueryForColumnsName(string sTabla, string sAlias)
        {
            string tmpAlias = "'" + sAlias + "'";
            string tmpTable = "'" + sTabla + "'";
            string _sSQL = " SELECT LIST(DISTINCT ISNULL(" + tmpAlias + " + COLUMN_NAME, ''), ', ' ORDER BY COLUMN_ID) AS PK  FROM SYSCOLUMN " +
                           "SC INNER JOIN SYSTABLE ST ON ST.TABLE_ID = SC.TABLE_ID WHERE TABLE_NAME = " + tmpTable + " AND PKEY = 'Y' ";
            if (this.QueryColumnsName != null)
            {
                QueryColumnsName(_sSQL, tmpAlias, tmpTable);
            }
        }

        private string BuildSqlSave()
        {
            string sCols = ColumnasGridSQL(_tableEdit);
            DataGridTables dgtTmp = new DataGridTables();
            dgtTmp.AddDataGridTable(_tableEdit);
            string sSQL = BeginSql(dgtTmp, "", sCols);
            if (!string.IsNullOrEmpty(_whereClause))
                sSQL += _whereClause;
            return sSQL;
        }

        private string CreateStringFromVirtualColumns(string sInit, DataGridTable dataGridTable)
        {
           string columnasVirtuales= ColumnasVirtualSQL(dataGridTable);
            string sBegin = sInit;
            sBegin += dataGridTable.JoinText;
            sBegin = string.Format("{0}     (   {1} ) {2} {3}", sBegin, BeginSql(dataGridTable.VirtualTables, sBegin, columnasVirtuales), dataGridTable.AliasTable, dataGridTable.Criterias );
            return sBegin;
        }
        private string BeginSql(DataGridTables dataGridTables, string sqlQuery, string columnNames)
        {
            string sBegin = "";
            IList<DataGridTable> orderedDataGridTables = dataGridTables.Ordered();
            for (int currentIndex = 0; currentIndex <= orderedDataGridTables.Count - 1; currentIndex++)
            {
                DataGridTable dataGridTable = orderedDataGridTables[currentIndex];
                if (dataGridTable.VirtualTables.Count != 0)
                {
                    sBegin = CreateStringFromVirtualColumns(sBegin, dataGridTable);
                }
                else
                {
                    sBegin = sBegin + dataGridTable.JoinText;
                    sBegin = sBegin + dataGridTable.Table + " " + dataGridTable.AliasTable + " " +
                             dataGridTable.Criterias;
                }
            }
            string sqlString = columnNames + "\n" + sBegin;
            return sqlString;
            
        }

        private string ColumnasVirtualSQL(DataGridTable dataGridTable)
        {
            string sCols = "";
            IList<DataGridColumnVirtual> currentColumnVirtuals = dataGridTable.ColumnasTablaVirtual.Ordered();

            for (int regIndex = 0; regIndex <= currentColumnVirtuals.Count - 1; ++regIndex)
            {
                DataGridColumnVirtual tempColumnVirtual = currentColumnVirtuals[regIndex];
                string sAlias = "";
                if (regIndex != 0)
                {
                    sCols = sCols + ", ";
                }
                if (!string.IsNullOrEmpty(tempColumnVirtual.AliasTable))
                {
                    sAlias = tempColumnVirtual.AliasTable + ".";
                }
                if (!string.IsNullOrEmpty(tempColumnVirtual.Expression))
                {
                    sCols = sCols + " " + tempColumnVirtual.Expression + " " + tempColumnVirtual.AliasField;
                }
                else
                {
                    sCols = sCols + " " + sAlias + tempColumnVirtual.Name + " " + tempColumnVirtual.AliasField;
                }
            }
            if (!string.IsNullOrEmpty(sCols))
            {
                sCols = " SELECT " + sCols;
            }
            return sCols;
        }
            

        private string ColumnasGridSQL(DataGridTable table = null)
        {
            string sCols = "";
            string sAlias = null;
            string sCol = "";
            IList<DataGridColumn> columns = _columns.Ordered();
           
            string filterTable = "";
            string sMarcar = "";
            string sPaginado = "";
            //*===============================================================================
            if ((table != null)) {
                filterTable = table.AliasTable;
            }
            if (_pageSize == 0)
                _pageSize = 100;
            if (_gridView.DataGridType == KarveGridView.GridType.Search)
                sPaginado = " TOP " + _pageSize;
           
            //Buscamos todas las columnas de la colleccion para buscar los campos de la virtual
            for (int colIndex = 0; colIndex <= columns.Count - 1; colIndex++) {
                if (string.IsNullOrEmpty(filterTable) |  columns[colIndex].Table == filterTable) {
                    sAlias = ((!string.IsNullOrEmpty(columns[colIndex].Table)) ? columns[colIndex].Table + "." : "");

                    if (colIndex != 0)
                        sCols = sCols + ", ";
                    //Añade coma menos en la última
                    if (!string.IsNullOrEmpty(columns[colIndex].Table))
                        sAlias = columns[colIndex].Table + ".";
                    //Si hay Expresión prevalece sobre name
                    if (!string.IsNullOrEmpty(columns[colIndex].ExpressionDb)) {
                        sCol = ((string.IsNullOrEmpty(columns[colIndex].ExtendedFieldName)) ? columns[colIndex].AliasField : columns[colIndex].ExtendedFieldName);
                        sCols = sCols + " " + columns[colIndex].ExpressionDb + " " + sCol;
                    } else {
                        if (string.IsNullOrEmpty(columns[colIndex].ExtendedFieldName))
                            columns[colIndex].ExtendedFieldName = columns[colIndex].AliasField;
                        if (string.IsNullOrEmpty(columns[colIndex].AliasField))
                            columns[colIndex].AliasField = columns[colIndex].ExtendedFieldName;
                              
                        if (string.IsNullOrEmpty(filterTable)) {
                            sCols = sCols + " " + sAlias + columns[colIndex].ExtendedFieldName + " " + columns[colIndex].AliasField;
                            // cuando se construye la sql de guardar no se pueden usar alias ya que si no no se puede guardar el dataset
                        } else {
                            sCols = sCols + " " + sAlias + columns[colIndex].ExtendedFieldName;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(sCols))
                sCols = " SELECT " + sPaginado + sMarcar + sCols;
            return sCols;
        }

    }
}
