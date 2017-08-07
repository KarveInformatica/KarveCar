using Prism.Mvvm;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace PaymentTypeModule.ChargeClients.ViewModel
{
    public class GridPopUpViewModel: BindableBase
    {
        private string _queryType;
        private string _title;
        private string _firstColumnQuery;
        private string _secondColumnQuery;
        private DataTable _sourceDataTable;
        private bool _isVisible = true;
       
        public GridPopUpViewModel()
        {
        //    this.DataGridChangedSelection = new DelegateCommand<object>(OnSelectedRow);
        }

        public ICommand DataGridChangedSelection { get; set; }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }

        }

        private void OnSelectedRow(object param)
        {
            MessageBox.Show("SelectedRow Command");
        }
        public string QueryType
        {
            get { return _queryType; }
            set
            {
                _queryType = value;
                RaisePropertyChanged("QueryType");
            }

       }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }

        }
        public string FirstColumnQuery
        {
            get { return _firstColumnQuery; }
            set
            {
                _firstColumnQuery = value;
                RaisePropertyChanged("FirstColumnQuery");
            }

        }
        public string SecondColumnQuery
        {
            get { return _secondColumnQuery; }
            set
            {
                _secondColumnQuery = value;
                RaisePropertyChanged("SecondColumnQuery");
            }

        }

        public DataTable QueryTable
        {
            get { return _sourceDataTable; }
            set {
                _sourceDataTable = value;
                RaisePropertyChanged("QueryTable");
            }
        }
    }
}
