using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.ColumnGroup
{
    public class DataGridColumnGroup : GridViewColumnGroup
    {

        public void AddColumns(ref GridViewDataColumn col)
        {
            if (Rows.Count > 0)
            {
                Rows[0].Columns.Add(col);
            }
        }

        public DataGridColumnGroup()
        {
            this.Rows.Add(new GridViewColumnGroupRow());
        }
    }
}
