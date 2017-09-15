using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class InsertCommandObject : IMapperCommand
    {
        private ISupplierMonitoringData monitoring;
        private string v;

        public InsertCommandObject(ISupplierMonitoringData monitoring, string v)
        {
            this.monitoring = monitoring;
            this.v = v;
        }

        public DataMapper Mapper { get; set; }
        public ISessionScope Scope { get; set; }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}