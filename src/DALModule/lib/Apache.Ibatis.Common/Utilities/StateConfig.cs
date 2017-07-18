namespace Apache.Ibatis.Common.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public struct StateConfig
    {
        /// <summary>
        /// Master Config File name.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Delegate called when a file is changed, use it to rebuild.
        /// </summary>
        public ConfigureHandler ConfigureHandler;
    }
}