using System.ComponentModel;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  Abstract Class que implementa INotifyPropertyChanged
    /// </summary>
    public abstract class GenericPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}