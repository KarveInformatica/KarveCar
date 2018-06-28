using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for ActivitySector
    /// </summary>
    public partial class ActivitySector : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnSectoresActividad;
        public string Header
        {
            get
            {
                return _header;
            }
        }
        public ActivitySector()
        {
            InitializeComponent();
        }
    }
}
