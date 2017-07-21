using System.Collections.ObjectModel;

namespace KRibbon.Model.Generic
{
    /// <summary>
    /// ObservableCollection<object>() genérica que implementa INotifyPropertyChanged
    /// </summary>
    public class GenericObservableCollection : GenericPropertyChanged
    {
        #region Constructores
        public GenericObservableCollection()
        {
            this.genericobscollection = new ObservableCollection<object>();
        }

        public GenericObservableCollection(ObservableCollection<object> genericobscollection)
        {
            this.genericobscollection = genericobscollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<object> genericobscollection;
        public ObservableCollection<object> GenericObsCollection
        {
            get { return genericobscollection; }
            set
            {
                genericobscollection = value;
                OnPropertyChanged("GenericObsCollection");
            }
        }
        #endregion
    }
}
