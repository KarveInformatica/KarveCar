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

namespace MasterModule.Views
{

    
    /// <summary>
    /// Lógica de interacción para CumulativeSummaryControl.xaml
    /// </summary>
    public partial class CumulativeSummaryControl : UserControl
    {
        public static readonly DependencyProperty CustomMarkCommandProperty =
           DependencyProperty.Register("CustomMarkCommand", typeof(ICommand), typeof(CumulativeSummaryControl), 
               new PropertyMetadata(null));
        public static readonly DependencyProperty CustomUnmarkCommandProperty =
           DependencyProperty.Register("CustomUnmarkCommand", typeof(ICommand), typeof(CumulativeSummaryControl),
               new PropertyMetadata(null));

        public ICommand CustomMarkCommand
        {
            set
            {
                SetValue(CustomMarkCommandProperty, value);
            }
            get
            {
                return (ICommand) GetValue(CustomMarkCommandProperty);
            }
        }
        public ICommand CustomUnmarkCommand
        {
            set
            {
                SetValue(CustomUnmarkCommandProperty, value);

               
            }
            get
            {
                return (ICommand)GetValue(CustomUnmarkCommandProperty);
                
            }
        }
        public CumulativeSummaryControl()
        {
            InitializeComponent();
            this.LayoutCumulativeSummary.DataContext = this;
            this.MarkButton.Click += MarkButton_Click;
            this.UnmarkButton.Click += UnmarkButton_Click;
        }

        private void UnmarkButton_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();
            // TODO: put the appropriate parameters to convey
            if (this.CustomUnmarkCommand!=null)
            {
                CustomMarkCommand.Execute(values);
            }
        }

        private void MarkButton_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();
            // TODO: put the appropriate parameters to convey
            if (this.CustomMarkCommand != null)
            {
                CustomMarkCommand.Execute(values);
            }
        }
    }
}
