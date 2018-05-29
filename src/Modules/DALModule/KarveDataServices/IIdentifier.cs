namespace KarveDataServices
{
    public interface IIdentifier
    {
        /// <summary>
        ///  This generate an unique identifier in the invoice.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        string NewId();
    }
}