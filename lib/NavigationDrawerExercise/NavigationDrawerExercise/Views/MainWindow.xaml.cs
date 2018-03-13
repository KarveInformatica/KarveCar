using NavigationDrawerExercise.Views;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationDrawerExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        private DashboardView mainBoard = new DashboardView();
        private MasterBoard masterboard = new MasterBoard();
        private InvoiceBoard invoiceBoard = new InvoiceBoard();
        private HelperBoard helperBoard = new HelperBoard();
      
        public MainWindow()
        {
            InitializeComponent();


            mainBoard.NavigationDrawer = this.Drawer;
            this.Drawer.ContentView = mainBoard;
            //  this.button.Click += Button_Click;
//            this.Drawer.ContentView = mainBoard;
      //      mainBoard
        }
        public SfNavigationDrawer NavigationDrawer { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SfNavigationDrawer sfNavigationDrawer = this.Drawer;
          
            if (sfNavigationDrawer != null)
            {

                if (sfNavigationDrawer.IsOpen)
                {
                    sfNavigationDrawer.ToggleDrawer();
                }
                else
                {
                    sfNavigationDrawer.ToggleDrawer();
                }
            }
        }
    }
}
