using System.Collections.Generic;
using System.Windows;

namespace KarveControls.KarveGrid.Events
{
    
    class ChangeFilterEvent: RoutedEventArgs
    {
        public ChangeFilterEvent(RoutedEvent filterChangeEvent): base(filterChangeEvent)
        {
        }
        /// <summary>
        /// Clause of the filter
        /// </summary>
        public IList<string> ExpressionList { get; set; }
        /// <summary>
        /// Table to be updated from the view model
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Columns to be included in the select.
        /// </summary>
        public IList<string> ColumnsNames { get; set; }
    }
}