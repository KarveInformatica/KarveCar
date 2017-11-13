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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoFrameSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void c_folderDrop_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.None;
            else
                e.Effects = e.AllowedEffects;
            e.Handled = true;
        }

        private void c_folderDrop_Drop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            var folder = paths.Where((p) => System.IO.Directory.Exists(p)).FirstOrDefault();
            if (folder == null)
                return;
            c_photoFrame.ImageFolder = folder;

            c_folderDrop.Background = Brushes.BlanchedAlmond;
        }

        private void c_folderDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
                return;
            }
            e.Effects = DragDropEffects.Copy;
            c_folderDrop.Background = Brushes.Beige;
            e.Handled = true;
        }

        private void c_folderDrop_DragLeave(object sender, DragEventArgs e)
        {
            c_folderDrop.Background = Brushes.BlanchedAlmond;
        }

        private void c_interval_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (c_photoFrame == null)
                // This will be called before the photoframe has loaded
                return;
            int seconds;
            if (Int32.TryParse(c_interval.Text, out seconds))
                c_photoFrame.Interval = TimeSpan.FromSeconds(seconds);
        }
    }
}
