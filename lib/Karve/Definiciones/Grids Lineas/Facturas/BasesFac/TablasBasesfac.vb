Imports CustomControls

Public Class TablasBasesfac

    Public Function BasesFac() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "BASESFAC"
        tb.AliasTabla = "BF"
        Return tb
    End Function
End Class
