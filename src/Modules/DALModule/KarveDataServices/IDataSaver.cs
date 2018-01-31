using System;
using System.Threading.Tasks;

namespace KarveDataServices
{

    public interface IDataSaver<Dto>
    {
        Task<bool> SaveAsync(Dto save);
    }

}