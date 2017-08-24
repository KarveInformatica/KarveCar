Imports CustomControls

Public Class TablasClavesPresupuesto
    Public Function ClavesPresupuestoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLAVEPTO"
        Tb.AliasTabla = "CLP"

        Return Tb
    End Function
End Class