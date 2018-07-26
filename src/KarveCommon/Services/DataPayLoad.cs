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
using System.Windows.Input;
using KarveDataServices.DataObjects;

namespace KarveCommon.Services
{
    public enum DataSubSystem
    {
        PaymentSubsystem = 0,
        VehicleSubsystem = 1,
        HelperSubsytsem = 2,
        SupplierSubsystem = 3,
        CommissionAgentSubystem = 4,
        ClientSubsystem = 5,
        OfficeSubsystem = 6,
        CompanySubsystem = 7,
        None = 8,
        FareSubsystem = 9,
        InvoiceSubsystem = 10,
        BookingSubsystem = 11,
    };
    /// <summary>
    /// DataPayLoad is a generic exchange class between the different parts of the system.
    /// You can consider each view model like an actor, see https://www.brianstorti.com/the-actor-model/
    /// Each view model receive from other view models a data payload. The payload can arrive through
    /// the incoming message mailbox or can arrive through broadcast propagation (EventManager).
    /// Each view model belongs to a subsystem.
    /// In each subsystem there is a controller view model and a set of info view models.
    /// </summary>
    [Serializable]
    public class DataPayLoad: ICloneable, IDataPayLoad
    {


        public enum Type
        {
            Raw = -2,
            Initialized = -1,
            Insert = 0,
            Delete = 1,
            Update = 2,
            RegistrationPayload = 3,
            Show = 4,
            UpdateView = 5,
            UpdateData = 6,
            Any = 7,
            CultureChange = 8,
            UpdateInsertGrid = 9,
            DeleteGrid = 10,
            RevertChanges = 11,
            UpdateError = 12,
            UnregisterPayload = 13,
            Dispose = 14,
            ShowNavigate = 15
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

        /// <summary>
        ///  Contains the previous value to do the undo
        /// </summary>
        public bool HasOldValue { set; get; }

        /// <summary>
        ///  contains the value of the oldvalue
        /// </summary>

        public bool HasSaveCommand { set; get; }
        public bool HasNewCommand { set; get; }

        public bool HasDeleteCommand { set; get; }

        public object OldValue { set; get; }

        /// <summary>
        ///  Data dictionary of elements.
        /// </summary>

        public IDictionary<string, object> DataDictionary { set; get; }


        
        /// We map each command inside the system with a Uri. Each viewmodel has an unique uri,
        /// since a view model represent a resource.
        ///  karve://suppliers/viewmodel?id=8392893  - this means the save the object
        ///  karve://vehicles/group?action=save - this means save the vehicles group
        ///  karve://contracts/all?action=new - this means a new contract has to be crafted 
        public Uri ObjectPath { get; set; }
        /// <summary>
        ///  Set or Get Type of the payload
        /// </summary>
        public Type PayloadType {
            get { return _payLoadType; }
            set { _payLoadType = value; }
        }
        /// <summary>
        ///  Set or Get Data object name. The name of the data object
        /// </summary>
        public string DataObjectName { get; set; }
        /// <summary>
        /// Set or Get the name of primary key.
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// Set or Get the DataObject to be used.
        /// </summary>
        public object DataObject { get; set; }
        /// <summary>
        ///  Set or Get the Related data object.
        /// </summary>
        public object RelatedObject { set; get; }
        /// <summary>
        /// Set or Get the Datamap to be used.
        /// </summary>
        public IDictionary<string, object> DataMap { get; set; }
        /// <summary>
        /// Set or Get the collection of object to be delivered.
        /// </summary>
        public ObservableCollection<object> Data { get; set; }
        /// <summary>
        ///  Set or Get the List of set to be used.
        /// </summary>
        public IList<DataSet> SetList { get; set; }
        /// <summary>
        ///  Set or Get the Dataset to be used.
        /// </summary>
        public DataSet Set { get; set; }
        /// <summary>
        ///  This is useful for the registration with the event manager.
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        ///  This is useful for the subsystem.
        /// </summary>
        public DataSubSystem Subsystem { get; set; }
        /// <summary>
        ///  Name of the subystem to be used inside the event dispatcher.
        /// </summary>
        public string SubsystemName { get; set; }
        /// <summary>
        ///  Dictionary of the queries that the payload led.
        /// </summary>
        public IDictionary<string, string> Queries { get; set; }
        /// <summary>
        /// Set or Get the Sender, the address or the name of the sender.
        /// TODO: see if we can avoid replication with ObjectPath.
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        ///  Set or Get the the name of the controller view model in the subsystem.
        /// </summary>
        public string SubsystemViewModel { get; set; }
        /// <summary>
        ///  Set or Get the the name of the primary key in the subsystem.
        /// </summary>
        public string PrimaryKeyValue { get; set; }
        /// <summary>
        ///  Set or Get the the name of the related object in the subsystem.
        /// </summary>
        public bool HasRelatedObject { get; set; }
        /// <summary>
        ///  Set or Get the the name of the ResultString.
        /// </summary>
        public string ResultString { get; set; }

        public bool IsTest { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public Uri Destination { get; set; }

        /// <summary>
        ///  Set or Get the the name of the ShallowCopy.
        /// </summary>

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        ///  Set or Get the the name of the controller view model in the subsystem.
        /// </summary>

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
