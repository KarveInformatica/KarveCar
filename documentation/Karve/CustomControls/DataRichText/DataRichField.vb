Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports VariablesGlobales
Imports Telerik.WinControls.RichTextBox.FormatProviders.Txt
Imports Telerik.WinControls.RichTextBox.FormatProviders.Rtf
Imports Telerik.WinControls.RichTextBox.FileFormats.Html
Imports Telerik.WinControls.RichTextBox.FileFormats.OpenXml.Docx
Imports System.IO
Imports Telerik.WinControls.RichTextBox.FormatProviders
Imports System.ComponentModel
Imports Telerik.WinControls.RichTextBox.FileFormats.Rtf
Imports Telerik.WinControls.RichTextBox.Model.Styles
Imports System.Drawing
Imports Telerik.WinControls.RichTextBox.Model
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.RichTextBox

Public Class DataRichField
    Inherits ctrBase
    Implements INotifyPropertyChanged

#Region "Variables"
    Protected _DataField As String
    Protected _DataTable As String = ""
    Protected _Descripcion As String
    Protected _Text As String
    Protected _DataAllowed As List_Data = List_Data.Libre
    Protected _AllowEmpty As Boolean = True
    Protected _Encoding As Code_Collation = Code_Collation.LATIN
    Protected _Incorrecto As Boolean = False
    Protected _Validate As Boolean = True
    Protected _UpperCase As Boolean = False
    Protected _MensajeIncorrecto As String
    Protected _NullOnEmpty As Boolean = False
    Protected WithEvents _Binding As Binding
    Protected _Theme As ThemeType = ThemeType.Plain
    Protected _TextType As TextType
    Protected _Byte As Byte()

    Private kMsgBox As New CustomControls.kMsgBox

    Protected rbnEdicion As New RibbonRichField

    Shadows Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    'este evento es para que funcione el PropertyChanged en nuestra propiedad Index y funcione correctamente el binding

    Public Enum List_Data
        Text
        Libre
    End Enum

    Public Enum Code_Collation
        LATIN
        UTF8
    End Enum

    Public Enum TextType
        Plain
        RTF
        HTML
        DOCX
    End Enum

#End Region

#Region "Propiedades"
    Property DataField As String
        Get
            Return _DataField
        End Get
        Set(ByVal value As String)
            _DataField = value
        End Set
    End Property

    Property DataTable As String
        Get
            Return _DataTable
        End Get
        Set(ByVal value As String)
            _DataTable = value
        End Set
    End Property

    Overrides Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Property ReadOnly_Data As Boolean
        Get
            Return rtbData.IsReadOnly
        End Get
        Set(ByVal value As Boolean)
            rtbData.IsReadOnly = value
            If value Then
                rtbData.BackColor = Drawing.Color.LightBlue
                'rtbData.UseGenericBorderPaint = True
            Else
                rtbData.BackColor = Drawing.SystemColors.Window
                'rtbData.UseGenericBorderPaint = False
            End If
        End Set
    End Property

    Property Data_Allowed As List_Data
        Get
            Return _DataAllowed
        End Get
        Set(ByVal value As List_Data)
            _DataAllowed = value
        End Set
    End Property

    Property Encoding As Code_Collation
        Get
            Return _Encoding
        End Get
        Set(ByVal value As Code_Collation)
            _Encoding = value
        End Set
    End Property

    Property Text_Data As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            OnPropertyChanged("Text_Data")
        End Set
    End Property

    Property Byte_Data As Byte()
        Get
            Return _Byte
        End Get
        Set(value As Byte())
            _Byte = value
            OnPropertyChanged("Byte_Data")
        End Set
    End Property

    Property Allow_Empty As Boolean
        Get
            Return _AllowEmpty
        End Get
        Set(ByVal value As Boolean)
            _AllowEmpty = value
        End Set
    End Property

    Property Upper_Case As Boolean
        Get
            Return _UpperCase
        End Get
        Set(ByVal value As Boolean)
            _UpperCase = value
        End Set
    End Property

    Property Validate_on_lost_focus As Boolean
        Get
            Return _Validate
        End Get
        Set(ByVal value As Boolean)
            _Validate = value
        End Set
    End Property

    Property Null_on_Empty As Boolean
        Get
            Return _NullOnEmpty
        End Get
        Set(ByVal value As Boolean)
            _NullOnEmpty = value
        End Set
    End Property

    Overrides ReadOnly Property Incorrecto As Boolean
        Get
            Return _Incorrecto
        End Get
    End Property

    Overrides ReadOnly Property MensajeIncorrecto As String
        Get
            Return _MensajeIncorrecto
        End Get
    End Property

    Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            change_theme()
        End Set
    End Property
    Protected Overridable Sub change_theme()
        If Theme = ThemeType.Plain Then
            rtbData.ThemeName = "Windows8"
        Else
            rtbData.ThemeName = "Windows7"
        End If
    End Sub

    Property Text_Type As TextType
        Get
            Return _TextType
        End Get
        Set(value As TextType)
            _TextType = value
        End Set
    End Property

    ReadOnly Property HasRibbon() As Boolean
        Get
            Return True
        End Get
    End Property

#End Region

#Region "Eventos"
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Private Sub DataRichField_Load(sender As Object, e As EventArgs) Handles Me.Load
        rtbData.ChangeFontFamily("Calibri")
        rtbData.ChangeFontSize(14)
        If Not Me.DesignMode Then
            setEvents()
            rbnEdicion.setRibbon()
        End If
    End Sub

    Private Sub DataRichField_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        rtbData.Focus()
    End Sub

    Private Sub rtbData_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If _Validate Then
            Validar()
        End If
        Text_Validating()
        EndEdit()
    End Sub

    Private Sub txtCst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If _DataAllowed = List_Data.Text Then
            e.Handled = Char_Code(_Encoding, e.KeyChar)
            If _UpperCase Then
                e.KeyChar = UCase(e.KeyChar)
            End If
        End If
    End Sub

    Private Sub Datafield_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.X And e.Control Then
            Cut(sender)
        ElseIf e.KeyCode = Keys.C And e.Control Then
            Copy(sender)
        ElseIf e.KeyCode = Keys.V And e.Control Then
            Paste(sender)
        End If
    End Sub

    Private Sub rtbData_TextChanged(sender As Object, e As EventArgs)
        Text_Changed()
    End Sub

    Protected Overridable Sub Text_Changed()

    End Sub
    Protected Overridable Sub Text_Validating()

    End Sub
#End Region

#Region "Funciones del Texto"

    Public Function ExportToTXT() As String
        Dim provider As New TxtFormatProvider
        Return provider.Export(rtbData.Document)
    End Function

    Public Function ExportToRTF() As String
        Dim provider As New RtfFormatProvider
        Return provider.Export(rtbData.Document)
    End Function

    Public Function ExportToHTML() As String
        Dim provider As New HtmlFormatProvider
        Return provider.Export(rtbData.Document)
    End Function

    Public Sub ExportToDOCX()
        Dim provider As New DocxFormatProvider()
        Dim saveDialog As New SaveFileDialog()
        saveDialog.DefaultExt = ".docx"
        saveDialog.Filter = "Documents|*.docx"
        Dim dialogResult As DialogResult = saveDialog.ShowDialog()
        If dialogResult = System.Windows.Forms.DialogResult.OK Then
            Using output As Stream = saveDialog.OpenFile()
                provider.Export(rtbData.Document, output)
            End Using
        End If
    End Sub

    Public Function ExportFromDOCXtoByteArray() As Byte()
        Dim provider As New DocxFormatProvider()
        Dim ms As New MemoryStream()
        provider.Export(rtbData.Document, ms)
        Dim data As Byte() = ms.GetBuffer()
        Return data
    End Function

    Public Sub ImportFromByteArrayToDOCX(ByVal data As Byte())
        Dim provider As IDocumentFormatProvider = New DocxFormatProvider()
        'Dim ms As New MemoryStream()
        Using ms As New MemoryStream(data, 0, data.Length)
            ms.Write(data, 0, data.Length)
            rtbData.Document = provider.Import(ms)
        End Using
    End Sub

    Public Sub ImportFromRTF(ByVal text As String)
        Try
            Dim provider As New RtfFormatProvider
            rtbData.Document = provider.Import(text)
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromTXT(ByVal text As String)
        Try
            Dim provider As New TxtFormatProvider
            rtbData.Document = provider.Import(text)
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromHTML(ByVal text As String)
        Try
            Dim provider As New HtmlFormatProvider
            rtbData.Document = provider.Import(text)
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromRTFFile(ByVal filePath As String)
        Dim provider As New RtfFormatProvider
        Try
            Using stream As New FileStream(filePath, FileMode.Open)
                rtbData.Document = provider.Import(stream)
            End Using
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromTXTFile(ByVal filePath As String)
        Try
            Dim provider As New TxtFormatProvider
            Using stream As New FileStream(filePath, FileMode.Open)
                rtbData.Document = provider.Import(stream)
            End Using
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromHTMLFile(ByVal filePath As String)
        Try
            Dim provider As New HtmlFormatProvider
            Dim stream As StreamReader = File.OpenText(filePath)
            Dim str As String = ""
            Do While stream.Peek() >= 0
                str &= stream.ReadLine
            Loop
            stream.Close()
            rtbData.Document = provider.Import(str)
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub ImportFromDOCXFile(ByVal filePath As String)
        Try
            Dim provider As IDocumentFormatProvider = New DocxFormatProvider()
            Using stream As New FileStream(filePath, FileMode.Open)
                rtbData.Document = provider.Import(stream)
            End Using
        Catch ex As Exception
            kMsgBox.Print("Error al cargar el documento.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Public Sub loadText()
        Select Case _TextType
            Case TextType.Plain
                ImportFromTXT(_Text)
            Case TextType.RTF
                ImportFromRTF(_Text)
            Case TextType.HTML
                ImportFromHTML(_Text)
            Case TextType.DOCX
                ImportFromByteArrayToDOCX(_Byte)
        End Select
    End Sub

    Public Sub saveText()
        Select Case _TextType
            Case TextType.Plain
                Me.Text_Data = ExportToTXT()
            Case TextType.RTF
                Me.Text_Data = ExportToRTF()
            Case TextType.HTML

            Case TextType.DOCX
                Me.Byte_Data = ExportFromDOCXtoByteArray()
        End Select
    End Sub

#End Region

#Region "Funciones de Validacion"
    Public Overrides Sub Validar()
        _Incorrecto = Not ValidateData()
        ValidateLabel()
    End Sub

    Private Function Char_Code(ByRef Code As Code_Collation, ByRef Character As Char) As Boolean
        Char_Code = False
        If _Encoding = Code_Collation.UTF8 Then
            Char_Code = Not Validate_Regex(Character, "[A-Z a-z 0-9 _\-\b\'!·$%&/()=?¿¡^*+¨{}\[\]ºª,.;:@]")
        Else
            Char_Code = Not Validate_Regex(Character, "[A-Z a-z 0-9 \-_\'À-Ä È-Ï Ò-Ö Ù-Ü à-ä è-ï ò-ö ù-ü ñçÑÇ\b!·$%&/()=?¿¡^*+¨{}\[\]ºª,.;:@]")
        End If
    End Function

    Private Function Validate_Regex(ByVal Text_To_Validate As String, ByVal Pattern As String) As Boolean
        Dim Text_Validated As Match = Regex.Match(Text_To_Validate, Pattern)
        Validate_Regex = Text_Validated.Success
    End Function

    Public Function ValidateData() As Boolean
        If Not _AllowEmpty And rtbData.Text = "" Then
            _MensajeIncorrecto = ("No se permite un dato vacío.")
            Return False
        End If
        If Not ValidateExtra() Then
            Return False
        End If
        Return True
    End Function

    Protected Overridable Function ValidateExtra() As Boolean

        Return True
    End Function

    Protected Overridable Sub ValidateLabel()

    End Sub

#End Region

#Region "Funciones de Acceso a Datos"
    Public Overrides Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            If _TextType = TextType.DOCX Then
                _Binding = New Binding("Byte_Data", dta, _DataField)
            Else
                _Binding = New Binding("Text_Data", dta, _DataField)
            End If
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            bindingExtra()
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            If _TextType = TextType.DOCX Then
                _Binding = New Binding("Byte_Data", dts.Tables(_DataTable), _DataField)
            Else
                _Binding = New Binding("Text_Data", dts.Tables(_DataTable), _DataField)
            End If
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            bindingExtra()
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            If _TextType = TextType.DOCX Then
                _Binding = New Binding("Byte_Data", bs, _DataField)
            Else
                _Binding = New Binding("Text_Data", bs, _DataField)
            End If
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            bindingExtra()
        End If
    End Sub

    Private Sub Format(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Format
        If Not IsDBNull(e.Value) And Text_Data = "" Then
            Text_Data = e.Value
        End If
        loadText()
    End Sub

    Private Sub Parse(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Parse
        If e.Value.ToString = "" And _NullOnEmpty Then
            e.Value = DBNull.Value
        End If
    End Sub

    Public Overrides Sub Clear()
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Me.DataBindings.Clear()
            _Binding = Nothing
        End If
        rtbData.Document = Nothing
        ClearExtra()
    End Sub

    Public Overrides Sub EndEdit()
        Try
            saveText()
            If _TextType = TextType.DOCX Then
                Me.DataBindings("Byte_Data").BindingManagerBase.EndCurrentEdit()
            Else
                Me.DataBindings("Text_Data").BindingManagerBase.EndCurrentEdit()
            End If
        Catch
        End Try
    End Sub

    Protected Overridable Sub bindingExtra()

    End Sub

    Protected Overridable Sub ClearExtra()

    End Sub
#End Region

#Region "Funciones"
    Public Overrides Sub traduc()

    End Sub

    Public Function getRibbon() As RibbonRichField
        Return Me.rbnEdicion
    End Function
#End Region

#Region "Cut Copy Paste"
    Private Sub Cut(ByRef sender As Object)
        If sender.SelectedText.Length > 0 Then
            Clipboard.SetDataObject(sender.SelectedText)
            sender.Cut()
        End If
    End Sub
    Private Sub Copy(ByRef sender As Object)
        If sender.SelectedText.Length > 0 Then
            sender.Copy()
        End If
    End Sub
    Private Sub Paste(ByRef sender As Object)
        If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
            sender.Paste()
        End If
    End Sub
#End Region

#Region "Ribbon"

    Protected Sub setEvents()
        AddHandler rtbData.CurrentEditingStyleChanged, AddressOf stylePropertiesChanged
        AddHandler rtbData.Document.Selection.SelectionChanged, AddressOf stylePropertiesChanged

        AddHandler rbnEdicion.Paste, AddressOf ribbonPaste
        AddHandler rbnEdicion.Copy, AddressOf ribbonCopy
        AddHandler rbnEdicion.Cut, AddressOf ribbonCut

        AddHandler rbnEdicion.Bold, AddressOf ribbonBold
        AddHandler rbnEdicion.Italic, AddressOf ribbonItalic
        AddHandler rbnEdicion.Underline, AddressOf ribbonUnderline

        AddHandler rbnEdicion.FontFamily, AddressOf ribbonFontFamily
        AddHandler rbnEdicion.FontSize, AddressOf ribbonFontSize

        AddHandler rbnEdicion.AlignChange, AddressOf AlignChange

        AddHandler rbnEdicion.LoadFile, AddressOf LoadFile

        AddHandler rbnEdicion.InsertImage, AddressOf InsertImage
        AddHandler rbnEdicion.InsertLink, AddressOf InsertLink
        AddHandler rbnEdicion.InsertTable, AddressOf InsertTable
    End Sub

    Private Sub stylePropertiesChanged()
        Dim style As StyleDefinition = rtbData.CurrentEditingStyle
        Dim fontWeight As TextStyle = DirectCast(style.GetPropertyValue(Span.FontStyleProperty), TextStyle)
        Dim fontFamily As String = DirectCast(style.GetPropertyValue(Span.FontFamilyProperty), String)
        Dim fontSize As Integer = style.GetPropertyValue(Span.FontSizeProperty)
        Dim underline As Boolean = style.GetPropertyValue(Span.UnderlineTypeProperty)
        Dim align As Telerik.WinControls.RichTextBox.Layout.RadTextAlignment = style.GetPropertyValue(Paragraph.TextAlignmentProperty)

        If fontWeight = TextStyle.Bold Or fontWeight = (TextStyle.Bold Or TextStyle.Italic) Then
            rbnEdicion.btnBold.IsChecked = True
        Else
            rbnEdicion.btnBold.IsChecked = False
        End If
        If fontWeight = TextStyle.Italic Or fontWeight = (TextStyle.Bold Or TextStyle.Italic) Then
            rbnEdicion.btnItalic.IsChecked = True
        Else
            rbnEdicion.btnItalic.IsChecked = False
        End If
        rbnEdicion.btnUnderline.IsChecked = underline

        rbnEdicion.cbxFontFamily.EditableElementText = fontFamily
        rbnEdicion.cbxFontSize.EditableElementText = fontSize
        Select Case align
            Case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Left
            Case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Center
            Case Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Right
        End Select
    End Sub

    Private Sub ribbonPaste()
        rtbData.Paste()
        rtbData.Focus()
    End Sub

    Private Sub ribbonCopy()
        rtbData.Copy()
        rtbData.Focus()
    End Sub

    Private Sub ribbonCut()
        rtbData.Cut()
        rtbData.Focus()
    End Sub

    Private Sub ribbonBold()
        rtbData.ToggleBold()
        rtbData.Focus()
    End Sub

    Private Sub ribbonItalic()
        rtbData.ToggleItalic()
        rtbData.Focus()
    End Sub

    Private Sub ribbonUnderline()
        rtbData.ToggleUnderline()
        rtbData.Focus()
    End Sub

    Private Sub ribbonFontFamily(ByVal font As String)
        rtbData.ChangeFontFamily(font)
    End Sub

    Private Sub ribbonFontSize(ByVal size As Integer)
        rtbData.ChangeFontSize(size)
    End Sub

    Private Sub AlignChange(ByVal Align As RibbonRichField.Align)
        Select Case Align
            Case RibbonRichField.Align.Left
                rtbData.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Left)
            Case RibbonRichField.Align.Right
                rtbData.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Right)
            Case RibbonRichField.Align.Center
                rtbData.ChangeTextAlignment(Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Center)
        End Select
        rtbData.Focus()
    End Sub

    Private Sub LoadFile(ByVal filePath As String, ByVal fileType As DataRichField.TextType)
        Select Case fileType
            Case TextType.DOCX
                ImportFromDOCXFile(filePath)
            Case TextType.HTML
                ImportFromHTMLFile(filePath)
            Case TextType.Plain
                ImportFromTXTFile(filePath)
        End Select
    End Sub

    Private Sub InsertImage(ByVal filePath As String)
        Dim bmp As New Bitmap(filePath)
        rtbData.InsertImage(bmp)
    End Sub

    Private Sub InsertLink()

    End Sub

    Private Sub InsertTable(ByVal filas As Integer, ByVal columnas As Integer)
        rtbData.InsertTable(filas, columnas)
    End Sub
#End Region
End Class
