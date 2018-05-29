namespace KarveCommon.Generic
{
    /// <summary>
    ///  Kind of enumeration operation.
    /// </summary>
    public enum QueryOperation
    {
        FIRST, AND, OR, NOT
    };
    
    /// <summary>
    ///  Filter to be used
    /// </summary>
    public interface IQueryFilter
    {
        /// <summary>
        /// Get the id of the filter 
        /// </summary>
        long Id { get; }
        /// <summary>
        ///  Resolve the condition of the query.
        /// </summary>
        /// <returns></returns>
        string Resolve();
    }
}