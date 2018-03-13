using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using KarveCommon;
using KarveDataServices.DataTransferObject;
using KarveCommon.Generic;
using System.ComponentModel;

namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///  Load the data grid from the name.
    /// </summary>
    class ProxyDataLoader
    {
        /// <summary>
        ///  load the data.
        /// </summary>
        private IDataServices _dataServices;
        private string _gridName;
        private INotifyTaskCompletion<IEnumerable<BaseDto>> _initializationTable;
       
        /// <summary>
        ///  This dictionary takes a list of action to be done.
        /// </summary>
        private IDictionary<string, Func<string, Task<IEnumerable<BaseDto>>>> _action;
        
        /// Init dictionary.
        
        private void InitDictionary()
        {
        }
        /// <summary>
        ///  This is the loader for the proxy
        /// </summary>
        /// <param name="services">Services for the data loading</param>
        /// <param name="gridName">Name of the grid</param>
        public ProxyDataLoader(IDataServices services, string gridName)
        {
            _dataServices = services;
            _gridName = gridName;
            InitDictionary();
        }        
        /// <summary>
        ///  Load Asynchronous.
        /// </summary>
        /// <param name="key">Key to be used for loading.</param>
        /// <param name="id">Identifier to be invoked.</param>
        /// <returns></returns>
        public async Task<IEnumerable<BaseDto>> LoadAsync(string key, string id)
        {
            Func<string, Task<IEnumerable<BaseDto>>> currentHandler;
            _action.TryGetValue(key, out currentHandler);
            if (currentHandler != null)
            {
                var result = await currentHandler.Invoke(id);
                return result;
            }
            // better listing.
            return new List<ContractDto>();
        }
        
    };
}
