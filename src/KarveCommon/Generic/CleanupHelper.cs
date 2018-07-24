using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public static class CleanupHelper<T>
    {
        public static void CleanList(IEnumerable<T> list)
        {
            if (list is IncrementalList<T> summary)
            {
                summary.Clear();
            }
        }
    }
}
