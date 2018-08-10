using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.Win32;
using Prism.Commands;
using System.IO;
using Prism.Mvvm;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.Linq;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using EmailValidation;

namespace KarveControls
{
    public class AttachmentDescriptor: BindableBase
    {
        private string _attachedFile;
        private ICommand _removeCommand;
       

        public AttachmentDescriptor(string fileName, ICommand command)
        {
            this._attachedFile = fileName;
            this._removeCommand = command;
        }

        /// <summary>
        ///  Set or get the attached filepath
        /// </summary>
        public string AttachedFile {
            set
            {
                _attachedFile = value;
                RaisePropertyChanged("AttachedFile");
            }
            get
            {
                return _attachedFile;
            }
        }
        /// <summary>
        ///  Set or get the remove command
        /// </summary>
        public ICommand RemoveCommand
        {
            set
            {
                _removeCommand = value;
                RaisePropertyChanged("RemoveCommand");
            }
            get
            {
                return _removeCommand;
            }
        } 

    }
    /// <summary>
    /// Interaction logic for MailControl.xaml
    /// </summary>
    public partial class MailControl : UserControl, IDisposable, INotifyPropertyChanged
    {

        private const string OutlookSmtpAddress = "smtp-mail.outlook.com";
        private const string GmailSmtpAddress = "smtp.gmail.com";
        private const int UniversalSmtpPort = 587;
        private const string AttachedClip = "/KarveControls;component/Images/attachfile.png";
        private BodyBuilder _bodyMessageBuilder;
        private ObservableCollection<string> _autoCompleteList = new ObservableCollection<string>();
        private ObservableCollection<AttachmentDescriptor> _attachementListComplete = new ObservableCollection<AttachmentDescriptor>();
        private bool skipUpdating = false;
        private bool _hasContent;
        private ICommand _sendMailCommand;
        private ICommand _exportPDFCommand;
        public static readonly DependencyProperty SmtpServerProperty = DependencyProperty.Register(
  "SmtpServer", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SmtpPortProperty = DependencyProperty.Register(
"SmtpPort", typeof(int), typeof(MailControl), new PropertyMetadata(22));
        public static readonly DependencyProperty IsGmailProperty = DependencyProperty.Register(
"IsGmail", typeof(bool), typeof(MailControl), new PropertyMetadata(false));
        public static readonly DependencyProperty IsOutlookProperty = DependencyProperty.Register(
"IsOutlook", typeof(bool), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty UserProperty = DependencyProperty.Register(
"User", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
"Password", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ControlPasswordProperty = DependencyProperty.Register(
"ControlPassword", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SenderAddressProperty = DependencyProperty.Register(
"SenderAddress", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty SenderReadOnlyProperty = DependencyProperty.Register(
"SenderReadOnly", typeof(bool), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty DestinationAddressProperty = DependencyProperty.Register(
"DestinationAddress", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SubjectProperty = DependencyProperty.Register(
"Subject", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty TextContentProperty = DependencyProperty.Register(
"TextContent", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty FilePathProperty = DependencyProperty.Register(
"FilePath", typeof(string), typeof(MailControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty AttachFileCommandProperty = DependencyProperty.Register(
"AttachFileCommand", typeof(ICommand), typeof(MailControl));

        public static readonly DependencyProperty PrintCommandProperty = DependencyProperty.Register(
"PrintCommand", typeof(ICommand), typeof(MailControl));

        public static readonly DependencyProperty ExportPDFCommandProperty = DependencyProperty.Register(
"ExportPDFCommand", typeof(ICommand), typeof(MailControl));

        public static readonly DependencyProperty SendMailCommandProperty = DependencyProperty.Register(
"SendMailCommand", typeof(ICommand), typeof(MailControl));
        // SpellerCheckerCommand
        public static readonly DependencyProperty SpellerCheckerCommandProperty = DependencyProperty.Register("SpellerCheckerCommand", typeof(ICommand), typeof(MailControl));

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///  Set or get the smtp server.
        /// </summary>
        public string SmtpServer
        {
            set
            {
                SetValue(SmtpServerProperty, value);
            }
            get
            {
                return (string)GetValue(SmtpServerProperty);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<AttachmentDescriptor> AttachmentSource
        {
            set
            {
                _attachementListComplete = value;
                OnPropertyChanged("AttachmentSource");
            }
            get
            {
                return _attachementListComplete;
            }
        }
        /// <summary>
        ///  Set or Get the smtp port.
        /// </summary>
        public int SmtpPort
        {
            set
            {
                SetValue(SmtpPortProperty, value);
            }
            get
            {
                return (int)GetValue(SmtpPortProperty);
            }
        }
        public bool IsGmail
        {
            set
            {
                SetValue(IsGmailProperty, value);
            }
            get
            {
                return (bool)GetValue(IsGmailProperty);
            }
        }
        public bool IsOutlook
        {
            set
            {
                SetValue(IsOutlookProperty, value);
            }
            get
            {
                return (bool)GetValue(IsOutlookProperty);
            }
        }
  
        public string SenderAddress
        {
            set
            {
                SetValue(SenderAddressProperty, value);
            }
            get
            { 
                return (string)GetValue(SenderAddressProperty);
            }
        }
        public string User
        {
            set
            {
                SetValue(UserProperty, value);
            }
            get
            {
                return (string)GetValue(UserProperty);
            }
        }
        public string Password
        {
            set
            {
                SetValue(PasswordProperty, value);
            }
            get
            {
                return (string)GetValue(PasswordProperty);
            }
        }
        public bool SenderReadOnly
        {
            set
            {
                SetValue(SenderReadOnlyProperty, value);
            }
            get
            {
                return (bool)GetValue(SenderReadOnlyProperty);
            }
        }

        public string DestinationAddress
        {
            set
            {
                SetValue(DestinationAddressProperty, value);
            }
            get
            {
                return (string)GetValue(DestinationAddressProperty);
            }
        }
        public string Subject
        {
            set
            {
                SetValue(SubjectProperty, value);
            }
            get
            {
                return (string)GetValue(SubjectProperty);
            }
        }
        /// <summary>
        ///  Set or get the text content.
        /// </summary>
        public string TextContent
        {
            set
            {
                SetValue(TextContentProperty, value);
            }
            get
            {
                return (string)GetValue(TextContentProperty);
            }
        }
        /// <summary>
        ///  Set or Get the attached file command.
        /// </summary>
        public ICommand AttachFileCommand
        {
            set
            {
                SetValue(AttachFileCommandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(AttachFileCommandProperty);
            }
        }
        public ICommand ExportPDFCommand
        {
            set
            {
                SetValue(ExportPDFCommandProperty, value);
             
            }
            get
            {
                return (ICommand) GetValue(ExportPDFCommandProperty);
            }
        }
        public ICommand SendMailCommand
        {
            set
            {
                SetValue(SendMailCommandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(SendMailCommandProperty);
            }
        }
        /// <summary>
        ///  Path of the attached file.
        /// </summary>
        public string FilePath
        {
            set
            {
                SetValue(FilePathProperty, value);
            }
            get
            {
                return (string)GetValue(FilePathProperty);
            }
        }

        void AttachItem(string fileName)
        {
            var descriptor = new AttachmentDescriptor(fileName,new DelegateCommand<object>(OnRemoveCommand));
            this.AttachmentSource.Add(descriptor);
        }

        private void OnRemoveCommand(object name)
        {
            var  fileName = name as string;
            var firstDefault = AttachmentSource.FirstOrDefault(x => x.AttachedFile == fileName);
            if (firstDefault != null)
            {
                AttachmentSource.Remove(firstDefault);
            }
        }

        void ExportDocument()
        {
            // Initializes the file save picker.
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Word Document (*.docx)|*.docx|Word 97 - 2003 Document (*.doc)|*.doc|Web Page (*.htm,*.html)|*.htm;*.html|Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt|Xaml File (*.xaml)|*.xaml",
                FilterIndex = 1
            };
            if ((bool)saveFileDialog.ShowDialog())
            {
                // Saves the document content into a file.
                richTextBoxAdv.Save(saveFileDialog.FileName);
            }
        }

        private string GetHtmlBody()
        {
            var body = new StringBuilder();
            if (richTextBoxAdv.Document != null)
            {
                // To skip internal updation of document on setting HtmlText property.
                Stream stream = new MemoryStream();
                // Serialize the document as Html Format into stream.
                richTextBoxAdv.Save(stream, Syncfusion.Windows.Controls.RichTextBoxAdv.FormatType.Html);
                stream.Position = 0;
                // Reads the Html text from the stream.
                using (StreamReader reader = new StreamReader(stream))
                {
                    string readText = reader.ReadToEnd();
                    body.Append(readText);
                }
            }
            return body.ToString();
        }

        private string GetTextBody()
        {
            string value = string.Empty;

            if (richTextBoxAdv.Document != null)
            {
                // To skip internal updation of document on setting HtmlText property.
                Stream stream = new MemoryStream();
                // Serialize the document as Html Format into stream.
                richTextBoxAdv.Save(stream, Syncfusion.Windows.Controls.RichTextBoxAdv.FormatType.Txt);
                stream.Position = 0;
                // Reads the Html text from the stream.
                // Reads the Html text from the stream.
                using (StreamReader reader = new StreamReader(stream))
                {
                    value = reader.ReadToEnd();
                }   
                
            }
            return value;
        }
        void ExportPDFDocument()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "PDF Document (*.pdf)|*.pdf",
                FilterIndex = 1
            };
            if ((bool)saveFileDialog.ShowDialog())
            {
                if ((saveFileDialog.FileName != null) &&
                (!string.IsNullOrEmpty(saveFileDialog.FileName)))
                {
                    using (var docStream = new MemoryStream())
                    {
                        try
                        {
                            richTextBoxAdv.Save(docStream, Syncfusion.Windows.Controls.RichTextBoxAdv.FormatType.Docx);
                            var wordDocument = new WordDocument(docStream);
                            // Creates an instance of DocToPDFConverter.
                            var converter = new DocToPDFConverter();
                            // Converts the Word document into PDF document.
                            var pdfDocument = converter.ConvertToPDF(wordDocument);
                            // Closes the instance of Word document object.
                            wordDocument.Close();
                            // Saves the PDF file.
                            pdfDocument.Save(saveFileDialog.FileName);
                            // Closes the instance of PDF document object.
                            pdfDocument.Close(true);
                        } catch (Exception ex)
                        {
                            MessageBox.Show("Error during saving: " + ex.Message);
                            return;
                        }
                        MessageBox.Show("Message saved with success", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        public void OnAttachCommand()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string openImageFile = KarveLocale.Properties.Resources.lrapmnitAbrir;
            dlg.Filter = openImageFile + "(*.doc, *.png, *.pdf) | *.doc; *.png;*.png";
            dlg.Title =  KarveLocale.Properties.Resources.lattachdocument;
            dlg.DefaultExt = ".png"; // Default file extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                // at this point i shall check if the file is not empty
                if ((!string.IsNullOrEmpty(filename)) && (File.Exists(filename)))
                {
                    AttachItem(filename);
                 
                }
            }       
        }
       
        private  bool ValidateMessage(string emailValue)
        {
            var emailValid = EmailValidator.Validate(emailValue);
            if (!emailValid)
            {
                MessageBox.Show(KarveLocale.Properties.Resources.laddressMail +" "+ emailValue + " not valid", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }


        private void SendMail()
        {
            var message = CraftMessage();
            var smtpServer = SmtpServer;
            var smtpPort = 25;
            if (IsGmail)
            {
                smtpServer = GmailSmtpAddress;
                smtpPort = UniversalSmtpPort;
            }
            else if (IsOutlook)
            {
                smtpServer = OutlookSmtpAddress;
                smtpPort = UniversalSmtpPort;
            }
            if (string.IsNullOrEmpty(smtpServer))
            {
                MessageBox.Show(KarveLocale.Properties.Resources.lservernotconfigured);
            }

            if (message != null)
            {
             
                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.Connect(smtpServer, smtpPort, false);
                        if (IsGmail || IsOutlook)
                        {
                            client.Authenticate(User, Password);

                        }
                        // Note: only needed if the SMTP server requires authentication
                        client.Send(message);
                        client.Disconnect(true);
                    } catch(Exception ex)
                    {
                        MessageBox.Show("Sending message failed :" + ex.Message);
                    }
                }

            }
        }
        private bool ValidateContent(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("No message will be sent. The body is empty!");
                return false;
            }
            return true;
        }
        private MimeMessage CraftMessage()
        {

            /* 
             * Now i have to get the addresses  from and to.
             * 1. Get the from address and validate.
             * 2. Get the to address and validate.
             * 3. Create the body and validate.
             */

            var message = new MimeMessage();
            var validMail = ValidateMessage(this.SenderAddress);
            if (validMail)
            {
                validMail = ValidateMessage(this.DestinationAddress);
                return null;
            }
            if (validMail)
            {
                message.From.Add(new MailboxAddress(this.SenderAddress));
                message.To.Add(new MailboxAddress(this.DestinationAddress));
                message.Subject = this.Subject;
            }
            else
            {
                return null;
            }
            var builder = new BodyBuilder();
            builder.TextBody = GetTextBody();
            if (!ValidateContent(builder.TextBody))
            {
                return null;
            }
            foreach (var attachment in AttachmentSource)
            {
                builder.Attachments.Add(attachment.AttachedFile);
            }
            message.Body = builder.ToMessageBody();
            return message;
        }

        public MailControl()
        {
            InitializeComponent();
#if Framework4_0
            //Enables touch manipulation.
            rte.IsManipulationEnabled = true;
#endif

            DataContext = this;
            // this enable pdf export.
            HasData = true;
            InitCommands();
            
            this.richTextBoxAdv.ContentChanged += RicTextBoxAdv_ContentChanged;
        }
        public bool HasData {
            set
            {
                _hasContent = value;
                OnPropertyChanged("HasContent");
            }
            get
            {
                return _hasContent;
            }
        }

      
        private void RicTextBoxAdv_ContentChanged(object obj, ContentChangedEventArgs args)
        {
            if (richTextBoxAdv.Document != null)
            {
                // To skip internal updation of document on setting HtmlText property.
                skipUpdating = true;
                Stream stream = new MemoryStream();
                // Serialize the document as Html Format into stream.
                richTextBoxAdv.Save(stream, Syncfusion.Windows.Controls.RichTextBoxAdv.FormatType.Html);
                stream.Position = 0;
                // Reads the Html text from the stream.
                using (StreamReader reader = new StreamReader(stream))
                {
                    UpdateDocument(reader.ReadToEnd());
                }
                skipUpdating = false;
            }
            
        }
        private void UpdateDocument(string htmlText)
        {
            // If HtmlText property is set internally means, skip updating the document.
            if (!skipUpdating && !string.IsNullOrEmpty(TextContent))
            {
                Stream stream = new MemoryStream();
                // Convert the html text to byte array.
                byte[] bytes = Encoding.UTF8.GetBytes(TextContent);
                // Writes the byte array to stream.
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                //Load the stream.
                this.richTextBoxAdv.Load(stream, Syncfusion.Windows.Controls.RichTextBoxAdv.FormatType.Txt);
               
            }
        }

        void InitCommands()
        {
            AttachFileCommand = new DelegateCommand(OnAttachCommand);
            ExportPDFCommand = new DelegateCommand(ExportPDFDocument);
            SendMailCommand = new DelegateCommand(SendMail);
        }

        public void Dispose()
        {
            _bodyMessageBuilder = null;
        }
    }
}
