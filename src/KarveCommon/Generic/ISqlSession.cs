using System;
using System.Collections.Generic;

namespace KarveCommon.Generic
{
    public interface ISqlSession: IDisposable
    {
        IList<T> ExecuteAsync<T>(string sqlQuery);
    }
}