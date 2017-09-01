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
            Insert = 0, Delete = 1, Update = 2,
            RegistrationPayload = 3
        };
        /// <summary>
        ///  It endicate the data object associated
        /// </summary>
        public bool HasDataObject { get; set; }
        /// <summary>
        ///  It has a data set associated
        /// </summary>
        public bool HasDataSet { set; get; }
        /// <summary>
        ///  It has an observable collection associated.
        /// </summary>
        public bool HasObservableCollection { set; get; }
        ///
        /// We map each command inside the system with a Uri
        ///  karve://suppliers/all?action=save  - this means the save the object
        ///  karve://vehicles/group?action=save - this means save the vehicles group
        ///  karve://contracts/all?action=new - this means a new contract has to be crafted 
        public Uri ObjectPath { get; set; }
        /// <summary>
        ///  type of the payload
        /// </summary>
        public Type PayloadType { get; set; }
        /// <summary>
        ///  data object name. The name of the data object
        /// </summary>
        public string DataObjectName { get; set; }

        public object DataObject { get; set; }
        
        public IDictionary<string, object> DataMap { get; set; }
        /// <summary>
        ///  colleaction of object to be delivered.
        /// </summary>
        public ObservableCollection<object> Data { get; set; }

        public DataSet Set { get; set; }
        /// <summary>
        ///  This is useful for the registration with the event manager.
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        ///  This is useful for the subsystem.
        /// </summary>
        public int Subsystem { get; set; }
    }
}
