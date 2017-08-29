using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Services
{
    /// <summary>
    ///  TODO: add support for generics.
    /// </summary>
    public class DataPayLoad
    {
        public enum Type {
            Insert = 0, Delete = 1, Update = 2
        };
        
        ///  string
        public string ObjectPath { get; set; }
        /// <summary>
        ///  type of the payload
        /// </summary>
        public Type PayloadType { get; set; }
        /// <summary>
        ///  data object name. The name of the data object
        /// </summary>
        public string DataObjectName { get; set; }

        public object DataObject { get; set; }
        /// <summary>
        ///  colleaction of object to be delivered.
        /// </summary>

        public ObservableCollection<object> Data { get; set; }

        public DataSet Set { get; set; }
    }
}
