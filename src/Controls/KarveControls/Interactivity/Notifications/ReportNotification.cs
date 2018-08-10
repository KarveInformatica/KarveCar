using KarveControls.Annotations;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Interactivity.Notifications
{
    /// <summary>
    /// ReportNotification. It repors a confirmation for notification.
    /// </summary>
    public class ReportNotification : BaseNotification, IDisposable
    {
        private MemoryStream _document;
       
        /// <summary>
        /// Set or Get the stream of documents.
        /// </summary>
        public MemoryStream Document
        {
            get => _document;
            set
            {

                _document = value;
                OnPropertyChanged("Document");

            }
        }
       

        public void Dispose()
        {
            if (_document != null)
            {
                _document.Close();
                _document = null;
            }
        }
    }
}
