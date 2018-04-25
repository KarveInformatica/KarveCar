namespace KarveDataServices
{
    public interface ISqlCommand
    {
        /// <summary>
        ///  Sql Commands for executing queries in a batch.
        /// </summary>
        string CommandStatemement { set; get; }
        /// <summary>
        ///  Execute a NoSql query.
        /// </summary>
        void ExecuteNoQuery();
        /// <summary>
        ///  Execute a SQL query.
        /// </summary>
	    void ExecuteQuery();
    }
}