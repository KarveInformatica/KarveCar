namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Personal Position Data Transfer Object, it is resposible for the charge of personal. 
    /// </summary>
    public class PersonalPositionDto: BaseDto
    {
        /// <summary>
        ///  Codigo
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///  Nombre
        /// </summary>
        public string Name { get; set; }
        
    }
}