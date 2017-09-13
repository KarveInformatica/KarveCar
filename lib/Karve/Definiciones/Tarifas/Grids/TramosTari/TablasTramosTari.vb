Imports CustomControls

Public Class TablasTramosTari

    Public Function TramosTari() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "TRAMOS_TARI"
        tb.AliasTabla = "TRT"
        Return tb
    End Function
End Class
