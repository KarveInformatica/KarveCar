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
    public partial class ExortToPdfPlacerControl : INotifyPropertyChanged
    {
        public ExortToPdfPlacerControl()
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
            style.ItemsSource = Enum.GetValues(typeof(ExcelTableStyle));
            codeViewer.LoadData("ExortToPdfPlacerControl");
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
                                           var sd = new SaveFileDialog {Filter = "Pdf documents (*.pdf)|*.pdf"};
                                           sd.ShowDialog();
                                           if(!string.IsNullOrEmpty(sd.FileName))
                                           {
                                               txtPdfFileLocation.Text = sd.FileName;
                                           }
                                       });
        }

        private void ExportClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPdfFileLocation.Text)) return;
            TryCatch.BeginTryCatch(() => grid.ExportToPdf(txtPdfFileLocation.Text,(ExcelTableStyle)style.SelectedValue, true));
        }
    }
}
