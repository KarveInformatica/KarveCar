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

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for UpperBarViewSupplier.xaml
    /// </summary>
    public partial class UpperBarViewSupplier : UserControl
    {
        public static readonly DependencyProperty DataSourceDependencyProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(UpperBarViewSupplier), new PropertyMetadata(null, OnDataSourceChanged));

        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperBarViewSupplier upperBarView = d as UpperBarViewSupplier;
            if (upperBarView != null)
            {
                upperBarView.OnDataSourceChanged(e);
            }
        }


       
        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(object),
                typeof(UpperBarViewSupplier), new PropertyMetadata(null, OnViewSourceChanged));

        private static void OnViewSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            UpperBarViewSupplier upperBarView = d as UpperBarViewSupplier;
            if (upperBarView != null)
            {
                upperBarView.OnViewSourceChanged(e);
            }
        }
        private void OnDataSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                this.Nif.DataObject = e.NewValue;
                this.Persona.DataObject = e.NewValue;
                this.NumeroSupplier.DataObject = e.NewValue;
                this.TipoProveSearch.DataSource = e.NewValue;
            }
        }
        private void OnViewSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            this.TipoProveSearch.SourceView = e.NewValue;
        }
        /// <summary>
        ///  SourceView dependency property.
        /// </summary>
        public object SourceView
        {
            get { return GetValue(SourceViewDependencyProperty); }
            set
            {
                SetValue(SourceViewDependencyProperty, value);
            }
        }

        /// <summary>
        ///  DataSource dependency property.
        /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceDependencyProperty); }
            set
            {
                SetValue(DataSourceDependencyProperty, value);
            }
        }
        public UpperBarViewSupplier()
        {
            InitializeComponent();
        }
    }
}
