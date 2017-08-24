Imports CustomControls

Public Class TablasBloquesFacturacion

    Public Function BloquesFacturacionFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "BLOQUEFAC"
        Tb.AliasTabla = "BLQF"

        Return Tb
    End Function

End Class
