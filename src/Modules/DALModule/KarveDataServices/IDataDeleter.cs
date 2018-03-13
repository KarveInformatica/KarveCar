using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    ///  Generic data deleter interface.
    /// </summary>
    /// <typeparam name="T">Entity to delete</typeparam>
     public interface IDataDeleter<T>
    {
        
        Task<bool> DeleteAsync(T data);
    }
}