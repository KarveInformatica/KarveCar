Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class DataCheck
    Inherits RadCheckBox

#Region "Variables"
    Protected _DataField As String
    Protected _DataTable As String = ""

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

    Property Descripcion As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Property Value As Boolean
        Get
            Return Me.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.Checked = value
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
        If _Theme = ThemeType.Plain Then
            Me.ThemeName = "Windows8"
        Else
            Me.ThemeName = "Windows7"
        End If
    End Sub
#End Region

#Region "Funciones de Acceso a Datos"
    Protected WithEvents _Binding As Binding

    Public Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Checked", dta, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Checked", dts.Tables(_DataTable), _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Public Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Checked", bs, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
        End If
    End Sub

    Private Sub Parse(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Parse

    End Sub

    Private Sub Format(ByVal sender As Object, e As ConvertEventArgs) Handles _Binding.Format
        If IsDBNull(e.Value) Then
            e.Value = False
        End If
    End Sub

    Public Sub Clear()
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Me.DataBindings.Clear()
        End If
        Me.Checked = False
    End Sub

    Public Sub EndEdit()
        Try
            Me.DataBindings("Checked").BindingManagerBase.EndCurrentEdit()
        Catch
        End Try
    End Sub
#End Region

    Private Sub DataCheck_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Font = New System.Drawing.Font("Verdana", 8.25)
        Me.ThemeName = "Windows8"
    End Sub

#Region "Funciones"
    Public Sub traduc()
        Descripcion = Translate(Descripcion)
    End Sub
#End Region
End Class
