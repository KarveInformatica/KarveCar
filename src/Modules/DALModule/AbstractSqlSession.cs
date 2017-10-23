using System;
using System.Collections.Generic;
using KarveDataServices;

namespace DataAccessLayer
{
    internal class AbstractSqlSession : ISqlSession
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteAsync<T>(string sqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}