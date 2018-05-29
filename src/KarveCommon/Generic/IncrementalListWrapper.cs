using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public class IncrementalListWrapper<T, Dto>
    {
        public Dto PagedView { set; get; }
        public T PagedValue { set; get; }
        private IncrementalList<Dto> dtoWrapper;
        private IDbConnection _connection;
        public IncrementalListWrapper(IDbConnection connection, Dto startData)
        {
            _connection = connection;
            dtoWrapper = new IncrementalList<Dto>(LoadMoreItems);
        }

        private void LoadMoreItems(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }
    }
}
