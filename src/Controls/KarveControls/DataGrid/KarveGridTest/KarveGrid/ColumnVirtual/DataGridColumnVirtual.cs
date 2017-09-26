using KarveGrid.Column.Types;

namespace KarveGrid.ColumnVirtual
{
    public class DataGridColumnVirtual
    {
        private int _item;
        private string _sName;
        private string _sExpression;
        private string _sAlias;
        private string _sAliasTable;




        public int Item {
            get { return _item; }
            set { _item = value; }
        }
        public string Name {
            get { return _sName; }
            set { _sName = value; }
        }
        public string Expression {
            get { return _sExpression; }
            set { _sExpression = value; }
        }

        public string AliasField {
            get { return _sAlias; }
            set { _sAlias = value; }
        }
        public string AliasTable {
            get { return _sAliasTable; }
            set { _sAliasTable = value; }
        }

    }
}
