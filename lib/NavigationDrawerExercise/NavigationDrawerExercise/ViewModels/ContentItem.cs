using Syncfusion.Windows.Shared;

namespace NavigationDrawerExercise
{
    /// <summary>
    ///  ContentItem is a class resposible for the menu.
    /// </summary>
    public class ContentItem: NotificationObject
    {

        private string _name;
        private string _sourceImage;

        public ContentItem(string name, string sourceImage)
        {
            SourceImage= sourceImage;
            Name = name;
        }
        /// <summary>
        ///  Source of the image
        /// </summary>
        string SourceImage {
            set
            {
                this._sourceImage = value;
                RaisePropertyChanged("SourceImage");
            }
            get
            {
                return this._sourceImage;
            }
        }
        /// <summary>
        /// Name of the menu.
        /// </summary>
        string Name
        {   set
            {
                this._name = value;
                RaisePropertyChanged("Name");
            }
            get
            {
                return this._name;
            }
        }
    }
}