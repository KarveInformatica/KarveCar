using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;

namespace DataAccessLayer
{
    internal class UpdateCommandTable : IMapperCommand
    {
        private DataTable monitoringData;
        private string v;
        private string v1;

        public UpdateCommandTable(DataTable monitoringData)
        {
            this.monitoringData = monitoringData;
        }

        public UpdateCommandTable(DataTable monitoringData, string v) : this(monitoringData)
        {
            this.v = v;
        }

        public UpdateCommandTable(DataTable monitoringData, string v, string v1) : this(monitoringData, v)
        {
            this.v1 = v1;
        }

        public DataMapper Mapper { get; set; }
        public ISessionScope Scope { get; set; }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}