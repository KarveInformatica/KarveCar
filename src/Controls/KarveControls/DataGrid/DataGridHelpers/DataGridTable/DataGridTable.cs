using KarveControls.DataGrid.DataGridHelpers.DataGridColumnVirtual;

namespace KarveControls.DataGrid.DataGridHelpers.DataGridTable
{
    public class DataGridTable
    {

        #region "   .   VARIABLES.  "

        public enum euCriteriosJoin
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

        int _Item;
        string _Table;
        string _Alias;
        euCriteriosJoin _Join;
        string _Criterio;
        DataGridTables _TablasVirtual = new DataGridTables();
        DataGridColumnVirtuales _ColumnasVirtual = new DataGridColumnVirtuales();

        private string _Name;
        #endregion

        #region "   -   PROPERTY.   "

        public int Item {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Table {
            get { return _Table; }
            set { _Table = value; }
        }

        public string AliasTabla {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public euCriteriosJoin Join {
            get { return _Join; }
            set { _Join = value; }
        }

        public string JoinText {
            get {
                string sJoin = "";
                switch (_Join) {
                    case euCriteriosJoin.FromJoin:
                        sJoin = " FROM ";
                        break;
                    case euCriteriosJoin.InnerJoin:
                        sJoin = " INNER JOIN ";
                        break;
                    case euCriteriosJoin.LeftJoin:
                        sJoin = " LEFT OUTER JOIN ";
                        break;
                    case euCriteriosJoin.RightJoin:
                        sJoin = " RIGHT OUTER JOIN ";
                        break;
                    case euCriteriosJoin.FromFrom:
                        sJoin = ", ";
                        break;
                    case euCriteriosJoin.Union:
                        sJoin = " UNION ";
                        break;
                    case euCriteriosJoin.UnionAll:
                        sJoin = " UNION ALL ";
                        break;
                    case euCriteriosJoin.FullJoin:
                        sJoin = " FULL OUTER JOIN ";
                        break;
                }
                return sJoin;
            }
        }


        public string Criterio {
            get { return _Criterio; }
            set { _Criterio = value; }
        }

        public DataGridTables TablasVirtual {
            get { return _TablasVirtual; }
            set { _TablasVirtual = value; }
        }

        public DataGridColumnVirtuales ColumnasTablaVirtual {
            get { return _ColumnasVirtual; }
            set { _ColumnasVirtual = value; }
        }

        public object Name {
            get {
                if (!string.IsNullOrEmpty(_Name)) {
                    return _Name;
                } else {
                    return _Table;
                }
            }
            set { _Name = (string)value; }
        }

        #endregion

    }
}
