Imports CustomControls

Public Class TablasComportaTarifas

    Public Function ComportaTari() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "COMPORTA_TARIFAS"
        tb.AliasTabla = "CPT"
        Return tb
    End Function
End Class
