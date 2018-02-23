Imports System.Windows.Forms
Imports VariablesGlobales

Public Class EmpresaOficina
    Inherits ctrBase

#Region "Variables"
    Protected _Incorrecto As Boolean = False 'indica si el campo es incorrecto tras validar es readonly
    Protected _MensajeIncorrecto As String 'el mensaje de error en caso de que lo haya
    Protected _MensajeIncorrectoCustom As String
    Private _descipcion As String

#End Region

#Region "Propiedades"

    Property ShowLupa As Boolean
        Get
            Return dtfOficina.ShowButton
        End Get
        Set(value As Boolean)
            dtfOficina.ShowButton = value
        End Set
    End Property

    Property OficinaReadOnly As Boolean
        Get
            Return dtfOficina.ReadOnly_Data
        End Get
        Set(value As Boolean)
            dtfOficina.ReadOnly_Data = value
        End Set
    End Property

    Property DataField_Oficina As String
        Get
            Return dtfOficina.DataField
        End Get
        Set(value As String)
            dtfOficina.DataField = value
        End Set
    End Property

    Property DataField_Empresa As String
        Get
            Return dtfEmpresa.DataField
        End Get
        Set(value As String)
            dtfEmpresa.DataField = value
        End Set
    End Property

    Property DataTable_Oficina As String
        Get
            Return dtfOficina.DataTable
        End Get
        Set(value As String)
            dtfOficina.DataTable = value
        End Set
    End Property

    Property DataTable_Empresa As String
        Get
            Return dtfEmpresa.DataTable
        End Get
        Set(value As String)
            dtfEmpresa.DataTable = value
        End Set
    End Property

    Property Size_Empresa As Integer
        Get
            Return dtfEmpresa.Width
        End Get
        Set(value As Integer)
            If value < 85 Then value = 85
            dtfEmpresa.Width = value
        End Set
    End Property

    Public Overrides Property Descripcion As String
        Get
            Return _descipcion
        End Get
        Set(value As String)
            _descipcion = value
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

    Property Text_Oficina As String
        Get
            Return dtfOficina.Text_Data
        End Get
        Set(value As String)
            dtfOficina.Text_Data = value
        End Set
    End Property

    Property Text_Empresa As String
        Get
            Return dtfEmpresa.Text_Data
        End Get
        Set(value As String)
            dtfEmpresa.Text_Data = value
        End Set
    End Property

    Property Lupa As String
        Get
            Return dtfOficina.Lupa
        End Get
        Set(value As String)
            dtfOficina.Lupa = value
        End Set
    End Property

#End Region

#Region "Eventos"
    Private Sub dtfOficina_QueryThrown(dts As DataSet) Handles dtfOficina.QueryThrown
        Try
            dtfEmpresa.Text_Data = dts.Tables(0).Rows(0).Item(1)
        Catch
            dtfEmpresa.Text_Data = ""
        End Try
    End Sub

#End Region

#Region "Funciones de Validacion"
    Public Overrides Sub Validar()
        _MensajeIncorrecto = ""
        dtfOficina.Validar()
        dtfEmpresa.Validar()
        If dtfOficina.Incorrecto Then
            _Incorrecto = True
            _MensajeIncorrecto &= dtfOficina.MensajeIncorrecto
        End If
        If dtfEmpresa.Incorrecto Then
            _Incorrecto = True
            If _MensajeIncorrecto <> "" Then _MensajeIncorrecto &= vbCrLf
            _MensajeIncorrecto &= dtfEmpresa.MensajeIncorrecto
        End If
    End Sub
#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"

    Public Overrides Sub setBinding(ByRef dta As DataTable)
        If Not IsNothing(dtfOficina.DataField) And dtfOficina.DataField <> "" Then
            dtfOficina.setBinding(dta)
        End If
        If Not IsNothing(dtfEmpresa.DataField) And dtfEmpresa.DataField <> "" Then
            dtfEmpresa.setBinding(dta)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        If Not IsNothing(dtfOficina.DataField) And dtfOficina.DataField <> "" Then
            dtfOficina.setBinding(dts)
        End If
        If Not IsNothing(dtfEmpresa.DataField) And dtfEmpresa.DataField <> "" Then
            dtfEmpresa.setBinding(dts)
        End If
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        If Not IsNothing(dtfOficina.DataField) And dtfOficina.DataField <> "" Then
            dtfOficina.setBinding(bs)
        End If
        If Not IsNothing(dtfEmpresa.DataField) And dtfEmpresa.DataField <> "" Then
            dtfEmpresa.setBinding(bs)
        End If
    End Sub
#End Region 'Funciones de bindeo con sobrecarga en funcion del donde se guarden los datos


    Public Overrides Sub Clear()
        'Limpia el campo de texto y rompe los bindings si los hay
        dtfOficina.Clear()
        dtfEmpresa.Clear()
    End Sub

    Public Overrides Sub EndEdit()
        'Fuerza el final de edicion de los bindings
        dtfOficina.EndEdit()
        dtfEmpresa.EndEdit()
    End Sub

#End Region

    Public Overrides Sub traduc()
        dtfOficina.traduc()
        dtfEmpresa.traduc()
    End Sub
End Class
