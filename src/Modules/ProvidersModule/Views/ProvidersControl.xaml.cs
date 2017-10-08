using System;
using System.Collections.Generic;
using System.Data;
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
using ExtendedGrid.ExtendedGridControl;
using System.Windows.Media.Animation;
namespace ProvidersModule.Views
{
    /// <summary>
    /// Lógica de interacción para ProvidersControl.xaml
    /// </summary>
    public partial class ProvidersControl : UserControl, IProvidersView
    {
        public ProvidersControl()
        {
            InitializeComponent();
        }
    }
}
