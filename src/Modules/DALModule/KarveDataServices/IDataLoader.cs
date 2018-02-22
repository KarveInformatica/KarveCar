using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;

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
        /// It load at most n entities and it preserve the state.
        /// </summary>
        /// <param name="n">Number of the entities to load.</param>
        /// <param name="back">This parameters allows to go backward. It addes subtract the back value from the current cursos</param>
        /// <returns></returns>
        Task<IEnumerable<T>> LoadValueAtMostAsync(int n, int back = 0);
      
        // set of helpers to be loaded.
        // IHelperBase Helper { set; get; }
    }
}