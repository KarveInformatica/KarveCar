using KarveCommon.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// A simple data object
    /// </summary>
    public class BankDataObject : GenericPropertyChanged
    {

        private string _code;
        private string _name;
        private string _swift;

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }


        public string Swift
        {
            get { return _swift; }
            set
            {
                _swift = value;
                OnPropertyChanged("Swift");
            }
        }

    }
}
