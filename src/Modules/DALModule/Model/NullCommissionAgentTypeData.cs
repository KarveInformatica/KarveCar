using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects.Wrapper
{
    /// <summary>
    ///  Null design pattern. Return a null type in case of not valid data.
    /// </summary>
    internal class NullCommissionAgentTypeData : ICommissionAgentTypeData
    {
        private string _code = "";
        private string _name = "";
        /// <summary>
        /// Commission Type Code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// Name of the commission type.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}