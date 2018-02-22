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
using System.Windows.Threading;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for KarveClock.xaml
    /// </summary>
    public partial class KarveClock : UserControl
    {
        private DispatcherTimer timer;
        public KarveClock()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            int min = DateTime.Now.Minute;
            var value = string.Empty;
            if (min < 9)
            {
                value = "0" + min;
            }
            else
            {
                value = ""+min;
            }
            clockText.Text = "" + DateTime.Now.Hour + ":"
            + min + ":"
            + DateTime.Now.Second;

            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Start();
            timer.Tick += new EventHandler(delegate (object s, EventArgs a)
            {
                min = DateTime.Now.Minute;
                value = string.Empty;
                if (min < 9)
                {
                    value = "0" + min;
                }
                else
                {
                    value = "" + min;
                }
                clockText.Text = "" + DateTime.Now.Hour + ":"
              + value + ":"
              + DateTime.Now.Second;


            });
        }
    }
}
