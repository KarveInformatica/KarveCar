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

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    ///
    public partial class ClientsInfoView : UserControl
    {
        private Stopwatch watch = new Stopwatch();
        public ClientsInfoView()
        {
            try
            {
                watch.Start();
                InitializeComponent();
                watch.Stop();
                long elapsed = watch.ElapsedMilliseconds;
                
            }
            catch (Exception e)
            {
                var v = e.Message;
            }
        }
        public string Header
        { set; get; }

       
    }
}
