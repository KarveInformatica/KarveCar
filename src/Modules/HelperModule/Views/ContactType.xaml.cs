using System.Windows.Controls;
namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for ContactType.xaml
    /// </summary>
    public partial class ContactType : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnTiposContacto;
        public string Header { get { return _header; } }
        public ContactType()
        {
            InitializeComponent();
        }

    }
}
