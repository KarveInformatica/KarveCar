using Prism.Mvvm;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace PaymentTypeModule.ChargeClients.ViewModel
{
    public class GridPopUpViewModel : BindableBase
    {
        private QueryTypeEnum _queryType;
        private string _title;
        private string _firstColumnQuery;
        private string _secondColumnQuery;
        private DataTable _sourceDataTable;
        private bool _isVisible = true;
        private DelegateCommand<object> _currentCommand;
        private int _selectedIndex;
        public ICommand DataGridChangedSelection { get; set; }
        public enum QueryTypeEnum {
            BillingAccount = 0,
            Banks = 1,
            OfficeAccount,
            Account,
            CommissionAccount,
            CommissionBank
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }
        public GridPopUpViewModel()
        {
            this.DataGridChangedSelection = new DelegateCommand<object>(OnSelection);
            _selectedIndex = -1;
        }


        private void OnSelection(object p)
        {
            if (_selectedIndex >= 0)
            {
                _currentCommand.Execute(p);
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }

        }

        public QueryTypeEnum QueryType
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
            set
            {
                _sourceDataTable = value;
                RaisePropertyChanged("QueryTable");
            }
        }

        public DelegateCommand<object> RegionSelectionAction
        {
            get { return _currentCommand; }
            set
            {
                _currentCommand = value;
            }
        }
    }
}
