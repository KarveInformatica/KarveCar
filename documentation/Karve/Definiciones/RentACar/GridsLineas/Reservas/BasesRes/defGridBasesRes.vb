Imports CustomControls
Public Class defGridBasesRes
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasBasesRes
        Dim tmp As Object

        dgcColumns.Add(cols.BaseBasesRes)
        dgcColumns.Add(cols.IvaPorBasesRes)
        dgcColumns.Add(cols.CuotaBasesRes)
        dgcColumns.Add(cols.RecargoBasesRes)
        dgcColumns.Add(cols.CuorecaBasesRes)
        dgcColumns.Add(cols.SubtotalBasesRes)

        tmp = cols.ReservaBasesRes
        dgcColumns.Add(tmp)
        colRelation = tmp

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasBasesRes
        Dim tmp As Object

        tmp = tablas.BasesRes
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
