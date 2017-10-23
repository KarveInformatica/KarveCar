using System;
using System.Collections.Generic;

namespace KarveDataServices
{
    public interface ISqlSession: IDisposable
    {
        IList<T> ExecuteAsync<T>(string sqlQuery);
    }
}