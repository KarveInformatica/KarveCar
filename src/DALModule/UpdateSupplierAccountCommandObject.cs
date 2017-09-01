using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class UpdateSupplierAccountCommandObject : IMapperCommand
    {
        private ISupplierAccountObjectInfo account;
        private string v;

        public UpdateSupplierAccountCommandObject(ISupplierAccountObjectInfo account, string v)
        {
            this.account = account;
            this.v = v;
        }

        public DataMapper Mapper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISessionScope Scope { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}