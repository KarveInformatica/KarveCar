Imports CustomControls

Public Class TablasFormasProvee

    Public Function FormasProveeFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "FORPRO"
        Tb.AliasTabla = "FPR"

        Return Tb
    End Function

End Class
