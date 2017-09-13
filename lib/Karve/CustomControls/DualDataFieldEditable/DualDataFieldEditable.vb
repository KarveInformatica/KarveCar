Imports VariablesGlobales

Public Class DualDataFieldEditable
    Inherits DualDatafield

    Public Property DataField_DescEdit As String
        Get
            Return dtfDesc.DataField
        End Get
        Set(ByVal value As String)
            dtfDesc.DataField = value
        End Set
    End Property

    Public Property DataTable_DescEdit As String
        Get
            Return dtfDesc.DataTable
        End Get
        Set(ByVal value As String)
            dtfDesc.DataTable = value
        End Set
    End Property

    Public Property ReadOnly_Desc As Boolean
        Get
            Return dtfDesc.ReadOnly_Data
        End Get
        Set(ByVal value As Boolean)
            dtfDesc.ReadOnly_Data = value
        End Set
    End Property

    Protected Overrides Sub bindingExtra(ByRef dataAdapter As Object)
        dtfDesc.setBinding(dataAdapter)
    End Sub
End Class
