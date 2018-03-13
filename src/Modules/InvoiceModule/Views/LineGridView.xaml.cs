#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;

namespace InvoiceModule.Views
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class LineGridView : UserControl
    {
        public LineGridView()
        {
            InitializeComponent();
            this.SyncfusionGrid.AllowEditing = true;
            this.SyncfusionGrid.AllowDraggingRows = true;
            this.SyncfusionGrid.AllowDeleting = true;
            this.SyncfusionGrid.GridCopyOption = GridCopyOption.CopyData | GridCopyOption.CutData;
            this.SyncfusionGrid.GridPasteOption = GridPasteOption.PasteData;
          
         //   this.sfDataPager.MoveToFirstPage();
        }

        private void SyncfusionGrid_GridPasteContent(object sender, GridCopyPasteEventArgs e)
        {
            MessageBox.Show("Pasted");
        }

        private void SyncfusionGrid_GridCopyContent(object sender, GridCopyPasteEventArgs e)
        {
            MessageBox.Show("Copied");
        }
    }
}
