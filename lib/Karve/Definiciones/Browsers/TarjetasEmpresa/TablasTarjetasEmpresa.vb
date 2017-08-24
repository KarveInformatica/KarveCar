Imports CustomControls

Public Class TablasTarjetasEmpresa
    Public Function TarjetasCreditoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TARJETA_EMP"
        Tb.AliasTabla = "TARE"

        Return Tb
    End Function
End Class
