using System.Collections.Generic;

namespace KarveDataServices.Assist
{
    /// <summary>
    ///  This give us a result 
    /// </summary>
    /// <typeparam name="T">Type of the result</typeparam>
    public interface IAssistResult<T>
    {
        /// <summary>
        /// Result
        /// </summary>
        /// <returns></returns>
        T Result();
        /// <summary>
        /// ResultList.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ResultList();
    }
}