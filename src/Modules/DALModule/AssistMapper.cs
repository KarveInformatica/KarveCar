using KarveDataServices;
using KarveDataServices.Assist;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /* this class maps all the call that shall arrive from the magnifiers in the forms */

    public class AssistMapper<DataTransfer>: IAssistMapper<DataTransfer> where DataTransfer: class, new()
    { 
        private IDictionary<string, Func<object, Task<object>>> _assistMapper = new Dictionary<string,Func<object, Task<object>>>();
        
        /// <summary>
        ///  This configure the value of the stream
        /// </summary>
        /// <param name="value">Name of the value in XAML</param>
        /// <param name="score">Lambda function or delegate to be used to smash the assist.</param>
        public void Configure(string value, Func<object, Task<object>> score)
            
        {
            if (!_assistMapper.ContainsKey(value))
            {
                _assistMapper.Add(value, score);
            }
        }
        /// <summary>
        ///  what happens if the tag is not in.
        /// </summary>
        /// <param name="name">Tag to be used</param>
        /// <param name="arg">Object to be used</param>
        /// <returns>A null assit object in case there is not match with the name, alist of result if it is ok</returns>
        public async Task<object> ExecuteAssistGeneric(string name, object arg)
        {
            Func<object, Task<object>> transfer = null;

            var value = _assistMapper.TryGetValue(name, out transfer);
            var emptyValue = new NullAssist();
            if (value)
            {
                return await transfer.Invoke(arg);
            }
            return emptyValue;

           
        }
        /// <summary>
        /// Execute an assist given its tag.
        /// </summary>
        /// <param name="name">Tag to be used.</param>
        /// <param name="arg">Argument to be used.</param>
        /// <returns></returns>
        public async Task<IncrementalList<DataTransfer>> ExecuteAssist(string name, object arg)
        {

            var value = _assistMapper.TryGetValue(name, out Func<object, Task<object>> transfer);
            var emptyValue = new IncrementalList<DataTransfer>((uint x,int y)=> { });
            if (value)
            {
                return await transfer.Invoke(arg) as IncrementalList<DataTransfer>;
            }
            return emptyValue;
        }
    }
}
