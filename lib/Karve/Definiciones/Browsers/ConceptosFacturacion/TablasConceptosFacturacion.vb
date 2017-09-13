Imports CustomControls

Public Class TablasConceptosFacturacion
    Public Function ConceptosFacturacionFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CONCEP_FACTUR"
        Tb.AliasTabla = "COF"

        Return Tb
    End Function
End Class
