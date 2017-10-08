using KarveControls.KarveGrid.Column;
using KarveControls.KarveGrid.GridDefinition;

namespace KarveControls.KarveGrid.GridFilters
{
    internal interface IKarveGridFilter
    {
       void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules);
    
    }
}