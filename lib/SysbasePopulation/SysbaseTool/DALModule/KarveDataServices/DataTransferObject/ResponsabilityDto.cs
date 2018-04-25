namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  ResposabilityDto. Data Transfer Object responsability
    /// </summary>
    public class ResponsabilityDto: BaseDto
    {
        /// <summary>
        /// Code of the resposability
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// Name of the responsability
        /// </summary>
        public string Name { set; get; }
    }
}