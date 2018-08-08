using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarveCommon.DialogService.ViewModels
{
    class ConfirmMessageViewModel: BindableBase
    {
        private string _message;
        private string _title;
        private string _subtitle;


        public ConfirmMessageViewModel()
        {
            ConfirmedCommand = new DelegateCommand(OnConfirmed);
            CancelledCommand = new DelegateCommand(OnCancelled);
        }
        public Action CloseAction
        {
          get;
          set;
        }
        public string Title
        {
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
            get
            {
                return _title;
            }
        }
        public string Subtitle
        {
            set
            {
                _subtitle = value;
                RaisePropertyChanged("Subtitle");
            }
            get
            {
                return _subtitle;
            }
        }
        public string Message
        {
            set
            {
                _message = value;
                RaisePropertyChanged("Message");

            }
            get
            {
                return _message;
            }
        }
        /// <summary>
        /// True when the message has been confirmed.  
        /// </summary>
        public bool IsConfirmed { set; get; }
        /// <summary>
        ///  True when the message has been cancelled.
        /// </summary>
        public bool IsCancelled { set; get; }

       public ICommand ConfirmedCommand
        {
            set; get;
        }
        public ICommand CancelledCommand
        {
            set; get;
        }
        private void OnConfirmed()
        {
            if (CloseAction != null)
            {
                IsConfirmed = true;
                CloseAction();
            }
        }
        private void OnCancelled()
        {
            IsCancelled = true;
            CloseAction();
        }
    }
}
