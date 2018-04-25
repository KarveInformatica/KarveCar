using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /* this class maps all the call that shall arrive from the magnifiers in the forms */

    public class AssistMapper<DataTransfer>: IAssistMapper<DataTransfer> where DataTransfer: class, new()
    {
        private IDictionary<string, Func<object, Task<IEnumerable<DataTransfer>>>>
            _assitMapper = new Dictionary<string, Func<object, Task<IEnumerable<DataTransfer>>>>();
        /// <summary>
        ///  This configure the value of the stream
        /// </summary>
        /// <param name="value">Name of the value in XAML</param>
        /// <param name="score">Lambda function or delegate to be used to smash the assist.</param>


        public void Configure(string value, Func<object, Task<IEnumerable<DataTransfer>>> score)
            
        {
            if (!_assitMapper.ContainsKey(value))
            {
                _assitMapper.Add(value, score);
            }
        }
        /// <summary>
        ///  This execute the assist.
        /// </summary>
        /// <param name="name">Name of the asssit to execute</param>
        /// <param name="arg">Parameters coming from the view model.</param>
        /// <returns></returns>
        public async Task<IEnumerable<DataTransfer>> ExecuteAssist(string name, object arg)
        {
            Func<object, Task<IEnumerable<DataTransfer>>> transfer = null;

            var value = _assitMapper.TryGetValue(name, out transfer);
            var emptyValue = new List<DataTransfer>();
            if (value)
            {
                return await transfer.Invoke(arg);
            }
            return emptyValue;
        }

       
    }
}
