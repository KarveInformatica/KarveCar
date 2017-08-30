using System;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    public class SupplierInfoDataObject : GenericPropertyChanged, ISupplierDataInfo
    {
        private string _countryCode = "";
        private string _direction = "";
        private string _city = "";
        private string _provinceCode = "";
        private string _phone = "";
        private string _fax = "";
        private string _website = "";
        private string _notes = "";
        private string _personas = "";
        private string _deliveringPeriod = "";
        private string _dischargeDate = "";
        private string _leavingDate = "";
        private string _country = "";
        private string _province = "";
        private string _email = "";
        private string _observation = "";
        private string _name = "";
        private string _nif = "";
        private string _code = "";
        private string _number = "";
        private string _mapDirection = "";
        private string _mobilePhone = "";
        private string _commercialName = "";
        private object _type;
        private object _zip;
        private string _lastChange = "";
        private string _changedByUser = "";
        private string _vatDate = "";
        public string Nif
        {
            get
            {
                return _nif;
            }
            set
            {
                _nif = value;
                OnPropertyChanged("Nif");
            }
        }
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }
        public string Number
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
        /// <summary>
        ///  Direction of the supplier
        /// </summary>
        public string Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                OnPropertyChanged("Direction");
            }
        }
        /// <summary>
        ///  Country code of the supplier
        /// </summary>
        public string CountryCode
        {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }
        /// <summary>
        /// City of the supplier.
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }
        /// <summary>
        ///  Province code of the supplier.
        /// </summary>
        public string ProvinceCode
        {
            get
            {
                return _provinceCode;
            }
            set
            {
                _provinceCode = value;
                OnPropertyChanged("ProvinceCode");
            }
        }
        /// <summary>
        ///  Phone of the supplier.
        /// </summary>
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        /// <summary>
        ///  Fax of the supplier
        /// </summary>
        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
                OnPropertyChanged("Fax");
            }
        }
        /// <summary>
        ///  Web site of the supplier.
        /// </summary>
        public string WebSite
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
                OnPropertyChanged("WebSite");
            }
        }
        /// <summary>
        ///  Notes of the supplier
        /// </summary>
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }
        /// <summary>
        ///  Supplier persona responsability.
        /// </summary>
        public string Persona
        {
            get
            {
                return _personas;
            }
            set
            {
                _personas = value;
                OnPropertyChanged("Persona");
            }
        }
        /// <summary>
        ///  Delivering Period of the supplier.
        /// </summary>
        public string DeliveringPeriod
        {
            get
            {
                return _deliveringPeriod;
            }
            set
            {
                _deliveringPeriod = value;
                OnPropertyChanged("DeliveringPeriod");
            }
        }
        /// <summary>
        ///  DischargeDate of the supplier.
        /// </summary>
        public string DischargeDate
        {
            get
            {
                return _dischargeDate;
            }
            set
            {
                _dischargeDate = value;
                OnPropertyChanged("DischargeDate");
            }
        }
        /// <summary>
        ///  Leaving date of the supplier.
        /// </summary>
        public string LeavingDate
        {
            get
            {
                return _leavingDate;
            }
            set
            {
                _leavingDate = value;
                OnPropertyChanged("LeavingDate");
            }
        }
        /// <summary>
        ///  Supplier Country 
        /// </summary>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }
        /// <summary>
        ///  Province Supplier.
        /// </summary>
        public string Province
        {
            get
            {
                return _province;
            }
            set
            {
                _province = value;
                OnPropertyChanged("Province");
            }
        }
        /// <summary>
        ///  Email Supplier.
        /// </summary>
        public string Email
        {
            get
            {
                string tmpValue = _email.Replace("#", "@");
                return tmpValue;
            }
            set
            {
                // in the db is stored as "#".
                string tmpValue = value.Replace("@", "#");
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        /// <summary>
        ///  Observatin supplier.
        /// </summary>
        public string Observation
        {
            get
            {
                return _observation;
            }
            set
            {
                _observation = value;
                OnPropertyChanged("Observation");
            }
        }
        /// <summary>
        ///  Supplier Name.
        /// </summary>
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

        public string MapDirection
        {
            get
            {
                _mapDirection = this.Direction + "," + this.City + "," + this.Country;
                return _mapDirection;
            }
            set
            {
                _mapDirection = value;
            }
        }
        public string MobilePhone
        {
            set
            {
                _mobilePhone = value;
                OnPropertyChanged("MobilePhone");
            }
            get
            {
                return _mobilePhone;
              
            }
        }
        public string CommercialName
        {
            set
            {
                _commercialName = value;
                OnPropertyChanged("CommercialName");
            }
            get
            {
                return _commercialName;
            }
        }
        public object Zip
        {
            set
            {
                _zip = value;
                OnPropertyChanged("Zip");
            }
            get
            {
                return _zip;
            }
        }
        public object Type
        {
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
            get
            {
                return _type;
            }
        }

        public string VATDate
        {
            set
            {
                _vatDate = value;
                OnPropertyChanged("VATDate");
            }
            get
            {
                return _vatDate;
            }
        }
        public string LastChange {

            set
            {
                _lastChange = value;
                OnPropertyChanged("LastChange");
            }
            get
            {
                return _lastChange;
            }

        }
        public string ChangedByUser
        {

            set
            {
                _changedByUser = value;
                OnPropertyChanged("ChangedByUser");
            }
            get
            {
                return _changedByUser;
            }

        }

        public string Surname1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Surname2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
