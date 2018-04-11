namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Personal Position Data Transfer Object, it is resposible for the charge of personal. 
    /// </summary>
    public class PersonalPositionDto: BaseDto
    {
        private string _code = string.Empty;
        private string _name = string.Empty;

        /// <summary>
        ///  Codigo
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Nombre
        /// </summary>
        public string Name {
            get { return _name;  }
            set
            { _name = value; RaisePropertyChanged(); }
        }
        
    }
}