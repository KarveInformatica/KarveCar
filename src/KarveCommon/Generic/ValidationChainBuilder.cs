using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This class has the single resposability to build a validation chain.
    /// </summary>
    /// <typeparam name="T">Type of the validation</typeparam>
    public class ValidationChainBuilder<T>
    {
        private ValidationChain<T> _currentItem = null;
        /// <summary>
        /// ValidationChainBuilder.  
        /// </summary>
        public ValidationChainBuilder()
        {
            First = _currentItem;
        }
        /// <summary>
        ///  Add a new item.
        /// </summary>
        /// <param name="item">Item to be inserted in the validation chain</param>
        public void AddItem(ValidationChain<T> item)
        {
            if (_currentItem == null)
            {
                _currentItem = item;
                First = _currentItem;
            }
            else
            {
                _currentItem.SetNext(item);
                _currentItem = item;  
            }
        }
        /// <summary>
        /// First element in the validation chain.
        /// </summary>
        public ValidationChain<T> First { get; private set; }
    }
}
