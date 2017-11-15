namespace KarveDataServices
{
    /// <summary>
    ///  Rule of validation.
    /// </summary>
    public interface SqlValidationRule<T>
    {
        bool Validate(T request);
    } 
}
