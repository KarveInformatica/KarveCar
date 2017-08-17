using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Exceptions;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    public class QueryAsyncForDataTableCommand : BaseQueryAsyncCommand
    {
        private object _param;
        /// <summary>
        /// Constructor for query async data table command
        /// </summary>
        /// <param name="id">Statement id</param>
        /// <param name="param">Parameters</param>
        public QueryAsyncForDataTableCommand(string id, object param)
        {
            base.Statement = id;
            this._param = param;
        }
        public override async Task<DataTable> ExecuteAsync()
        {
            if ((_mapper == null) || (_scope == null))
            {
                throw new DataMapperException("Scope and mapper shall be set before executing");
            }
            DataTable x = await _mapper.QueryAsyncForDataTableSession(this._statement, this._param, _scope);
            return x;
        }
    }
}
