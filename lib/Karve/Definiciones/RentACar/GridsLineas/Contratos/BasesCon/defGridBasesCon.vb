Imports CustomControls
Public Class defGridBasesCon
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasBasesCon
        Dim tmp As Object

        dgcColumns.Add(cols.BaseBasescon)
        dgcColumns.Add(cols.IvaPorBasescon)
        dgcColumns.Add(cols.CuotaBasescon)
        dgcColumns.Add(cols.RecargoBasescon)
        dgcColumns.Add(cols.CuorecaBasescon)
        dgcColumns.Add(cols.SubtotalBasescon)

        tmp = cols.ContratoBasescon
        dgcColumns.Add(tmp)
        colRelation = tmp

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasBasesCon
        Dim tmp As Object

        tmp = tablas.BasesCon
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
