using System;
using System.Data;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;
using System.Collections.Generic;

namespace DataAccessLayer
{
    internal class UpdateCommandDictionary : IMapperCommand
    {
        private string _statementId;
        private IDictionary<string, object> _dictionaryParm;

        public UpdateCommandDictionary(string v, IDictionary<string, object> p)
        {
            this._statementId = v;
            this._dictionaryParm = p;
        }

        public DataMapper Mapper { get; set; }
        public ISessionScope Scope { get; set; }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}