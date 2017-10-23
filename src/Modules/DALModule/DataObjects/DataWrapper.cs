
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.DataObjects
{
    public class DataWrapper<T>: IDataWrapper<T>
    {
        public bool HasDataSet { get; set; }
        public DataSet Set { get; set; }
        public bool HasDataObject { get; set; }
        public T Value { get; set; }
    }
}
