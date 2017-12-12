using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.Assist;
using DataAccessLayer.Assist;
namespace DataAccessLayer.Assist
{
    /// <summary>
    ///  Registry of the assist handlers.
    /// TODO: think more to avoid the last switch.
    /// </summary>
    public class AssistHandlerRegistry
    {
        private readonly IDictionary<string, object> _handlerDictionary = new Dictionary<string, object>();
       
        /// <summary>
        ///  Register a new handler
        /// </summary>
        /// <typeparam name="THandlerType"></typeparam>
        /// <param name="assist">This register a new assist for the query</param>
        /// <param name="handlerType">This register the typeof the handler</param>
        public void RegisterHandler<THandlerType>(string assist, THandlerType handlerType)
        {
            _handlerDictionary.Add(assist,handlerType);
        }
        /// <summary>
        ///  This returns true if it contains the name of the assist handler.
        /// </summary>
        /// <param name="assist"></param>
        /// <returns></returns>
        public bool ContainsHandler(string assist)
        {
            return _handlerDictionary.ContainsKey(assist);
        }

        /// <summary>
        /// This resolve the assist from the magnifier to execute a query 
        /// </summary>
        /// <typeparam name="THandlerType">Type of the result</typeparam>
        /// <param name="assist">Name of the assist.</param>
        /// <param name="assistHandler">This register the type of the assistHandler</param>
        /// <returns>Returns true if the assist has been registered.</returns>
        public bool TryResolve<THandlerType>(string assist, out THandlerType assistHandler)
        {
            object value = null;
            if (_handlerDictionary.TryGetValue(assist, out value))
            {
                if (value.GetType() == typeof(THandlerType))
                {
                   assistHandler = (THandlerType)value;
                   return true;
                }
            }
            
            assistHandler = default(THandlerType);
            return false;
        }
      
       
        /// <summary>
        ///  Remove Handler
        /// </summary>
        /// <param name="assist">Remove the assist handler</param>
        public void RemoveHandler(string assist)
        {
            _handlerDictionary.Remove(assist);
        }
    }
}
