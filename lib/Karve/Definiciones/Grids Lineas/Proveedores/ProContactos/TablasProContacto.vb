Imports CustomControls

Public Class TablasProContacto

    Public Function CliDelega() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "PROCONTACTOS"
        tb.AliasTabla = "PRC"
        Return tb
    End Function

End Class
