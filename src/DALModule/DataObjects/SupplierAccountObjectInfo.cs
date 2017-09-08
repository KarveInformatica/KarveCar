using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveCommon.Generic;

namespace DataAccessLayer.DataObjects
{
    public class SupplierAccountObjectInfo : GenericPropertyChanged, ISupplierAccountObjectInfo
    {
        private string _prefixAccount;
        private string _accoutableAccount;
        private string _accountName;
        private double _accountBalance;
        private string _accountDescription;
        private string _accountDescription2;
        private string _expensesAccountCode;
        private string _expensesAccount;
        private string _customerAccount;
        private string _deductionAccountCode;
        private string _deductionAccount;
        private string _deductionPercentage;
        private string _paymentAccountCode;
        private string _paymentAccount;
        private string _intraAccountSop;
        private string _intraAccountRep;
        private string _iban;
        private object _swift;
        private string _transferAccount;
        private string _lastChange;
        private string _changedByUser;
        private string _sublicen;
        private object _active;
        private bool _isInvoiceManagementEnabled;
        private object _edKCli;
        private string _nif;
        private string _commissionNumber;
        private string _cpAccount;
        private string _lpAccount;

		public string PrefixAccount
        {
		  get
          {
           return _prefixAccount;
          }
		  set
           {
                _prefixAccount = value;
            }
		}
		public string AccountableAccount
        {
			get { return _accoutableAccount; }
			set { _accoutableAccount = value; }
		}
		public string AccountName
        {
		    get { return _accountName; }
			set { _accountName = value; }
		}
		public double AccountBalance
        {
			get { return _accountBalance; }
			set { _accountBalance = value; }
		}
		public string AccountDescription
        {
		     get { return _accountDescription; }
			 set { _accountDescription = value;}
		}
		public string AccountDescription2
        {
			get { return _accountDescription2; }
			set { _accountDescription2 = value; }
		}
		public string ExpensesAccountCode
        {
			get { return _expensesAccountCode; }
			set { _expensesAccountCode = value; }
		}
		public string ExpensesAccount
        {
			get { return _expensesAccount; }
		    set { _expensesAccount = value; }
        }
		public string CustomerAccount
        {
            get { return _customerAccount; }
            set { _customerAccount = value; }
        }
		public string DeductionAccountCode
        {
            get { return _deductionAccountCode;  }
            set { _deductionAccountCode = value; }
        }
		public string DeductionAccount
        {
            get { return _deductionAccount;  }
		    set { _deductionAccount = value; }
        }
		public string DeductionPercentage
        {
            get { return _deductionPercentage; }
             set { _deductionPercentage = value; } 
        }
		public string PaymentAccountCode { get { return _paymentAccountCode; }  set { _paymentAccountCode = value; } }
		public string PaymentAccount { get { return _paymentAccount; }  set { _paymentAccount = value; } }
		public string IntraAccountSop { get { return _intraAccountSop; } set { _intraAccountSop = value; }  }
		public string IntraAccountRep { get { return _intraAccountRep; } set { _intraAccountRep = value; }  }
		public string IBAN { get { return _iban; } set { _iban = value; } }
		public object SWIFT { get { return _swift; } set { _swift = value; } }
		public string TransferAccount { get { return _transferAccount; } set { _transferAccount = value; } }
		public string LastChange { get { return _lastChange; } set { _lastChange = value; }  }
		public string ChangedByUser { get { return _changedByUser; }  set { _changedByUser = value; } }
		public string Sublicen { get { return _sublicen; }
                                 set {  _sublicen = value; } }
		public object Active { get { return _active; } set { _active = value; } }
		public bool IsInvoiceManagementEnabled { get { return _isInvoiceManagementEnabled; } set { _isInvoiceManagementEnabled = value; }  }
		public object edKCli { get { return _edKCli; }  set { _edKCli = value; }  }
		public string Nif { get { return _nif; }  set { _nif = value; }  }
		public string CommissionNumber { get { return _commissionNumber; } set { _commissionNumber = value; } }

        public string CPAccount { get { return _cpAccount; } set { _cpAccount = value; } }

        public string LPAccount { get { return _lpAccount; } set { _lpAccount = value; } }
    }
}
