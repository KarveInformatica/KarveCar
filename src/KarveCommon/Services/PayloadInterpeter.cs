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
            public delegate void ViewModelInitializer(string value, DataPayLoad payLoad, bool insertion);

            public delegate void Dispose(string primaryKey, DataSubSystem subSystem, string subsystemName);
             /// <summary>
             ///  Initializer of the model.
             /// </summary>
            public  ViewModelInitializer Init { set; get;  }
            /// <summary>
            ///     Function to dispose the model.
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
        /// ActionOnPayload. This function acts on a payload calling cleanup or init delegates.
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

                if (payLoad == null)
                {
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
                            CleanUp?.Invoke(primaryKeyValue, subSystem, subsystemName);
                        }

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
