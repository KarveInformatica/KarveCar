Imports CustomControls
Public Class defGridLicon
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasLicon
        Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object

        colRel = cols.ConceptoLicon
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.DescripcionLiCon
        dgcColumns.Add(colRel.RelatedColumn)

        dgcColumns.Add(cols.IncluidoLicon)
        dgcColumns.Add(cols.UnidadLiCon)
        dgcColumns.Add(cols.CantidadLiCon)
        dgcColumns.Add(cols.PrecioLiCon)
        dgcColumns.Add(cols.DtoLiCon)
        dgcColumns.Add(cols.IvaLiCon)
        dgcColumns.Add(cols.SubtotalLiCon)

        dgcColumns.Add(cols.GruposLiCon)
        dgcColumns.Add(cols.TarifasLiCon)

        tmp = cols.ContratoLiCon
        dgcColumns.Add(tmp)
        colRelation = tmp
        dgcColumns.Add(cols.PKLiCon)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrOder As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasLicon
        Dim tmp As Object

        tmp = tablas.LiCon
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
