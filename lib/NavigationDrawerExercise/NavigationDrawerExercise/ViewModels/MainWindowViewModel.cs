using Prism.Commands;
using Prism.Mvvm;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationDrawerExercise
{
    class MainWindowViewModel: BindableBase
    {
        private ObservableCollection<ContentItem> _contents;
        private ICommand _drawerCommand;

        public MainWindowViewModel()
        {
            Contents = new ObservableCollection<ContentItem>()
            {
                new ContentItem("Maestros", "/Images/registry.png"),
                new ContentItem("Auxiliares", "/Images/helper.png"),
                new ContentItem("Facturacion", "/Images/billing.png"),
                new ContentItem("Settings", "/Images/settings.png") 

            };            
        }

        /// <summary>
        ///  This command is useful for opening a drawer.
        /// </summary>
        public ICommand OpenDrawerCommand {
            set { _drawerCommand = value; RaisePropertyChanged(); }
            get { return _drawerCommand;  }
        }
        public ObservableCollection<ContentItem> Contents
        {
            set
            {
                _contents = value;
                RaisePropertyChanged();
            }
            get
            {
                return _contents;
            }
        }
    }
}
