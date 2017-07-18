namespace Apache.Ibatis.Common.Utilities
{
    /// <summary>
    /// Represents the method that handles calls from Configure.
    /// </summary>
    /// <remarks>
    /// obj is a null object in a DaoManager context.
    /// obj is the reconfigured sqlMap in a SqlMap context.
    /// </remarks>
    public delegate void ConfigureHandler(object obj);
}