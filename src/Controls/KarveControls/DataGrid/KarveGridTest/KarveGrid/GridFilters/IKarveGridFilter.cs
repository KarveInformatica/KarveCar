using KarveGrid.Column;
using KarveGrid.GridDefinition;

namespace KarveGrid.GridFilters
{
    internal interface IKarveGridFilter
    {
       void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules);
    
    }
}