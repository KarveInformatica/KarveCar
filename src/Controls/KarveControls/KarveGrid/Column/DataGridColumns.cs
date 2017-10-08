using System.Collections.Generic;
using System.Linq;

namespace KarveControls.KarveGrid.Column
{
    public class DataGridColumns
    {
        private IDictionary<string, DataGridColumn> _dataGridColumns = new Dictionary<string, DataGridColumn>();
        public void AddColumns(DataGridColumn Columna)
        {

            Columna.Item = _dataGridColumns.Count;
            _dataGridColumns.Add(Columna.Name, Columna);
        }

        public DataGridColumn this[string name]
        {
             get { return _dataGridColumns[name]; }
             set { _dataGridColumns[name] = value; }

        }
        public IList<DataGridColumn> Ordered()
        {
            IList<DataGridColumn> _dataGridList = new List<DataGridColumn>();
            dynamic columns = (from c in _dataGridColumns.Values orderby c select c);
            foreach (var val in columns)
            {
                _dataGridList.Add(val);
            }
            return _dataGridList;
        }

    }
}

