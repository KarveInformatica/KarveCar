using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IDataAccessLayer<Dto, ExtendedDto>
    {
        Task<bool> DeleteAsyncDo(Dto data);
        Task<IEnumerable<ExtendedDto>> GetAsyncSummary();
        Task<Dto> GetAsyncDo(string clientIndentifier);
        Task<bool> SaveAsync(Dto data);
        string GetNewId();

    }
}
