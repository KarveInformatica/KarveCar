using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Regions;
using TabControlRegion.Core;
using ModuleA;
namespace ModuleA.ViewModels
{
    public class ViewBViewModel : ViewModelBase
    {
        private DalObjectDataProvider dataProvider = new DalObjectDataProvider();
        private CustomerUIObjects customerUiObjects = null;
        public ViewBViewModel()
        {
            Title = "View B";
            Initialize();
        }
        private void Initialize()
        {
            customerUiObjects = dataProvider.GetCustomers();
            OnPropertyChanged("Customers");
        }


        public CustomerUIObjects Customers
        {
            get { return customerUiObjects; }

            set
            {
                SetProperty(ref customerUiObjects, value );

            }
        }
    }
}
