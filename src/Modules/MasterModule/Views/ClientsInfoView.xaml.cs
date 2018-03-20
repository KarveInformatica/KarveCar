using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using KarveCommonInterfaces;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    ///
    public partial class ClientsInfoView : UserControl, ICreateRegionManagerScope
    {
        private Stopwatch watch = new Stopwatch();
        public ClientsInfoView()
        {
                watch.Start();
                InitializeComponent();
                watch.Stop();
                long elapsed = watch.ElapsedMilliseconds;
                var m = "";
                
            
        }
        public string Header
        { set; get; }

        public bool CreateRegionManagerScope => true;
    }
}
