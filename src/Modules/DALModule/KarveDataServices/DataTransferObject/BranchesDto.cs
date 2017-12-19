using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  The branches dto is a data transfer object for the branches.
    /// </summary>
    [DataContract]
    public class BranchesDto
    {
        public BranchesDto()
        { }

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
        }

        [DataMember]
        public int BranchId;
        [DataMember]
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
        [DataMember]
        public ProvinciaDto Province { get; set; }

    }
}