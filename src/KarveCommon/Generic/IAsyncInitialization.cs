using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    /// <summary>
    /// This is basically a marker interface for async initialization. Async method poses an interesting problem:
    /// Asynchronous construction poses an interesting problem. It would be useful to be able to use await in a constructor, 
    /// but this would mean that the constructor would have to return a Task<T> 
    /// representing a value that will be constructed in the future, instead of a constructed value. 
    /// This kind of concept would be very difficult to work into the existing language. So we need and AsyncInitialization
    /// <see cref="https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html"/>
    /// </summary>
    public interface IAsyncInitialization
    {
        /// <summary>
        /// The result of the asynchronous initialization of this instance.
        /// </summary>
        Task<DataSet> Initialization { get; }
    }

}
