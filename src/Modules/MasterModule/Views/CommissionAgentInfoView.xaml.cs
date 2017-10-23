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
using KarveControls.UIObjects;
using KarveControls.VisualTreeDumper;
using MasterModule.Interfaces;
using MasterModule.ViewModels;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for CommissionAgentInfoView.xaml
    /// </summary>
    public partial class CommissionAgentInfoView : UserControl, ICommissionAgentView
    {
        public CommissionAgentInfoView()
        {
            var obj = this.DataContext;
            InitializeComponent();
            IDictionary<string, List<string>> currentList = new Dictionary<string, List<string>>();
            IDictionary<string, List<string>> assistList = new Dictionary<string, List<string>>();
            VisualTreeDumper.CollectData(this, ref currentList, ref assistList);
            ///   SQLBuilder.SqlLogicalTreeFieldCollector(this, ref currentList, ref assistList);
            int i = currentList.Count;
            int j = assistList.Count;

            //    var obj1 = currentList;

        }

        public string Header
        { set; get; }
    }
}
