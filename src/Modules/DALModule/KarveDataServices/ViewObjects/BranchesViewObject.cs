using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  The branches viewObject is a data transfer object for the branches.
    /// </summary>
    [DataContract]
    public class BranchesViewObject : BaseViewObject
    {
        private ProvinceViewObject _provinciadto;
        private object _provincia;

        public BranchesViewObject()
        {
            _provincia = new ProvinceViewObject();
           
            //   ProvinceSource = _provincia;
        }
        public BranchesViewObject(BranchesViewObject lastBranchesViewObject)
        {
            BranchId = lastBranchesViewObject.BranchId;
            Address = lastBranchesViewObject.Address;
            Address2 = lastBranchesViewObject.Address2;
            Phone = lastBranchesViewObject.Phone;
            Phone2 = lastBranchesViewObject.Phone2;
            Province = lastBranchesViewObject.Province;
            Email = lastBranchesViewObject.Email;
            City = lastBranchesViewObject.City;
            Province = lastBranchesViewObject.Province;
            BranchKeyId = lastBranchesViewObject.BranchKeyId;
            Zip = lastBranchesViewObject.Zip;
            Fax = lastBranchesViewObject.Fax;
        }
        [DataMember]
        [Required]
        public string BranchKeyId { get; set; }
        [DataMember]
        [PrimaryKey]
        public string BranchId { get; set; }
        [DataMember]
        [StringLength(45,ErrorMessage ="Nombre delegacion demasiado ancho")]
        public string Branch { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Phone2 { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string City { get; set; }
        public string Zip { get; set; }
        public string Fax { get; set; }
        [DataMember]
        public ProvinceViewObject Province {
            get { return _provinciadto; }
            set
            {
                _provinciadto = value;
                RaisePropertyChanged("ProvinceSource");
            } 
        }
        public string ProvinceName { set; get; }
        public string ProvinceId { set; get; }
        public string Notes { get; set; }
        public object ProvinceSource {
            set
            {
                _provincia = value; 
                RaisePropertyChanged();
            }
            get
            {
                return _provincia;
            }
        }
        public override bool HasErrors
        {
            get
            {
               
                return false;
            }
        }
        public string CellPhone { get; set; }
    }
}