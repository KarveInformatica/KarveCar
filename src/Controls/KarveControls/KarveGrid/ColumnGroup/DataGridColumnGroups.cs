using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.ColumnGroup
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {

        public void AddColumns(ref GridViewColumnGroup col)
        {
            this.ColumnGroups.Add(col);
        }
    }
}
