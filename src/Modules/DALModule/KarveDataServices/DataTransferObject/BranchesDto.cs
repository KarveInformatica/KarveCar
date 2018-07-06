using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  The branches dto is a data transfer object for the branches.
    /// </summary>
    [DataContract]
    public class BranchesDto : BaseDto
    {
        private ProvinciaDto _provinciadto;
        private object _provincia;

        public BranchesDto()
        {
            _provincia = new ProvinciaDto();
           
            //   ProvinceSource = _provincia;
        }
        public BranchesDto(BranchesDto lastBranchesDto)
        {
            BranchId = lastBranchesDto.BranchId;
            Address = lastBranchesDto.Address;
            Address2 = lastBranchesDto.Address2;
            Phone = lastBranchesDto.Phone;
            Phone2 = lastBranchesDto.Phone2;
            Province = lastBranchesDto.Province;
            Email = lastBranchesDto.Email;
            City = lastBranchesDto.City;
            Province = lastBranchesDto.Province;
            BranchKeyId = lastBranchesDto.BranchKeyId;
            Zip = lastBranchesDto.Zip;
            Fax = lastBranchesDto.Fax;
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
        public ProvinciaDto Province {
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
                if ((Branch != null) && (Branch.Length > 45))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                if ((Email != null) && (!IsValidEmailField(Email)))
                {
                    ErrorList.Add(ConstantDataError.InvalidEmail);
                    return true;
                }
                if ((CellPhone != null) && (!IsValidPhoneField(CellPhone)))
                {
                    ErrorList.Add(ConstantDataError.InvalidPhone);
                    return true;
                }
                return false;
            }
        }
        public string CellPhone { get; set; }
    }
}