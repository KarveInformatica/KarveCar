using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.Assist
{
    
    /// <summary>
    /// This give us an handler list.
    /// </summary>
 
    public interface IAssistHandler
    {
        Task<IAssistResult<T>> HandleAssist<T>(IAssist assist);
    }
}
