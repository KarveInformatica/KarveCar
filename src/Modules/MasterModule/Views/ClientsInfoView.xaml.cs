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
    /// Info view model provided for clients. 
    /// </summary>
    /// 
    public partial class ClientsInfoView : UserControl, ICreateRegionManagerScope
    {
        /// <summary>
        ///  Constructors. 
        /// </summary>
        public ClientsInfoView()
        {
                InitializeComponent();
        }
        /// <summary>
        ///  Header of the window.
        /// </summary>
        public string Header
        { set; get; }
        /// <summary>
        ///  Create a new region manager scope.
        /// </summary>
        public bool CreateRegionManagerScope => true;
    }
}
