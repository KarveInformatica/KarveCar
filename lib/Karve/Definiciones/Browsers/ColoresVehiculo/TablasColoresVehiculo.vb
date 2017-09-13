Imports CustomControls

Public Class TablasColoresVehiculo

    Public Function ColoresVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "COLORFL"
        Tb.AliasTabla = "CLF"

        Return Tb
    End Function

End Class
