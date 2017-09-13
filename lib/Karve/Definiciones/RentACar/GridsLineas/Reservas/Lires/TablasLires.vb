Imports CustomControls

Public Class TablasLires

    Public Function LiRes() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "LIRESER"
        tb.AliasTabla = "LR"
        Return tb
    End Function
End Class
