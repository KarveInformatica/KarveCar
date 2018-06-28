using System.Windows.Controls;

namespace BookingModule.Views
{
    /// <summary>
    /// Interaction logic for ReservationRequestControl
    /// </summary>
    public partial class ReservationRequestControl : UserControl
    {
        public ReservationRequestControl()
        {
            Header = "Peticion";
            InitializeComponent();
        }
        public string Header { set; get; }
    }
}
