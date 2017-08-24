Imports CustomControls

Public Class TablasNegocioCliente

    Public Function NegocioClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "NEGOCIO"
        Tb.AliasTabla = "NC"

        Return Tb
    End Function

End Class
