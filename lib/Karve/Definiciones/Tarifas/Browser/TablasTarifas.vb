Imports CustomControls

Public Class TablasTarifas

    Public Function TarifasFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "NTARI"
        Tb.AliasTabla = "NT"

        Return Tb
    End Function

End Class
