Imports CustomControls

Public Class defGridLupaMotivosRepostaje
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasMotivosRepostaje

        dgcColumns.Add(Cols.CodigoMotivosRepostaje)
        dgcColumns.Add(Cols.NombreMotivosRepostaje)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesMotivosRepostaje
        dgoOrdenes.Add(Cols.OrdenCodMotivosRepostaje)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasMotivosRepostaje

        dgtTables.Add(Tbls.MotivosRepostajeFrom)

    End Sub
End Class