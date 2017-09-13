Imports CustomControls

Public Class TablasModelosVehiculo

    Public Function ModelosVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "MODELO"
        Tb.AliasTabla = "MOD"

        Return Tb
    End Function
End Class