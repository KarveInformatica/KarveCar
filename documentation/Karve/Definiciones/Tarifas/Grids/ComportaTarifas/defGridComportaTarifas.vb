Imports CustomControls
Public Class defGridComportaTarifas
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasComportaTarifas
        Dim tmp As Object

        dgcColumns.Add(cols.ConceptoComportaTari)
        dgcColumns.Add(cols.SiempreComportaTari)
        dgcColumns.Add(cols.FacturarAComportaTari)
        dgcColumns.Add(cols.TipoComportaTari)
        dgcColumns.Add(cols.ImporteComportaTari)
        dgcColumns.Add(cols.MinimoComportaTari)
        dgcColumns.Add(cols.MaximoComportaTari)
        dgcColumns.Add(cols.AcumulaComportaTari)

        tmp = cols.NtariTramosTari
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
