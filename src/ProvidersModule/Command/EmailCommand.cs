using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace ProvidersModule.Command
{
    public class EmailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool isOutLookPresent = false;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        private void OutLookStrategy(string emailAddress)
        {
            /*
            List<string> lstAllRecipients = new List<string>();
            lstAllRecipients.Add(emailAddress);
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            Outlook.Inspector oInspector = oMailItem.GetInspector;
            // Recipient
            Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
            foreach (String recipient in lstAllRecipients)
            {
                Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                oRecip.Resolve();
            }
            //Add Subject
            oMailItem.Subject = "Notifica";
            //Display the mailbox
            oMailItem.Display(true);
            */
        }
      
        public void Execute(object parameter)
        {
            // here i suppose that paramter is a string
            string emailAddress = parameter as string;
            if (emailAddress != null)
            {
                if (isOutLookPresent)
                {
                    OutLookStrategy(emailAddress);
                }
                else
                {
                    string subject = "Subject";
                    string emailTag = string.Format("mailto:{0}?subject={1}",emailAddress,subject);
                    System.Diagnostics.Process.Start(emailTag);
                }
            }
         }
    }
}
