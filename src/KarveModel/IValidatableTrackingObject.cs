using System.ComponentModel;

namespace KarveModel
{ 
        public interface IValidatableTrackingObject :
   IRevertibleChangeTracking,
   INotifyPropertyChanged
        {
            bool IsValid { get; }
        }
    
}