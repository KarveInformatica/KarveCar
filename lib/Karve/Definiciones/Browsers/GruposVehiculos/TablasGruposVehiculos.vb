Imports CustomControls

Public Class TablasGruposVehiculos

    Public Function GruposFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "GRUPOS"
        Tb.AliasTabla = "GRU"

        Return Tb
    End Function

End Class
