using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.WinControls.UI;

namespace KarveGrid
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public class KarveGrid : Control
    {
        private RadGridView _view = new RadGridView();
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        System.Windows.Forms.Integration.WindowsFormsHost
        public KarveGrid()
        {
    
            this.DataGrid.DataContext = this;
        }
        private void KarveGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _view;
            DataGrid.Children.Add(host);          
        }

        protected override void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
           
        }

        public override void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();
            if (!string.IsNullOrEmpty(field))
            {
                Binding oBind = new Binding("ItemsSource");
                oBind.Source = dta;
                oBind.Mode = BindingMode.TwoWay;
                oBind.ValidatesOnDataErrors = true;
                oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                if (rules != null)
                {
                    foreach (ValidationRule rule in rules)
                    {
                        oBind.ValidationRules.Add(rule);
                    }
                }
                SetBinding(ItemsSource, oBind);
            }
        }

        // unimplemnted properties.
        protected override void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        protected override void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        protected override void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        protected override void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
        }

    }
}
