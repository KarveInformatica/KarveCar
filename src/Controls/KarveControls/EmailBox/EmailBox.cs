using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KarveControls
{
    public class EmailBox: TextBox
    {
        public EmailBox() : base()
        {
        }
        static EmailBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmailBox), new FrameworkPropertyMetadata(typeof(EmailBox)));

        }
    }
}
