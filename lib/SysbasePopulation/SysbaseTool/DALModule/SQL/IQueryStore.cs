using System.Collections.Generic;
namespace DataAccessLayer.SQL
{

    /// <summary>
    ///  Interface for abstracting the query store. T
    ///  The query store is the place of the queries reside inside this application. 
    ///  It can be serialized in XML.
    /// </summary>
    public interface IQueryStore
    {
        // Returns the dictionary of queries configured in the system.
        Dictionary<QueryType, string> Queries { get; }
        /// <summary>
        ///  A query might have a parameter to be inserted from the user: i.e 
        ///  "SELECT * FROM WHERE codeName='%d'
        ///  With the query type you select the type of query.
        ///  With the code you select the code of the query.
        /// </summary>
        /// <param name="queryType">Query type.</param>
        /// <param name="code">Parameter of the query to builded</param>
        void AddParam(QueryType queryType, string code);
        /// <summary>
        ///  Select the type of the query to be built.
        /// </summary>
        /// <param name="queryCompanySummary">Query type to be built.</param>
        void AddParam(QueryType queryCompanySummary);
        /// <summary>
        /// Method generate a query paged. A query paged is a query with a max limit of items,
        /// the limit of items has been given by the number n.
        /// </summary>
        /// <param name="queryPagedClient">Query type to build in a paged way</param>
        /// <param name="currentQueryPos">Lower limit</param>
        /// <param name="n">Number of items starting from the lower limit</param>
        void AddParamRange(QueryType queryPagedClient, long currentQueryPos, long n);

        /// <summary>
        /// Method to build the query
        /// </summary>
        /// <returns>The query to be built.</returns>
        string BuildQuery();
    }
}
