using Telerik.WinControls.UI;

namespace KarveControls.DataGrid.DataGridHelpers.DataGridColumns
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {
        public void Add(ref GridViewColumnGroup col)
        {
            this.ColumnGroups.Add(col);
        }
    }
}

