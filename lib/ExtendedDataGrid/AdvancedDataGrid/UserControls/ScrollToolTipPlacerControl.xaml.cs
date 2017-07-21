using System;
using System.ComponentModel;
using System.Data;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for CopyPastePlacerControl.xaml
    /// </summary>
    public partial class ScrollToolTipPlacerControl  : INotifyPropertyChanged
    {
        public ScrollToolTipPlacerControl()
        {
           
            DataContext = this;
            InitializeComponent();
            SourceTable = new DataTable();
            SourceTable.Columns.Add(new DataColumn("GameName", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Creator", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Publisher", typeof(string)));
            SourceTable.Columns.Add(new DataColumn("Owner", typeof(string)));
            var row = SourceTable.NewRow();
           
            for(var i=0;i<200;i++)
            {
                row = SourceTable.NewRow();
                SourceTable.Rows.Add(row);
                row["GameName"] = "Gears Of War"+i.ToString();
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
    }
}
