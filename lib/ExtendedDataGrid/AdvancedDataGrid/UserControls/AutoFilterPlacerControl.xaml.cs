using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Data;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for PlacerControl.xaml
    /// </summary>
    public partial class AutoFilterPlacerControl : INotifyPropertyChanged
    {
        public AutoFilterPlacerControl()
        {

            DataContext = this;
            InitializeComponent();
            SourceTable = new DataTable();
            SourceTable.Columns.Add(new DataColumn("GameName", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Creator", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Publisher", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Owner", typeof(string)));
            var row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "World Of Warcraft";
            row["Creator"] = "Blizzard";
            row["Publisher"] = "Blizzard";
            row["Owner"] = "Mark";
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Halo";
            row["Creator"] = "Bungie";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Bill";
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Gears Of War";
            row["Creator"] = "Epic";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Steve";
            codeViewer.LoadData(this.GetType().Name);
        }

        DataTable _sourceTable;

        public DataTable SourceTable
        {
            get
            {

                return _sourceTable;
            }
            set
            {
                _sourceTable = value;
                NotifyPropertyChanged("SourceTable");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
            
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RollNumber { get; set; }
    }
}
