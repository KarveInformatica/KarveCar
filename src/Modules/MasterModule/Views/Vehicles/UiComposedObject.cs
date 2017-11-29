using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterModule.Views.Vehicles
{
    public class UiComposedObject: BindableBase
    {
        private object _dataSource;
        private ICommand _command;
        private object _stringConstants;

        public string DataSourcePath1 { set; get; }
        public string DataSourcePath2 { set; get; }
        public string DataSourcePath3 { set; get; }
        public string DataText { set; get; }
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

        public ICommand ItemCommandChanged
        {
            get { return _command; }
            set
            {
                _command = value; RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  String constants.
        /// </summary>
        public object StringConstants
        {
            get { return _stringConstants;  }
            set { _stringConstants = value;
                  RaisePropertyChanged(); }
        }
    }
}
