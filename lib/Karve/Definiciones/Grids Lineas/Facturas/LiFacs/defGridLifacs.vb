Imports CustomControls
Public Class defGridLifacs
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasLifacs
        Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object

        dgcColumns.Add(cols.LineaLifacs)
        colRel = cols.ConceptoLifacs
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.DescripcionLifacs
        dgcColumns.Add(colRel.RelatedColumn)

        dgcColumns.Add(cols.CantidadLifacs)
        dgcColumns.Add(cols.PrecioLifacs)
        dgcColumns.Add(cols.DtoLifacs)
        dgcColumns.Add(cols.IvaLifacs)
        dgcColumns.Add(cols.SubtotalLifacs)

        tmp = cols.FacturaLifacs
        dgcColumns.Add(tmp)
        colRelation = tmp
        dgcColumns.Add(cols.PKLifacs)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasLifacs
        Dim tmp As Object

        tmp = tablas.LiFacs
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
