using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class DataGridTables : Dictionary<object, DataGridTable>
    {

        public void Add(DataGridTable TablaQuery)
        {
            TablaQuery.Item = this.Count;
            base.Add(TablaQuery.Name, TablaQuery);
        }

        public ArrayList ToArray()
        {
            dynamic HC = (from c in Values orderby c.Item select  c);
            ArrayList RS = new ArrayList();
            foreach (DataGridTable ctr in HC) {
                RS.Add(ctr);
            }
            return RS;
        }

    }
}
