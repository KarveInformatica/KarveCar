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
using KarveCommon.Generic;
using KarveControls.UIObjects;

namespace KarveControls.TestUIObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // List<string> columns = SQLBuilder.SqlBuilderColumns<Window>(this);
            string sql = SQLBuilderFactory.GetSqlQueryBuilder<Window>(this);
//                getSqlQueryBuilder("dataTable",columns);
                // SqlBuilderSelect(columns, "MARCA", "AS", null, string.Empty, null);
            SimpleViewModel viewModel = (SimpleViewModel)this.DataContext;
           // viewModel.Query = sql.Query;

            
        }

       
    }
}
