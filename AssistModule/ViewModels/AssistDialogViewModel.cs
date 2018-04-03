using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace AssistModule.ViewModels
{
    /// <summary>
    ///  Assist Dialog View Model. This is used to show a grid.
    /// </summary>
    class AssistDialogViewModel<T>: BindableBase, IInteractionRequestAware where T : class
    {
        private object _dataSource;
        private string _title;
        /// <summary>
        ///  Return a title.
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
            }
        }
        /// <summary>
        ///  Return a data source.
        /// </summary>
        public object DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                RaisePropertyChanged();
            }
        }
        private AssistSelectionNotification<T> notification;
        public AssistDialogViewModel()
        {
            this.SelectItemCommand = new DelegateCommand(this.AcceptSelectedItem);
            this.CancelCommand = new DelegateCommand(this.CancelInteraction);
        }

        // Both the FinishInteraction and Notification properties will be set by the PopupWindowAction
        // when the popup is shown.
        public Action FinishInteraction { get; set; }
        /// <summary>
        ///  This is a notification for the selection.
        /// </summary>
        public INotification Notification
        {
            get
            {
                return this.notification;
            }
            set
            {
                if (value is AssistSelectionNotification<T>)
                {
                    // To keep the code simple, this is the only property where we are raising the PropertyChanged event,
                    // as it's required to update the bindings when this property is populated.
                    // Usually you would want to raise this event for other properties too.
                    this.notification = value as AssistSelectionNotification<T>;
                    RaisePropertyChanged();
                }
            }
        }
        /// <summary>
        ///  Set or Get the selected item.
        /// </summary>
        public T SelectedItem { get; set; }

        /// <summary>
        ///  Set or Get the selected item command
        /// </summary>
        public ICommand SelectItemCommand { get; private set; }
        /// <summary>
        /// Set or Get the cancel command
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        ///  Accept the selected item command.
        /// </summary>
        public void AcceptSelectedItem()
        {
            if (this.notification != null)
            {
                this.notification.SelectedItem = this.SelectedItem;
                this.notification.Confirmed = true;
            }

            this.FinishInteraction();
        }
        /// <summary>
        ///  Cancel the interaction.
        /// </summary>
        public void CancelInteraction()
        {
            if (this.notification != null)
            {
                this.notification.SelectedItem = null;
                this.notification.Confirmed = false;
            }

            this.FinishInteraction();
        }

    }
}
