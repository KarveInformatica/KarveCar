
using Karve.Interactivity.Notifications;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;

namespace Karve.Interactivity.ViewModels
{
    public class InteractionRequestViewModel : BindableBase, IModalViewModel
    {
        private string resultMessage;

        public InteractionRequestViewModel()
        {
            // To setup the interaction request we only need to create instances of the InteractionRequest class
            // and expose them through properties. The InteractionRequestTriggers will bind to them and subscribe
            // to the corresponding events automatically.
            // The InteractionRequest class requires a parameter that has to inherit from the INotification class.
            this.ItemSelectionRequest = new InteractionRequest<ItemSelectionNotification>();

            // Commands for each of the buttons. Each of these raise a different interaction request.
            this.RaiseItemSelectionCommand = new DelegateCommand(this.RaiseItemSelection);
        }

        public string InteractionResultMessage
        {
            get
            {
                return this.resultMessage;
            }
            set
            {
                this.resultMessage = value;
                this.OnPropertyChanged("InteractionResultMessage");
            }
        }
        public InteractionRequest<ItemSelectionNotification> ItemSelectionRequest { get; private set; }

        public IEnumerable DataSource { set; get; }
        
        public ICommand RaiseItemSelectionCommand { get; private set; }

        
        private void RaiseItemSelection()
        {
            // Here we have a custom implementation of INotification which allows us to pass custom data in the 
            // parameter of the interaction request. In this case, we are passing a list of items.
            ItemSelectionNotification notification = new ItemSelectionNotification();
            if (DataSource!= null)
            {
                foreach (var source in DataSource)
                {
                    notification.Items.Add(source);
                }
            }
           
            notification.Title = "Items";

            // The custom popup view in this case has its own view model which implements the IInteractionRequestAware interface
            // therefore, its Notification property will be automatically populated with this notification by the PopupWindowAction.
            // Like this that view model is able to recieve data from this one without knowing each other.
            this.InteractionResultMessage = "";
            this.ItemSelectionRequest.Raise(notification,
                returned =>
                {
                    if (returned != null && returned.Confirmed && returned.SelectedItem != null)
                    {
                        this.InteractionResultMessage = "The user selected: " + returned.SelectedItem;
                    }
                    else
                    {
                        this.InteractionResultMessage = "The user cancelled the operation or didn't select an item.";
                    }
                });
        }
    }
}
