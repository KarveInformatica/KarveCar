using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Office
{
    internal sealed class OfficeDataDeleter: IDataDeleter<OfficeDtos>
    {
        private ISqlExecutor _executor;

        public OfficeDataDeleter(ISqlExecutor executor)
        {
            _executor = executor;
        }

        public Task<bool> DeleteAsync(OfficeDtos data)
        {
            throw new NotImplementedException();
        }
    }
}
