Imports CustomControls

Public Class TablasVendedores
    Public Function Vendedor() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "VENDEDOR"
        Tb.AliasTabla = "VEND"
        Return Tb
    End Function
End Class
