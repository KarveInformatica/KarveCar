namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  This data transfer object returns the id for each locale, the traduction, 
    ///  the original value for a given culture.
    /// </summary>
    public class LocaleDataDto
    {
        /// <summary>
        ///  Id of the data.
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        ///  Original value of the data.
        /// </summary>
        public string Original { set; get; }
        /// <summary>
        ///  Real value of the data.
        /// </summary>
        public string Value { set; get; }
    }
}
