using System.Collections.Generic;
using KarveCommon.Services;

namespace KarveCommon
{
    /// <summary>
    /// Handler interface for the change handling.
    /// 1. The component send a dictionary that contains a changed item and the previous value
    /// 2. The change handler extract valuable information from evDictionary and act accordily.
    /// 3. After processing and updating value, notify the toolbar.
    /// </summary>
    public interface IChangeHandler
    {
        /// <summary>
        /// Insert and notify the toolbar.
        /// </summary>
        /// <param name="payLoad">Payload to be inserted</param>
        /// <param name="evDictionary">Event dictionary to be inserted</param>
         void OnInsert(DataPayLoad payLoad, IDictionary<string,object> evDictionary);
        /// <summary>
        /// Update the value and notify the toolbar.
        /// </summary>
        /// <param name="payLoad">Payload to be updated</param>
        /// <param name="evDictionary">Event dictionary to be updated.</param>
         void OnUpdate(DataPayLoad payLoad, IDictionary<string, object> evDictionary);
       
    }
}
