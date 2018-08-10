using Prism.Interactivity.InteractionRequest;
using System.ComponentModel;
using KarveControls.Annotations;
using System.Runtime.CompilerServices;

namespace KarveControls.Interactivity.Notifications
{

    /// <summary>
    ///  Send an email notification.
    ///  A confirmation asset,.
    /// </summary>
    public sealed class MailNotification : BaseNotification
    {

        public bool _isGmailEnable;
        public bool _isOutLookEnable;
        private int _smtpPort;
        private string _smtpServer;
        private string _senderAddress;
        private string _destinationAddress;
        private bool _emailSent;


        /// <summary>
        ///  Set or Get a notification address.
        /// </summary>

        public string DestinationAddress
        {
            set
            {
               _destinationAddress = value;
                OnPropertyChanged("DestinationAddress");

            }
            get
            {
                return _destinationAddress;
            }
        }
        /// <summary>
        ///  Set or Get a sender address.
        /// </summary>
        public string SenderAddress
        {
            set
            {
                _senderAddress = value;
                OnPropertyChanged("SenderAddress");
                
            }
            get
            {
                return _senderAddress;
            }
        }
        /// <summary>
        ///  Set or get an email.
        /// </summary>
        public bool EmailSent
        {
            set
            {
                _emailSent = value;
                OnPropertyChanged("EmailSent");

            }
            get
            {
                return _emailSent;
            }
        }

        /// <summary>
        ///  Set or Get gmail value.
        /// </summary>
        public bool GmailEnabled
        {
            set
            {
                _isGmailEnable = value;
                OnPropertyChanged("GmailEnabled");
            }
            get
            {
                return _isGmailEnable;
            }
        }
        /// <summary>
        ///  Set or Get outlook
        /// </summary>
        public bool OutLookEnable
        {
            set
            {
                _isOutLookEnable = value;
                OnPropertyChanged("OutLookEnable");
            }
            get
            {
                return _isOutLookEnable;
            }
        }
        /// <summary>
        ///  Set or Get the smtp port.
        /// </summary>
        public int SmtpPort
        {
            set
            {
                _smtpPort = value;
                OnPropertyChanged("SmtpPort");
            }
            get
            {
                return _smtpPort;
            }
        }
        /// <summary>
        ///  Set or get the smtp server.
        /// </summary>
        public string SmtpServer
        {
            set
            {
                _smtpServer = value;
                OnPropertyChanged("SmtpServer");
            }
            get
            {
                return _smtpServer;
            }
        }
      
    }
}
