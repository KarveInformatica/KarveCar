using System.Data;

namespace KarveDataServices
{
    /// <summary>
    ///  This is an interface for allowing the duality between dataset and data object.
    /// A data object is a POCO (Plain Old CLR Object).
    /// </summary>
    /// <typeparam name="T">Interface or type of the plain POCO.</typeparam>
    public interface IDataWrapper<T>
    {
        /// <summary>
        ///  This field says if the data has a data set
        /// </summary>
        bool HasDataSet { set; get; }
        /// <summary>
        /// DataSet value
        /// </summary>
        DataSet Set { set; get; }
        /// <summary>
        ///  This field says if the data has a data object
        /// </summary>
        bool HasDataObject { set; get; }
        /// <summary>
        ///  Value object value of tyhe data
        /// </summary>
        T Value { set; get; }
}
}
