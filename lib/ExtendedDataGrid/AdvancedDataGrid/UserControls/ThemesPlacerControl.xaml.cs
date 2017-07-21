using System;
using System.ComponentModel;
using System.Data;
using ExtendedGrid.ExtendedGridControl;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for CopyPastePlacerControl.xaml
    /// </summary>
    public partial class ThemesPlacerControl  : INotifyPropertyChanged
    {
        private bool _isLoading = false;
        public ThemesPlacerControl()
        {
            _isLoading = true;
            DataContext = this;
            InitializeComponent();
            SourceTable = new DataTable();
            SourceTable.Columns.Add(new DataColumn("GameName", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Creator", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Publisher", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Owner", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Count", typeof(int)));
            var row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "World Of Warcraft";
            row["Creator"] = "Blizzard";
            row["Publisher"] = "Blizzard";
            row["Owner"] = "Mark";
            row["Count"] = 1;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Halo";
            row["Creator"] = "Bungie";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Bill";
            row["Count"] = 2;
            row = SourceTable.NewRow();
            SourceTable.Rows.Add(row);
            row["GameName"] = "Gears Of War";
            row["Creator"] = "Epic";
            row["Publisher"] = "Microsoft";
            row["Owner"] = "Steve";
            row["Count"] = 3;
            for(var i=0;i<200;i++)
            {
                row = SourceTable.NewRow();
                SourceTable.Rows.Add(row);
                row["GameName"] = "Gears Of War";
                row["Creator"] = "Epic";
                row["Publisher"] = "Microsoft";
                row["Owner"] = "Steve";
                row["Count"] = i+4;
            }

            var source = Enum.GetValues(typeof (ExtendedDataGrid.Themes));
            cmbTheme.ItemsSource = source;
            cmbTheme.SelectedIndex = 0;
            cmbTheme.IsEditable = false;
            _isLoading = false;
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

        private void CmbThemeSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           if(_isLoading)return;
            var selectedTheme = Convert.ToString(cmbTheme.SelectedItem);
            var selecttedTheme = (ExtendedDataGrid.Themes)Enum.Parse(typeof(ExtendedDataGrid.Themes), selectedTheme);
            grid.Theme = selecttedTheme;

        }

    }
}
