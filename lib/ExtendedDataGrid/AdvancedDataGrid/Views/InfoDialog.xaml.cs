using System.Windows;

namespace MultiEventCommand.Views
{
    /// <summary>
    /// Interaction logic for InfoDialog.xaml
    /// </summary>
    public partial class InfoDialog
    {
        public InfoDialog(string message)
        {
            InitializeComponent();
            textblockMessage.Text = message;
        }

        public bool DontShow { get; private set; }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (chkDontShow.IsChecked != null) DontShow = !chkDontShow.IsChecked.Value;
            Close();
        }
    }
}
