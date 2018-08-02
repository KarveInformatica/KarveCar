using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  The resolver will solve any resolution.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResolver
    {
        ICollection<T> ResolveReference<T>(string code);
    }
}
