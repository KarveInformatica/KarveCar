Imports CustomControls

Public Class TablasCanalCliente

    Public Function CanalClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CANAL"
        Tb.AliasTabla = "CAC"

        Return Tb
    End Function

End Class
