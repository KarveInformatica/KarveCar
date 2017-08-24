Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports VariablesGlobales
Imports System.ComponentModel

Public Class MaskedDataField
    Inherits ctrBase

#Region "Variables"
    Protected _DataField As String 'campo de la base de la base de datos al que se bindea
    Protected _DataTable As String = "" 'tabla del dataset al que accede por defecto la 0 ya que muchas veces solo hay una
    Protected _Descripcion As String 'descripción del campo para los mensajes de error
    Protected _DataAllowed As List_Data 'tipo de dato que acepta el campo
    Protected _AllowEmpty As Boolean = True 'si permite o no que el campo quede vacio al validar, por defecto si
    Protected _AllowNegative As Boolean = True 'si permite o no que el campo acepte negativos al validar, por defecto si
    Protected _ValueMax As Double 'el valor maximo del campo en caso de que se le quiera dar uno
    Protected _Encoding As Code_Collation 'si es UTF o Latin, para textos y numericos
    Protected _Incorrecto As Boolean = False 'indica si el campo es incorrecto tras validar es readonly
    Protected _Validate As Boolean = True 'si valida al perder el foco, por defecto si
    Protected _UpperCase As Boolean = False 'si transforma todo a mayuscualas, por defecto no
    Protected _MensajeIncorrecto As String 'el mensaje de error en caso de que lo haya
    Protected _NullOnEmpty As Boolean = True 'si guarda vacios cuando el campo esta vacio, por degfecto no
    Protected WithEvents _Binding As Binding
    Protected _Theme As ThemeType = ThemeType.Plain 'el tema que usa el control
    Protected _topPadding As Integer 'el padding superior para los docking
    Protected _MensajeIncorrectoCustom As String
    Private normalColor As System.Drawing.Color
    Protected _regexInput As String
    Protected _regex
    Protected _defaultValue As String


    Public Shadows Event TextChanged()
    Public Shadows Event KeyDown(sender As Object, e As KeyEventArgs)
    Protected Shadows Event Focused()
    Protected Shadows Event UnFocused()

    Public Enum List_Data
        Text
        nDouble
        nInteger
        NIF
        Libre
    End Enum

    Public Enum Code_Collation
        LATIN
        UTF8
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

    Property Font_Data As System.Drawing.Font
        Get
            Return txtData.Font
        End Get
        Set(value As System.Drawing.Font)
            txtData.Font = value
        End Set
    End Property

    Overridable Property ReadOnly_Data As Boolean
        Get
            Return txtData.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtData.ReadOnly = value
            If value Then
                txtData.BackColor = Drawing.Color.LightBlue
                Me.TabStop = False
            Else
                txtData.BackColor = Drawing.SystemColors.Window
                Me.TabStop = True
            End If
            ReadOnly_ProperyChanged()
        End Set
    End Property

    Protected Overridable Sub ReadOnly_ProperyChanged()
    End Sub

    Property Text_Data As String
        Get
            Return txtData.Text
        End Get
        Set(ByVal value As String)
            txtData.Text = value
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

    Overrides ReadOnly Property Incorrecto As Boolean
        Get
            Return _Incorrecto
        End Get
    End Property

    Overrides ReadOnly Property MensajeIncorrecto As String
        Get
            If _MensajeIncorrectoCustom <> "" And Text_Data = "" And Not _AllowEmpty Then
                Return Translate(_MensajeIncorrectoCustom)
            Else
                Return Translate(_MensajeIncorrecto)
            End If
        End Get
    End Property

    Property MensajeIncorrectoCustom As String
        Get
            Return _MensajeIncorrectoCustom
        End Get
        Set(value As String)
            _MensajeIncorrectoCustom = value
        End Set
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
            txtData.ThemeName = "Windows8"
        Else
            txtData.ThemeName = "Windows7"
        End If
    End Sub

    Property TopPadding As Integer
        Get
            Return _topPadding
        End Get
        Set(value As Integer)
            Me.Size = New Drawing.Size(Me.Width, Me.Height - _topPadding + value)
            For Each ctr As Control In Me.Controls
                ctr.Location = New Drawing.Point(ctr.Location.X, ctr.Location.Y - _topPadding)
            Next
            _topPadding = value
        End Set
    End Property

    Public Property Mask As String
        Get
            Return txtData.Mask
        End Get
        Set(value As String)
            txtData.Mask = value
        End Set
    End Property

    Public Property RegexInput As String
        Get
            Return _regexInput
        End Get
        Set(value As String)
            _regexInput = value
        End Set
    End Property

    Public Property Regex As String
        Get
            Return _regex
        End Get
        Set(value As String)
            _regex = value
        End Set
    End Property

    Property Alignemnt As HorizontalAlignment
        Get
            Return txtData.TextAlign
        End Get
        Set(value As HorizontalAlignment)
            txtData.TextAlign = value
        End Set
    End Property

#End Region

#Region "Eventos"
    Protected Overridable Sub cstDatafield_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        txtData.Focus()
    End Sub

    Private Sub txtData_GotFocus(sender As Object, e As EventArgs) Handles txtData.GotFocus
        txtData.SelectAll()
        RaiseEvent Focused()
    End Sub

    Private Sub Datafield_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        RaiseEvent UnFocused()
    End Sub

    Private Sub Datafield_Leave(sender As Object, e As EventArgs) Handles Me.Leave
    End Sub

    Private Sub txtData_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtData.Validating
        'si valida al perder el foco
        If _Validate Then
            Validar()
        End If
        Text_Validating() 'funcion para los controles heredados
        EndEdit() 'fuerza el la edicion
    End Sub

    Private Sub txtCst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtData.KeyPress
        If Not Validate_Regex(e.KeyChar, _regexInput) And Not Validate_Regex(e.KeyChar, "[\b]") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Datafield_KeyDown(sender As Object, e As KeyEventArgs) Handles txtData.KeyDown
        If e.KeyCode = Keys.X And e.Control Then
            Cut(sender)
        ElseIf e.KeyCode = Keys.C And e.Control Then
            Copy(sender)
        ElseIf e.KeyCode = Keys.V And e.Control Then
            Paste(sender)
        Else
            RaiseEvent KeyDown(sender, e)
        End If
    End Sub

    Private Sub txtData_TextChanged(sender As Object, e As EventArgs) Handles txtData.TextChanged
        RaiseEvent TextChanged()
        Text_Changed() 'funcion para los controles heredados
    End Sub

    Protected Overridable Sub Text_Changed()
        'funcion para los controles heredados
    End Sub
    Protected Overridable Sub Text_Validating()
        'funcion para los controles heredados
    End Sub

    Private Sub txtData_Leave(sender As Object, e As EventArgs) Handles txtData.Leave
        setColor()
    End Sub

    Private Sub txtData_Enter(sender As Object, e As EventArgs) Handles txtData.Enter
        txtData.MaskedEditBoxElement.Border.ForeColor = Drawing.SystemColors.Highlight
    End Sub

    Private Sub Datafield_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        normalColor = Drawing.SystemColors.ControlDark
        _defaultValue = txtData.Text
        setColor()
    End Sub

    Private Sub setColor()
        txtData.MaskedEditBoxElement.Border.ForeColor = normalColor
        txtData.MaskedEditBoxElement.Border.TopColor = normalColor
        txtData.MaskedEditBoxElement.Border.BottomColor = normalColor
        txtData.MaskedEditBoxElement.Border.LeftColor = normalColor
        txtData.MaskedEditBoxElement.Border.RightColor = normalColor
    End Sub

#End Region

#Region "Funciones de Validacion"
    Public Sub forceSetError()
        _Incorrecto = True
        normalColor = Drawing.Color.Red
        setColor()
        ValidateLabel()
    End Sub

    Public Overrides Sub Validar()
        'si ValidateData devuelve TRUE los datos son correctos, por eso incorrecto es el negado
        _Incorrecto = Not ValidateData()
        If _Incorrecto Then
            normalColor = Drawing.Color.Red
        Else
            normalColor = Drawing.SystemColors.ControlDark
        End If
        setColor()
        ValidateLabel()
    End Sub
    Protected Overridable Sub ValidateLabel()
        'para los heredados que usan etiqueta, si es incorrecto se pone en rojo con un tooltip del error
    End Sub

    Private Function Char_Code(ByRef Code As Code_Collation, ByRef Character As Char) As Boolean
        'valida los caracteres entrados en funcion de si es UTF o Latin, ya que el primero no admite acentos, etc...
        'devuelve TRUE si NO encaja (se usa para el handled de keypress)
        Char_Code = False
        If _Encoding = Code_Collation.UTF8 Then
            Char_Code = Not Validate_Regex(Character, "[A-Z a-z 0-9 _\-\b\'!·$%&/()=?¿¡^*+¨{}\[\]ºª,.;:@]")
        Else
            Char_Code = Not Validate_Regex(Character, "[A-Z a-z 0-9 \-_\'À-Ä È-Ï Ò-Ö Ù-Ü à-ä è-ï ò-ö ù-ü ñçÑÇ\b!·$%&/()=?¿¡^*+¨{}\[\]ºª,.;:@]")
        End If
    End Function

    Private Function Validate_Regex(ByVal Text_To_Validate As String, ByVal expresion As String) As Boolean
        'devuelve true si el texto encaja con la regex
        Validate_Regex = True
        If expresion <> "" Then
            Dim Text_Validated As Match = System.Text.RegularExpressions.Regex.Match(Text_To_Validate, expresion)
            Validate_Regex = Text_Validated.Success
        End If
    End Function

    Private Function ValidateData() As Boolean

        If Allow_Empty And txtData.Text = _defaultValue Then
            Return True
        End If
        If Not _AllowEmpty And txtData.Text = _defaultValue Then 'comprueba si el texto puede ser vacio
            _MensajeIncorrecto = ("No se permite un dato vacío.")
            Return False
        End If
        If _regex <> "" Then
            If Not Validate_Regex(txtData.Text, _regex) Then
                _MensajeIncorrecto = ("El valor introducido no contiene el formato correcto " & _regex & " .")
                Return False
            End If
        End If
        Return True
    End Function

#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"

    Public Overrides Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Text", dta, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            txtData.DataBindings.Add(_Binding)
            Dim len As Integer = dta.Columns(_DataField).MaxLength
            bindingExtra(dta)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Text", dts.Tables(_DataTable), _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            txtData.DataBindings.Add(_Binding)
            Dim len As Integer = dts.Tables(_DataTable).Columns(_DataField).MaxLength
            bindingExtra(dts)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Text", bs, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            txtData.DataBindings.Add(_Binding)
            Dim len As Integer = CType(bs.DataSource, DataTable).Columns(_DataField).MaxLength
            bindingExtra(bs)
        End If
    End Sub
#End Region 'Funciones de bindeo con sobrecarga en funcion del donde se guarden los datos

    Private Sub Parse(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Parse
        'Al guardar os datos si el campo de texto esta vacio y se acepa guardar nulls
        If e.Value.ToString = "" And _NullOnEmpty Then
            e.Value = DBNull.Value
        End If
    End Sub

    Private Sub Format(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Format
        'No se usa
        'If e.Value.ToString = "" And _NullOnEmpty Then
        '   e.Value = DBNull.Value
        'End If
    End Sub

    Public Overrides Sub Clear()
        'Limpia el campo de texto y rompe los bindings si los hay
        If Not IsNothing(_DataField) And _DataField <> "" Then
            txtData.DataBindings.Clear()
            _Binding = Nothing
        End If
        txtData.Text = ""
        normalColor = Drawing.SystemColors.ControlDark
        setColor()
        ClearExtra()
        ClearLabel()
    End Sub

    Public Overrides Sub EndEdit()
        'Fuerza el final de edicion de los bindings
        Try
            txtData.DataBindings("Text").BindingManagerBase.EndCurrentEdit()
        Catch
        End Try
    End Sub

    Protected Overridable Sub bindingExtra(ByRef dataAdapter As Object)
        'para los controles heredados
    End Sub
    Protected Overridable Sub ClearExtra()
        'para los controles heredados
    End Sub
    Protected Overridable Sub ClearLabel()
        'para los controles heredados
    End Sub
#End Region

#Region "Funciones"
    Public Overrides Sub traduc()
        Descripcion = Translate(Descripcion)
    End Sub
#End Region

#Region "Cut Copy Paste"
    Private Sub Cut(ByRef sender As Object)
        If Me.txtData.SelectedText.Length > 0 Then
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

    Private Sub Datafield_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        size_changed()
    End Sub

    Protected Overridable Sub size_changed()
        txtData.Width = Me.Width - txtData.Location.X
    End Sub

End Class
