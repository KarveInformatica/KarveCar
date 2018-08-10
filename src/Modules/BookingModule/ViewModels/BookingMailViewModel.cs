using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModule.ViewModels
{
    class BookingMailViewModel: BindableBase
    {
        private string _destinationAddress;
        private string _subject;
        private string _senderAddress;

        public string DestinationAddress
        {
            get
            {
                return _destinationAddress;
            }
            set
            {
                _destinationAddress = value;
                RaisePropertyChanged("DestinationAddress");
            }
        }
        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                RaisePropertyChanged("Subject");
            }
        }
        public string SenderAddress {
            get
            {
                return _senderAddress;
            }
            set
            {
                _senderAddress = value;
                RaisePropertyChanged("SenderAddress");
            }
        }
    }
}
