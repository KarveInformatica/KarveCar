namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  This object contains a simple property for page.
    /// </summary>
    public class PageParameterObject
    {
        private long _startPosition;
        public long startPos
        {
            set
            {
                _startPosition = value;
            }
            get
            {
                return _startPosition;
            }
        }
    }
}
