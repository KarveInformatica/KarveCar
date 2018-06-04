using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// This is a line base dto.
    /// </summary>
    /// <typeparam name="InnerType"></typeparam>
    public class LineBaseDto<InnerType>: BaseDto
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
