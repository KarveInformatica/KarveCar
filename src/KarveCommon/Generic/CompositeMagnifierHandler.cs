using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace KarveCommon.Generic
{
    /// <summary>
    /// This composite magnifier allows to aggregate handlers for each kind.
    /// </summary>
    public class CompositeMagnifier: IMagnifierHandler
    {
        
        private IDictionary<string, IMagnifierHandler> _handlerList = new Dictionary<string, IMagnifierHandler>();
        /// <summary>
        /// Add a handler and its name.
        /// </summary>
        /// <param name="paramDictionary">Dictionary.</param>
        public void AddHandler(string name, IMagnifierHandler ev)
        {
            _handlerList.Add(name, ev);        
        }
        public void RemoveHandler(string name, IMagnifierHandler ev)
        {
            _handlerList.Remove(name);
        }

        public void HandleAssist(string assistQuery, string tableName)
        {
            if (_handlerList.ContainsKey(tableName))
            {
                IMagnifierHandler magnifier = _handlerList[tableName];
                magnifier.HandleAssist(assistQuery, tableName);

            }
        }
    }
}
