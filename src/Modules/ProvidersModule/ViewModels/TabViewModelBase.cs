using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.ViewModels
{

    public class TabViewModelBase : BindableBase, INavigationAware
    {
        private string _title = "";
        public const string PROVINCES = "Provincias";
        public const string COUNTRIES = "Paises";
        public const string NUMBER = "Numero";
        public const string TYPE = "Tipo";
        public const string SUPPLIERS = "Proveedores";
        public const string NOTES = "Notes";


        public string Header
        {
            get { return _title; }
            set { _title = value;  RaisePropertyChanged("Header"); }
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
   
}
