Imports CustomControls
Public Class defGridTramosTari
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasTramosTari

        dgcColumns.Add(cols.TramoTramosTari)
        dgcColumns.Add(cols.DesdeTramosTari)
        dgcColumns.Add(cols.HastaTramosTari)
        dgcColumns.Add(cols.CantidadTramosTari)
        dgcColumns.Add(cols.UnidadTramosTari)
        Dim tmp As Object = cols.NtariTramosTari
        dgcColumns.Add(tmp)
        colRelation = tmp
        dgcColumns.Add(cols.PKTramosTari)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasTramosTari
        Dim tmp As Object

        tmp = tablas.TramosTari
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
