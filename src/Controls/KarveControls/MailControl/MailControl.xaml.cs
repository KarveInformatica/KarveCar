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

namespace KarveControls.MailControl
{
    public class AttachmentDescriptor: BindableBase
    {
        private string _attachedFile;
        private ICommand _removeCommand;
        /// <summary>
        ///  Set or get the attached filepath
        /// </summary>
        public string AttachedFile {
            set
            {
                _attachedFile = value;
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
    public partial class MailControl : UserControl
    {

        private const string OutlookSmtpAddress = "smtp-mail.outlook.com";
        private const string GmailSmtpAddress = "smtp.gmail.com";
        private const int UniversalSmtpPort = 587;
        private IList<string> linkedString = new List<string>();
        private IList<string> autoCompleteList = new List<string>();

       
        
        public static readonly DependencyProperty SmtpServerProperty = DependencyProperty.Register(
  "SmtpServer", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty SmtpPortProperty = DependencyProperty.Register(
"SmtpPort", typeof(int), typeof(MailControl), new PropertyMetadata(false));
        public static readonly DependencyProperty IsGmailProperty = DependencyProperty.Register(
"IsGmail", typeof(bool), typeof(MailControl), new PropertyMetadata(false));
        public static readonly DependencyProperty IsOutlookProperty = DependencyProperty.Register(
"IsOutlook", typeof(bool), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty UserProperty = DependencyProperty.Register(
"User", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
"Password", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty SenderAddressProperty = DependencyProperty.Register(
"SenderAddress", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty DestinationAddressProperty = DependencyProperty.Register(
"DestinationAddress", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty SubjectProperty = DependencyProperty.Register(
"Subject", typeof(string), typeof(MailControl), new PropertyMetadata(false));


        public static readonly DependencyProperty HtmlContentProperty = DependencyProperty.Register(
"HtmlContent", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty FilePathProperty = DependencyProperty.Register(
"FilePath", typeof(string), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty AttachFileCommandProperty = DependencyProperty.Register(
"AttachFileCommand", typeof(ICommand), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty PrintCommandProperty = DependencyProperty.Register(
"PrintCommand", typeof(ICommand), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty ExportPDFCommandProperty = DependencyProperty.Register(
"ExportPDFCommand", typeof(ICommand), typeof(MailControl), new PropertyMetadata(false));

        public static readonly DependencyProperty SendMailCommandProperty = DependencyProperty.Register(
"SendMailCommand", typeof(ICommand), typeof(MailControl), new PropertyMetadata(false));
        // SpellerCheckerCommand
        public static readonly DependencyProperty SpellerCheckerCommandProperty = DependencyProperty.Register("SpellerCheckerCommand", typeof(ICommand), typeof(MailControl), new PropertyMetadata(false));

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
        ///  Set or get the html content.
        /// </summary>
        public string HtmlContent
        {
            set
            {
                SetValue(HtmlContentProperty, value);
            }
            get
            {
                return (string)GetValue(HtmlContentProperty);
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
        public ICommand PrintCommand
        {
            set
            {
                SetValue(PrintCommandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(PrintCommandProperty);
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
                return (ICommand)GetValue(ExportPDFCommandProperty);
            }
        }
        /// <summary>
        ///  Path of the attached file.
        /// </summary>
        public string FilePath
        {
            set
            {
                SetValue(HtmlContentProperty, value);
            }
            get
            {
                return (string)GetValue(HtmlContentProperty);
            }
        }

        public void OnAttachCommand()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string openImageFile = "Abres File";
            dlg.Filter = openImageFile + "(*.doc, *.png, *.pdf) | *.doc; *.png;*.png";
            dlg.Title = "Alega documento";
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
                    this.linkedString.Add(filename);

                }
            }       
        }
        private void SendMail()
        {

             var builder = new BodyBuilder();
             
       
        }
        public MailControl()
        {
            InitializeComponent();
#if Framework4_0
            //Enables touch manipulation.
            rte.IsManipulationEnabled = true;
            
#endif

            this.DataContext = this;
        }
        void InitCommands()
        {
            AttachFileCommand = new DelegateCommand(OnAttachCommand);
        }
    }
}
