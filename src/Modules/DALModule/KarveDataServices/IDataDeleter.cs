using System.Threading.Tasks;

namespace DataAccessLayer
{

    internal interface IDataDeleter<T>
    {
        
        Task<bool> DeleteAsync(T data);
    }
}