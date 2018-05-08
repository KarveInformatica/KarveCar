// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using KarveControls.Interactivity.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace KarveControls.Interactivity.Views
{
    /// <summary>
    /// Interaction logic for ItemSelectionView.xaml
    /// </summary>
    public partial class ItemSelectionView : UserControl
    {
        public ItemSelectionView()
        {
            this.DataContext = new ItemSelectionViewModel();
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            /*
            Window win = ((UserControl)sender).Parent as Window;
            if (win != null)
            {

                win.WindowStyle = WindowStyle.;
               

            }*/

        }
    }
}
