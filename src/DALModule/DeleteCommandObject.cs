using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class DeleteCommandObject : IMapperCommand
    {
        private ISupplierDataInfo dataInfo;
        private string v;

        public DeleteCommandObject(ISupplierDataInfo dataInfo, string v)
        {
            this.dataInfo = dataInfo;
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