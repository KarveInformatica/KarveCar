using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace MasterModule.Views.VehicleAssurance
{

    /// <summary>
    ///  Object for generating an item control with items.
    /// </summary>
    public class UiMetaObject : BindableBase
    {
        private string _labelText = string.Empty;
        private string _changedSourcePath = string.Empty;
        private ICommand _changedItem;
        private object _changedSource = null;
        /// <summary>
        /// Delegate to be assigned in a item
        /// </summary>
        public ICommand ChangedItem {
            set {
                _changedItem = value;
                RaisePropertyChanged();
            }
            get
            {
                return _changedItem;
            }
        }
        /// <summary>
        /// DataSource to be used
        /// </summary>
        public object DataSource {
            set
            {
               _changedSource =  value;
                RaisePropertyChanged();
            }
            get
            {
                return _changedSource;
            }
        }
        /// <summary>
        /// Data Source Path to be used
        /// </summary>
        public string DataSourcePath
        {
            set
            {
                _changedSourcePath = value;
                RaisePropertyChanged();
            }
            get
            {
                return _changedSourcePath;
            }
        }
        /// <summary>
        /// Label text to be used.
        /// </summary>
        public string LabelText
        {
            set { _labelText = value; RaisePropertyChanged(); }
            get { return _labelText; }
        }
    }
    
}
