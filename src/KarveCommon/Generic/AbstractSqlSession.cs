using System;
using System.Collections.Generic;

namespace KarveCommon.Generic
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