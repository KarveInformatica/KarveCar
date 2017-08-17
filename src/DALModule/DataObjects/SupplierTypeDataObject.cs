using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveCommon.Generic;

namespace DataAccessLayer.DataObjects
{
    public class SupplierTypeDataObject : GenericPropertyChanged, ISupplierTypeDataObject
    {
        private string _user;
        private string _emergencyAccount;
        private string _lastModification;
        private string _name;
        private object _number;
        
        public string User {
            get {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
             }
        public string EmergencyAccount
        {
            get
            {
                return _emergencyAccount;
            }
            set
            {
                _emergencyAccount = value;
                OnPropertyChanged("EmergencyAccount");
            }
        }
        public string LastModification
        {
            get
            {
                return _lastModification;
            }
            set
            {
                _lastModification = value;
                OnPropertyChanged("LastModification");
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public object Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
    }
}
