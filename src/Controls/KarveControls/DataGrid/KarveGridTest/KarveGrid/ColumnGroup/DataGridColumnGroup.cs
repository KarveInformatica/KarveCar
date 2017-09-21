using Telerik.WinControls.UI;

namespace KarveGrid.ColumnGroup
{
    public class DataGridColumnGroup : GridViewColumnGroup
    {

        public void Add(ref GridViewDataColumn col)
        {
            this.Rows(0).Columns.Add(col);
        }

        public DataGridColumnGroup()
        {
            this.Rows.Add(new GridViewColumnGroupRow());
        }
    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
