Imports CustomControls

Public Class TablasCargosPersonalCliente

    Public Function CargosPersonalFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PERCARGOS"
        Tb.AliasTabla = "PCC"

        Return Tb
    End Function

End Class
