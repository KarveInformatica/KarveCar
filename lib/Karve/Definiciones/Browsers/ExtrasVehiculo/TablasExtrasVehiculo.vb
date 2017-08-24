Imports CustomControls

Public Class TablasExtrasVehiculo

    Public Function ExtrasVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "EXTRASVEHI"
        Tb.AliasTabla = "EXVEH"
        Return Tb
    End Function

    Public Function TiposVehiculo() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CATEGO"
        Tb.Criterio = "ON EXVEH.TIPO_VEHI = CAT.CODIGO"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "CAT"

        Return Tb
    End Function

End Class
