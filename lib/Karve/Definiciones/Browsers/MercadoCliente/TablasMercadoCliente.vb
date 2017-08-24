Imports CustomControls

Public Class TablasMercadoCliente

    Public Function MercadosClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "MERCADO"
        Tb.AliasTabla = "MC"

        Return Tb
    End Function

End Class
