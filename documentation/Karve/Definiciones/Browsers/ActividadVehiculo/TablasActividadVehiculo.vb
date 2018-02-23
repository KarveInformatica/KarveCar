Imports CustomControls

Public Class TablasActividadVehiculo

    Public Function ActividadesVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "ACTIVEHI"
        Tb.AliasTabla = "ATV"

        Return Tb
    End Function

End Class

