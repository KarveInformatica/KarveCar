using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Telerik.WinControls.RichTextBox.FormatProviders.Txt;
using Telerik.WinControls.RichTextBox.FormatProviders.Rtf;
using Telerik.WinControls.RichTextBox.FileFormats.Html;
using Telerik.WinControls.RichTextBox.FileFormats.OpenXml.Docx;
using System.IO;
using Telerik.WinControls.RichTextBox.FormatProviders;
using System.ComponentModel;
using Telerik.WinControls.RichTextBox.FileFormats.Rtf;
using Telerik.WinControls.RichTextBox.Model.Styles;
using System.Drawing;
using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.UI;
using Telerik.WinControls.RichTextBox;
using System.Collections.Generic;
using System.Windows.Controls;
using RichFormatTextSpan = Telerik.WinControls.RichTextBox.Model.Span;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for BindableRichTextbox.xaml
    ///  This is a control for 
    /// </summary>
    public partial class DataRichTextField : System.Windows.Controls.UserControl, INotifyPropertyChanged
    { 
        #region "Variables"
        private RadRichTextBox _dataContainer;
        private TextType _textType;
        private string _tableName;
        private string _dataField;
        private DataTable _itemSource;
        private bool _textError;
        private byte[] _bytes;
        public enum List_Data
        {
           Text,
            Any
        }
        public enum Code_Collation
        {
          LATIN,
          UTF8
        }
        public enum TextType
        {
          Plain,
          RTF,
          HTML,
          DOCX
        }

        #endregion

        #region "Properties"
        #region DataAllowed
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(CommonControl.DataType),
                typeof(DataRichTextField),
                new PropertyMetadata(CommonControl.DataType.Any));
#endregion
        #region DataField
        public static DependencyProperty DataBaseFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnDataBaseFieldChanged));

        public string DataField
        {
            get { return (string)GetValue(DataBaseFieldDependencyProperty); }
            set { SetValue(DataBaseFieldDependencyProperty, value); }
        }
        private static void OnDataBaseFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField controlDataField = d as DataRichTextField;
            if (controlDataField != null)
            {
                controlDataField.OnPropertyChanged("DataField");
                controlDataField.OnDataFieldPropertyChanged(e);
            }
        }
        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            if ((this._itemSource != null) && (this._itemSource.Rows.Count > 0))
            {
                DataRow row = this._itemSource.Rows[0];
                string field = row[_dataField] as string;
                _dataContainer.Text = field;
            }

        }
        #endregion

        #region Description

        

        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataRichTextField),
                new PropertyMetadata(String.Empty));

        #endregion

        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataRichTextField),
                new PropertyMetadata(false));

        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }
        
        public static readonly DependencyProperty ValidateDependencyProperty =
            DependencyProperty.Register(
                "Validate",
                typeof(bool),
                typeof(DataRichTextField),
                new PropertyMetadata(false));
        public bool Validate
        {
            get { return (bool)GetValue(ValidateDependencyProperty); }
            set { SetValue(ValidateDependencyProperty, value); }
        }

        #region TextContent
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataRichTextField), new PropertyMetadata(string.Empty, OnTextContentChange));

        public string TextContent
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }
        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("TextContent");
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            _dataContainer.Text = value;
        }
        #endregion

        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(DataRichTextField),
                new PropertyMetadata(false, OnReadOnlyDependencyProperty));


        private static void OnReadOnlyDependencyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField controlDataField = d as DataRichTextField;
            if (controlDataField != null)
            {
                controlDataField.OnPropertyChanged("IsReadOnly");
                controlDataField.OnReadOnlyPropertyChanged(e);
            }
        }

        private void OnReadOnlyPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                _dataContainer.BackColor = System.Drawing.Color.LightBlue;
            }
            else
            {
                _dataContainer.BackColor = System.Drawing.Color.White;
            }
            this._dataContainer.IsReadOnly = value;
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }

        #endregion
        #region TableName
        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataSearchTextBox),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }

        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }

        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }
        #endregion
        #region LabelVisible

        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnLabelVisibleChange));

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisibleChanged(e);
            }
        }

        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.LabelField.Visibility = Visibility.Visible;
            }
            else
            {
                this.LabelField.Visibility = Visibility.Hidden;
            }
        }
        #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextChanged(e);
            }
        }
        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string label = e.NewValue as string;
            this.LabelField.Text = label;
        }
        #endregion

        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Width = value;
        }

        #endregion
        #region TextType 
        public readonly static DependencyProperty TextTypeDependencyProperty =
            DependencyProperty.Register(
                "TextKind",
                typeof(TextType),
                typeof(DataRichTextField),
                new PropertyMetadata(TextType.Plain));

        public TextType TextKind
        {
            get { return (TextType)GetValue(TextTypeDependencyProperty); }
            set { SetValue(TextTypeDependencyProperty, value); }
        }

        #endregion

        #region TextData 
        public readonly static DependencyProperty TextDataDependencyProperty =
            DependencyProperty.Register(
                "TextData",
                typeof(string),
                typeof(DataRichTextField),
                new PropertyMetadata(String.Empty));

        public string TextData
        {
            get { return (string)GetValue(TextDataDependencyProperty); }
            set { SetValue(TextDataDependencyProperty, value); }
        }

        #endregion

        #region BinaryData
        public readonly static DependencyProperty BinaryDataDependencyProperty =
            DependencyProperty.Register(
                "BinaryData",
                typeof(string),
                typeof(DataRichTextField),
                new PropertyMetadata(new byte[0]));

        public byte[] BinaryData
        {
            get { return (byte[])GetValue(BinaryDataDependencyProperty); }
            set { SetValue(BinaryDataDependencyProperty, value); }
        }

        #endregion

      
        #endregion


        // ok this is  new to get the text.

        

        #region "Eventos"
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
       

        

            private void DataRichField_Enter(object sender, EventArgs e)
            {
                _dataContainer.Focus();
            }

            private void DataRichField__Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
            /*
                if (this.Validate)
                {
                    Validar();
                }
                Text_Validating();
                */
                EndEdit();
            }

            private void txtCst_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
            /*
                if (_DataAllowed == List_Data.Text)
                {
                    e.Handled = Char_Code(ref _Encoding, ref e.KeyChar);
                    if (_UpperCase)
                    {
                        e.KeyChar = Strings.UCase(e.KeyChar);
                    }
                }
                */
            }

            private void Datafield_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == Keys.X & e.Control)
                {
                    Cut(ref sender);
                }
                else if (e.KeyCode == Keys.C & e.Control)
                {
                    Copy(ref sender);
                }
                else if (e.KeyCode == Keys.V & e.Control)
                {
                    Paste(ref sender);
                }
            }

            private void rtbData_TextChanged(object sender, EventArgs e)
            {
                Text_Changed();
            }


            protected virtual void Text_Changed()
            {
            }

            protected virtual void Text_Validating()
            {
            }
            #endregion

            #region "Funciones del Texto"

            public string ExportToTXT()
            {
                TxtFormatProvider provider = new TxtFormatProvider();
                return provider.Export(_dataContainer.Document);
            }

            public string ExportToRTF()
            {
                RtfFormatProvider provider = new RtfFormatProvider();
                return provider.Export(_dataContainer.Document);
            }

            public string ExportToHTML()
            {
                HtmlFormatProvider provider = new HtmlFormatProvider();
                return provider.Export(_dataContainer.Document);
            }

            public void ExportToDOCX()
            {
                DocxFormatProvider provider = new DocxFormatProvider();
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = ".docx";
                saveDialog.Filter = "Documents|*.docx";
                DialogResult dialogResult = saveDialog.ShowDialog();
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    using (Stream output = saveDialog.OpenFile())
                    {
                        provider.Export(_dataContainer.Document, output);
                    }
                }
            }

            public byte[] ExportFromDOCXtoByteArray()
            {
                DocxFormatProvider provider = new DocxFormatProvider();
                MemoryStream ms = new MemoryStream();
                provider.Export(_dataContainer.Document, ms);
                byte[] data = ms.GetBuffer();
                return data;
            }

            public void ImportFromByteArrayToDOCX(byte[] data)
            {
                IDocumentFormatProvider provider = new DocxFormatProvider();
                using (MemoryStream ms = new MemoryStream(data, 0, data.Length))
                {
                    ms.Write(data, 0, data.Length);
                    _dataContainer.Document = provider.Import(ms);
                }
            }

            public void ImportFromRTF(string text)
            {
                try
                {
                    RtfFormatProvider provider = new RtfFormatProvider();
                    _dataContainer.Document = provider.Import(text);
                }
                catch (Exception ex)
                {
                    //kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromTXT(string text)
            {
                try
                {
                    TxtFormatProvider provider = new TxtFormatProvider();
                    _dataContainer.Document = provider.Import(text);
                }
                catch (Exception ex)
                {
               //     kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromHTML(string text)
            {
                try
                {
                    HtmlFormatProvider provider = new HtmlFormatProvider();
                    _dataContainer.Document = provider.Import(text);
                }
                catch (Exception ex)
                {
      //              kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromRTFFile(string filePath)
            {
                RtfFormatProvider provider = new RtfFormatProvider();
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        _dataContainer.Document = provider.Import(stream);
                    }
                }
                catch (Exception ex)
                {
                   // kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromTXTFile(string filePath)
            {
                try
                {
                    TxtFormatProvider provider = new TxtFormatProvider();
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        _dataContainer.Document = provider.Import(stream);
                    }
                }
                catch (Exception ex)
                {
                  //  kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromHTMLFile(string filePath)
            {
                try
                {
                    HtmlFormatProvider provider = new HtmlFormatProvider();
                    StreamReader stream = File.OpenText(filePath);
                    string str = "";
                    while (stream.Peek() >= 0)
                    {
                        str += stream.ReadLine();
                    }
                    stream.Close();
                    _dataContainer.Document = provider.Import(str);
                }
                catch (Exception ex)
                {
                   // kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void ImportFromDOCXFile(string filePath)
            {
                try
                {
                    IDocumentFormatProvider provider = new DocxFormatProvider();
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        _dataContainer.Document = provider.Import(stream);
                    }
                }
                catch (Exception ex)
                {
                  //  kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message);
                }
            }

            public void LoadText()
            {
                switch (this.TextKind)
                {
                    case TextType.Plain:
                        ImportFromTXT(this.TextContent);
                        break;
                    case TextType.RTF:
                        ImportFromRTF(this.TextContent);
                        break;
                    case TextType.HTML:
                        ImportFromHTML(this.TextContent);
                        break;
                    case TextType.DOCX:
                        ImportFromByteArrayToDOCX(_bytes);
                        break;
                }
            }

            public void saveText()
            {
                switch (TextKind)
                {
                    case TextType.Plain:
                        this.TextData = ExportToTXT();
                        break;
                    case TextType.RTF:
                        this.TextData = ExportToRTF();
                        break;
                    case TextType.HTML:

                        break;
                    case TextType.DOCX:
                        this.BinaryData = ExportFromDOCXtoByteArray();
                        break;
                }
            }

            #endregion

            #region "Funciones de Validacion"
            public void Validar()
            {
                this._textError = !ValidateData();
               // ValidateLabel();
            }

        /**
            private bool Char_Code(ref Code_Collation Code, ref char Character)
            {
                bool functionReturnValue = false;
                functionReturnValue = false;
                if (_Encoding == Code_Collation.UTF8)
                {
                    functionReturnValue = !Validate_Regex(Character, "[A-Z a-z 0-9 _\\-\\b\\'!·$%&/()=?¿¡^*+¨{}\\[\\]ºª,.;:@]");
                }
                else
                {
                    functionReturnValue = !Validate_Regex(Character, "[A-Z a-z 0-9 \\-_\\'À-Ä È-Ï Ò-Ö Ù-Ü à-ä è-ï ò-ö ù-ü ñçÑÇ\\b!·$%&/()=?¿¡^*+¨{}\\[\\]ºª,.;:@]");
                }
                return functionReturnValue;
            }
    */
            private bool Validate_Regex(string Text_To_Validate, string Pattern)
            {
                Match Text_Validated = Regex.Match(Text_To_Validate, Pattern);
                return Text_Validated.Success;
            }

            public bool ValidateData()
            {
                if (!this.AllowedEmpty & string.IsNullOrEmpty(_dataContainer.Text))
                {
                   // _MensajeIncorrecto = ("No se permite un dato vacío.");
                    return false;
                }
                
                return true;
            }


        #endregion

        #region "Funciones de Acceso a Datos"


        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();

            if (!string.IsNullOrEmpty(field))
            {
                System.Windows.Data.Binding oBind = null;
                if (TextKind == TextType.DOCX)
                {
                    oBind = new System.Windows.Data.Binding("TextData");
                }
                else
                {
                    oBind = new System.Windows.Data.Binding("TextContent");
                }
                oBind.Source = dta.Columns[field];
                oBind.Mode = BindingMode.TwoWay;
                oBind.ValidatesOnDataErrors = true;
                oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                if (rules != null)
                {
                    foreach (ValidationRule rule in rules)
                    {
                        oBind.ValidationRules.Add(rule);
                    }
                }
                
               // TextField.Width = dta.Columns[field].MaxLength;
                SetBinding(TextContentDependencyProperty, oBind);
            }

        }

        public static readonly DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DataRichTextField),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRichTextField control = d as DataRichTextField;
            if (control != null)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }
        private void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
            if (!string.IsNullOrEmpty(this.DataField))
            {
                SetDynamicBinding(ref _itemSource, null);
                ItemSource = _itemSource;
                //  DataRow row = table.Rows[0];
                //  string field = row[DataField] as string;
                //  TextContent = field;
            }
        }
        public void Clear()
        {
          if ((this.DataField != null) & !string.IsNullOrEmpty(DataField))
          {
                    BindingOperations.ClearBinding(this, TextContentDependencyProperty);
                }

                _dataContainer.Document = null;
              
            }

            public void EndEdit()
            {
                try
                {
                    saveText();
                /*
                  not yet pretty sure what happens here
                    if (_TextType == TextType.DOCX)
                    {
                         
                        this.DataBindings("Byte_Data").BindingManagerBase.EndCurrentEdit();
                    }
                    else
                    {
                        this.DataBindings("Text_Data").BindingManagerBase.EndCurrentEdit();
                    }
                    */
                }
                catch
                {
                }
            }

        
            #endregion

            #region "Cut Copy Paste"
            private void Cut(ref object sender)
            {
                /*
                if (sender.SelectedText.Length > 0)
                {
                    Clipboard.SetDataObject(sender.SelectedText);
                    sender.Cut();
                }
                */
            }
            private void Copy(ref object sender)
            {
            /*
                if (sender.SelectedText.Length > 0)
                {
                    sender.Copy();
                }
                */
            }
            private void Paste(ref object sender)
            {
            /*
            if (System.Windows.Clipboard.GetDataObject.GetDataPresent(DataFormats.Text))
                {
                    sender.Paste();
                }
                */
            }
            #endregion

            #region "Ribbon"

            protected void SetEvents()
            {
                _dataContainer.CurrentEditingStyleChanged+=DataContainerOnCurrentEditingStyleChanged;
                _dataContainer.Document.Selection.SelectionChanged+=SelectionOnSelectionChanged;
            /*
                rbnEdicion.Paste += ribbonPaste;
                rbnEdicion.Copy += ribbonCopy;
                rbnEdicion.Cut += ribbonCut;

                rbnEdicion.Bold += ribbonBold;
                rbnEdicion.Italic += ribbonItalic;
                rbnEdicion.Underline += ribbonUnderline;

                rbnEdicion.FontFamily += ribbonFontFamily;
                rbnEdicion.FontSize += ribbonFontSize;

                rbnEdicion.AlignChange += AlignChange;

                rbnEdicion.LoadFile += LoadFile;

                rbnEdicion.InsertImage += InsertImage;
                rbnEdicion.InsertLink += InsertLink;
                rbnEdicion.InsertTable += InsertTable;
                */
            }

        private void SelectionOnSelectionChanged(object sender, EventArgs eventArgs)
        {
          //  throw new NotImplementedException();
        }

        private void DataContainerOnCurrentEditingStyleChanged(object sender, EventArgs eventArgs)
        {
            StyleDefinition style = _dataContainer.CurrentEditingStyle;
          //  TextStyle fontWeight = (TextStyle)style.GetPropertyValue(RichFormatTextSpan.FontStyleProperty);
          //  TextStyle fontWeight = (TextStyle)style.GetPropertyValue(RichFormatTextSpan.FontStyleProperty);
            string fontFamily = (string)style.GetPropertyValue(RichFormatTextSpan.FontFamilyProperty);
            bool underline = (bool) style.GetPropertyValue(RichFormatTextSpan.UnderlineTypeProperty);
           // Telerik.WinControls.RichTextBox.Layout.RadTextAlignment align = (Telerik.WinControls.RichTextBox.Layout.RadTextAlignment)style.GetPropertyValue(Telerik.WinControls.RichTextBox.Model.Paragraph.TextAlignmentProperty) as Telerik.WinControls.RichTextBox.Layout.RadTextAlignment;

            // .. throw new NotImplementedException();
        }

        private void stylePropertiesChanged()
            {
                StyleDefinition style = _dataContainer.CurrentEditingStyle;
                TextStyle fontWeight = (TextStyle)style.GetPropertyValue(RichFormatTextSpan.FontStyleProperty);
                string fontFamily = (string)style.GetPropertyValue(RichFormatTextSpan.FontFamilyProperty);
                int fontSize = (int)style.GetPropertyValue(RichFormatTextSpan.FontSizeProperty);
                bool underline = (bool)style.GetPropertyValue(RichFormatTextSpan.UnderlineTypeProperty);
                Telerik.WinControls.RichTextBox.Layout.RadTextAlignment align = (Telerik.WinControls.RichTextBox.Layout.RadTextAlignment)style.GetPropertyValue(Telerik.WinControls.RichTextBox.Model.Paragraph.TextAlignmentProperty);

                if (fontWeight == TextStyle.Bold | fontWeight == (TextStyle.Bold | TextStyle.Italic))
                {
                  // TODO 
                //rbnEdicion.btnBold.IsChecked = true;
                }
                else
                {
                // TODO
                    //rbnEdicion.btnBold.IsChecked = false;
                }
                if (fontWeight == TextStyle.Italic | fontWeight == (TextStyle.Bold | TextStyle.Italic))
                {
                // TODO
                    //rbnEdicion.btnItalic.IsChecked = true;
                }
                else
                {
                    //rbnEdicion.btnItalic.IsChecked = false;
                }
                // rbnEdicion.btnUnderline.IsChecked = underline;

                // rbnEdicion.cbxFontFamily.EditableElementText = fontFamily;
                // rbnEdicion.cbxFontSize.EditableElementText = fontSize;
                switch (align)
                {
                    case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Left:
                        break;
                    case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Center:
                        break;
                    case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Right:
                        break;
                }
            }

            private void ribbonPaste()
            {
                _dataContainer.Paste();
                _dataContainer.Focus();
           
                //rtbData.Paste();
              //  rtbData.Focus();
            }

            private void ribbonCopy()
            {

            _dataContainer.Copy();
                //.Copy();
                _dataContainer.Focus();
            }

            private void ribbonCut()
            {
                _dataContainer.Cut();
                _dataContainer.Focus();
            }

            private void ribbonBold()
            {
                _dataContainer.ToggleBold();
                _dataContainer.Focus();
            }

            private void ribbonItalic()
            {
                _dataContainer.ToggleItalic();
               _dataContainer.Focus();
            }

            private void ribbonUnderline()
            {
                _dataContainer.ToggleUnderline();
               _dataContainer.Focus();
            }

            private void ribbonFontFamily(string font)
            {
                _dataContainer.ChangeFontFamily(font);
            }

            private void ribbonFontSize(int size)
            {
                _dataContainer.ChangeFontSize(size);
            }

        /*
            private void AlignChange(RibbonRichField.Align Align)
            {
                switch (Align)
                {
                    case RibbonRichField.Align.Left:
                       _dataContainer.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Left);
                        break;
                    case RibbonRichField.Align.Right:
                        _dataContainer.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Right);
                        break;
                    case RibbonRichField.Align.Center:
                        _dataContainer.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Center);
                        break;
                }
                rtbData.Focus();
            }
            */
            private void LoadFile(string filePath, TextType fileType)
            {
                switch (fileType)
                {
                    case TextType.DOCX:
                        ImportFromDOCXFile(filePath);
                        break;
                    case TextType.HTML:
                        ImportFromHTMLFile(filePath);
                        break;
                    case TextType.Plain:
                        ImportFromTXTFile(filePath);
                        break;
                }
            }

            private void InsertImage(string filePath)
            {
                Bitmap bmp = new Bitmap(filePath);
                _dataContainer.InsertImage(bmp);
            }


            private void InsertLink()
            {
            }

            private void InsertTable(int filas, int columnas)
            {
                _dataContainer.InsertTable(filas, columnas);
            }
        public DataRichTextField()
        {
            InitializeComponent();
            //this._dataContainer.Enter += DataRichField_Enter;
            //this._dataContainer.Va
             //   Load += DataRichField_Load;

        }
        
        #endregion

        private void RichTextPanel_OnLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            _dataContainer = new RadRichTextBox();
            host.Child = _dataContainer;
            _dataContainer.ChangeFontFamily("Calibri");
            _dataContainer.ChangeFontSize(14);
            RichTextPanel.Children.Add(host);

        }
        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}

