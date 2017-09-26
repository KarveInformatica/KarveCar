using KarveGrid.Column.Types;

namespace KarveGrid.GridOrder
{
    public class DataGridOrderedColumn: IMixinDataBaseExtension
    {
        public enum OrderCriteria
        {
            Asc,
            Desc
        }
        public int Item { get => MDataBaseExtension.GetItem(this); set => MDataBaseExtension.SetItem(this, value); }
        public string ExtendedFieldName { get => MDataBaseExtension.GetExtendedFieldName(this); set => MDataBaseExtension.SetExtendedFieldName(this, value); }
        public string Table { get => MDataBaseExtension.GetTable(this); set => MDataBaseExtension.SetTable(this, value); }
        public string ExpressionDb { get => MDataBaseExtension.GetExpressionDb(this); set => MDataBaseExtension.SetTable(this, value); }
        public System.Drawing.Color BackGroundColor { get => MDataBaseExtension.GetBackgroundColor(this); set => MDataBaseExtension.SetBackgroundColor(this, value); }

        private OrderCriteria _eCriteria;
        private string _sName;
        private string _sExpresion;
        private string _sCriterio;
        private string _sAliasTabla;
        private string _sAliasCampo;

        public string Name {
            get { return _sName; }
            set { _sName = value; }
        }
        public string Expresion {
            get { return _sExpresion; }
            set { _sExpresion = value; }
        }

        public string AliasTable {
            get { return _sAliasTabla; }
            set { _sAliasTabla = value; }
        }

        public OrderCriteria Criteria {
            get { return _eCriteria; }
            set {
                _eCriteria = value;
                switch (_eCriteria) {
                    case OrderCriteria.Asc:
                        _sCriterio = " ASC ";
                        break;
                    case OrderCriteria.Desc:
                        _sCriterio = " DESC ";
                        break;
                }
            }
        }
        public string CriteriaString {
            get { return _sCriterio; }
        }
        public string AliasField {
            get { return _sAliasCampo; }
            set { _sAliasCampo = value; }
        }

    }
}
