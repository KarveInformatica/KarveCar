using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;


namespace KarveControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class KarveGrid : UserControl
    {
        private RadGridView _view;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static readonly DependencyProperty ItemsSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(DataTable),
                typeof(KarveGrid), new PropertyMetadata(new DataTable(), OnItemSourceUpdate));

        private static void OnItemSourceUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGrid control = d as KarveGrid;
            if (control != null)
            {
                control.OnPropertyChanged("ItemsSource");
                control.OnItemsSourceChanged(e);
            }
        }
        private void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._view.DataSource = table;
        }
        public KarveGrid()
        {
            InitializeComponent();
            this.DataGrid.DataContext = this;
        }
        private void KarveGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            _view = new RadGridView();
            host.Child = _view;
            DataGrid.Children.Add(host);
          
        }
    }
}
