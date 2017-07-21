using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;

namespace KarveCommon.Generic
{
        public class ViewModelBase : BindableBase, INavigationAware
        {
        // TODO understand this.
            public virtual bool IsNavigationTarget(NavigationContext navigationContext)
            {
                return false;
            }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
