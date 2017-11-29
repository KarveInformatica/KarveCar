using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace KarveCommon.Generic
{
    public class CompositeMagnifier: IMagnifierHandler
    {
        
        private IDictionary<string, IMagnifierHandler> _handlerList = new Dictionary<string, IMagnifierHandler>();
        /// <summary>
        /// Handle assist 
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
        }
    }
}
