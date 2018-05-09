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
        public string ContactsKeyId { set; get; }
        /// <summary>
        ///  ContactName
        /// </summary>
        public string ContactName
        {
            get; set;
        }
        /// <summary>
        ///  Nif
        /// </summary>
        public string Nif { set; get; }
        /// <summary>
        ///  Responsability
        /// </summary>
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
                RaisePropertyChanged("ResponsabilitySource");

            }
        }
        /// <summary>
        ///  Telefono
        /// </summary>
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
     
        /// <summary>
        ///  Current delegation.
        /// </summary>
        public string CurrentDelegation { get; set; }
        [PrimaryKey]
        public string ContactId {
            get
            {
                return base.CodeId;
            }
            set
            {
                base.CodeId = value;
            }
        }
        /// <summary>
        ///  State.
        /// </summary>
        public int State { get; set; }
    }
}