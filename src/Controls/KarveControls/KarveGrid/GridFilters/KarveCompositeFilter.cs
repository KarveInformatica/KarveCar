using System;
using System.Collections.Generic;
using KarveControls.KarveGrid.Column;
using KarveControls.KarveGrid.GridDefinition;
using Telerik.WinControls.Data;

namespace KarveControls.KarveGrid.GridFilters
{
    internal class KarveCompositeFilter : BaseFilter
    {
        private CompositeFilterDescriptor _filterDescriptors;

        public KarveCompositeFilter(CompositeFilterDescriptor newValue)
        {
            this._filterDescriptors = newValue;
        }

        public override void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules)
        {
            DataGridColumn dataGridColumn = dataGridColumns[_filterDescriptors.PropertyName];
            DataGridRule dataGridRule;
            IDictionary<Type, DataGridRule.FilterType> kindOFilterTypes =
                new Dictionary<Type, DataGridRule.FilterType>();
            kindOFilterTypes.Add(typeof(FilterDescriptor), DataGridRule.FilterType.Text);
            kindOFilterTypes.Add(typeof(DateFilterDescriptor), DataGridRule.FilterType.Data);
            DataGridRules dataGridRulesParts = new DataGridRules();
            dataGridRule = new DataGridRule();
            if (dataGridColumn != null)
            {
                int i = 0;
                foreach (var filterDescriptor in _filterDescriptors.FilterDescriptors)
                {
                    dataGridRule.Table = dataGridColumn.Table;
                    dataGridRule.Name = dataGridColumn.Name;
                    dataGridRule.ExtendedFieldName = dataGridColumn.ExtendedFieldName;
                    dataGridRule.AliasField = dataGridColumn.AliasField;
                    dataGridRule.ExpressionDb = dataGridColumn.ExpressionDb;
                    dataGridRule.Criterio = DataGridRule.TranslateFromFilter(_filterDescriptors.Operator);
                    DataGridRule.FilterType type = kindOFilterTypes[filterDescriptor.GetType()];
                    bool isNull = (filterDescriptor.Operator == Telerik.WinControls.Data.FilterOperator.IsNull);
                    switch (type)
                    {
                        case DataGridRule.FilterType.Text:
                        {
                            dataGridRule.Value = (isNull) ? "" : filterDescriptor.Value;
                            break;
                        }
                        case DataGridRule.FilterType.Data:
                        {
                            dataGridRule.Value = (isNull)
                                ? " "
                                : Convert.ToDateTime(filterDescriptor.Value).ToString("yyyy-MM-dd");
                            break;
                        }
                    }

                    bool validOperator = (filterDescriptor.Operator != FilterOperator.IsNull);
                    string name = filterDescriptor.Value as string;

                    if (!string.IsNullOrEmpty(name) || (!validOperator))
                    {
                        dataGridRulesParts.Add(dataGridRule);
                        i += 1;
                    }
                }
            }
            DataGridRule tmpRule = dataGridRule;
            tmpRule.Table = dataGridColumn.Table;
            tmpRule.Name = dataGridColumn.Name;
            tmpRule.ExtendedFieldName = dataGridColumn.ExtendedFieldName;
            tmpRule.ExpressionDb = dataGridColumn.ExpressionDb;
            tmpRule.CurrentFilterType = DataGridRule.FilterType.Composed;
            tmpRule.Operador = (_filterDescriptors.LogicalOperator == FilterLogicalOperator.And)
                ? DataGridRule.OperatorRule.And
                : DataGridRule.OperatorRule.Or;
            tmpRule.Expresion = " " + (_filterDescriptors.NotOperator ? "NOT" : "") + "(";
            foreach (DataGridRule rlPart in tmpRule.Rules.Order())
            {
                if (rlPart.Item > 0)
                {
                    tmpRule.Expresion += tmpRule.OperadorVal;
                }
                tmpRule.Expresion += tmpRule.Rules.ComputeWhereClause();

            }
            tmpRule.Expresion += ") ";
            if (tmpRule.Rules.Count() == 0)
            {
                rules.Remove(tmpRule.Name);
            }
            else if (rules.Exists(tmpRule.Name))
            {
                tmpRule.Item = rules[tmpRule.Name].Item;
                rules.Modify(tmpRule);
            }
            else
            {
                rules.Add(tmpRule);
            }
        }
    }
}