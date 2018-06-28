using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for CountryRegions
    /// </summary>
    public partial class CountryRegions : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnComunidadAutonoma;
        public string Header
        {
            get
            {
                return _header;
            }
        }
        public CountryRegions()
        {
            InitializeComponent();
        }
    }
}
