namespace KarveDataServices
{
    /// <summary>
    ///  This is a validation rule for SQL.
    ///  We will implement the chain of responsability design pattern in this case 
    /// </summary>
    public abstract class SqlValidationRule
    {
        protected SqlValidationRule successor = null;
        /// <summary>
        /// This is the sql validation rule.
        /// </summary>
        /// <param name="successor">This is the successor.</param>
        public void SetSuccessor(SqlValidationRule successor)
        {
            this.successor = successor;
        }
        /// <summary>
        ///  Validate the payload request before passing a data layer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract bool Validate(IDataPayLoad request);
    }
}
