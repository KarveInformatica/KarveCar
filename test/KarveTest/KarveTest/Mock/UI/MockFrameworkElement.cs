using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveTest.Mock.UI
{
    class MockFrameworkElement : FrameworkElement
    {
        IList<BaseDto> baseDto = new List<BaseDto>();
        public MockFrameworkElement()
        {
            Items = baseDto;
        }
        public void RaiseLoaded()
        {
            this.RaiseEvent(new RoutedEventArgs(LoadedEvent));
        }

        public void RaiseUnloaded()
        {
            this.RaiseEvent(new RoutedEventArgs(UnloadedEvent));
        }
        IEnumerable<BaseDto> Items { set; get; }
        BaseDto SelectedItem { set; get; }
    }
}
