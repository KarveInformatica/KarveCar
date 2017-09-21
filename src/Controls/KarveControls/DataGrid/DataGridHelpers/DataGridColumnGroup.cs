using Telerik.WinControls.UI;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class DataGridColumnGroup : GridViewColumnGroup
    {
        public void Add(ref GridViewDataColumn col)
        {
            this.Rows[0].Columns.Add(col);
        }
        public DataGridColumnGroup()
        {
            this.Rows.Add(new GridViewColumnGroupRow());
        }
    }
}

