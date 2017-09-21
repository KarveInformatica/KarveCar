using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.WinControls.UI;

namespace KarveGrid
{
    public class KarveGrid2: Control
    {
        private RadGridView _currentView = new RadGridView();
        private Grid _baseContainer;
        private DataTable _dataTable;

        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(KarveGrid2));


        public static readonly RoutedEvent PagingEvent =
            EventManager.RegisterRoutedEvent(
                "PagingEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGrid2));

        static KarveGrid2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(KarveGrid2),
                new FrameworkPropertyMetadata(typeof(KarveGrid2)));
        }
        public KarveGrid2() : base()
        {
            _baseContainer = new Grid();
            _baseContainer.Name = "BaseGrid";
            this.AddVisualChild(_baseContainer);
            Loaded += KarveGrid2_Loaded;
        }

        private void KarveGrid2_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _currentView;
            _baseContainer.Children.Add(host);
        }
    }
}
