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
         string PrimaryKey { get; set; }

         object DataObject { get; set; }

         IDictionary<string, object> DataMap { get; set; }
        /// <summary>
        ///  colleaction of object to be delivered.
        /// </summary>
         ObservableCollection<object> Data { get; set; }

         IList<DataSet> SetList { get; set; }

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
         /// The sender. 
         /// </summary>
         string Sender { get; set; }
        /// <summary>
        ///  The subsystem view model.
        /// </summary>
         string SubsystemViewModel { get; set; }
        /// <summary>
        ///  Primary key.
        /// </summary>
         string PrimaryKeyValue { get; set; }
        /// <summary>
        ///  Clone objects.
        /// </summary>
        /// <returns></returns>
        object Clone();
    }
}