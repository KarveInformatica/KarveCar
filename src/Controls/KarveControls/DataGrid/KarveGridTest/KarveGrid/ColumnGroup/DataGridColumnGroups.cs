using Telerik.WinControls.UI;

namespace KarveGrid.ColumnGroup
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {

        public void AddColumns(ref GridViewColumnGroup col)
        {
            this.ColumnGroups.Add(col);
        }
    }
}
