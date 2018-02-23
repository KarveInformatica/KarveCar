Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports VariablesGlobales

Public Class DataLabel
    Inherits CustomControls.Label
    Protected _format As fotmatType

    Enum fotmatType
        plain
        fecha
        fechahora
        ultmodi
    End Enum

#Region "Variables"
    Protected _DataField As String 'campo de la base de la base de datos al que se bindea
    Protected _DataTable As String = "" 'tabla del dataset al que accede por defecto la 0 ya que muchas veces solo hay una
    Protected WithEvents _Binding As Binding
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

    Overridable Property Descripcion As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Property Fromat As fotmatType
        Get
            Return _format
        End Get
        Set(value As fotmatType)
            _format = value
        End Set
    End Property
#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"

    Public Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            '_Binding = New Binding("Text", dta, _DataField)
            '_Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            'Me.DataBindings.Add(_Binding)
            Me.Text = dta.Rows(0).Item(_DataField).ToString
            setFormat()
        End If
    End Sub

    Public Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            '_Binding = New Binding("Text", dts.Tables(_DataTable), _DataField)
            '_Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            'Me.DataBindings.Add(_Binding)
            Me.Text = dts.Tables(_DataTable).Rows(0).Item(_DataField).ToString
            setFormat()
        End If
    End Sub

    Public Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            '_Binding = New Binding("Text", bs, _DataField)
            '_Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            'Me.DataBindings.Add(_Binding)
            Me.Text = bs.Item(_DataField).ToString
            setFormat()
        End If
    End Sub
#End Region

    Public Sub Clear()
        'Limpia el campo de texto y rompe los bindings si los hay
        'If Not IsNothing(_DataField) And _DataField <> "" Then
        '    Me.DataBindings.Clear()
        '    _Binding = Nothing
        'End If
        Me.Text = ""
    End Sub

    Public Sub EndEdit()
        'Fuerza el final de edicion de los bindings
        'Try
        '    Me.DataBindings("Text").BindingManagerBase.EndCurrentEdit()
        'Catch
        'End Try
    End Sub
#End Region

#Region "Eventos"
    Private Sub DataLabel_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.AutoSize = False
    End Sub
#End Region

    Private Sub setFormat()
        If Me.Text <> "" Then
            Select Case (_format)
                Case fotmatType.fecha
                    formatToDate()
                Case fotmatType.fechahora
                    formatToDateTime()
                Case fotmatType.ultmodi
                    formatToUltmodi()
                Case Else

            End Select
        End If
    End Sub

    Private Sub formatToDate()
        Dim dt As New Date
        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
        dt = Date.ParseExact(Me.Text, "yyyyMMdd", provider)
        Me.Text = dt.ToString("dd/MM/yyyy")
    End Sub

    Private Sub formatToDateTime()
        Dim dt As New Date
        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
        dt = Date.ParseExact(Me.Text, "yyyyMMddhhmm", provider)
        Me.Text = dt.ToString("hh:mm dd/MM/yyyy")
    End Sub

    Private Sub formatToUltmodi()
        Dim dt As New DateTime
        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
        dt = DateTime.ParseExact(Me.Text, "yyyyMMddHH:mm", provider)
        Me.Text = dt.ToString("hh:mm dd/MM/yyyy")
    End Sub
End Class
