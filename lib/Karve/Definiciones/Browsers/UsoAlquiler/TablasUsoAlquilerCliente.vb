Imports CustomControls

Public Class TablasUsoAlquilerCliente

    Public Function UsoAlquilerClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "USO_ALQUILER"
        Tb.AliasTabla = "UAC"

        Return Tb
    End Function

End Class
