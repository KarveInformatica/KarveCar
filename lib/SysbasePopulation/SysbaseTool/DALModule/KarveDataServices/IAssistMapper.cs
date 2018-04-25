using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IAssistMapper<T>
    {
        void Configure(string value, Func<object, Task<IEnumerable<T>>> score);
        Task<IEnumerable<T>> ExecuteAssist(string name, object arg);
    }
}