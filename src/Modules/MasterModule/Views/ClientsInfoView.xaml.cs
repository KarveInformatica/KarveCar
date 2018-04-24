using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                var msg = e.StackTrace;
            }
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
