using MultiEventCommand.ViewModels;

namespace MultiEventCommand.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard
    {
        readonly DashboardViewModel _model=new DashboardViewModel();
        public Dashboard()
        {
         
            DataContext = _model;
            InitializeComponent();
            
        }

      
    }
}
