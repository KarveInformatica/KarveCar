using System;
using System.Windows.Controls;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for OfficeView.xaml
    /// </summary>
    public partial class OfficeInfoView : UserControl
    {
        public OfficeInfoView()
        {
            try
            {  
                InitializeComponent();
            } catch(Exception e)
            {
                var current = e.Message;
            }
        }
        public string Header
        { set; get; }

    }
}
