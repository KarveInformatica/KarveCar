using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace KarveDataServices
{
    /// <summary>
    ///  DataPayload interface.
    /// </summary>
    public interface IDataPayLoad
    {
        /// <summary>
        ///  It endicate the data object associated
        /// </summary>
        bool HasDataObject { get; set; }
        /// <summary>
        ///  It has a data set associated
        /// </summary>
         bool HasDataSet { set; get; }
        ///
        /// Data Set list.
        /// 
         bool HasDataSetList { set; get; }
        /// 
        /// <summary>
        ///  It has an observable collection associated.
        /// </summary>
         bool HasObservableCollection { set; get; }
        ///
        /// It has a dictionary associated. 
        ///
         bool HasDictionary { set; get; }

        /// <summary>
        ///  Data dictionary.
        /// </summary>
         IDictionary<string, object> DataDictionary { set; get; }

        /// We map each command inside the system with a Uri
        ///  karve://suppliers/all?action=save  - this means the save the object
        ///  karve://vehicles/group?action=save - this means save the vehicles group
        ///  karve://contracts/all?action=new - this means a new contract has to be crafted 
         Uri ObjectPath { get; set; }
        /// <summary>
        ///  type of the payload
        /// </summary>
      
        /// <summary>
        ///  data object name. The name of the data object
        /// </summary>
         string DataObjectName { get; set; }
        /// <summary>
        ///  Get or Set the value of the primary key
        /// </summary>
         string PrimaryKey { get; set; }
        /// <summary>
        ///  Get or Set the data object to be carried in the payload.
        /// </summary>
         object DataObject { get; set; }
        /// <summary>
        ///  Get or set a dictionary of object to be carried in the payload.
        /// </summary>
         IDictionary<string, object> DataMap { get; set; }
        /// <summary>
        ///  colleaction of object to be delivered.
        /// </summary>
         ObservableCollection<object> Data { get; set; }
        /// <summary>
        ///  Get or Set a list of values.
        /// </summary>
         IList<DataSet> SetList { get; set; }
        /// <summary>
        ///  Get or Set the values.
        /// </summary>
         DataSet Set { get; set; }
        /// <summary>
        ///  This is useful for the registration with the event manager.
        /// </summary>
         string Registration { get; set; }
        /// <summary>
        ///  This is useful for the subsystem.
        /// </summary>
         //DataSubSystem Subsystem { get; set; }
         string SubsystemName { get; set; }
         /// <summary>
         ///  Queries to be conveyed between modules in the system.
         /// </summary>
         IDictionary<string, string> Queries { get; set; }
         /// <summary>
         /// Get or Set the sender.
         /// </summary>
         string Sender { get; set; }
        /// <summary>
        ///  Get or Set the subsystem view model.
        /// </summary>
         string SubsystemViewModel { get; set; }
        /// <summary>
        ///  Get or Set the primary key.
        /// </summary>
         string PrimaryKeyValue { get; set; }
        /// <summary>
        /// Get or Set the clone.
        /// </summary>
        /// <returns></returns>
        object Clone();
    }
}