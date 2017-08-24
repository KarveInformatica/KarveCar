Imports CustomControls

Public Class TablasBasesCon

    Public Function BasesCon() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "BASESCon"
        tb.AliasTabla = "BC"
        Return tb
    End Function
End Class
