using System.Collections.Generic;
using System.Linq;

namespace KarveControls.KarveGrid.GridDefinition
{
    public class DataGridRules 
    {
        private IDictionary<string, DataGridRule> _dataGridRules = new Dictionary<string, DataGridRule>();
        public void Add(DataGridRule queryTable)
        {
            queryTable.Item = _dataGridRules.Count;
            _dataGridRules.Add(queryTable.Name, queryTable);
        }

        public int Count()
        {
            return _dataGridRules.Count;
        }
        public void Remove(string key)
        {
            _dataGridRules.Remove(key);
            int i = 0;
            dynamic orderedValuesGridRules = (from c in _dataGridRules.Values orderby c.Item select c); 
            foreach (DataGridRule ctr in orderedValuesGridRules)
            {
                ctr.Item = i;
                i += 1;
            }
        }
        public IList<DataGridRule> Order()
        {
            dynamic orderedRules = (from c in  _dataGridRules.Values orderby c.Item select c);
            IList<DataGridRule> orderedDataGridRules = new List<DataGridRule>();
            foreach (DataGridRule ctr in orderedDataGridRules)
            {
                orderedDataGridRules.Add(ctr);
            }
            return orderedDataGridRules;
        }
        public bool Exists(string Value)
        {
            return _dataGridRules.ContainsKey(Value);
        }
        public DataGridRule ItemExists(string value)
        {
            dynamic items = (from c in _dataGridRules.Values where c.Name == value orderby c.Item select c);
            if (items.Count != 0)
            {
                return items.First();
            }
            
             return null;
        }
        public void Modify(DataGridRule TablaQuery)
        {
            if (!string.IsNullOrEmpty(TablaQuery.Name))
            {
                _dataGridRules[TablaQuery.Name] = TablaQuery;
            }
        }
        public string ComputeWhereClause()
        {
            string sWhere = "";
            string sClausula = "";
            string sOperador = "";

            foreach (DataGridRule gridRule in Order())
            {
                if (gridRule.Item > 0)
                {
                    sOperador = gridRule.OperadorVal;
                }
                if (!string.IsNullOrEmpty(gridRule.Expresion))
                {
                    sClausula = gridRule.Expresion;
                }
                else
                {
                    sClausula = ComputeClause(gridRule);
                }
                sWhere = sWhere + sOperador + sClausula;
            }
            if (!string.IsNullOrEmpty(sWhere))
                sWhere = " WHERE " + sWhere;
            return sWhere;
        }
        public string ComputeClause(DataGridRule dataGridRule)
        {
            string sClausula = "";
            string sCampo = "";
            if (!string.IsNullOrEmpty(dataGridRule.ExpressionDb))
            {
                sCampo = dataGridRule.ExpressionDb;
            }
            else if (!string.IsNullOrEmpty(dataGridRule.AliasField) & dataGridRule.AliasField != dataGridRule.ExtendedFieldName)
            {
                sCampo = dataGridRule.AliasField;
            }
            else
            {
                sCampo = dataGridRule.Table + ".";
                sCampo += dataGridRule.ExtendedFieldName;
            }
           
            if (dataGridRule.Criterio == DataGridRule.SortingCriteria.Contains)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'%" + dataGridRule.Value + "%'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.NotContains)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'%" + dataGridRule.Value + "%'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.IsNotEqualTo)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'" + dataGridRule.Value + "'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.IsEqualTo)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'" + dataGridRule.Value + "'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.StartsWith)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'" + dataGridRule.Value + "%'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.Ends)
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'%" + dataGridRule.Value + "'";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.IsNull)
            {
                sClausula = sCampo + " IS NULL ";
            }
            else if (dataGridRule.Criterio == DataGridRule.SortingCriteria.IsNotNull)
            {
                sClausula = sCampo + " IS NOT NULL ";
            }
            else
            {
                sClausula = sCampo + dataGridRule.OrderBy + "'" + dataGridRule.Value + "'";
            }
            return sClausula;
        }

        public void Clear()
        {
            _dataGridRules.Clear();
        }

        public DataGridRule this[string name]
        {
            get { return _dataGridRules[name]; }
        }
    }
}
