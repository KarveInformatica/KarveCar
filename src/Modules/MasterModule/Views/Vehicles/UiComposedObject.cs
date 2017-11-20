using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.Views.Vehicles
{
    public class UiComposedObject: BindableBase
    {
        private object _dataSource;
        public string DataSourcePath1 { set; get; }
        public string DataSourcePath2 { set; get; }
        public string DataSourcePath3 { set; get; }
        public object DataSource
        {
            set
            {
                _dataSource = value;
                RaisePropertyChanged();
            }
            get
            {
                return _dataSource;
            }
        }
    }
}
