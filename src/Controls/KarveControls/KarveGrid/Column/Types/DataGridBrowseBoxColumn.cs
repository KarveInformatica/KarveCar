using System.Data;
using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.Column.Types
{
    public class DataGridBrowseBoxColumn : GridViewBrowseColumn, IMixinDataBaseExtension
    {

        #region "Variables"
        protected GridViewDataColumn _relatedColumn;
        protected System.Drawing.Color _BackColor = DefaultColors.DefaultBackgroundColor;
        private string _Desc_Datafield;
        //tabla con la que se rellena el campo descripcion
        private string _Desc_DBTable;
        //referencia de la tabla descripcion (el textbox editable)
        private string _Desc_DBPK;
        //filtro extra en la consulta
        private string _myWhere;
        //si tiene que volver a tirar la query (se pone en true cuando el texto cambia)
        private bool _requery = true;
        //si tira la query cada vez que el texto cambia o espera al lost focus, si por defecto
        private bool _queryOnTextChanged = true;
        protected int _txtDataWidth;
        private string _extraSQL = "";
        private DataSet _dataSet = new DataSet();
        public event QueryThrownEventHandler QueryThrown;
        public delegate DataSet QueryThrownEventHandler(string mysql);
        #endregion

        #region "Propiedades"
        
        
        public string AliasCampo {
            get { return FieldName; }
            set { FieldName = value; }
        }

      
        public override bool ReadOnly {
            get { return base.ReadOnly; }
            set {
                base.ReadOnly = value;
                if (value) { 
                   BackGroundColor = DefaultColors.DefaultReadOnlyColor;
                }
            }
        }

        
        public GridViewDataColumn RelatedColumn {
            get { return _relatedColumn; }
            set { _relatedColumn = value; }
        }

        public string Desc_Datafield {
            get { return _Desc_Datafield; }
            set { _Desc_Datafield = value; }
        }

        public string Desc_DBTable {
            get { return _Desc_DBTable; }
            set { _Desc_DBTable = value; }
        }

        public string Desc_DBPK {
            get { return _Desc_DBPK; }
            set { _Desc_DBPK = value; }
        }

        public string Desc_Where {
            get { return _myWhere; }
            set { _myWhere = value; }
        }

        public bool Query_on_Text_Changed {
            get { return _queryOnTextChanged; }
            set { _queryOnTextChanged = value; }
        }

        public string ExtraSQL {
            get { return _extraSQL; }
            set { _extraSQL = value; }
        }

        public bool Requery {
            get { return _requery; }
            set { _requery = value; }
        }

        public DataSet TableSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }
        public int Item { get => MDataBaseExtension.GetItem(this); set => MDataBaseExtension.SetItem(this, value); }
        public string ExtendedFieldName { get => MDataBaseExtension.GetExtendedFieldName(this); set => MDataBaseExtension.SetExtendedFieldName(this, value); }
        public string Table { get => MDataBaseExtension.GetTable(this); set => MDataBaseExtension.SetTable(this, value); }
        public string ExpressionDb { get => MDataBaseExtension.GetExpressionDb(this); set => MDataBaseExtension.SetTable(this, value); }
        public System.Drawing.Color BackGroundColor { get => MDataBaseExtension.GetBackgroundColor(this); set => MDataBaseExtension.SetBackgroundColor(this, value); }
        #endregion


        public void QueryDescription(string codigo)
        {
            string mySql = "select " + _Desc_Datafield + (!string.IsNullOrEmpty(_extraSQL) ? ", " + _extraSQL : "") + " from " + _Desc_DBTable + " where " + _Desc_DBPK + " = '" + codigo + "'";
            if ((Desc_Where != null) & !string.IsNullOrEmpty(Desc_Where))
            {
                mySql = mySql + " and " + Desc_Where;
            }
            if (QueryThrown != null)
            {
                QueryThrown(mySql);
            }

            /*
            string functionReturnValue = null;
            //lanza la query para resolver la descripción
            _requery = false;
            if (!string.IsNullOrEmpty(codigo)) {
                ASADB.Connection db = new ASADB.Connection();
                string mySql = "select " + _Desc_Datafield + (!string.IsNullOrEmpty(_extraSQL) ? ", " + _extraSQL : "") + " from " + _Desc_DBTable + " where " + _Desc_DBPK + " = '" + codigo + "'";
                if ((myWhere != null) & !string.IsNullOrEmpty(myWhere)) {
                    mySql = mySql + " and " + myWhere;
                }
                DataSet dts = new DataSet();
                dts = db.fillDts(mySql);
                string tmp = null;
                try {
                    tmp = dts.Tables(0).Rows(0).Item(0);
                } catch {
                    tmp = "";
                }
                if (!string.IsNullOrEmpty(tmp)) {
                    functionReturnValue = tmp;
                } else {
                    functionReturnValue = "Inexistente.";
                }
                if (QueryThrown != null) {
                    QueryThrown(dts);
                }
            } else {
                functionReturnValue = "";
            }
            */
          
        }

    }
}
