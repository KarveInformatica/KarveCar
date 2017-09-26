using KarveGrid.Column;
using KarveGrid.GridDefinition;
using Telerik.WinControls.Data;

namespace KarveGrid.GridFilters
{
    internal class TextFilter : BaseFilter
    {
        private FilterDescriptor _filterDescriptor;

        public TextFilter(FilterDescriptor desc)
        {
            _filterDescriptor = desc;
        }

        public override void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules)
        {

            DataGridColumn col = dataGridColumns[_filterDescriptor.PropertyName];
            if (col != null)
            {
                DataGridRule customGridRule = new DataGridRule();
                customGridRule.Table = col.Table;
                customGridRule.Name = col.Name;
                customGridRule.ExtendedFieldName = col.ExtendedFieldName;
                customGridRule.AliasField = col.AliasField;
                customGridRule.ExpressionDb = col.ExpressionDb;
                customGridRule.Criterio = DataGridRule.TranslateFromFilter(_filterDescriptor.Operator);
                customGridRule.CurrentFilterType = DataGridRule.FilterType.Text;
                if (_filterDescriptor.Operator == Telerik.WinControls.Data.FilterOperator.IsNull)
                {
                    customGridRule.Value = "";
                }
                else
                {
                    customGridRule.Value = _filterDescriptor.Value;

                }

                base.UpdateRules(_filterDescriptor, customGridRule, ref rules);

            }

        }
    }
}