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

namespace KarveGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Name"));
            table.Columns.Add(new DataColumn("Surname"));
            table.Columns.Add(new DataColumn("Address"));
            table.Columns.Add(new DataColumn("Place"));
            table.Columns.Add(new DataColumn("City"));
            table.Columns.Add(new DataColumn("Phone"));
            table.Columns.Add(new DataColumn("Fake"));
            table.Columns.Add(new DataColumn("Super"));
            table.Columns.Add(new DataColumn("Name1"));
            table.Columns.Add(new DataColumn("Surname1"));
            table.Columns.Add(new DataColumn("Address1"));
            table.Columns.Add(new DataColumn("Place1"));
            table.Columns.Add(new DataColumn("City1"));
            table.Columns.Add(new DataColumn("Phone1"));
            table.Columns.Add(new DataColumn("Fake1"));
            table.Columns.Add(new DataColumn("Super1"));

            double maxRecords = 20000 * 10;




        for (double i = 0; i < maxRecords ; ++i)
            {
                DataRow row = table.NewRow();
                row["Name"] = "Giorgio";
                row["Surname"] = "Zoppi";
                row["Address"] = "Via Biancamano 125";
                row["Place"] = "Pitelli";
                row["City"] = "La Spezia";
                row["Phone"] = "0187560874";
                row["Fake"] = "4459340490";
                row["Super"] = "44593422";
                row["Name1"] = "Giorgio";
                row["Surname1"] = "Zoppi";
                row["Address1"] = "Via Biancamano 125";
                row["Place1"] = "Pitelli";
                row["City1"] = "La Spezia";
                row["Phone1"] = "0187560874";
                row["Fake1"] = "4459340490";
                row["Super1"] = "44593422";
                table.Rows.Add(row);
            }
          //  DataTable set = new DataTable();
           // set.Tables.Add(table);
            this.MainGrid.SourceView = table;
        }
    }
}
