using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersModule.ViewModels
{

    public class TabViewModelBase : BindableBase, INavigationAware
    {
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value;  RaisePropertyChanged("Title"); }
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
   
}
