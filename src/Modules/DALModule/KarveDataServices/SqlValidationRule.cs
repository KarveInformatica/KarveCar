namespace KarveDataServices
{
    /// <summary>
    ///  This is a validation rule for SQL.
    ///  We will implement the chain of responsability design pattern in this case 
    /// </summary>
    public abstract class SqlValidationRule
    {
        protected SqlValidationRule successor = null;
      
        public void SetSuccessor(SqlValidationRule successor)
        {
            this.successor = successor;
        }

        public abstract bool Validate(DataPayLoad request);
    }
}
