using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class CreateSupplierAccountCommandObject : IMapperCommand
    {
        private ISupplierAccountObjectInfo account;

        public CreateSupplierAccountCommandObject(ISupplierAccountObjectInfo account)
        {
            this.account = account;
        }

        public DataMapper Mapper { get; set; }
        public ISessionScope Scope { get; set; }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}