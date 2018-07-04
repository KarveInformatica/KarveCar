using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This is the payload interpeter
    /// </summary>
    /// <typeparam name="T">Kind of payload.</typeparam>
        public class PayloadInterpeter<T>
        {
        /// <summary>
        ///  Delegate that defines a view model initializer when it received a datapayload. It allows to express
        ///  the action to be done in that case.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="payLoad"></param>
        /// <param name="insertion"></param>
            public delegate void ViewModelInitializer(string value, DataPayLoad payLoad, bool insertion);
        /// <summary>
        ///  Delegate that defines a view model cleaner when it received a data payload.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="subSystem"></param>
        /// <param name="subsystemName"></param>
            public delegate void Dispose(DataPayLoad payLoad, DataSubSystem subSystem, string subsystemName);

        private enum InterpeterState { Initialized, CleanedUp, None };
            /// <summary>
             ///  Initializer of the model. It is has used to call an Init method to be set from the user.
             ///  Currently the user is a view model when it hands a message coming from the EventManager/Mediator.
             /// </summary>
            public  ViewModelInitializer Init { set; get;  }
            /// <summary>
            ///  Function to dispose the model.
            /// </summary>
            public Dispose CleanUp { set; get; }
            

            /// <summary>
            ///  This function has the single resposability to check the current operational state. 
            /// </summary>
            /// <param name="payLoad"></param>
            /// <returns></returns>
            public DataPayLoad.Type CheckOperationalType(DataPayLoad payLoad)
            {
                switch (payLoad.PayloadType)
                {
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                        return DataPayLoad.Type.Show;
                    default:
                        return payLoad.PayloadType;
                }
            }
        /// <summary>
        /// ActionOnPayload. This metion acts on a payload calling cleanup or init delegates.
        /// </summary>
        /// <param name="payLoad">Incoming payload</param>
        /// <param name="primaryKeyValue">Primary Key of the view model.</param>
        /// <param name="newId">New generated indentifier</param>
        /// <param name="subSystem">Current subsystem</param>
        /// <param name="subsystemName">Current subsystem name</param>
            public void ActionOnPayload(DataPayLoad payLoad, string primaryKeyValue, string newId, 
                                        DataSubSystem subSystem, string subsystemName)
            {
                if (Init == null)
                {
                    throw new Exception("Interpreter not initalized"); 
                }
            // check on primary key
            if ((payLoad.PayloadType == DataPayLoad.Type.Insert) &&
           (primaryKeyValue == payLoad.PrimaryKeyValue))
            {
                return;
            }
            
            switch (payLoad)
                {
                    case null:
                    case NullDataPayload _:
                        return;
                }

                switch (payLoad.PayloadType)
                {
                    case DataPayLoad.Type.Update:
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                    {
                        Init?.Invoke(primaryKeyValue, payLoad, false);
                        break;
                    }
                    case DataPayLoad.Type.Insert:
                    {
                       
                        if (string.IsNullOrEmpty(primaryKeyValue))
                        {
                            primaryKeyValue = newId;
                        }
                        Init?.Invoke(primaryKeyValue, payLoad, true);
                        break;
                    }
                    case DataPayLoad.Type.Delete:
                    {

                        if (primaryKeyValue == payLoad.PrimaryKey)
                        {
                                CleanUp?.Invoke(payLoad, subSystem, subsystemName);
                                
                        }
                        

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
