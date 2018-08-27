using KarveDataServices.ViewObjects;
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
        IList<BaseViewObject> baseDto = new List<BaseViewObject>();
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
        IEnumerable<BaseViewObject> Items { set; get; }
        BaseViewObject SelectedItem { set; get; }
    }
}
