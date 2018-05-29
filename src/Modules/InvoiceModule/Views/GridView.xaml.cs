#region Copyright Syncfusion Inc. 2001-2017.

// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 

#endregion

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceModule.Views
{
    /// <summary>
    ///     Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        public GridView()
        {
            InitializeComponent();
            Loaded += GridView_Loaded;
            Unloaded += GridView_Unloaded;
        }

        private void GridView_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= GridView_Loaded;
            Unloaded -= GridView_Unloaded;
            // if (this.DataContext is ViewModel)
            //     (this.DataContext as ViewModel).PropertyChanged -= GridView_PropertyChanged;
        }

        private void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            //  if (this.DataContext is ViewModel)
            //        (this.DataContext as ViewModel).PropertyChanged += GridView_PropertyChanged;
        }

        private void GridView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //  if (e.PropertyName.Equals("Expenses"))
            //      this.sfDataPager.MoveToFirstPage();
        }
    }
}