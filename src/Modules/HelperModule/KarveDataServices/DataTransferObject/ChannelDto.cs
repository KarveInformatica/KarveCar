namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data transfer object for the CANAL table
    /// </summary>
    public class ChannelDto
    {
        /// <summary>
        ///  Channel code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Channel Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Last modification.
        /// </summary>
        public string LastModification { get; set; }
    }
}