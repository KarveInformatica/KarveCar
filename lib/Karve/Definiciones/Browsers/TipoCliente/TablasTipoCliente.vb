Imports CustomControls

Public Class TablasTipoCliente

    Public Function TipoClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TIPOCLI"
        Tb.AliasTabla = "TC"

        Return Tb
    End Function

End Class
