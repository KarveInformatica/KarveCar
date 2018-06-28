using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for SupplierType
    /// </summary>
    public partial class SupplierType : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnTiposProveedores;
        public string Header
        {
            get
            {
                return _header;
            }
        }
        public SupplierType()
        {
            InitializeComponent();
        }
    }
}
