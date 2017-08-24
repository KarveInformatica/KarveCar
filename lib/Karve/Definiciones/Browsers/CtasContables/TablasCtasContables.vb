Imports CustomControls

Public Class TablasCtasContables

    Public Function CtasContablesFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CU1"
        Tb.AliasTabla = "CTA"

        Return Tb
    End Function


End Class
