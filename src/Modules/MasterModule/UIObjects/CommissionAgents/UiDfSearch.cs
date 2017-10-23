using KarveControls.UIObjects;

namespace MasterModule.UIObjects.CommissionAgents
{
    /// <summary>
    /// This is the data field search.
    /// </summary>
    public class UiDfSearch: UiDualDfSearchTextObject
    {
        private object _dataObject;
        /// <summary>
        /// UiDfSearch. it is an object more easy to configure for collection objects
        /// </summary>
        public UiDfSearch(): base()
        {
            ButtonImage = MasterModule.ImagePath;
        }
        /// <summary>
        /// UiDfSearch.
        /// </summary>
        /// <param name="labelTxt">Label to be configured.</param>
        public UiDfSearch(string labelTxt) : base(labelTxt,"100")
        {
            ButtonImage = MasterModule.ImagePath;
        }
        /// <summary>
        /// Source of the data.
        /// </summary>
        public object DataSource
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }
         
    }


}
