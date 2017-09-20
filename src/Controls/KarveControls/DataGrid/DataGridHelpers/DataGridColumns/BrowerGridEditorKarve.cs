using System;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace KarveControls.DataGrid.DataGridHelpers.DataGridColumns
{
    public class BrowerGridEditorKarve : BaseGridEditor
    {
        private bool endEditOnLostFocus_Renamed = true;
        public override object Value
        {
            get
            {
                BrowseEditorElement editor = (BrowseEditorElement) this.EditorElement;
                return editor.TextBox.Text;
            }
            set
            {
                BrowseEditorElement editor = (BrowseEditorElement) this.EditorElement;
                if (value != null && !object.ReferenceEquals(value, DBNull.Value))
                {
                    editor.TextBox.Text = value as string;
                }
                else
                {
                    editor.TextBox.Text = "";
                }
            }
        }

        public override void BeginEdit()
        {
            base.BeginEdit();
            BrowseEditorElement editor = (BrowseEditorElement) this.EditorElement;
            editor.TextBox.HostedControl.Focus();
            editor.Button.Click += Button_click;
        }

        public override bool EndEdit()
        {
            BrowseEditorElement editor = (BrowseEditorElement) this.EditorElement;
            editor.Button.Click -= Button_click;
            return base.EndEdit();
        }

        protected override RadElement CreateEditorElement()
        {
            return new BrowseEditorElement();
        }

        public override bool EndEditOnLostFocus
        {
            get { return endEditOnLostFocus_Renamed; }
        }

        private void Button_click(object sender, EventArgs e)
        {
            endEditOnLostFocus_Renamed = false;
            //Interaction.MsgBox("");
            endEditOnLostFocus_Renamed = true;
        }

    }
}

