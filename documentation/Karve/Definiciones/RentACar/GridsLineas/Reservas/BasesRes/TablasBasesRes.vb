Imports CustomControls

Public Class TablasBasesRes

    Public Function BasesRes() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "BASESRES"
        tb.AliasTabla = "BR"
        Return tb
    End Function
End Class
