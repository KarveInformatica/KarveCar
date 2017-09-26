using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KarveGrid.GridTable
{
    public class DataGridTables
    {
        private IDictionary<string, DataGridTable> _tableQuery;

        public DataGridTables()
        {
            _tableQuery = new Dictionary<string, DataGridTable>();   
        }
        public DataGridTables(IDictionary<string, DataGridTable> tableQuery)
        {
            _tableQuery = tableQuery;
        }
        public void AddDataGridTable(DataGridTable tableQuery)
        {
            tableQuery.Item = _tableQuery.Count;
            _tableQuery.Add(tableQuery.Name, tableQuery);
        }
        public int Count
        {
       
            get { return this._tableQuery.Count; }
        }
        public IList<DataGridTable> Ordered()
        {
            dynamic orderdDataGridTables = (from c in _tableQuery.Values orderby c.Item select c);
            IList<DataGridTable> orderedArrayList = new List<DataGridTable>();
            foreach (DataGridTable ctr in orderdDataGridTables) {
               orderedArrayList.Add(ctr);
            }
            return orderedArrayList;
        }

    }
}