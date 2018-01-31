using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataLoader<T> where T: class
    {
        /// <summary>
        ///  This load asynchronously all the data.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> LoadAsyncAll();
        /// <summary>
        ///  THis load a single value asynchronously.
        /// </summary>
        /// <param name="code">PrimaryKey value of the value to load.</param>
        /// <returns></returns>
        Task<T> LoadValueAsync(string code);
        /// <summary>
        ///  This is load async data.
        /// </summary>
        /// <param name="query"> This load the query.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> LoadAsyncAll(string query);
    }
}