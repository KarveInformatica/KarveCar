Imports CustomControls

Public Class TablasZonas

    Public Function ZonasFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "ZONAS"
        Tb.AliasTabla = "ZN"

        Return Tb
    End Function

End Class
