using System;
using System.Collections.Generic;
using KarveDataServices;

namespace KarveCommon.Services
{
    /// <summary>
    ///  Singleton factory. There is no need of multiple instance.
    ///  This gets used just for testing purposes.
    /// </summary>
    public class DataPayloadFactory
    {
        private static DataPayloadFactory _payLoad;    
        
        private DataPayloadFactory()
        {

        }
        /// <summary>
        /// Get instance.
        /// </summary>
        /// <returns>Return a payload factory</returns>
        public static DataPayloadFactory GetInstance()
        {
            return _payLoad ?? (_payLoad = new DataPayloadFactory());
        }
        public DataPayLoad BuildRegistrationPayLoad(string path, object dataObject, DataSubSystem subSystem)
        {
            DataPayLoad payload = new DataPayLoad();
            payload.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payload.DataObject = dataObject;
            payload.ObjectPath = new Uri(path);
            payload.Subsystem = subSystem;
            return payload;
        }
        public DataPayLoad BuildSystemDataPayLoad(string path, object dataObject, DataSubSystem subSystem)
        {
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = new Uri(path);
            payload.DataObject = dataObject;
            payload.Subsystem = subSystem;
            return payload;
        }

        public DataPayLoad BuildInsertPayLoadDo<T>(string name, T Object, DataSubSystem subSystem, string route, string sender = "", Uri objectPath = null, IDictionary<string, string> queries = null)
        {
            var currentPayload = BuildDefaultPayLoad<T>(name, Object, subSystem, route, sender, objectPath, queries);
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            return currentPayload;

        }
        public DataPayLoad BuildShowPayLoadDo<T>(string name, T Object, DataSubSystem subSystem, string route, string sender = "", Uri objectPath = null, IDictionary<string, string> queries = null)
        {
            var currentPayload = BuildDefaultPayLoad<T>(name, Object, subSystem, route, sender, objectPath, queries);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            return currentPayload;
        }
        private DataPayLoad BuildDefaultPayLoad<T>(string name, T Object, DataSubSystem subSystem, string route, string sender = "", Uri objectPath = null, IDictionary<string, string> queries = null)
        {
            var currentPayload = new DataPayLoad();
            var routedName = route;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.Subsystem = subSystem;
            currentPayload.DataObject = Object;
            currentPayload.Sender = sender;
            currentPayload.ObjectPath = objectPath;
            if (queries != null)
            {
                currentPayload.Queries = queries;
            }
            return currentPayload;
        }

    };
}