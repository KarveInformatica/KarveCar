Imports CustomControls

Public Class TablasTiposVisita

    Public Function TiposVisitaFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TIPOVISITAS"
        Tb.AliasTabla = "TVIS"

        Return Tb
    End Function
End Class
