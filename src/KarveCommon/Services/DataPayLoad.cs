using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveCommon.Services
{
    public enum DataSubSystem
    {
        PaymentSubsystem = 0,
        VehicleSubsystem = 1,
        HelperSubsytsem = 2,
        SupplierSubsystem = 3,
        CommissionAgentSubystem = 4,
        None = 5,
    };


    /// <summary>
    ///  TODO: add support for generics.
    /// </summary>
    [Serializable]
    public class DataPayLoad: ICloneable, IDataPayLoad
    {


        public enum Type
        {
            Insert = 0, Delete = 1, Update = 2,
            RegistrationPayload = 3, Show = 4, UpdateView = 5,
            UpdateData = 6,
            Any = 7
        };

        private Type _payLoadType = Type.Insert;
        /// <summary>
        ///  It endicate the data object associated
        /// </summary>
        public bool HasDataObject { get; set; }
        /// <summary>
        ///  It has a data set associated
        /// </summary>
        public bool HasDataSet { set; get; }
        ///
        /// Data Set list.
        /// 
        public bool HasDataSetList { set; get; }
        /// 
        /// <summary>
        ///  It has an observable collection associated.
        /// </summary>
        public bool HasObservableCollection { set; get; }
        ///
        /// It has a dictionary associated. 
        ///
        public bool HasDictionary { set; get; }


        public IDictionary<string, object> DataDictionary { set; get; }

        /// We map each command inside the system with a Uri
        ///  karve://suppliers/all?action=save  - this means the save the object
        ///  karve://vehicles/group?action=save - this means save the vehicles group
        ///  karve://contracts/all?action=new - this means a new contract has to be crafted 
        public Uri ObjectPath { get; set; }
        /// <summary>
        ///  type of the payload
        /// </summary>
        public Type PayloadType {
            get { return _payLoadType; }
            set { _payLoadType = value; }
        }
        /// <summary>
        ///  data object name. The name of the data object
        /// </summary>
        public string DataObjectName { get; set; }
        public string PrimaryKey { get; set; }

        public object DataObject { get; set; }
        
        public IDictionary<string, object> DataMap { get; set; }
        /// <summary>
        ///  colleaction of object to be delivered.
        /// </summary>
        public ObservableCollection<object> Data { get; set; }

        public IList<DataSet> SetList { get; set; }

        public DataSet Set { get; set; }
        /// <summary>
        ///  This is useful for the registration with the event manager.
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        ///  This is useful for the subsystem.
        /// </summary>
        public DataSubSystem Subsystem { get; set; }
        public string SubsystemName { get; set; }

        public IDictionary<string, string> Queries { get; set; }
        public string Sender { get; set; }
        public string SubsystemViewModel { get; set; }
        public string PrimaryKeyValue { get; set; }

        public object Clone()
        {
            DataPayLoad payLoad = new DataPayLoad();
            if (!typeof(DataPayLoad).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                payLoad = (DataPayLoad)formatter.Deserialize(stream);
            }
            return payLoad;
        }
    }
    // just a null payload.
    public class NullDataPayload : DataPayLoad
    {
        public NullDataPayload() : base()
        { 
        }
    }
}
