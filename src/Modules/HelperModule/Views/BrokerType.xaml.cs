using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for BrokerType
    /// </summary>
    public partial class BrokerType : UserControl
    {
        public string _header = KarveLocale.Properties.Resources.lrbtnTipoComisionista;
        public string Header
        {
            get
            {
                return _header;
            }
        }
        public BrokerType()
        {
            InitializeComponent();
        }
    }
}
