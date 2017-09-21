using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KarveGrid.GridTable
{
    public class DataGridTables
    {
        private IDictionary<string, DataGridTable> _tableQuery;
        public void Add(DataGridTable tableQuery)
        {
            tableQuery.Item = _tableQuery.Count;
            _tableQuery.Add(tableQuery.Name, tableQuery);
        }

        public ArrayList ToArray()
        {
            dynamic orderdDataGridTables = (from c in _tableQuery.Values orderby c.Item select c);
            ArrayList orderedArrayList = new ArrayList();
            foreach (DataGridTable ctr in orderdDataGridTables) {
               orderedArrayList.Add(ctr);
            }
            return orderedArrayList;
        }

    }
}