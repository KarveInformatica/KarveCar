namespace DataAccessLayer.DataObjects
{
    public class SupplierTransportDataObject
    {
        private string _name;
        private string _orderType;
        private string _last;
        private string _changedBy;
        private string _supplierCode;
        private string _porTrans;
        private string _impMaxTrans;
        private string _porTransAdd;
        private string _impMaxTransAdd;

        string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        string OrderType
        {
            get
            {
                return _orderType;
            }
            set
            {
                _orderType = value;
            }
        }
        string LastChange
        {
            get
            {
                return _last;
            }
            set
            {
                _last = value;
            }
        }
        string ChangedBy
        {
            get
            {
                return _changedBy;
            }
            set
            {
                _changedBy = value;
            }
        }
        string SupplierCode
        {
            get
            {
                return _supplierCode;
            }
            set
            {
                _supplierCode = value;
            }
        }
        string PorTrans
        {
            get
            {
                return _porTrans;
            }
            set
            {
                _porTrans = value;
            }
        }
        string ImpMaxTrans
        {
            get
            {
                return _impMaxTrans;
            }
            set
            {
                _impMaxTrans = value;
            }
        }
        string PorTransAdd
        {
            get
            {
                return _porTransAdd;
            }
            set
            {
                _porTransAdd = value;
            }
        }
        string ImpMaxTransAdd
        {
            get
            {
                return _impMaxTransAdd;
            }
            set
            {
                _impMaxTransAdd = value;
            }
        }

    }
}
