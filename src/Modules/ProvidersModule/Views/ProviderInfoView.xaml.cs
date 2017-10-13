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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for ProviderInfoView.xaml
    /// </summary>
    public partial class ProviderInfoView : UserControl, ISupplierInfoView
    {
        public ProviderInfoView()
        {
            InitializeComponent();
            Header = "Notes";
           // this.SupplierBriefSummary.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
                
        }
        public string Header
        { set; get; }

        /// <summary>
        ///  Scale up the botton in the accumulado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

            /*
       
        private void ScaleUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UIElement cellContents = (UIElement)sender;

            // Bring the cell forward so it doesn't get occluded by other cells when animating.
            Panel.SetZIndex(cellContents, Panel.GetZIndex(cellContents) + 1);

            // Create a ScaleTransform, leave it at original scale)
            cellContents.RenderTransform = new ScaleTransform(1, 1);

            // Create an animation to animate up the cell's scale from 1X to 1.5X.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1;
            myDoubleAnimation.To = 1.5;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            // Begin the animation            
            cellContents.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, myDoubleAnimation);
            cellContents.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, myDoubleAnimation);
        }

        private void ScaleDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UIElement cellContents = (UIElement)sender;

            // Create a ScaleTransform for the cell at its current enlarged scale size
            cellContents.RenderTransform = new ScaleTransform(1.5, 1.5);

            // Create an animation to animate down the cell's scale from 1.5X to 1.0X.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Timeline.SetDesiredFrameRate(myDoubleAnimation, 20);
            myDoubleAnimation.From = 1.5;
            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            // Begin the animation            
            cellContents.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, myDoubleAnimation);
            cellContents.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, myDoubleAnimation);

            // Reset the Button's Z order
            Panel.SetZIndex(cellContents, 0);
        }

        private void Maximize(object sender, System.Windows.RoutedEventArgs e)
        {
            // This is what the logical tree looks like:
            //                   DockPanel
            //                  /         \
            //                Button    Viewbox
            //                              \
            //                              Live widget (or bitmap preview)
            // 
            // For the FinancialStatement and SalesReport we have a bitmap preview and
            // not the live widget sine it doesn't make sense to have a live preview of
            // a large document. So for these two, we'll need to hook the live widget up to the
            // root panel of the tree when the maximize button is pressed.
            // For all other widgets, we want to get to the widget 
            // and disconnect it from it's current location in the tree,
            // and then reconnect it at the root so it's maximized.
            // 
            // Read more about logical trees here:
            // http://windowssdk.msdn.microsoft.com/library/default.asp?url=/library/en-us/wpf_conceptual/html/e83f25e5-d66b-4fc7-92d2-50130c9a6649.asp

            // Get to the DockPanel
            Button maximizeButton = (Button)sender;
            DockPanel dockPanel = (DockPanel)maximizeButton.Parent;
            _currentDashboardViewbox = (Viewbox)dockPanel.Children[2];
            UIElement widget;


            // Get to the widget and remember where its current place is
            // so that we can put it back when the user hits the minimize button
            widget = _currentDashboardViewbox.Child;

            //Disconnect widget from its current location in the tree
            _currentDashboardViewbox.Child = null;


            // Create a new DockPanel so that we can place the widget in 
            // it and a minimize button.
            DockPanel maximizedDockPanel = new DockPanel();
            maximizedDockPanel.Background = (LinearGradientBrush)FindResource("CellBrush");

            // Create the minimize button
            Button minimizeButton = new Button();
            minimizeButton.Background = Brushes.Transparent;

            minimizeButton.SetValue(DockPanel.DockProperty, Dock.Top);
            minimizeButton.Click += new RoutedEventHandler(Minimize);
            minimizeButton.Width = 60;
            minimizeButton.Height = 20;
            minimizeButton.VerticalAlignment = VerticalAlignment.Top;
            minimizeButton.HorizontalAlignment = HorizontalAlignment.Right;

            // Setup the new Panel with our widget and the 
            // minimize button
            maximizedDockPanel.Children.Add(minimizeButton);
            if (widget != null)
                maximizedDockPanel.Children.Add(widget);

            // Finally add the new DockPanel containing our widget
            // to the root so that it's maximized.
            RootGrid.Children.Add(maximizedDockPanel);

            // Create a nice fade in effect when widget is maximized 
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            maximizedDockPanel.BeginAnimation(DockPanel.OpacityProperty, myDoubleAnimation);

        }
        private void Minimize(object sender, System.Windows.RoutedEventArgs e)
        {
            Button minimizeButton = (Button)sender;
            DockPanel maximizedDockPanel = (DockPanel)minimizeButton.Parent;

            UIElement widget = maximizedDockPanel.Children[1];

            maximizedDockPanel.Children.RemoveAt(1);
            RootGrid.Children.RemoveAt(1);


            _currentDashboardViewbox.Child = widget;


            // Create a nice fade out effect when widget is minimized
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(.75));
            RootGrid.BeginAnimation(Grid.OpacityProperty, myDoubleAnimation);
        }

        private Viewbox _currentDashboardViewbox;
    */   
    }
    
    

}
