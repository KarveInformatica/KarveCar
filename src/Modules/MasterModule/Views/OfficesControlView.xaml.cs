using System.Windows.Controls;
using KarveCommonInterfaces;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for OfficesControlSummary.xaml
    /// </summary>
    public partial class OfficesControlView : UserControl, ICreateRegionManagerScope
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnOficinas;
        public OfficesControlView()
        {
            InitializeComponent();
        }
        public string Header
        {
            set
            {
                _header = value;
            }
            get
            {
                return _header;
            }
        }

        public bool CreateRegionManagerScope => false;
    }
}
