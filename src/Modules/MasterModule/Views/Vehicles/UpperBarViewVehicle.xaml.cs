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
    /// Interaction logic for UpperBarViewVehicle.xaml
    /// </summary>
    public partial class UpperBarViewVehicle : UserControl
    {

        /// <summary>
        /// DataSource is done.
        /// </summary>
        public static readonly DependencyProperty DataSourceDependencyProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(UpperBarViewVehicle), new PropertyMetadata(null, OnDataSourceChanged));

        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperBarViewVehicle upperBarView = d as UpperBarViewVehicle;
            if (upperBarView != null)
            {
                upperBarView.OnDataSourceChanged(e);
            }
        }

        private void OnDataSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            var dataSourceValue = e.NewValue;
            if (e.NewValue != null)
            {
                this.Codigo.DataObject = e.NewValue;
                this.Colore.DataSource = e.NewValue;
                this.Marca.DataSource = e.NewValue;
                this.Matricula.DataObject = e.NewValue;
                this.Modelo.DataSource = e.NewValue;  
            }
        }
        /// <summary>
        ///  SourceView dependncy properties.
        /// </summary>
        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(object),
                typeof(UpperBarViewVehicle), new PropertyMetadata(null, OnViewSourceChanged));

        private static void OnViewSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperBarViewVehicle upperBarView = d as UpperBarViewVehicle;
            if (upperBarView != null)
            {
                upperBarView.OnViewSourceChanged(e);
            }
        }

        private void OnViewSourceChanged(DependencyPropertyChangedEventArgs d)
        {
          IEnumerable<object> value =  d.NewValue as IEnumerable<object>;
            
          if (value != null)
          {
              var v = value as object[] ?? value.ToArray();
              if (v.Count() != 3)
              {
                  return;
              }
              this.Colore.SourceView = v.ElementAt(0);
              this.Marca.SourceView = v.ElementAt(1);
             // this.Modelo.So = v.ElementAt(2);
          }
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
        public UpperBarViewVehicle()
        {
            InitializeComponent();
           
        }
    }
}
