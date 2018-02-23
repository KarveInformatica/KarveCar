Imports CustomControls

Public Class TablasLifacs

    Public Function LiFacs() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "LIFAC"
        tb.AliasTabla = "LF"
        Return tb
    End Function
End Class
