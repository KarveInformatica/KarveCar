using KarveGrid.ColumnVirtual;

namespace KarveGrid.GridTable
{
    public class DataGridTable
    {

        #region "Variables Definition"

        public enum JoinCriterias
        {
            FromJoin,
            InnerJoin,
            LeftJoin,
            RightJoin,
            FullJoin,
            Union,
            UnionAll,
            FromFrom
        }

        private int _item;
        private string _table;
        private string _alias;
        private JoinCriterias _join;
        private string _criteria;
        private DataGridTables _virtualTables = new DataGridTables();
        private VirtualDataGridColumns _virtualColumns = new VirtualDataGridColumns();
        private string _name;
        #endregion

        #region "   -   PROPERTY.   "

        public int Item {
            get { return _item; }
            set { _item = value; }
        }

        public string Table {
            get { return _table; }
            set { _table = value; }
        }

        public string AliasTable {
            get { return _alias; }
            set { _alias = value; }
        }

        public JoinCriterias Join {
            get { return _join; }
            set { _join = value; }
        }

        public string JoinText {
            get {
                string sJoin = "";
                switch (_join) {
                    case JoinCriterias.FromJoin:
                        sJoin = " FROM ";
                        break;
                    case JoinCriterias.InnerJoin:
                        sJoin = " INNER JOIN ";
                        break;
                    case JoinCriterias.LeftJoin:
                        sJoin = " LEFT OUTER JOIN ";
                        break;
                    case JoinCriterias.RightJoin:
                        sJoin = " RIGHT OUTER JOIN ";
                        break;
                    case JoinCriterias.FromFrom:
                        sJoin = ", ";
                        break;
                    case JoinCriterias.Union:
                        sJoin = " UNION ";
                        break;
                    case JoinCriterias.UnionAll:
                        sJoin = " UNION ALL ";
                        break;
                    case JoinCriterias.FullJoin:
                        sJoin = " FULL OUTER JOIN ";
                        break;
                }
                return sJoin;
            }
        }


        public string Criterio {
            get { return _criteria; }
            set { _criteria = value; }
        }

        public DataGridTables VirtualTables {
            get { return _virtualTables; }
            set { _virtualColumns = value; }
        }

        public VirtualDataGridColumns ColumnasTablaVirtual {
            get { return _virtualColumns; }
            set { _virtualColumns = value; }
        }

        public string Name {
            get {
                if (!string.IsNullOrEmpty(_name)) {
                    return _name;
                } else {
                    return _table;
                }
            }
            set { _name = value; }
        }
        #endregion

    }
}

