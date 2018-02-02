using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KarveCar.Logic.Generic
{
    public class NavigationDrawerProperties : NotificationObject
    {
        public NavigationDrawerProperties()
        {
            Contents = new ObservableCollection<ListContent>();
            Contents.Add(new ListContent() { Name = "Home" });
            Contents.Add(new ListContent() { Name = "Maestro" });
            Contents.Add(new ListContent() { Name = "Photos" });
        }
        private ObservableCollection<ListContent> contents;

        public ObservableCollection<ListContent> Contents
        {
            get { return contents; }
            set { contents = value; RaisePropertyChanged("Contents"); }
        }
        private Clock.Position position = Clock.Position.Left;

        public Clock.Position SlidePosition
        {
            get { return position; }
            set { position = value; RaisePropertyChanged("SlidePosition"); }
        }

        /*
        public Transition.Transition SlideTransition
        {
            get { return transition; }
            set { transition = value; RaisePropertyChanged("SlideTransition"); }
        }
        */

    }

    public class ListContent : NotificationObject
    {
        private string name;
        private string content;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name"); }
        }

        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged("Content"); }
        }
    }
    
}
