Imports CustomControls

Public Class TablasVehiMante

    Public Function VehiMante() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "MANTENIMIENTO_VEHICULO"
        tb.AliasTabla = "MV"
        Return tb
    End Function

End Class
