using KarveControls.Interactivity.Notifications;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Interactivity.ViewModels
{
    public class  InteractionReportViewModel: InteractionBaseViewModel<ReportNotification>
    {
        private MemoryStream _document;
      

        public InteractionReportViewModel()
        {
            // To setup the interaction request we only need to create instances of the InteractionRequest class
            // and expose them through properties. The InteractionRequestTriggers will bind to them and subscribe
            // to the corresponding events automatically.
            // The InteractionRequest class requires a parameter that has to inherit from the INotification class.
            this.InteractionRequest = new InteractionRequest<ReportNotification>();
        }
        /// <summary>
        ///  Set or Get the document to show.
        /// </summary>
        public MemoryStream Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;
                RaisePropertyChanged("Document");
            }
        }
       

        public override void RaiseInteraction()
        {
            ReportNotification notification = new ReportNotification();
            notification.Document = Document;
            notification.Title = Title;
            if (InteractionRequest != null)
            {
                InteractionRequest.Raise(notification);
            }
        }

    }
}
