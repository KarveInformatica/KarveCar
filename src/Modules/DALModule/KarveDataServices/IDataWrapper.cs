using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IDataWrapper<T>
    {
        /// <summary>
        ///  This field says if the data has a data set
        /// </summary>
        bool HasDataSet { set; get; }
        /// <summary>
        /// DataSet value
        /// </summary>
        DataSet Set { set; get; }
        /// <summary>
        ///  This field says if the data has a data object
        /// </summary>
        bool HasDataObject { set; get; }
        /// <summary>
        ///  Value object value of tyhe data
        /// </summary>
        T Value { set; get; }
}
}
