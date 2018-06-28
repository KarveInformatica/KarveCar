using System.Collections.Generic;
using System.ComponentModel;
using KarveCommon.Generic;
using KarveCommonInterfaces;

namespace DataAccessLayer.SQL
{
    public enum QueryTable
    {
        Client, Supplier, Broker, Invoice
    };

    /// <summary>
    ///  Fluent Interface for abstracting the query store.
    ///  A fluent inteface is an inteface that in some methods returns itself
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
        IQueryStore AddParam(QueryType queryType, string code);
        /// <summary>
        /// A query parameters to be added.
        /// </summary>
        /// <typeparam name="T1">Type of the first code</typeparam>
        /// <typeparam name="T2">Type of the second code</typeparam>
        /// <param name="queryType">QueryType to be used.</param>
        /// <param name="firstCode">First code</param>
        /// <param name="secondCode">Second code</param>
        IQueryStore AddParam<T1, T2>(QueryType queryType, T1 firstCode, T2 secondCode);
       


        /// <summary>
        ///  A query parameters to be added
        /// </summary>
        /// <typeparam name="T1">Type of the first code</typeparam>
        /// <typeparam name="T2">Type of the second code</typeparam>
        /// <typeparam name="T3">Type of the third code</typeparam>
        /// <param name="queryType">Type of the query</param>
        /// <param name="firstCode">First code parameter</param>
        /// <param name="secondCode">Second code parameter</param>
        /// <param name="thirdCode">Third code parameter</param>
        IQueryStore AddParam<T1, T2, T3>(QueryType queryType, T1 firstCode, T2 secondCode, T3 thirdCode);
       

        /// <summary>
        ///  Add sorting parameters to the query.
        /// </summary>
        /// <param name="queryTemplate">QueryType to be used</param>
        /// <param name="sortChain">List of chain to be sorted</param>
        IQueryStore AddParamFilterSort(QueryType queryTemplate, Dictionary<string, ListSortDirection> sortChain);

        /// <summary>
        /// Add a new parameter.
        /// </summary>
        /// <param name="query">Type of the query</param>
        /// <param name="parameter">List of string values that provides the parameters</param>
        IQueryStore AddParam(QueryType query, IList<string> parameter);

        /// <summary>
        ///  Select the type of the query to be built.
        /// </summary>
        /// <param name="queryCompanySummary">Query type to be built.</param>
        IQueryStore AddParam(QueryType queryCompanySummary);
        /// <summary>
        /// Method generate a query paged. A query paged is a query with a max limit of items,
        /// the limit of items has been given by the number n.
        /// </summary>
        /// <param name="queryPagedClient">Query type to build in a paged way</param>
        /// <param name="currentQueryPos">Lower limit</param>
        /// <param name="n">Number of items starting from the lower limit</param>
        /// <param name="code">Value of the code string</param>
        IQueryStore AddParamRange(QueryType queryPagedClient, long currentQueryPos, long n);
        /// <summary>
        /// Method to add a set of query filters in the paged query 
        /// </summary>
        /// <param name="pagedQuery">Type of the paged queru</param>
        /// <param name="queryFilter">Filter to add</param>
        IQueryStore AddParamFilter(QueryType pagedQuery, IQueryFilter queryFilter);
        /// <summary>
        /// Method to build the query
        /// </summary>
        /// <returns>The query to be built.</returns>
        string BuildQuery();
        /// <summary>
        ///  Clean the working memory of the store.
        /// </summary>
        IQueryStore Clear();
        /// <summary>
        ///  Build a query directly
        /// </summary>
        /// <param name="queryType">Type of the queries</param>
        /// <param name="param">Parameters</param>
        /// <returns></returns>
        string BuildQuery(QueryType queryType, IList<string> param);
        /// <summary>
        ///  Get the number of items in a table
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        string GetCountQuery(QueryTable client);
        /// <summary>
        ///  The number of items in a table with the restriction.
        ///  It might be useful for the crosslink.
        /// </summary>
        /// <param name="table">Name of the table</param>
        /// <param name="key">Key of the table</param>
        /// <param name="number">Number of the inner value</param>
        /// <returns>The number of items</returns>
        string GetCountItems(string table, string key, string number);
        /// <summary>
        ///  This will allows yout to add parameters with count.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="table"></param>
        /// <param name="primaryKey"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryStore AddParamCount(QueryType type, string code);
        IQueryStore AddParamCount(QueryType type, string code, string refCode="");
        IQueryStore AddParamCount(QueryType type, string table, string primaryKey, string code, string refCode = "");
       
    }
}
