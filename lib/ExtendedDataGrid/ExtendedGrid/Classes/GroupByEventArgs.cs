using System;
using System.Windows.Controls;

namespace ExtendedGrid.Classes
{
    public class GroupByEventArgs:EventArgs
    {
        public DataGridColumn Column { get; set; }
    }
}
