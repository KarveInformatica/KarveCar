using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    /// <summary>
    ///  base class for each async command to be sent in the batch execution engine.
    /// </summary>
    public abstract class BaseQueryAsyncCommand: IMapperCommand
    {
        protected string _statement;
        protected DataMapper _mapper;
        protected ISessionScope _scope;
        /// <summary>
        ///  This is the query that we want to execute
        /// </summary>
        public string Statement
        {
            set
            {
                _statement = value;
            }
            get
            {
                return _statement;
            }
        }
        public DataMapper Mapper
        {
            set
            {
                _mapper = value;
            }
            get
            {
                return _mapper;
            }
        }
        public ISessionScope Scope
        {
            set
            {
                _scope = value;
            }
            get
            {
                return _scope;
            }
        }

        public abstract Task<DataTable> ExecuteAsync();
       
    }
}
