using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IAssistMapper<T>
    {
        void Configure(string value, Func<object, Task<object>> score);
        Task<IncrementalList<T>> ExecuteAssist(string name, object arg);
        Task<object> ExecuteAssistGeneric(string name, object arg);
    }
}