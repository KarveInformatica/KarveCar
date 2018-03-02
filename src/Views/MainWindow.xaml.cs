using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KarveCar.Utility;
using MahApps.Metro.Controls;
using Syncfusion.Windows.Shared;

namespace KarveCar.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            InitializeComponent();

         //   Navigation.Navigation.Frame = new Frame() {NavigationUIVisibility = NavigationUIVisibility.Hidden};
          //  Navigation.Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;

            // Navigate to the home page.
          //  this.Loaded += (sender, args) => Navigation.Navigation.Navigate(new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private IUnityContainer _container;

        public IUnityContainer UnityContainer
        {
            get { return _container; }
            set { _container = value; }

        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            //this.HamburgerMenuControl.Content = e.Content;
           // this.HamburgerMenuControl.SelectedItem = e.ExtraData ?? ((ShellViewModel)this.DataContext).GetItem(e.Uri);
           // this.HamburgerMenuControl.SelectedOptionsItem = e.ExtraData ?? ((ShellViewModel)this.DataContext).GetOptionsItem(e.Uri);
           // GoBackButton.Visibility = Navigation.Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
          //  Navigation.Navigation.GoBack();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            var menuItem = e.InvokedItem as MenuItem;
            /*
            if (menuItem != null && menuItem)
            {
               // Navigation.Navigation.Navigate(menuItem.NavigationDestination, menuItem);
            }*/

        }
    }
}