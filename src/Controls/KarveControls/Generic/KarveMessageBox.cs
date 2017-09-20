using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using System.Windows.Media;
using Telerik.WinControls.RichTextBox.FormatProviders.Txt;


namespace KarveControls.Generic
{
    public class kMsgBox
    {

        #region "Variables"

       // private Media.SystemSound sound;
        public enum kMsgBoxStyle
        {
            OkOnly,
            OkCancel,
            YesNo,
            YesNoCancel,
            Exclamation,
            Information,
            Question,
            ErrorInformation,
            Critical
        }
        #endregion

        #region "Print"
        public DialogResult Print(string msg, kMsgBoxStyle style = kMsgBoxStyle.OkOnly, string extraMsg = "", string title = "Karve")
        {
            /*
            msg = Translate(msg);
            setState(msg, style, extraMsg, title);
            lblMasDetalles.Text = "+ Más Detalles";
            this.Height = 142;
            masDetalles = false;
            OK_Button.Select();
            this.ShowDialog();
            */
            return DialogResult.OK;
        }

        private void kMsgBox_Shown(object sender, EventArgs e)
        {
            //bgwSound.RunWorkerAsync();
        }

        private void bgwSound_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
              //  My.Computer.Audio.PlaySystemSound(sound);
            }
            catch
            {
            }
        }
        #endregion

        #region "SetSate"
        private void setState(string msg, kMsgBoxStyle style, string extraMsg, string title)
        {
            /*
            lblInfo.Text = msg;
            this.Text = title;
            TxtFormatProvider provider = new TxtFormatProvider();
            rtbDetalles.Document = provider.Import(extraMsg);

            lblInfo.Location = new Drawing.Point(12, 12);
            lblInfo.Width = 337;
            pbxImage.Visible = false;

            sound = Media.SystemSounds.Beep;

            switch (style)
            {
                case kMsgBoxStyle.OkOnly:
                    OkOnly();
                    break;
                case kMsgBoxStyle.OkCancel:
                    OkCancel();
                    break;
                case kMsgBoxStyle.YesNo:
                    YesNo();
                    break;
                case kMsgBoxStyle.YesNoCancel:
                    YesNoCancel();
                    break;
                case kMsgBoxStyle.Exclamation:
                    Exclamation();
                    break;
                case kMsgBoxStyle.Information:
                    Information();
                    break;
                case kMsgBoxStyle.Question:
                    Question();
                    break;
                case kMsgBoxStyle.ErrorInformation:
                    ErrorInformation();
                    break;
                case kMsgBoxStyle.Critical:
                    Critical();
                    break;
            }
            */
        }

        private void OkOnly()
        {
            /*
            showButtons(1);
            OK_Button.DialogResult = Windows.Forms.DialogResult.OK;
            OK_Button.Text = "Aceptar";
            showDetails();
            */
        }
        private void OkCancel()
        {
            showButtons(2);
            /*
            OK_Button.DialogResult = Windows.Forms.DialogResult.OK;
            OK_Button.Text = "Aceptar";
            Cancel_Button.DialogResult = Windows.Forms.DialogResult.Cancel;
            Cancel_Button.Text = "Cancelar";
            showDetails();
            */
        }
        private void YesNo()
        {
            //showButtons(2);
            /*
            OK_Button.DialogResult = Windows.Forms.DialogResult.Yes;
            OK_Button.Text = "Si";
            Cancel_Button.DialogResult = Windows.Forms.DialogResult.No;
            Cancel_Button.Text = "No";
            */
            showDetails();
        }
        private void YesNoCancel()
        {
            showButtons(3);
            /*
            OK_Button.DialogResult = Windows.Forms.DialogResult.Yes;
            OK_Button.Text = "Si";
            Cancel_Button.DialogResult = Windows.Forms.DialogResult.No;
            Cancel_Button.Text = "No";
            btnExtra.DialogResult = Windows.Forms.DialogResult.Cancel;
            btnExtra.Text = "Cancelar";
            */
            showDetails();
        }
        private void Exclamation()
        {
            OkOnly();
            showImage(kMsgBoxStyle.Exclamation);
           // sound = Media.SystemSounds.Exclamation;
        }
        private void Information()
        {
            OkOnly();
            showImage(kMsgBoxStyle.Information);
            // sound = Media.SystemSounds.Asterisk;
        }
        private void Question()
        {
            YesNoCancel();
            showImage(kMsgBoxStyle.Question);
            // sound = Media.SystemSounds.Question;
        }
        private void ErrorInformation()
        {
            OkOnly();
            showImage(kMsgBoxStyle.ErrorInformation);
            //sound = Media.SystemSounds.Hand;
        }
        private void Critical()
        {
            /*
            OK_Button.DialogResult = Windows.Forms.DialogResult.None;
            OK_Button.Text = "Continuar";
            Cancel_Button.DialogResult = Windows.Forms.DialogResult.Abort;
            Cancel_Button.Text = "Salir";
            showDetails();
            showImage(kMsgBoxStyle.Critical);
            sound = Media.SystemSounds.Hand;
            */
        }

        private void showDetails()
        {
            TxtFormatProvider provider = new TxtFormatProvider();
            string txt = "";
            // string txt = provider.Export(rtbDetalles.Document);
            if (!string.IsNullOrEmpty(txt))
            {
              //  lblMasDetalles.Visible = true;
              //  rtbDetalles.Visible = true;
            }
            else
            {
            //    lblMasDetalles.Visible = false;
             //   rtbDetalles.Visible = false;
            }
        }
        private void showImage(kMsgBoxStyle style)
        {
            /*
            lblInfo.Location = new Drawing.Point(69, 12);
            lblInfo.Width = 280;

            pbxImage.Visible = true;
            */
            switch (style)
            {
                case kMsgBoxStyle.Exclamation:
                  //  pbxImage.Image = CustomControls.My.Resources.Resources.exclamation48x48;
                    break;
                case kMsgBoxStyle.Information:
                   // pbxImage.Image = CustomControls.My.Resources.Resources.information48x48;
                    break;
                case kMsgBoxStyle.Question:
                   // pbxImage.Image = CustomControls.My.Resources.Resources.question48x48;
                    break;
                case kMsgBoxStyle.ErrorInformation:
                   // pbxImage.Image = CustomControls.My.Resources.Resources.critical48x48;
                    break;
                case kMsgBoxStyle.Critical:
                   // pbxImage.Image = CustomControls.My.Resources.Resources.critical48x48;
                    break;
            }
        }
        private void showButtons(int nButtons)
        {
            if (nButtons == 1)
            {
                /*
                tlpButtons.ColumnCount = 1;
                tlpButtons.Size = new Drawing.Size(73, 29);
                tlpButtons.Location = new Drawing.Point(276, 72);
                btnExtra.Visible = false;
                Cancel_Button.Visible = false;
                this.CancelButton = Cancel_Button;
                */
            }
            else if (nButtons == 2)
            {
                /*
                tlpButtons.ColumnCount = 2;
                tlpButtons.Size = new Drawing.Size(146, 29);
                tlpButtons.Location = new Drawing.Point(203, 72);
                Cancel_Button.Visible = true;
                btnExtra.Visible = false;
                this.CancelButton = Cancel_Button;
                */
            }
            else
            {
                /*
                tlpButtons.ColumnCount = 3;
                tlpButtons.Size = new Drawing.Size(219, 29);
                tlpButtons.Location = new Drawing.Point(130, 72);
                Cancel_Button.Visible = true;
                btnExtra.Visible = true;
                this.CancelButton = btnExtra;
                */
            }
        }
        #endregion

        #region "Buttons"
        private void OK_Button_Click(System.Object sender, System.EventArgs e)
        {
            /*
            this.DialogResult = OK_Button.DialogResult;
            if (OK_Button.DialogResult == Windows.Forms.DialogResult.Abort)
            {
                System.Environment.Exit(-1);
            }
           */
           // this.Close();
        }

        private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
        {
            /*
            this.DialogResult = Cancel_Button.DialogResult;
            if (Cancel_Button.DialogResult == Windows.Forms.DialogResult.Abort)
            {
                System.Environment.Exit(-1);
            }
            */
            //this.Close();
        }

        private void btnExtra_Click(object sender, EventArgs e)
        {
            /*
            this.DialogResult = btnExtra.DialogResult;
            if (btnExtra.DialogResult == Windows.Forms.DialogResult.Abort)
            {
                System.Environment.Exit(-1);
            }
            this.Close();
            */
        }
        #endregion

        #region "MasDetalles"

        private bool masDetalles = false;
        private void lblMasDetalles_Click(object sender, EventArgs e)
        {
            /*
            if (!masDetalles)
            {
                lblMasDetalles.Text = "- Menos Detalles";
                this.Height = 292;
                masDetalles = true;
            }
            else
            {
                lblMasDetalles.Text = "+ Más Detalles";
                this.Height = 142;
                masDetalles = false;
            }
            */
        }

        private void OK_Button_MouseHover(object sender, EventArgs e)
        {
           // Cursor = Windows.Forms.Cursors.Hand;
        }

        private void OK_Button_MouseLeave(object sender, EventArgs e)
        {
           // Cursor = Windows.Forms.Cursors.Arrow;
        }
        public kMsgBox()
        {
           // Shown += kMsgBox_Shown;
        }

        #endregion

    }
  
}
