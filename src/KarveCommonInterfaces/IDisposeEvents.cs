using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///  This is an interface to be called when a tab item gets closed.
    /// </summary>
    public interface IDisposeEvents
    {
        /// <summary>
        ///  This is helpful to dispose events.
        /// </summary>
       void DisposeEvents();
    }
}
