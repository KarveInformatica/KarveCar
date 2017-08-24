Imports System.Windows.Forms
Imports System.ComponentModel
Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class DataTime
    Inherits ctrBase
    Implements INotifyPropertyChanged

#Region "Variables"
    Protected _DataField As String 'campo de la base de la base de datos al que se bindea
    Protected _DataTable As String = "" 'tabla del dataset al que accede por defecto la 0 ya que muchas veces solo hay una
    Protected _Descripcion As String 'descripción del campo para los mensajes de error
    Protected _Time As TimeSpan?
    Protected WithEvents _Binding As Binding
    Private isNull As Boolean = False
    Private dropDown As Boolean = False
    Protected _Validate As Boolean = True 'si valida al perder el foco, por defecto si
    Protected _Incorrecto As Boolean = False 'indica si el campo es incorrecto tras validar es readonly
    Protected _MensajeIncorrecto As String 'el mensaje de error en caso de que lo haya
    Protected _AllowEmpty As Boolean = True 'si permite o no que el campo quede vacio al validar, por defecto si
    Protected _Horarios As New List(Of Horario)
    Protected _MensajeIncorrectoCustom As String
    Public Event ValueChanged()

    Shadows Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    'este evento es para que funcione el PropertyChanged en nuestra propiedad Index y funcione correctamente el binding

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

    Property Time As TimeSpan?
        Get
            Return _Time
        End Get
        Set(ByVal value As TimeSpan?)
            _Time = value
            If Not IsNothing(value) Then
                isNull = False
                dropDown = False
                tmpData.Value = New DateTime(1, 1, 1, value.Value.Hours, value.Value.Minutes, 0)
            Else
                isNull = True
                dropDown = False
                tmpData.Value = Nothing
            End If
            OnPropertyChanged("Time")
        End Set
    End Property

    Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            For Each ctr In Me.Controls
                If ctr.GetType Is GetType(DataRadio) Then
                    CType(ctr, DataRadio).Theme = _Theme
                End If
            Next
            If Theme = ThemeType.Plain Then
                tmpData.ThemeName = "Windows8"
            Else
                tmpData.ThemeName = "Windows7"
            End If
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Property Horarios As List(Of Horario)
        Get
            Return _Horarios
        End Get
        Set(value As List(Of Horario))
            _Horarios = value
        End Set
    End Property

    Property ReadOnly_Data As Boolean
        Get
            Return tmpData.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            tmpData.ReadOnly = value
            If value Then
                tmpData.TimePickerElement.DropDownButton.Enabled = False
                tmpData.TimePickerElement.BackColor = Drawing.Color.LightBlue
                tmpData.TimePickerElement.EditorElement.BackColor = Drawing.Color.LightBlue
            Else
                tmpData.TimePickerElement.DropDownButton.Enabled = True
                tmpData.TimePickerElement.BackColor = Drawing.Color.White
                tmpData.TimePickerElement.EditorElement.BackColor = Drawing.Color.White
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

    Overrides ReadOnly Property Incorrecto As Boolean
        Get
            Return _Incorrecto
        End Get
    End Property

    Overrides ReadOnly Property MensajeIncorrecto As String
        Get
            If _MensajeIncorrectoCustom <> "" Then
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

    Private Sub DataTime_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        AddHandler tmpData.TimePickerElement.DropDownButton.Click, AddressOf dropDownClick
    End Sub

    Private Sub dropDownClick()
        dropDown = True
    End Sub

    Private Sub tmpData_KeyDown(sender As Object, e As KeyEventArgs) Handles tmpData.KeyDown
        If e.KeyData = Keys.Delete Then
            Time = Nothing
            'tmpData.Value = Nothing
            isNull = True
        Else
            isNull = False
        End If
    End Sub

    Private Sub tmpData_ValueChanged(sender As Object, e As EventArgs) Handles tmpData.ValueChanged
        Try
            If Not isNull Or dropDown Then 'tmpData.Value.Value.TimeOfDay <> New TimeSpan(0, 0, 0) Or Not isNull Then
                _Time = New TimeSpan(tmpData.Value.Value.Hour, tmpData.Value.Value.Minute, 0)
                isNull = False
            End If
            dropDown = False
            OnPropertyChanged("Time")
            RaiseEvent ValueChanged()
        Catch
        End Try
    End Sub

    Private Sub DataTime_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
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
        If Not _AllowEmpty And IsNothing(_Time) Then 'comprueba si el texto puede ser vacio
            _MensajeIncorrecto = ("No se permite un dato vacío.")
            Return False
        End If
        If Not IsNothing(_Horarios) And Not IsNothing(_Time) Then
            For Each h As Horario In _Horarios
                If _Time < h.HoraInicio Or _Time > h.HoraFinal Then
                    _MensajeIncorrecto = ("Esta fuera del rango de horas permitido.")
                    Return False
                End If
            Next
        End If
        Return True
    End Function
#End Region

#Region "Funciones de Acceso a Datos"

#Region "Bindings"
    Public Overrides Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Time", dta, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Time", dts.Tables(_DataTable), _DataField, True, DataSourceUpdateMode.OnPropertyChanged)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Time", bs, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

#End Region

    Private Sub Parse(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Parse
        'Al guardar os datos si el campo de texto esta vacio y se acepa guardar nulls
        'If _Time = New TimeSpan(0, 0, 0) And isNull Or _Time = Nothing Then
        '    e.Value = DBNull.Value
        'End If
    End Sub

    Public Overrides Sub Clear()
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Me.DataBindings.Clear()
        End If
    End Sub

    Public Overrides Sub EndEdit()
        Try
            Me.DataBindings("Time").BindingManagerBase.EndCurrentEdit()
        Catch
        End Try
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

End Class
