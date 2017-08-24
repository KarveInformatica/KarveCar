Imports System.Windows.Forms
Imports VariablesGlobales

Public Class TrackBar
    Inherits ctrBase

#Region "Variables"
    Private _datafield_octavos As String
    Private _datafield_litros As String
    Private _datatable_octavos As String
    Private _datatable_litros As String
    Private _descripcion As String
    Private _totalLitros As Double
    Private _litrosAct As Double
    Private _ocatvos As Integer
    Private recalculando As Boolean = False

    Public Event OctavosValueChanged()
    Public Event LitrosValueChanged()
    Public Event BarValueChanged()
#End Region

#Region "Propiedades"
    'Property DataField_Octavos As String
    '    Get
    '        Return _datafield_octavos
    '    End Get
    '    Set(value As String)
    '        _datafield_octavos = value
    '    End Set
    'End Property

    'Property DataField_Litros As String
    '    Get
    '        Return _datafield_litros
    '    End Get
    '    Set(value As String)
    '        _datafield_litros = value
    '    End Set
    'End Property

    'Property Datatable_Octavos As String
    '    Get
    '        Return _datatable_octavos
    '    End Get
    '    Set(value As String)
    '        _datatable_octavos = value
    '    End Set
    'End Property

    'Property Datatable_Litros As String
    '    Get
    '        Return _datatable_litros
    '    End Get
    '    Set(value As String)
    '        _datatable_litros = value
    '    End Set
    'End Property

    'Overrides Property Descripcion As String
    '    Get
    '        Return _descripcion
    '    End Get
    '    Set(value As String)
    '        _descripcion = value
    '    End Set
    'End Property

    Property TotalLitros() As Double
        Get
            Return _totalLitros
        End Get
        Set(value As Double)
            _totalLitros = value
        End Set
    End Property

    Property LitrosAct() As Double
        Get
            Return _litrosAct
        End Get
        Set(value As Double)
            _litrosAct = value
            LitrosChanged()
        End Set
    End Property

    Property Octavos As Integer
        Get
            Return _ocatvos
        End Get
        Set(value As Integer)
            _ocatvos = value
            OctavosChanged()
        End Set
    End Property

#End Region

#Region "Funciones de Validacion"
    Public Overrides Sub Validar()

    End Sub

#End Region

    '#Region "Funciones de Acceso a Datos"
    '#Region "Bindings"
    '    Public Overrides Sub setBinding(ByRef dta As DataTable)
    '        dtfOctavos.setBinding(dta)
    '        dtfLitros.setBinding(dta)
    '    End Sub
    '    Public Overrides Sub setBinding(ByRef dts As DataSet)
    '        dtfOctavos.setBinding(dts)
    '        dtfLitros.setBinding(dts)
    '    End Sub
    '    Public Overrides Sub setBinding(ByRef bs As BindingSource)
    '        dtfOctavos.setBinding(bs)
    '        dtfLitros.setBinding(bs)
    '    End Sub

    '#End Region

    '    Public Overrides Sub Clear()
    '        dtfOctavos.Clear()
    '        dtfLitros.Clear()
    '    End Sub
    '    Public Overrides Sub EndEdit()
    '        dtfOctavos.Clear()
    '        dtfLitros.Clear()
    '    End Sub

    '#End Region

#Region "Calculo Litros Octavos"

    Private Sub trbBarra_ValueChanged(sender As Object, e As EventArgs) Handles trbBarra.ValueChanged
        Try
            If Not recalculando And Not DesignMode Then
                recalculando = True
                _ocatvos = trbBarra.Value / 2
                _litrosAct = Math.Round((_totalLitros / 16 * trbBarra.Value), 2, MidpointRounding.AwayFromZero)
                _ocatvos = CInt(Math.Round(Octavos, 0, MidpointRounding.AwayFromZero))
                recalculando = False
                RaiseEvent BarValueChanged()
            End If
        Catch
            recalculando = False
        End Try
    End Sub

    Private Sub OctavosChanged()
        Try
            If Not recalculando And Not DesignMode Then
                recalculando = True
                _litrosAct = Math.Round((_totalLitros / 8 * _ocatvos), 2, MidpointRounding.AwayFromZero)
                trbBarra.Value = _ocatvos * 2
                recalculando = False
                RaiseEvent LitrosValueChanged()
            End If
        Catch
            recalculando = False
        End Try
    End Sub

    Private Sub LitrosChanged()
        Try
            If Not recalculando Then
                recalculando = True
                Dim tmp As Double
                If _totalLitros <> 0 Then
                    tmp = (_litrosAct * 8) / _totalLitros
                Else
                    _ocatvos = 0
                End If

                trbBarra.Value = tmp * 2
                _ocatvos = CInt(Math.Round(tmp, 0, MidpointRounding.AwayFromZero))
                recalculando = False
                RaiseEvent OctavosValueChanged()
            End If
        Catch
            recalculando = False
        End Try
    End Sub

#End Region

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        recalculando = True
        _ocatvos = 0
        _litrosAct = 0
        _totalLitros = 0
        trbBarra.Value = 0
        recalculando = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class
