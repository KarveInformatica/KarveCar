namespace KarveControls.DataGrid.DataGridHelpers.DataGridDefinicion
{
    public class DataGridDefinicion
    {
        /*

#region "Variables"
        
        private string _sSQL;
        private DataGridTable _TablaEdit;
        DataGridTables _Tablas = new DataGridTables();
        DataGridColumns _Columnas = new DataGridColumns();
        DataGridColumnGroups _columnasGrupos = new DataGridColumnGroups();
        DataGridRules _Clausulas = new DataGridRules();
        DataGridOrdenColumnas _Ordenes = new DataGridOrdenColumnas();
        bool _GridEditable;
        Telerik.WinControls.UI.RadData _Grid;
        int _iPaginado;
        IGridDataServices db;
        DataSet dts = new DataSet();
        const string MarcarName = "MARCAR_GRID";

        #endregion

        protected string sWhere;

        #region "Propiedades"

        public IGridDataServices DataServices
        {
            get { return db; }
            set { db = value; }            
        }

        public string NombreColMarcar
        {
            get { return MarcarName; }
        }

        public bool EnforceConstrains
        {
            get { return dts.EnforceConstraints; }
            set { dts.EnforceConstraints = value; }
        }

        public bool Editable
        {
            get { return _GridEditable; }
            set { _GridEditable = value; }
        }

        public int NRegPaginado
        {
            get { return _iPaginado; }
            set { _iPaginado = value; }
        }

        public DataGridTables TablasQuery
        {
            get { return _Tablas; }
            set { _Tablas = value; }
        }

        public DataGridColumns Columnas
        {
            get { return _Columnas; }
            set { _Columnas = value; }
        }

        public DataGridTable TablaEdit
        {
            get { return _TablaEdit; }
            set { _TablaEdit = value; }
        }

        public DataGridRules Clausulas
        {
            get { return _Clausulas; }
            set { _Clausulas = value; }
        }

        public DataGridOrdenColumnas Ordenes
        {
            get { return _Ordenes; }
            set { _Ordenes = value; }
        }

        public DataGridColumnGroups GruposColumnas
        {
            get { return _columnasGrupos; }
            set { _columnasGrupos = value; }
        }

        #endregion

        public void LoadGrid(ref DataGrid Grid)
        {
            _Grid = Grid;
            _sSQL = ConstruyeSQL();
            clearGrid();
            ConstruyeCols();
            DataSource();
            //Construye Criterios Filtros 
            GridEditable();
        }

        public void LoadCons(ref DataGrid Grid, bool bMerge = false)
        {
            //_Grid = Grid
            _sSQL = ConstruyeSQL();
            DataSource(bMerge);
        }

        public void Save()
        {
            try
            {
                dynamic saveSQL = ConstruyeSQLGuardar();
                DataSet saveDTS = new DataSet();
                ArrayList deleteCols = new ArrayList();
                _Grid.EndEdit();

                string columns_extract = "";

                saveDTS = dts.Copy;
                foreach (object col in _Columnas.ToArray())
                {
                    saveDTS.Tables(0).Columns(col.AliasCampo).ColumnName = col.Campo;

                    if (col.Tabla != _TablaEdit.AliasTabla)
                    {
                        columns_extract += col.Campo + " ";
                    }
                }
                foreach (DataColumn col in saveDTS.Tables(0).Columns)
                {
                    if (Strings.InStr(columns_extract, col.ColumnName, CompareMethod.Text) > 0)
                    {
                        deleteCols.Add(col);
                    }
                }

                foreach (void col_loopVariable in deleteCols)
                {
                    col = col_loopVariable;
                    saveDTS.Tables(0).Columns.Remove(col);
                }

                db.updateDts(saveSQL, saveDTS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DataSource(bool bMerge = false)
        {
            DataSet dtsc = new DataSet();
            DataGridTable TBL = new DataGridTable();
            string sAlias = "";
            TBL = _Tablas.ToArray.Item(0);
            if (!string.IsNullOrEmpty(TBL.AliasTabla))
                sAlias = TBL.AliasTabla + ".";
            string sPks = DameListPkTabla(TBL.Table, TBL.AliasTabla);
            try
            {
                if (!string.IsNullOrEmpty(_sSQL))
                {
                    if (bMerge)
                    {
                        if (!string.IsNullOrEmpty(sPks))
                            dtsc = dts.Copy();
                        dts = db.fillDts(_sSQL);
                        dts.Merge(dtsc);
                    }
                    else
                    {
                        dts = db.fillDts(_sSQL);
                    }
                    if (_Grid.MarcarFilas)
                        dts.Tables(0).Columns(MarcarName).ReadOnly = false;
                    _Grid.DataSource = dts.Tables(0);
                }
            }
            catch
            {
            }
        }

        private void ConstruyeCols()
        {
            _Grid.AutoGenerateColumns = false;
            if (_Grid.MarcarFilas)
                _Grid.Columns.Add(Marcar());
            foreach (void col_loopVariable in _Columnas.ToArray)
            {
                col = col_loopVariable;
                _Grid.Columns.Add(col);
                DefineColumnaEspecial(col);
            }
            //grupos aqui
            if (_columnasGrupos.ColumnGroups.Count > 0)
            {
                _Grid.ViewDefinition = _columnasGrupos;
            }
        }

        private DataGridCheckBoxColumn Marcar()
        {

            DataGridCheckBoxColumn col = default(DataGridCheckBoxColumn);
            col = new DataGridCheckBoxColumn();
            col.HeaderText = "Marcar";
            col.AliasCampo = MarcarName;
            col.Name = MarcarName;
            col.Width = 80;
            col.AllowFiltering = false;
            col.ReadOnly = false;
            col.AllowHide = false;
            col.AllowReorder = false;
            col.AllowResize = false;
            return col;

        }

        private void clearGrid()
        {
            try
            {
                _Grid.Columns.Clear();
                _Grid.DataSource = null;

            }
            catch (Exception ex)
            {
            }
        }

        private void DefineColumnaEspecial(object col)
        {
            if (col is DataGridDateColumn)
            {
                ((DataGridDateColumn) col).Format = DateTimePickerFormat.Custom;
                ((DataGridDateColumn) col).FormatString = "{0:dd/MM/yyyy}";
                _Grid.Columns(col.name).Width = 130;
                //_Grid.Columns(col.name).Format = Windows.Forms.DateTimePickerFormat.Custom
                //_Grid.Columns(col.name).CustomFormat = "dd/MM/yyyy"
                _Grid.Columns(col.name).AllowResize = false;
            }
        }

        private void GridEditable()
        {
            _Grid.AllowAddNewRow = _GridEditable;
            _Grid.AllowEditRow = _GridEditable;
            _Grid.AllowDeleteRow = _GridEditable;
        }

        private string ConstruyeSQL()
        {

            string sCols = ColumnasGridSQL();
            string sSQL = BeginSQL(_Tablas, "", sCols);
            string sOrder = _Ordenes.DameOrder;
            if (_GridEditable == false)
                sOrder = DameOrderPrincipal(sOrder);
            sWhere = _Clausulas.DameWhere;
            if (!string.IsNullOrEmpty(sWhere))
                sSQL += Constants.vbNewLine + sWhere;
            if (!string.IsNullOrEmpty(sOrder))
                sSQL += Constants.vbNewLine + sOrder;
            return sSQL;
        }

        public string ConstruyeSQL(int idReg, string sPk)
        {
            string sCols = " SELECT TOP 1 START AT " + idReg + " " + sPk;
            string sSQL = BeginSQL(_Tablas, "", sCols);
            string sOrder = _Ordenes.DameOrder;
            if (_GridEditable == false)
                sOrder = DameOrderPrincipal(sOrder);
            sWhere = _Clausulas.DameWhere;
            if (!string.IsNullOrEmpty(sWhere))
                sSQL += Constants.vbNewLine + sWhere;
            if (!string.IsNullOrEmpty(sOrder))
                sSQL += Constants.vbNewLine + sOrder;
            return sSQL;
        }

        public string ConstruyeSQLDesplaza(string sPk, string sPkCriterio = " ASC ")
        {
            string sOrder = _Ordenes.DameOrder;
            string sCols = "";
            if (_GridEditable == false)
                sOrder = DameOrderPrincipal(sOrder);
            if (!string.IsNullOrEmpty(sOrder))
            {
                sCols = " SELECT ROW_NUMBER() OVER (" + sOrder + ") X, " + sPk + " VALOR ";
            }
            string sSQL = BeginSQL(_Tablas, "", sCols);
            sWhere = _Clausulas.DameWhere;
            if (!string.IsNullOrEmpty(sWhere))
                sSQL += Constants.vbNewLine + sWhere;
            return sSQL;
        }

        private string DameOrderPrincipal(string sOrder)
        {
            DataGridTable TBL = new DataGridTable();
            string sAlias = "";
            TBL = _Tablas.ToArray.Item(0);
            if (!string.IsNullOrEmpty(TBL.AliasTabla))
                sAlias = TBL.AliasTabla + ".";
            string sOrdPpal = DameListPkTabla(TBL.Table, sAlias);
            if (!string.IsNullOrEmpty(sOrdPpal))
            {
                if (string.IsNullOrEmpty(sOrder))
                {
                    sOrder = " ORDER BY " + sOrdPpal + " ASC ";
                }
                else
                {
                    sOrder = sOrder + ", " + sOrdPpal + " ASC ";
                }
            }
            return sOrder;
        }

        private string DameListPkTabla(string sTabla, string sAlias)
        {
            string _sSQL = " SELECT LIST(DISTINCT ISNULL(" + VD.setApostrofa(sAlias) +
                           " + COLUMN_NAME, ''), ', ' ORDER BY COLUMN_ID) AS PK " + Constants.vbNewLine +
                           " FROM SYSCOLUMN SC " + Constants.vbNewLine +
                           " INNER JOIN SYSTABLE ST ON ST.TABLE_ID = SC.TABLE_ID " + Constants.vbNewLine +
                           " WHERE TABLE_NAME = " + VD.setApostrofa(sTabla) + Constants.vbNewLine + " AND PKEY = 'Y' ";
            string sPks = db.executeQuery(_sSQL);
            return sPks;
        }

        private string ConstruyeSQLGuardar()
        {
            string sCols = ColumnasGridSQL(_TablaEdit);
            DataGridTables dgtTmp = new DataGridTables();

            //sWhere = _Clausulas.DameWhere

            dgtTmp.Add(_TablaEdit);
            string sSQL = BeginSQL(dgtTmp, "", sCols);
            if (!string.IsNullOrEmpty(sWhere))
                sSQL += sWhere;
            return sSQL;
        }

        private string BeginSQL(DataGridTables DGTS, string sSQL, string sCols)
        {
            DataGridTable DGT = default(DataGridTable);
            string sBegin = "";
            int iRg = 0;
            string sColsX = "";
            ArrayList DGTa = DGTS.ToArray;
            //*==========================================================================
            for (iRg = 0; iRg <= DGTa.Count - 1; iRg++)
            {
                var _with1 = DGTS.Item(iRg);
                DGT = new DataGridTable();
                DGT = DGTa.Item(iRg);

                if (DGT.TablasVirtual.Count != 0)
                {
                    sColsX = ColumnasVirtualSQL(DGT);
                    sBegin = sBegin + DGT.JoinText;
                    sBegin = sBegin + "    (   " + Constants.vbNewLine + BeginSQL(DGT.TablasVirtual, sBegin, sColsX) +
                             Constants.vbNewLine + "    ) " + DGT.AliasTabla + " " + DGT.Criterio;

                }
                else
                {
                    sBegin = sBegin + DGT.JoinText;
                    sBegin = sBegin + " " + DGT.Table + " " + DGT.AliasTabla + " " + DGT.Criterio;
                }
            }
            sSQL = sCols + Constants.vbNewLine + sBegin;
            return sSQL;
        }

        private string ColumnasVirtualSQL(DataGridTable DGT)
        {
            string sCols = "";
            int iRg = 0;
            DataGridColumnVirtual DVC = null;
            string sAlias = "";
            ArrayList CTV = DGT.ColumnasTablaVirtual.Order;
            //*==============================================================

            //Buscamos todas las columnas de la colleccion para buscar los campos de la virtual
            for (iRg = 0; iRg <= CTV.Count - 1; iRg++)
            {
                DVC = new DataGridColumnVirtual();
                DVC = CTV(iRg);
                sAlias = "";
                if (iRg != 0)
                    sCols = sCols + ", ";
                //Añade coma menos en la última
                if (!string.IsNullOrEmpty(DVC.AliasTabla))
                    sAlias = DVC.AliasTabla + ".";
                //Si hay Expresión prevalece sobre name
                if (!string.IsNullOrEmpty(DVC.Expresion))
                {
                    sCols = sCols + " " + DVC.Expresion + " " + DVC.AliasCampo;
                }
                else
                {
                    sCols = sCols + " " + sAlias + DVC.Name + " " + DVC.AliasCampo;
                }
            }

            if (!string.IsNullOrEmpty(sCols))
                sCols = " SELECT " + sCols;
            return sCols;
        }

        private string ColumnasGridSQL(DataGridTable Table = null)
        {
            string sCols = "";
            object DC = null;
            string sAlias = null;
            string sCol = "";
            ArrayList CLS = _Columnas.ToArray;
            string filterTable = "";
            string sMarcar = "";
            string sPaginado = "";
            //*===============================================================================
            if ((Table != null))
            {
                filterTable = Table.AliasTabla;
            }
            if (_Grid.MarcarFilas)
                sMarcar = " CAST(0 AS BIT) " + MarcarName + ", ";
            if (_iPaginado == 0)
                _iPaginado = 40;
            if (_Grid.DataGridType == DataGrid.GridType.Search)
                sPaginado = " TOP " + _iPaginado;
            var _with2 = CLS;
            //Buscamos todas las columnas de la colleccion para buscar los campos de la virtual
            for (iRg = 0; iRg <= _with2.Count - 1; iRg++)
            {
                DC = _with2.Item(iRg);
                if (string.IsNullOrEmpty(filterTable) | DC.Tabla == filterTable)
                {
                    sAlias = ((!string.IsNullOrEmpty(DC.Tabla)) ? DC.Tabla + "." : "");

                    if (iRg != 0)
                        sCols = sCols + ", ";
                    //Añade coma menos en la última
                    if (!string.IsNullOrEmpty(DC.Tabla))
                        sAlias = DC.Tabla + ".";
                    //Si hay Expresión prevalece sobre name
                    if (!string.IsNullOrEmpty(DC.ExpresionBd))
                    {
                        sCol = ((string.IsNullOrEmpty(DC.Campo)) ? DC.AliasCampo : DC.Campo);
                        sCols = sCols + " " + DC.ExpresionBd + " " + sCol;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(DC.Campo))
                            DC.Campo = DC.AliasCampo;
                        if (string.IsNullOrEmpty(DC.AliasCampo))
                            DC.AliasCampo = DC.campo;
                        if (string.IsNullOrEmpty(filterTable))
                        {
                            sCols = sCols + " " + sAlias + DC.Campo + " " + DC.AliasCampo;
                            // cuando se construye la sql de guardar no se pueden usar alias ya que si no no se puede guardar el dataset
                        }
                        else
                        {
                            sCols = sCols + " " + sAlias + DC.Campo;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(sCols))
                sCols = " SELECT " + sPaginado + sMarcar + sCols;
            return sCols;
        }
        */
    }
}