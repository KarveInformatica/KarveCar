using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistModule.ViewModels
{
    /// <summary>
    ///  AssistServiceViewModel.
    /// </summary>
    class AssistServiceViewModel: BindableBase
    {
        private object _interactionRequest;

        /// <summary>
        ///  This is the constructor fo the view model.
        /// </summary>
        public AssistServiceViewModel()
        {
           
        }
        public void RaiseItemSelection<T>(string title, IEnumerable<T> objects)
        {
            // Here we have a custom implementation of INotification which allows us to pass custom data in the 
            // parameter of the interaction request. In this case, we are passing a list of items.
            var selectionRequest = new InteractionRequest<AssistSelectionNotification<T>>();
            AssistSelectionNotification<T> notification = new AssistSelectionNotification<T>(objects);
            AssistSelectionRequest = selectionRequest;
            // performance kick.
            foreach (var v in objects)
            {
                notification.Items.Add(v);
            }
            notification.Title = title;

            // The custom popup view in this case has its own view model which implements the IInteractionRequestAware interface
            // therefore, its Notification property will be automatically populated with this notification by the PopupWindowAction.
            // Like this that view model is able to recieve data from this one without knowing each other.
            this.SelectedItem = null ;
            selectionRequest.Raise(notification,
                returned =>
                {
                    if (returned != null && returned.Confirmed && returned.SelectedItem != null)
                    {
                        this.SelectedItem= returned.SelectedItem;
                    }
                    else
                    {
                        this.SelectedItem = null;

                    }
                });
        }
        /// <summary>
        ///  This is an assist selection request.
        /// </summary>
        public object AssistSelectionRequest {
            get
            {
                return _interactionRequest;
            }
            set
            {
                _interactionRequest = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Here we have a selected item.
        /// </summary>
        public object SelectedItem { get; private set; }       
    }
}
