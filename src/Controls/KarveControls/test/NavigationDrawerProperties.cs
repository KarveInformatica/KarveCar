using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControlsTest
{

    #region Copyright Syncfusion Inc. 2001-2017.
    // Copyright Syncfusion Inc. 2001-2017. All rights reserved.
    // Use of this code is subject to the terms of our license.
    // A copy of the current license can be obtained at any time by e-mailing
    // licensing@syncfusion.com. Any infringement will be prosecuted under
    // applicable laws. 
    #endregion
    using Syncfusion.UI.Xaml.NavigationDrawer;
    using Syncfusion.Windows.Shared;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace KarveControlsTest
    {
        public class NavigationDrawerProperties : NotificationObject
        {
            public NavigationDrawerProperties()
            {
                Contents = new ObservableCollection<ListContent>();
                Contents.Add(new ListContent() { Name = "Home" });
                ListContent content = new ListContent();
                Contents.Add(new ListContent() { Name = "TextBox" });
                Contents.Add(new ListContent() { Name = "Calendar" });
            }
            private ObservableCollection<ListContent> contents;

            public ObservableCollection<ListContent> Contents
            {
                get { return contents; }
                set { contents = value; RaisePropertyChanged("Contents"); }
            }
            private Position position = Position.Left;

            public Position SlidePosition
            {
                get { return position; }
                set { position = value; RaisePropertyChanged("SlidePosition"); }
            }

            private Transition transition = Transition.SlideOnTop;

            public Transition SlideTransition
            {
                get { return transition; }
                set { transition = value; RaisePropertyChanged("SlideTransition"); }
            }
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

}
