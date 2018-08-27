using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    /// This is a line base viewObject.
    /// </summary>
    /// <typeparam name="InnerType"></typeparam>
    public class LineBaseViewObject<InnerType>: BaseViewObject
    {
        private IEnumerable<InnerType> _items;

        public IEnumerable<InnerType> Items { set
            {
                _items = value;
                RaisePropertyChanged();
            }
            get
            {
                return _items;
            }
        }
    }
}
