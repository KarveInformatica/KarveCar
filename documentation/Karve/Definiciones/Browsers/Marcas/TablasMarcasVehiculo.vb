Imports CustomControls

Public Class TablasMarcasVehiculo

    Public Function TiposVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "MARCAS"
        Tb.AliasTabla = "MAR"

        Return Tb
    End Function


End Class
