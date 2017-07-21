using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for CopyPastePlacerControl.xaml
    /// </summary>
    public partial class FrozenRowsPlacerControl  : INotifyPropertyChanged
    {
        public FrozenRowsPlacerControl()
        {
           
            DataContext = this;
            InitializeComponent();
            SourceTable = new DataTable();
            SourceTable.Columns.Add(new DataColumn("GameName", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Creator", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Publisher", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Owner", typeof(string)));

            for(var i=0;i<200;i++)
            {
                DataRow row = SourceTable.NewRow();
                SourceTable.Rows.Add(row);
                row["GameName"] = "Gears Of War "+i.ToString(CultureInfo.InvariantCulture);
                row["Creator"] = "Epic";
                row["Publisher"] = "Microsoft";
                row["Owner"] = "Steve";
            }
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

        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }

        private void GridLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            grid.FrozenRowCount = 5;
            txtFrozenRowCount.Text = "5";
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrozenRowCount.Text))return;
            if(grid==null)return;
            grid.FrozenRowCount = Convert.ToInt32(txtFrozenRowCount.Text);
        }

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var frozenRowCount = Convert.ToInt32(txtFrozenRowCount.Text);
            if(frozenRowCount+1<grid.Items.Count)
            {
                txtFrozenRowCount.Text = (frozenRowCount + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void ButtonClick1(object sender, System.Windows.RoutedEventArgs e)
        {
            var frozenRowCount = Convert.ToInt32(txtFrozenRowCount.Text);
            if (frozenRowCount!=0)
            {
                txtFrozenRowCount.Text = (frozenRowCount - 1).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
