using System.Windows.Controls;

namespace BookingModule.Views
{
    /// <summary>
    ///     Interaction logic for Booking control view
    /// </summary>
    public partial class BookingControlView : UserControl
    {
        public BookingControlView()
        {
            InitializeComponent();
        }
        public string Header { get; } = "Reservas";
    }
}