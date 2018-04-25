namespace KarveDataServices
{
    /// <summary>
    ///  Rule of validation.
    /// </summary>
    public interface ISqlValidationRule<T>
    {
        bool Validate(T request);
    } 
}
