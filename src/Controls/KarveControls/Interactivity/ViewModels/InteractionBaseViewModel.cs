using KarveCommonInterfaces;
using KarveControls.Interactivity.Notifications;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System.Windows.Input;

namespace KarveControls.Interactivity.ViewModels
{

    /// <summary>
    ///  InteractionBaseViewModel. Base class for each view model that wants to use 
    ///  the modal windows of the interaction controller.
    /// </summary>
    /// <typeparam name="T">type of the notification. A notification 
    /// specializes the fields to be shown inside a view model. 
    /// </typeparam>
    public abstract class InteractionBaseViewModel<T>: BindableBase, ICommandInteraction where T: BaseNotification
    {
        private InteractionRequest<T> _itemRequest;
        private string _title;

        public InteractionBaseViewModel()
        {
            _itemRequest = new InteractionRequest<T>();
            this.RaiseInteractionCommand = new DelegateCommand(RaiseInteraction);
        }
        /// <summary>
        ///  Set or Get the interaction request. 
        ///  An interaction request has associated a notification. 
        /// </summary>
        public InteractionRequest<T> InteractionRequest
        {
            get
            {
                return _itemRequest;
            }
            set
            {
                _itemRequest = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the title to show.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
        /// <summary>
        ///  Raise the interaction .
        /// </summary>
        public abstract void RaiseInteraction();
        /// <summary>
        ///  Set or Get the raise interaction command that 
        ///  will trigger the intereaction from the controller
        /// </summary>
        public ICommand RaiseInteractionCommand { set; get; }


    }
}
