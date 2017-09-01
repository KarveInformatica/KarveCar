using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class UpdateCommandObject : IMapperCommand
    {
        private ISupplierDataInfo dataInfo;
        private ISupplierTypeData dataType;
        private string v;

        public UpdateCommandObject(ISupplierTypeData dataType, string v)
        {
            this.dataType = dataType;
            this.v = v;
        }

        public UpdateCommandObject(ISupplierDataInfo dataInfo, ISupplierTypeData dataType, string v)
        {
            this.dataInfo = dataInfo;
            this.dataType = dataType;
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