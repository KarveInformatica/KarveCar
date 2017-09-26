using System.Collections.Generic;
using System.Linq;

namespace KarveGrid.GridOrder
{
    public class DataGridOrderedColumns
    {
        private IList<DataGridOrderedColumn> _dataGridSortingColumns = new List<DataGridOrderedColumn>();
        public void AddColumns(DataGridOrderedColumn column)
        {
            column.Item = _dataGridSortingColumns.Count;
            _dataGridSortingColumns.Add(column);
        }

        public IList<DataGridOrderedColumn> Ordered()
        {
            dynamic orderedRules = (from c in _dataGridSortingColumns orderby c.Item select c);
            return orderedRules;
        }
        public string SortingString()
        {
            string _sOrder = "";
            string _sClausula = "";
            string _sCampo = "";
            string _sOperador = "";
            //*====================================================================
            foreach (DataGridOrderedColumn orderedColumn in _dataGridSortingColumns.ToArray())
            {
                if (orderedColumn.Item > 0)
                    _sOperador = ", ";
                if (!string.IsNullOrEmpty(orderedColumn.Expresion))
                {
                    _sClausula = orderedColumn.Expresion + " " + orderedColumn.CriteriaString;
                } else if (!string.IsNullOrEmpty(orderedColumn.ExpressionDb))
                {
                  
                    _sClausula = string.Format("({0}) {1}", orderedColumn.ExpressionDb, orderedColumn.CriteriaString);

                } else if (!string.IsNullOrEmpty(orderedColumn.AliasField)) {
                    _sClausula = orderedColumn.AliasField + " " + orderedColumn.CriteriaString;
                } else {
                    _sCampo = "";
                    _sClausula = "";
                    //*------------------------------------------------------------
                    if (!string.IsNullOrEmpty(orderedColumn.AliasTable))
                        _sCampo = orderedColumn.AliasTable + ".";
                    _sCampo += orderedColumn.AliasTable;
                    _sClausula += _sCampo + " " + orderedColumn.CriteriaString;
                }
                _sOrder = _sOrder + _sOperador + _sClausula;
            }
            if (!string.IsNullOrEmpty(_sOrder))
                _sOrder = " ORDER BY " + _sOrder;
            return _sOrder;
        }

    }
}
