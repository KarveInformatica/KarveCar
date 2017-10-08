using System;
using KarveControls.KarveGrid.Column;
using KarveControls.KarveGrid.GridDefinition;
using Telerik.WinControls.Data;

namespace KarveControls.KarveGrid.GridFilters
{
    internal class DateFilter: BaseFilter
    {
         private FilterDescriptor _filterDescriptor;

        public DateFilter(FilterDescriptor filterDesc)
        {
            _filterDescriptor = filterDesc;
        }

        public override void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules)
        {
            DataGridRule dataGridRule = new DataGridRule();
            DataGridColumn col = dataGridColumns[_filterDescriptor.PropertyName];

            if ((col != null))
            {
                dataGridRule.Table = col.Table;
                dataGridRule.Name = col.Name;
                dataGridRule.ExtendedFieldName = col.ExtendedFieldName;
                dataGridRule.AliasField = col.AliasField;
                dataGridRule.ExpressionDb = col.ExpressionDb;
                dataGridRule.Criterio = DataGridRule.TranslateFromFilter(_filterDescriptor.Operator);
                dataGridRule.CurrentFilterType = DataGridRule.FilterType.Data;
                if (_filterDescriptor.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                {
                    dataGridRule.Value = "";
                }
                else
                {
                    dataGridRule.Value = Convert.ToDateTime(_filterDescriptor.Value).ToString("yyyy-MM-dd");
                }
                string filterValue = _filterDescriptor.Value as string;
                FilterOperator op = _filterDescriptor.Operator;
                UpdateRules(_filterDescriptor, dataGridRule, ref rules);
              
            }
        }
    }
}