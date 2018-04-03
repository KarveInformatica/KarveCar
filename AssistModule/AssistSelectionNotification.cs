using Prism.Interactivity.InteractionRequest;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistModule
{ 
    /// <summary>
    ///  AssistSelectionNotification is a confirmation of a selection from a grid.
    /// </summary>
    public class AssistSelectionNotification<T> : Confirmation
    {
        /// <summary>
        ///  This are the items to be included from the grid.
        /// </summary>
        private IncrementalList<T> _items;

        /// <summary>
        ///  AssistSelectionNotification pass a list of parameters from a grid.
        /// </summary>
        /// <param name="items"></param>
        public AssistSelectionNotification(IEnumerable<T> it)
        {

            var count = it.Count();
            _items = new IncrementalList<T>(LoadMoreItems) { MaxItemCount = count };
            Items = _items;
        }
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            var list = _items.Skip(baseIndex).Take(100).ToList();
            var summary = Items as IncrementalList<T>;
            summary.LoadItems(list);
        }
        /// <summary>
        ///  Items passed from a grid.
        /// </summary>
        public IncrementalList<T> Items { get; private set; }
        /// <summary>
        ///  Selected item.
        /// </summary>
        public T SelectedItem { get; set; }

        
    };
       
}
