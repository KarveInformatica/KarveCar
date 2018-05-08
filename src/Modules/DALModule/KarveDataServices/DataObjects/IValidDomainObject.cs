namespace KarveDataServices.DataObjects
{

    // Specific interface to define if an element of the domain is valid.
    public interface IValidDomainObject
    {
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
    }
}