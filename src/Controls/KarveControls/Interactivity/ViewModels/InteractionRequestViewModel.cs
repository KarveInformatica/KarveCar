

using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using KarveControls.Interactivity.Notifications;
using KarveCommonInterfaces;


namespace KarveControls.Interactivity.ViewModels
{
    public class InteractionRequestViewModel : BindableBase
    {
        private object resultMessage;
        private IEnumerable _dataSource;
        private string _title = string.Empty;
        
        public delegate void SelectedInteractionItem(SelectionState state, object value);
        public event SelectedInteractionItem OnSelectedItem;

        public InteractionRequestViewModel()
        {
            // To setup the interaction request we only need to create instances of the InteractionRequest class
            // and expose them through properties. The InteractionRequestTriggers will bind to them and subscribe
            // to the corresponding events automatically.
            // The InteractionRequest class requires a parameter that has to inherit from the INotification class.
            this.ItemSelectionRequest = new InteractionRequest<ItemSelectionNotification>();
            this.AssistProperties = string.Empty;
            // Commands for each of the buttons. Each of these raise a different interaction request.
            this.RaiseItemSelectionCommand = new DelegateCommand(this.RaiseItemSelection);
        }

        public object InteractionResultMessage
        {
            get
            {
                return this.resultMessage;
            }
            set
            {
                this.resultMessage = value;
             
            }
        }
        public InteractionRequest<ItemSelectionNotification> ItemSelectionRequest { get; private set; }

        public IEnumerable DataSource {
            set
            {
                _dataSource = value;
                RaisePropertyChanged();
            }
            get
            {
                return _dataSource;
            }
        }
        
        public string Title
        {
            set
            {
                _title = value;
            }
            get
            {
                return _title;
            }
        }
        public ICommand RaiseItemSelectionCommand { get; private set; }

        public string AssistProperties { get; set; }
        private void RaiseItemSelection()
        {
            // Here we have a custom implementation of INotification which allows us to pass custom data in the 
            // parameter of the interaction request. In this case, we are passing a list of items.
            ItemSelectionNotification notification = new ItemSelectionNotification();
            
           
            notification.Title = Title;
            notification.AssistProperites = AssistProperties;
            foreach (var v in DataSource)
            {
                notification.Items.Add(v);
            }
            // The custom popup view in this case has its own view model which implements the IInteractionRequestAware interface
            // therefore, its Notification property will be automatically populated with this notification by the PopupWindowAction.
            // Like this that view model is able to recieve data from this one without knowing each other.
         //   this.InteractionResultMessage = "";
            this.ItemSelectionRequest.Raise(notification,
                returned =>
                {
                    if (returned != null && returned.Confirmed && returned.SelectedItem != null)
                    {
                        this.InteractionResultMessage = returned.SelectedItem;
                        if (OnSelectedItem!=null)
                        {
                            OnSelectedItem.Invoke(SelectionState.OK, returned.SelectedItem);
                        }

                    }
                    else
                    {
                        if (OnSelectedItem!=null)
                        {
                            OnSelectedItem.Invoke(SelectionState.Cancel, returned.SelectedItem);

                        }
                    }
                });
        }
    }
}
