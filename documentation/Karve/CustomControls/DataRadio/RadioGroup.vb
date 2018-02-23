Imports System.Windows.Forms
Imports System.ComponentModel
Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class RadioGroup
    Inherits CustomControls.GroupBox
    Implements INotifyPropertyChanged

#Region "Variables"
    Protected _DataField As String 'campo de la base de la base de datos al que se bindea
    Protected _DataTable As String = "" 'tabla del dataset al que accede por defecto la 0 ya que muchas veces solo hay una
    Protected _Index As String 'ya que no hay propiedad a la que bindear, creamos la Propiedad Index donde se guardaran los datos
    Protected _DefaultIndex As String
    Protected WithEvents _Binding As Binding
    Public Event IndexChanged(Index As String)

    Shadows Event PropertyChanged As PropertyChangedEventHandler
    'este evento es para que funcione el PropertyChanged en nuestra propiedad Index y funcione correctamente el binding

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

    Property Index() As String
        Get
            Return _Index
        End Get
        Set(ByVal value As String)
            _Index = value
            OnPropertyChanged("Index")
            SelectRadio()
        End Set
    End Property

    Overrides Property Theme As ThemeType
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
                Me.ThemeName = "Windows8"
            Else
                Me.ThemeName = "Windows7"
            End If
        End Set
    End Property

    Property DefaultIndex As String
        Get
            Return _DefaultIndex
        End Get
        Set(value As String)
            _DefaultIndex = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
        RaiseEvent IndexChanged(_Index)
    End Sub

    Private Sub RadioGroup_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        'se asigna el tema del control a todos sus radiobutton
        For Each ctr In Me.Controls
            If ctr.GetType Is GetType(DataRadio) Then
                CType(ctr, DataRadio).Theme = _Theme
                AddHandler CType(ctr, DataRadio).CheckedChanged, AddressOf SelectionChanged
                'el evento de cuando se chequea un radiobutton para cambiar el index que se va a guardar
            End If
        Next
        Me.Font = New System.Drawing.Font("Verdana", 8.25)
        Me.ThemeClassName = "Telerik.WinControls.UI.RadGroupBox"
    End Sub

    Private Sub SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tmp As DataRadio = CType(sender, DataRadio)
        If tmp.IsChecked Then
            Me._Index = tmp.Index
            OnPropertyChanged("Index")
        End If
    End Sub
#End Region

#Region "Funciones de Acceso a Datos"
    Public Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Index", dta, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            SelectRadio()
        End If
    End Sub

    Public Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Index", dts.Tables(_DataTable), _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            SelectRadio()
        End If
    End Sub

    Public Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Clear()
            _Binding = New Binding("Index", bs, _DataField)
            _Binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            Me.DataBindings.Add(_Binding)
            SelectRadio()
        End If
    End Sub

    Private Sub SelectRadio()
        If Not IsDBNull(_Index) Then
            For Each ctr In Me.Controls
                If ctr.GetType Is GetType(DataRadio) Then
                    If CType(ctr, DataRadio).Index = _Index Then
                        CType(ctr, DataRadio).IsChecked = True
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub Clear()
        If Not IsNothing(_DataField) And _DataField <> "" Then
            Me.DataBindings.Clear()
            For Each ctr In Me.Controls
                If ctr.GetType Is GetType(DataRadio) Then
                    CType(ctr, DataRadio).IsChecked = False
                End If
            Next
            If _DefaultIndex <> "" Then
                _Index = _DefaultIndex
                SelectRadio()
            End If
        End If
    End Sub

    Public Sub EndEdit()
        Try
            _Binding.WriteValue()
            Me.DataBindings("Index").BindingManagerBase.EndCurrentEdit()
        Catch
        End Try
    End Sub
#End Region

#Region "Funciones"
    Public Overrides Sub traduc()
        Descripcion = Translate(Descripcion)
        For Each ctr In Me.Controls
            If ctr.GetType Is GetType(DataRadio) Then
                CType(ctr, DataRadio).traduc()
            End If
        Next
    End Sub
#End Region

End Class
