using System;
using System.ComponentModel;
using System.Data;


namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for ExportToExcelPlacerControl.xaml
    /// </summary>
    public partial class ColumnSplitterPlacerControl : INotifyPropertyChanged
    {
        public ColumnSplitterPlacerControl()
        {
           
            DataContext = this;
            InitializeComponent();
            SourceTable = new DataTable();
            SourceTable.Columns.Add(new DataColumn("GameName", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Creator", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Publisher", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Owner", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2006", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2007", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2008", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2009", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2010", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2011", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2012", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("2013", typeof(string)));
            var row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "World Of Warcraft";
            row["Creator"] = "Blizzard";
            row["Publisher"] = "Blizzard";
            row["Owner"] = "Mark";
            row["2006"] = null;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Halo";
            row["Creator"] = "Bungie";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Bill";
            row["2006"] = null;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Gears Of War";
            row["Creator"] = "Epic";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Steve";
            row["2006"] = null;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Gears Of War";
            row["Creator"] = "Epic";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Steve";
            row["2006"] = null;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Gears Of War";
            row["Creator"] = "Epic";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Steve";
            row["2006"] = null;
            for(int i=0;i<2;i++)
            {
                row = SourceTable.NewRow();
                SourceTable.Rows.Add(row);
                row["GameName"] = "Gears Of War";
                row["Creator"] = "Epic";
                row["Publisher"] = "Microsoft";
                row["Owner"] = "Steve";
                row["2006"] = null;
            }
            codeViewer.LoadData("ColumnSplitterPlacerControl");
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
    }
}
