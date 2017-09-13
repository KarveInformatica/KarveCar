Imports CustomControls

Public Class defGridLupaPoblacion
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasPoblacion

        dgcColumns.Add(Cols.CodigoPaisPobla)
        dgcColumns.Add(Cols.CPPobla)
        dgcColumns.Add(Cols.Pobla)
    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasPoblacion

        dgtTables.Add(Tbls.PoblacionFrom)
    End Sub
End Class
