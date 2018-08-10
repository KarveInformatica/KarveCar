using KarveControls.Annotations;
using Prism.Interactivity.InteractionRequest;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KarveControls.Interactivity.Notifications
{
    public class BaseNotification: Confirmation
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
