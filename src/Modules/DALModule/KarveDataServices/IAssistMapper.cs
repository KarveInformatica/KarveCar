using System;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  Interface to be used for responding to a query.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAssistMapper<T>
    {
        void Configure(string value, Func<object, Task<object>> score);
        Task<object> ExecuteAssistGeneric(string name, object arg);
    }
}