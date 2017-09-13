Imports CustomControls
Public Class defGridBasesfac
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasBasesfac
        Dim tmp As Object

        dgcColumns.Add(cols.BaseBasesfac)
        dgcColumns.Add(cols.IvaPorBasesfac)
        dgcColumns.Add(cols.CuotaBasesfac)
        dgcColumns.Add(cols.RecargoBasesfac)
        dgcColumns.Add(cols.CuorecaBasesfac)
        dgcColumns.Add(cols.SubtotalBasesfac)

        tmp = cols.FacturaBasesfac
        dgcColumns.Add(tmp)
        colRelation = tmp

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasBasesfac
        Dim tmp As Object

        tmp = tablas.BasesFac
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
