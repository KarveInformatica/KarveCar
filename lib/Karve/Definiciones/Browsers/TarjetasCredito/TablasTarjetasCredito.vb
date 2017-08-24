Imports CustomControls

Public Class TablasTarjetasCredito

    Public Function TarjetasCreditoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TARCREDI"
        Tb.AliasTabla = "TAC"

        Return Tb
    End Function

End Class
