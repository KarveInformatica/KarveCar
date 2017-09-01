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

        public DataMapper Mapper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISessionScope Scope { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<DataTable> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}