using System.Collections.Generic;
using System.Linq;

namespace KarveControls.KarveGrid.ColumnVirtual
{
    /// <summary>
    /// VirtualDataGridColumns is dictionary for storing a collection of a datagrid columns virtual by its name.
    /// </summary>
    public class VirtualDataGridColumns
    {
        private readonly IDictionary<string, DataGridColumnVirtual> _dataGridColumns = new Dictionary<string, DataGridColumnVirtual>();

        public void AddColumns(DataGridColumnVirtual queryTable)
        {
            _dataGridColumns.Add(queryTable.Name, queryTable);
        }

        public IList<DataGridColumnVirtual> Ordered()
        {
            dynamic orderedColumnVirtuals = (from c in _dataGridColumns.Values orderby c.Item select c);
            IList<DataGridColumnVirtual> arrayList = new List<DataGridColumnVirtual>();
            foreach (DataGridColumnVirtual item in orderedColumnVirtuals) {
                arrayList.Add(item);
            }
            return arrayList;
        }

    }
}