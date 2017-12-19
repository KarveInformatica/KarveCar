using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLog;
namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for VehicleInfoView.xaml
    /// </summary>
    public partial class VehicleInfoView : UserControl
    {
        private string _header = string.Empty;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public VehicleInfoView()
        {
            Stopwatch initCStopwatch = new Stopwatch();
            initCStopwatch.Start();
            InitializeComponent();
            initCStopwatch.Stop();
            long elapsedTime = initCStopwatch.ElapsedMilliseconds;
            logger.Debug("Elapsed time for loading Vehicle ms" + elapsedTime);
        }

        public string Header { set { _header = value; } get { return _header; } }
    }
}
