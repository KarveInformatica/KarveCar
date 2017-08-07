using Prism.Mvvm;
using System.Data;

namespace PaymentTypeModule.ChargeClients.ViewModel
{
    public class GridPopUpViewModel: BindableBase
    {
        private string _queryType;
        private string _title;
        private string _firstColumnQuery;
        private string _secondColumnQuery;

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
        public DataTable SourceTable { get; set; }
    }
}
