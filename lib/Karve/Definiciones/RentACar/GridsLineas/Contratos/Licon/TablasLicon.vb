Imports CustomControls

Public Class TablasLicon

    Public Function LiCon() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "LICON"
        tb.AliasTabla = "LC"
        Return tb
    End Function
End Class
