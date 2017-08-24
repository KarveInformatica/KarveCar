Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports VariablesGlobales
Imports System.ComponentModel

Public Class Datafield
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
    Private _FocoEnAgregar As Boolean = False

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

    Property Max_Value As Double
        Get
            Return _ValueMax
        End Get
        Set(ByVal value As Double)
            _ValueMax = value
        End Set
    End Property

    Property PasswordChar_Data As Char
        Get
            Return txtData.PasswordChar
        End Get
        Set(value As Char)
            txtData.PasswordChar = value
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

    Property Data_Allowed As List_Data
        Get
            Return _DataAllowed
        End Get
        Set(ByVal value As List_Data)
            _DataAllowed = value
            If _DataAllowed = List_Data.nDouble Or _DataAllowed = List_Data.nInteger Then
                Me.txtData.TextAlign = HorizontalAlignment.Right
            End If
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
            Return txtData.Text
        End Get
        Set(ByVal value As String)
            txtData.Text = value
        End Set
    End Property

    Property Length_Data As Integer
        Get
            Return txtData.MaxLength
        End Get
        Set(ByVal value As Integer)
            txtData.MaxLength = value
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

    Property Allow_Negative As Boolean
        Get
            Return _AllowNegative
        End Get
        Set(ByVal value As Boolean)
            _AllowNegative = value
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

    Public Overrides Property FocoEnAgregar As Boolean
        Get
            Return _FocoEnAgregar
        End Get
        Set(value As Boolean)
            _FocoEnAgregar = value
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
        If _DataAllowed = List_Data.nDouble Then 'si es double
            If Not Validate_Regex(e.KeyChar, "[\-\d\.,\b]") Then 'solo permite negativos, numeros, punto o coma y mas numeros
                e.Handled = True
            Else
                If _Encoding = Code_Collation.LATIN And e.KeyChar = "." Then 'intercambia el punto y la coma segun el collate
                    e.KeyChar = ","
                ElseIf _Encoding = Code_Collation.UTF8 And e.KeyChar = "," Then
                    e.KeyChar = "."
                End If
            End If
        ElseIf _DataAllowed = List_Data.nInteger Then 'solo permite negativos y numeros
            If Not Validate_Regex(e.KeyChar, "[\-\d\b]") Then
                e.Handled = True
            End If
        ElseIf _DataAllowed = List_Data.Text Then 'consulta los caracteres permitidos segun el colate
            e.Handled = Char_Code(_Encoding, e.KeyChar)
            If _UpperCase Then
                e.KeyChar = UCase(e.KeyChar)
            End If
        ElseIf _DataAllowed = List_Data.NIF Then 'el nif permite todo
            If _UpperCase Then
                e.KeyChar = UCase(e.KeyChar)
            End If
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
        txtData.TextBoxElement.Border.ForeColor = Drawing.SystemColors.Highlight
    End Sub

    Private Sub Datafield_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        normalColor = Drawing.SystemColors.ControlDark
        setColor()
    End Sub

    Private Sub setColor()
        txtData.TextBoxElement.Border.ForeColor = normalColor
        txtData.TextBoxElement.Border.TopColor = normalColor
        txtData.TextBoxElement.Border.BottomColor = normalColor
        txtData.TextBoxElement.Border.LeftColor = normalColor
        txtData.TextBoxElement.Border.RightColor = normalColor
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
        Dim Text_Validated As Match = Regex.Match(Text_To_Validate, expresion)
        Validate_Regex = Text_Validated.Success
    End Function

    Private Function ValidateData() As Boolean
        'valida los datos introducidos en el campo
        If txtData.Text <> "" Then 'si hay texto
            If _DataAllowed = List_Data.nDouble Then
                Dim regex As String = ""
                If _Encoding = Code_Collation.LATIN Then
                    regex = "^(|-)?\d+(\,\d+)?$"
                ElseIf _Encoding = Code_Collation.UTF8 Then
                    regex = "^(|-)?\d+(\.\d+)?$"
                End If
                If Not Validate_Regex(txtData.Text, regex) Then 'valida que tenga un formato double [-]<num>[./,][dec]
                    _MensajeIncorrecto = ("Revise el valor introducido. Se esperava un número decimal.")
                    Return False
                End If
                If Not validaNum() Then 'valida si permite o no negativos y que este en el rango de numeros
                    Return False
                End If
            ElseIf _DataAllowed = List_Data.nInteger Then
                If Not Validate_Regex(txtData.Text, "^(|-)?\d+$") Then 'valida que tenga un formato integer [-]<num>
                    _MensajeIncorrecto = ("Revise el valor introducido. Se esperava un número entero.")
                    Return False
                End If
                If Not validaNum() Then 'valida si permite o no negativos y que este en el rango de numeros
                    Return False
                End If
            ElseIf _Encoding = List_Data.NIF Then 'el nif lo acepta todo
                Return True
            End If
        End If
        If Not _AllowEmpty And txtData.Text = "" Then 'comprueba si el texto puede ser vacio
            _MensajeIncorrecto = ("No se permite un dato vacío.")
            Return False
        End If
        If Not ValidateExtra() Then 'para los controles heredados
            Return False
        End If
        Return True
    End Function

    Protected Overridable Function ValidateExtra() As Boolean
        'debe devolver true si es correcto
        Return True
    End Function

    Private Function validaNum() As Boolean
        If Not validateNegative() Then
            Return False
        End If
        If Not validaMaxNum() Then
            Return False
        End If
        Return True
    End Function

    Private Function validateNegative() As Boolean
        'valida que el valor introducido sea negativo
        Try
            If Not _AllowNegative Then
                Dim num As Double = CDbl(txtData.Text)
                If num < 0 Then
                    _MensajeIncorrecto = ("El valor introducido no puede ser negativo.")
                    Return False
                End If
            End If
        Catch ex As Exception
            _MensajeIncorrecto = ("Error inesperado.")
            Return False
        End Try
        Return True
    End Function

    Private Function validaMaxNum() As Boolean
        'valida que el numero este dentro del rango
        If Not IsNothing(_ValueMax) And _ValueMax <> 0 Then
            If (_DataAllowed = List_Data.nDouble Or _DataAllowed = List_Data.nInteger) And Not IsNothing(txtData.Text) And txtData.Text <> "" Then
                If Not _AllowNegative Then
                    If CDbl(txtData.Text) > _ValueMax Then
                        _MensajeIncorrecto = ("El valor introducido  no puede ser mayor al valor máximo " & _ValueMax & " estipulado.")
                        Return False
                    End If
                Else
                    If CDbl(txtData.Text) > _ValueMax Or CDbl(txtData.Text) < _ValueMax * (-1) Then
                        _MensajeIncorrecto = ("El valor no se encuentra en el intérvalo [ -" & _ValueMax & ", " & _ValueMax & "]")
                        Return False
                    End If
                End If
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
            If len > 0 Then Me.Length_Data = len
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
            If len > 0 Then Me.Length_Data = len
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
            If len > 0 Then Me.Length_Data = len
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
