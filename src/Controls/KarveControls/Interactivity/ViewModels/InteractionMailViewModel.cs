using KarveControls.Interactivity.Notifications;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Interactivity.ViewModels
{
    public class InteractionMailViewModel : InteractionBaseViewModel<MailNotification>
    {
        private string _destinationAddress;
        private int _port;
        private string _server;
        private bool _gmailEnable;
        private bool _outlookEnable;


       

        public InteractionMailViewModel(): base()
        {
            // To setup the interaction request we only need to create instances of the InteractionRequest class
            // and expose them through properties. The InteractionRequestTriggers will bind to them and subscribe
            // to the corresponding events automatically.
            // The InteractionRequest class requires a parameter that has to inherit from the INotification class.
            this.InteractionRequest = new InteractionRequest<MailNotification>();
          
        }

        /// <summary>
        ///  Set or Get a destination address.
        /// </summary>
        public string DestinationAddress
        {
            set
            {
                _destinationAddress = value;
                RaisePropertyChanged("DestinationAddress");
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
                _destinationAddress = value;
                RaisePropertyChanged("SenderAddress");
            }
            get
            {
                return _destinationAddress;
            }
        }
        /// <summary>
        ///  Set or get an smtp port.
        /// </summary>
        public int SmtpPort
        {   set
            {
                _port = value;
                RaisePropertyChanged("SmtpPort");
            }
            get
            {
                return _port;
            }
        }
        /// <summary>
        ///  Set or Get SmtpServer
        /// </summary>
        public string SmtpServer
        {
            set
            {
                _server = value;
                RaisePropertyChanged("SmtpServer");
            }
            get
            {
                return _server;
            }
        }

        /// <summary>
        ///  Set or Get GmailEnable
        /// </summary>
        public bool GmailEnable
        {
            set
            {
                _gmailEnable = value;
                RaisePropertyChanged("GmailEnable");
            }
            get
            {
                return _gmailEnable;
            }
        }
        /// <summary>
        ///  Set or Get OutlookEnable
        /// </summary>
        public bool OutlookEnable
        {
            set
            {
                _outlookEnable = value;
                RaisePropertyChanged("OutlookEnable");

            }
            get
            {
                return _outlookEnable;
            }
        }

        public string Subject { get; set; }

        public override void RaiseInteraction()
        {
            MailNotification notification = new MailNotification();
            notification.DestinationAddress = DestinationAddress;
            notification.SenderAddress = SenderAddress;
            notification.SmtpPort = SmtpPort;
            notification.SmtpServer = SmtpServer;
            notification.OutLookEnable = OutlookEnable;
            notification.GmailEnabled = GmailEnable;
            if (InteractionRequest!=null)
            {
                InteractionRequest.Raise(notification);
            }
        }

    }
}
