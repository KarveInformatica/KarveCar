using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;

namespace ProvidersModule.Common
{
    interface IUiComponentChangeHandler
    {
        /// <summary>
        ///  This handler handle the changes in the component change.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="eventManager"></param>
        void OnComponentChange(IDictionary<string, string> dictionary, IEventManager eventManager);
    }
}
