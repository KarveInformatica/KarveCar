Imports System.Windows.Forms

Public Class ctrBase

#Region "Propiedades"
    Overridable Property Descripcion As String
        Get
            Return ""
        End Get
        Set(value As String)

        End Set
    End Property

    Overridable ReadOnly Property Incorrecto As Boolean
        Get
            Return False

        End Get
    End Property
    Overridable ReadOnly Property MensajeIncorrecto As String
        Get
            Return ""
        End Get
    End Property

    Overridable Property FocoEnAgregar As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

#End Region

#Region "Funciones de Validacion"
    Public Overridable Sub Validar()

    End Sub

#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"
    Public Overridable Sub setBinding(ByRef dta As DataTable)

    End Sub
    Public Overridable Sub setBinding(ByRef dts As DataSet)

    End Sub
    Public Overridable Sub setBinding(ByRef bs As BindingSource)

    End Sub

#End Region

    Public Overridable Sub Clear()

    End Sub
    Public Overridable Sub EndEdit()

    End Sub

#End Region

#Region "Funciones"
    Public Overridable Sub traduc()

    End Sub
#End Region

End Class
