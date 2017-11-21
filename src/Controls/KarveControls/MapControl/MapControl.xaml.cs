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

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        /// <summary>
        ///  Map Dependency property.
        /// </summary>
        public static readonly DependencyProperty MapDependencyProperty = DependencyProperty.Register("DataObject",
            typeof(object), typeof(MapControl));

        /// <summary>
        /// Data Object dependency property.
        /// </summary>
        public static DependencyProperty DataObjectDependencyProperty
            = DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(MapControl),
                new PropertyMetadata(null, OnDataObjectChanged));

        /// <summary>
        ///  This is the data object to be saved.
        /// </summary>
        public object DataObject
        {
            get { return GetValue(DataObjectDependencyProperty); }
            set { SetValue(DataObjectDependencyProperty, value); }
        }

        private static void OnDataObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MapControl control = d as MapControl;
            if (control != null)
            {
            }
        }
        /// <summary>
        ///  Map control.
        /// </summary>
        public MapControl()
        {
            InitializeComponent();
        }
    }
}
