Imports CustomControls

Public Class TablasActividadCliente

    Public Function ActividadesClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "ACTIVI"
        Tb.AliasTabla = "ATC"

        Return Tb
    End Function

End Class
