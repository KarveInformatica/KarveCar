using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;

namespace DataAccessLayer
{
    internal class InsertCommissionNumberCommand : IMapperCommand
    {
        private string commissionNumber;
        private DataTable tmpSupplier;
        private string v;

        public InsertCommissionNumberCommand(string commissionNumber, DataTable tmpSupplier, string v)
        {
            this.commissionNumber = commissionNumber;
            this.tmpSupplier = tmpSupplier;
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