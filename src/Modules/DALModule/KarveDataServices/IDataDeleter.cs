using System.Threading.Tasks;

namespace DataAccessLayer
{

     public interface IDataDeleter<T>
    {
        
        Task<bool> DeleteAsync(T data);
    }
}