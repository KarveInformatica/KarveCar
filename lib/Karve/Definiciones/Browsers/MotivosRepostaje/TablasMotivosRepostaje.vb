Imports CustomControls

Public Class TablasMotivosRepostaje

    Public Function MotivosRepostajeFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "MOT_REPOSTAJE"
        Tb.AliasTabla = "MOR"

        Return Tb
    End Function
End Class