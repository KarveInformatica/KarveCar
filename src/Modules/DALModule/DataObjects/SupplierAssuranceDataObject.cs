using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataAccessLayer.DataObjects
{
    public class SupplierAssuranceDataObject
    {
        private string _supplierCode;
        private string _linea;
        private string _description;
        private string _minAge;
        private string _drivingLicenseYears;
        private string _observations;
        string SupplierCode
        {
            set
            {
                _supplierCode = value;
            }
            get
            {
                return _supplierCode;
            }
        }
        string Linea
        {
            set
            {
               _linea = value;
            }
            get
            {
                return _linea;
            }
        }
        string Description
        {
            set
            {
                _description = value;
            }
            get
            {
                return _description;
            }
        }
        string MinAge
        {
            set
            {
                _minAge = value;
            }
            get
            {
                return _minAge;
            }
        }
        string DrivingLicenseYears
        {
            set
            {
                _drivingLicenseYears = value;
            }
            get
            {
                return _drivingLicenseYears;
            }
        }
        string Observations
        {
            set
            {
                _observations = value;
            }
            get
            {
                return _observations;
            }
        }
    }
}
