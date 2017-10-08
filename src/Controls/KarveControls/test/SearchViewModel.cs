using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveControls
{
    public class SearchViewModel: BindableBase
    {
        private string _dataField;
        private string _dataLabel = "Nombre";
        private string _width;
        private DataTable _itemSource;

        private DataTable _dataTable;

        public DataTable AuxTable
        {
            get { return _itemSource; }
            set { _itemSource = value; RaisePropertyChanged(); }

        }
        public DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; RaisePropertyChanged(); }

        }
        public string Width
        {
            get { return _width; }
            set { _width = value; RaisePropertyChanged(); }
        }
        public string DataField
        {
            get { return _dataField; }
            set { _dataField = value; RaisePropertyChanged("DataField"); }
        }

        public string Label
        {
            get { return _dataLabel; }
            set { _dataLabel = value; RaisePropertyChanged(); }
        }
        public ICommand MagnifierPressCommand { set; get; }

        private void OnValue(object o)
        {
            MessageBox.Show("Name");
        }

        private void Open(object o)
        {
            MessageBox.Show("MyMessageBox");
        }
        public ICommand OpenItem { set; get; }

        public SearchViewModel()
        {
            
            this.MagnifierPressCommand = new DelegateCommand<object>(OnValue);
            this.OpenItem = new DelegateCommand<object>(Open);
            DataTable table = new DataTable();
           table.Columns.Add("Name");
            table.Columns.Add("Surname");
            DataRow row = table.NewRow();
            row["Name"] = "Giorgio";
            row["Surname"] = "Zoppi";
            table.Rows.Add(row);
            row = table.NewRow();
            row["Name"] = "Simone";
            row["Surname"] = "Lupi";
            table.Rows.Add(row);
            this.AuxTable = table;
            this.DataField = "Name";
            this.Label = "Nombre";
            this.DataTable = new DataTable();
            this.DataTable.Columns.Add("Name");
            this.DataTable.Columns.Add("Surname");
            row = this.DataTable.NewRow();
            row["Name"] = "Giorgio";
            row["Surname"] = "Zoppi";
            this.DataTable.Rows.Add(row);
            row = this.DataTable.NewRow();
            row["Name"] = "Simone";
            row["Surname"] = "Lupi";
            this.DataTable.Rows.Add(row);
        }
    }
}