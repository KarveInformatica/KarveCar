using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Company
{
    class CompanyDataSaver : IDataSaver<CompanyDto>
    {
        private ISqlExecutor sqlExecutor;

        public CompanyDataSaver(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public Task<bool> SaveAsync(CompanyDto save)
        {
            throw new NotImplementedException();
        }
    }
}
