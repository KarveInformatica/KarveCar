using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    public enum StateDto {  Clean = 0, Dirty = 1, Dead = 2}
    /// <summary>
    ///  ContactsDto. Data transfer object for contacts.
    /// </summary>
    public class ContactsDto : BaseDto
    {
        private string _resposability;
        private PersonalPositionDto _personalPositionDto;
        public ContactsDto()
        {
            _personalPositionDto = new PersonalPositionDto();
        }
        /// <summary>
        ///  ContactsKeyId
        /// </summary>
        [Display(Name = "Cod.Cliente")]
        public string ContactsKeyId { set; get; }
        /// <summary>
        ///  ContactName
        /// </summary>
        [Display(Name = "Nombre")]
        public string ContactName
        {

            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }
        /// <summary>
        ///  Nif
        /// </summary>
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        /// <summary>
        ///  Responsability
        /// </summary>
        [Display(Name = "Responsability")]
        public string Responsability {
            get
            {
               
                return _resposability;
            }
            set
            {
                ResponsabilitySource.Name = value;
                _resposability = value;
            }
        }
        /// <summary>
        ///  ResponsabilitySource
        /// </summary>
        public PersonalPositionDto ResponsabilitySource {
            get
            {
                return _personalPositionDto;
            }
            set
            {
                _personalPositionDto = value;
                RaisePropertyChanged("ResponsabilitySource");

            }
        }
        /// <summary>
        ///  Telefono
        /// </summary>
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        /// <summary>
        ///  Movil
        /// </summary>
        public string Movil { get; set; }
        /// <summary>
        ///  Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  Email
        /// </summary>
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "ClientName")]
        public string ClientName { set; get; }

        [Display(Name = "Num.Delegación")]

        public string BranchId { set; get; }
        /// <summary>
        ///  Current delegation.
        /// </summary>
        [Display(Name = "Delegation")]
        public string CurrentDelegation { get; set; }
        [PrimaryKey]
        public string ContactId {
            get
            {
                return base.Code;
            }
            set
            {
                base.Code = value;
            }
        }
        /// <summary>
        ///  State.
        /// </summary>
        public int State { get; set; }
    }
}