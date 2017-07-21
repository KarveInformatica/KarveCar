using System;
using System.ComponentModel;
using System.Data;
using ExtendedGrid.Classes;
using Microsoft.Win32;
using MultiEventCommand.Classes;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for ExportToExcelPlacerControl.xaml
    /// </summary>
    public partial class ExortToCSvPlacerControl : INotifyPropertyChanged
    {
        public ExortToCSvPlacerControl()
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

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            TryCatch.BeginTryCatch(()=>
                                       {
                                           var sd = new SaveFileDialog {Filter = "CSv documents (*.csv)|*.csv"};
                                           sd.ShowDialog();
                                           if(!string.IsNullOrEmpty(sd.FileName))
                                           {
                                               txtCsvFileLocation.Text = sd.FileName;
                                           }
                                       });
        }

        private void ExportClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCsvFileLocation.Text)) return;
            TryCatch.BeginTryCatch(() => grid.ExportToCsv("Test", txtCsvFileLocation.Text, true));
        }
    }
}
