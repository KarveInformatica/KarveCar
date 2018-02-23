Imports CustomControls

Public Class TablasTiposVehiculo

    Public Function TiposVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CATEGO"
        Tb.AliasTabla = "CAT"

        Return Tb
    End Function


End Class
