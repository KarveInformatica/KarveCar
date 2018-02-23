Imports VariablesGlobales
Imports VariablesGlobales.Modulo_VariablesGlobales
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataDate
    Inherits ctrBase
    Implements INotifyPropertyChanged

#Region "Variables"
    Protected _DataField As String 'campo de la base de la base de datos al que se bindea
    Protected _DataTable As String = "" 'tabla del dataset al que accede por defecto la 0 ya que muchas veces solo hay una
    Protected _Descripcion As String 'descripción del campo para los mensajes de error
    Protected _Incorrecto As Boolean = False 'indica si el campo es incorrecto tras validar es readonly
    Protected _MensajeIncorrecto As String 'el mensaje de error en caso de que lo haya
    Protected _AllowEmpty As Boolean = True 'si permite o no que el campo quede vacio al validar, por defecto si
    Protected _Validate As Boolean = True 'si valida al perder el foco, por defecto si
    Protected _DefaultValue As Date? = Today
    Protected _Value As Date?
    Protected _MinValue As Date?
    Protected _MaxValue As Date?
    Protected WithEvents _Binding As Binding
    Protected _MensajeIncorrectoCustom As String
    Public Event ValueChanged()
    Public Event ValueChanging(oldValue As Date, newValue As Date)

    Shadows Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected _Theme As ThemeType = ThemeType.Plain
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

    Property Value_Data As Date?
        Get
            Return _Value
        End Get
        Set(ByVal value As Date?)
            _Value = value
            If IsNothing(value) Then
                dtpData.SetToNullValue()
                dtpData.Refresh()
            Else
                dtpData.Value = value
            End If
            OnPropertyChanged("Value_Data")
        End Set
    End Property

    Property Default_Value As Date?
        Get
            Return _DefaultValue
        End Get
        Set(ByVal value As Date?)
            _DefaultValue = value
        End Set
    End Property

    Property MinDate As Date
        Get
            Return dtpData.MinDate
        End Get
        Set(value As Date)
            dtpData.MinDate = value
        End Set
    End Property

    Property MaxDate As Date
        Get
            Return dtpData.MaxDate
        End Get
        Set(value As Date)
            dtpData.MaxDate = value
        End Set
    End Property

    Property Min_Value As Date?
        Get
            Return _MinValue
        End Get
        Set(value As Date?)
            _MinValue = value
        End Set
    End Property

    Property Max_Value As Date?
        Get
            Return _MaxValue
        End Get
        Set(value As Date?)
            _MaxValue = value
        End Set
    End Property

    Property ReadOnly_Data As Boolean
        Get
            Return dtpData.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            dtpData.ReadOnly = value
            If value Then
                dtpData.DateTimePickerElement.ArrowButton.Enabled = False
                dtpData.DateTimePickerElement.TextBoxElement.TextBoxItem.BackColor = Drawing.Color.LightBlue
                dtpData.DateTimePickerElement.TextBoxElement.Fill.BackColor = Drawing.Color.LightBlue
            Else
                dtpData.DateTimePickerElement.ArrowButton.Enabled = True
                dtpData.DateTimePickerElement.TextBoxElement.TextBoxItem.BackColor = Drawing.Color.Transparent
                dtpData.DateTimePickerElement.TextBoxElement.Fill.BackColor = Drawing.Color.Transparent
            End If
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

    Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            If Theme = ThemeType.Plain Then
                dtpData.ThemeName = "Windows8"
            Else
                dtpData.ThemeName = "Windows7"
            End If
        End Set
    End Property

    Overrides ReadOnly Property Incorrecto As Boolean
        Get
            Return _Incorrecto
        End Get
    End Property

    Overrides ReadOnly Property MensajeIncorrecto As String
        Get
            If _MensajeIncorrectoCustom <> "" And IsNothing(Value_Data) And Not _AllowEmpty Then
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

    Property Validate_on_lost_focus As Boolean
        Get
            Return _Validate
        End Get
        Set(ByVal value As Boolean)
            _Validate = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Private Sub dtpData_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpData.KeyDown
        If e.KeyData = Keys.Delete And _AllowEmpty Then
            Value_Data = Nothing
        End If
    End Sub

    Private Sub dtpData_ValueChanging(sender As Object, e As Telerik.WinControls.UI.ValueChangingEventArgs) Handles dtpData.ValueChanging
        RaiseEvent ValueChanging(e.OldValue, e.NewValue)
    End Sub

    Private Sub dtpData_ValueChanged(sender As Object, e As EventArgs) Handles dtpData.ValueChanged
        If dtpData.Value <> New Date(1, 1, 1) Then
            _Value = dtpData.Value
        End If
        OnPropertyChanged("Value_Data")
        RaiseEvent ValueChanged()
    End Sub

    Private Sub DataDate_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        setToDefaultValue()
    End Sub

    Private Sub DataDate_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        'si valida al perder el foco
        If _Validate Then
            Validar()
        End If
        EndEdit() 'fuerza el la edicion
    End Sub

#End Region

#Region "Funciones de validacion"
    Public Sub forceSetError()
        _Incorrecto = True
        ValidateLabel()
    End Sub

    Public Overrides Sub Validar()
        'si ValidateData devuelve TRUE los datos son correctos, por eso incorrecto es el negado
        _Incorrecto = Not ValidateData()
        ValidateLabel()
    End Sub

    Protected Overridable Sub ValidateLabel()
        'para los heredados que usan etiqueta, si es incorrecto se pone en rojo con un tooltip del error
    End Sub

    Public Function ValidateData() As Boolean
        If Not _AllowEmpty And IsNothing(_Value) Then 'comprueba si el texto puede ser vacio
            _MensajeIncorrecto = ("No se permite un dato vacío.")
            Return False
        End If
        If Not IsNothing(_MinValue) And Not IsNothing(_MaxValue) Then
            If dtpData.Value < _MinValue Or dtpData.Value > _MaxValue Then
                _MensajeIncorrecto = ("La fecha debe estar entre " & CDate(_MinValue).ToString("dd/MM/yyyy") & " y " & CDate(_MaxValue).ToString("dd/MM/yyyy") & ".")
                Return False
            End If
        ElseIf Not IsNothing(_MinValue) And IsNothing(_MaxValue) Then
            If dtpData.Value < _MinValue Then
                _MensajeIncorrecto = ("La fecha no puede ser inferior a " & CDate(_MinValue).ToString("dd/MM/yyyy") & ".")
                Return False
            End If
        ElseIf IsNothing(_MinValue) And Not IsNothing(_MaxValue) Then
            If dtpData.Value > _MaxValue Then
                _MensajeIncorrecto = ("La fecha no puede ser superior a " & CDate(_MaxValue).ToString("dd/MM/yyyy") & ".")
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"
    'Funciones de bindeo con sobrecarga en funcion del donde se guarden los datos
    Public Overrides Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Value_Data", dta, _DataField, True)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Value_Data", dts.Tables(_DataTable), _DataField, True)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Value_Data", bs, _DataField, True)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub
#End Region

    Private Sub Parse(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Parse
        'Al guardar os datos si el campo de texto esta vacio y se acepa guardar nulls
        'If e.Value = New Date(1, 1, 1) Then
        '    'e.Value = DBNull.Value
        'End If
    End Sub

    Public Overrides Sub Clear()
        'Limpia el campo de texto y rompe los bindings si los hay
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Me.DataBindings.Clear()
            _Binding = Nothing
        End If
        setToDefaultValue()
        ClearLabel()
    End Sub

    Public Overrides Sub EndEdit()
        'Fuerza el final de edicion de los bindings
        Try
            Me.DataBindings("Value_Data").BindingManagerBase.EndCurrentEdit()
        Catch
        End Try
    End Sub

    Protected Overridable Sub ClearLabel()
        'para los controles heredados
    End Sub

#End Region

#Region "Funciones"
    Public Sub setToDefaultValue()
        If IsNothing(_DefaultValue) And Not _AllowEmpty Then
            Value_Data = Today
        Else
            Value_Data = _DefaultValue
        End If
    End Sub

    Public Overrides Function ToString() As String
        Try
            Return dtpData.Value.ToString("yyyy-MM-dd")
        Catch
            Return ""
        End Try
    End Function

    Public Overrides Sub traduc()
        Descripcion = Translate(Descripcion)
    End Sub
#End Region

End Class
