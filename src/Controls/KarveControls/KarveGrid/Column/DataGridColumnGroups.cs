using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.Column
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {

        public void AddColumns(GridViewColumnGroup col)
        {
            ColumnGroups.Add(col);
        }
        
    }
}