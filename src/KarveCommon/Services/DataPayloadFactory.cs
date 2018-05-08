using System;

namespace KarveCommon.Services
{
    /// <summary>
    ///  Singleton factory. There is no need of multiple instance.
    ///  This gets used just for testing purposes.
    /// </summary>
    public class DataPayloadFactory
    {
        private static DataPayloadFactory _payLoad;    
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



    };
}