using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterModule.ViewModels;
using Prism.Commands;

namespace MasterModule.Views
{


    

    /// <summary>
    /// Interaction logic for UpperBarView.xaml
    /// </summary>
    public partial class UpperBarView : UserControl
    {
        public static readonly DependencyProperty DataSourceDependencyProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(UpperBarView), new PropertyMetadata(null, OnDataSourceChanged));

        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(object),
                typeof(UpperBarView), new PropertyMetadata(null, OnViewSourceChanged));

        public static readonly DependencyProperty PersonDependencyPropertyVisible=DependencyProperty.Register("PersonVisible", typeof(bool), typeof(UpperBarView));
        public static readonly DependencyProperty DNIPropertyVisible = DependencyProperty.Register("DNIVisible", typeof(bool), typeof(UpperBarView));


        private static void OnViewSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperBarView upperBarView = d as UpperBarView;
            if (upperBarView != null)
            {
                upperBarView.OnViewSourceChanged(e);
            }
            
        }
        private void OnViewSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            this.TipoComiSearch.SourceView = e.NewValue;
        }

        /// <summary>
        ///  Property to se collapsed a person
        /// </summary>
        public bool PersonVisible
        {
            get { return (bool) GetValue(PersonDependencyPropertyVisible); }
            set { SetValue(PersonDependencyPropertyVisible, value);}
        }
        /// <summary>
        ///  Property for the field DNI.
        /// </summary>
        public bool DNIVisible
        {
            get { return (bool) GetValue(DNIPropertyVisible); }
            set { SetValue(DNIPropertyVisible, value); }

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
        /// <summary>
        ///  This gives us a data source changed.
        /// </summary>
        /// <param name="d">Dependency object to be used.</param>
        /// <param name="e">Depenendncy propperties to be used.</param>
        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperBarView upperBarView = d as UpperBarView;
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
                this.Nif.DataObject = e.NewValue;
                this.NumeroComi.DataObject = e.NewValue;
                this.Persona.DataObject = e.NewValue;
                this.TipoComiSearch.DataSource = e.NewValue;
            }
        }


        public UpperBarView()
        {
            InitializeComponent();
        }

        
    }
}
