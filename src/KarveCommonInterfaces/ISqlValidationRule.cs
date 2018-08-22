namespace KarveCommonInterfaces
{
    /// <summary>
    ///  Validation rule interface. This interface defines the contract to be used
    /// for rule validation.
    /// </summary>
    public interface ISqlValidationRule<in T>
    {
        /// <summary>
        ///  Method to validate the request
        /// </summary>
        /// <param name="request">Request to be validated</param>
        /// <returns>True if the request is valid</returns>
        bool Validate(T request);
        /// <summary>
        /// Check if the current request is ok, if it is ok forward to the successor validation rule. 
        /// </summary>
        /// <param name="request">Request to be validated</param>
        /// <returns>False if the request is not valid</returns>
        bool CheckRequest(T request);

        string ErrorMessage { get; set; }

    } 
}
